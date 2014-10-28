using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckCompiler
{
    public static class CompilerUtils
    {
        public static bool CheckSourceBasics(string src)
        {
            if (src.Length == 0) throw new ArgumentException("Исходный код имеет нулевую длину");
            int state = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == '[') state++;
                if (src[i] == ']') state--;
                //Выкидываем ошибку, если код неправильный.
                if (state < 0) throw new ArgumentException(String.Format("Исходный код не соответствует правилам построения. Позиция: {0}", i++));
            }
            if (state != 0) Console.WriteLine("Исходный код не соответствует правилам построения.");
            return state == 0;
        }

        public static string GetSourceCode(string path)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(path))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            string allines = sb.ToString();
            return allines;
        }

        public static void BuildAssembly(string src)
        {
            AssemblyName aName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder ASM = AppDomain.CurrentDomain.DefineDynamicAssembly(
                aName, 
                AssemblyBuilderAccess.RunAndSave); //Создаем сборку

            ModuleBuilder MDB = ASM.DefineDynamicModule(aName.Name);
            TypeBuilder TPB = MDB.DefineType("DynamicType", TypeAttributes.Class); //Создаем класс в модуле

            FieldBuilder FDB_1 = TPB.DefineField("Memory", typeof(byte[]), FieldAttributes.Private); // private byte[] Memory; //Память для операций.
            FieldBuilder FDB_2 = TPB.DefineField("Point", typeof(int), FieldAttributes.Private); //private int Point; //Указатель в памяти.
            MethodBuilder MTB = TPB.DefineMethod("Main", MethodAttributes.Static, CallingConventions.Any); //static void Main() //Main Procedure
            ASM.SetEntryPoint(MTB.GetBaseDefinition());
            ILGenerator MTB_IL = MTB.GetILGenerator();
            MTB_IL.Emit(OpCodes.Ldc_I4, 30000); //Загружаем в стек 30000 - длина нового массива памяти
            MTB_IL.Emit(OpCodes.Newarr, typeof(byte)); //Создаем массив 30000 байтов
            MTB_IL.Emit(OpCodes.Stsfld, FDB_1); //Ставим указатель Memory на созданный массив
            var Scopes = new Stack<Label>();
            foreach (var t in src) //Так как каждый оператор самодостаточен, то можно просто записывать каждый.
            {
                switch (t)
                {
                    case '>':
                        {
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_2); //Помещаем в стек поле POINT
                            MTB_IL.Emit(OpCodes.Ldc_I4_1); //Помещаем в стек 1
                            MTB_IL.Emit(OpCodes.Add); //Плюс
                            MTB_IL.Emit(OpCodes.Stsfld, FDB_2); //Выполняем операцию с Point то есть сдвигаем указатель вправо
                            break;
                        }
                    case '<':
                        {
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_2);//Помещаем в стек поле POINT
                            MTB_IL.Emit(OpCodes.Ldc_I4_1); //Помещаем в стек 1
                            MTB_IL.Emit(OpCodes.Sub); //Минус
                            MTB_IL.Emit(OpCodes.Stsfld, FDB_2); //Выполняем операцию с Point то есть сдвигаем указатель вправо
                            break;
                        }
                    case '+':
                        {
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_1);//Помещаем в стек поле MEMORY
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_2);//Помещаем в стек поле POINT
                            MTB_IL.Emit(OpCodes.Ldelema, typeof(byte)); //Помещаем в стек элемент MEMORY[POINT]
                            MTB_IL.Emit(OpCodes.Dup);
                            MTB_IL.Emit(OpCodes.Ldobj, typeof(byte));
                            MTB_IL.Emit(OpCodes.Ldc_I4_1);
                            MTB_IL.Emit(OpCodes.Add); //Плюс
                            MTB_IL.Emit(OpCodes.Conv_U1);
                            MTB_IL.Emit(OpCodes.Stobj, typeof(byte));//Сохраняем
                            break;
                        }
                    case '-':
                        {
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_1);//Помещаем в стек поле MEMORY
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_2);//Помещаем в стек поле POINT
                            MTB_IL.Emit(OpCodes.Ldelema, typeof(byte));//Помещаем в стек элемент MEMORY[POINT]
                            MTB_IL.Emit(OpCodes.Dup);
                            MTB_IL.Emit(OpCodes.Ldobj, typeof(byte));
                            MTB_IL.Emit(OpCodes.Ldc_I4_1);
                            MTB_IL.Emit(OpCodes.Sub); //Минус
                            MTB_IL.Emit(OpCodes.Conv_U1);
                            MTB_IL.Emit(OpCodes.Stobj, typeof(byte));//Сохраняем
                            break;
                        }
                    case '[':
                        {
                            var Lbl = MTB_IL.DefineLabel(); //Объявляем метку
                            MTB_IL.MarkLabel(Lbl); //И помечаем ей то место куда будем возвращаться, то есть начало цикла
                            Scopes.Push(Lbl); //В стек. Иначе не узнаем куда :)
                            break;
                        }
                    case ']':
                        {
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_1); //Конструкция из этих 3х элементов
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_2); //загружает в стек значение из массива 
                            MTB_IL.Emit(OpCodes.Ldelem_U1); //FDB_1 по адресу FDB_2
                            MTB_IL.Emit(OpCodes.Ldc_I4_0); //Загружаем в стек 0
                            MTB_IL.Emit(OpCodes.Ceq); // Если текущая ячейка=0
                            MTB_IL.Emit(OpCodes.Brtrue, 5); //Переход на послеследующую инструкцию
                            MTB_IL.Emit(OpCodes.Br, Scopes.Pop()); //Иначе на начало цикла. Занимает 5 байт.
                            break;
                        }
                    case '.':
                        {
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_1);//Помещаем в стек поле MEMORY
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_2);//Помещаем в стек поле POINT
                            MTB_IL.Emit(OpCodes.Ldelem_U1);//Помещаем в стек элемент MEMORY[POINT]
                            MTB_IL.EmitCall(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new[] { typeof(char) }), new[] { typeof(char) }); //Console.WriteLine(MEMORY[POINT]);
                            MTB_IL.Emit(OpCodes.Nop);
                            break;
                        }
                    case ',':
                        {
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_1);//Помещаем в стек поле MEMORY
                            MTB_IL.Emit(OpCodes.Ldsfld, FDB_2);//Помещаем в стек поле POINT
                            MTB_IL.EmitCall(OpCodes.Call, typeof(Console).GetMethod("ReadLine"), new[] { typeof(string) }); //Console.ReadLine();
                            MTB_IL.Emit(OpCodes.Call, typeof(Convert).GetMethod("ToByte", new[] { typeof(string) })); //Конвертация в байт.
                            MTB_IL.Emit(OpCodes.Stelem_I1); //Сохраняем
                            break;
                        }
                }
            }
            MTB_IL.Emit(OpCodes.Ret); //Заканчиваем
            TPB.CreateType(); //Завершаем класс
            ASM.Save("testfile.exe"); //Сохраняем сборку

        }

    }
}
