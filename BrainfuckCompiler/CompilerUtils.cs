using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BF;
using BF.Exceptions;
using BF.Parser;
using BF.Tokens;

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

        public static void BuildAssembly(string src, string path)
        {
            if (src != null)
            {
                var validChars = src.Where(c =>
                    c == '.' || c == ',' ||
                    c == '<' || c == '>' ||
                    c == '+' || c == '-' ||
                    c == '[' || c == ']');

                try
                {
                    IEnumerable<Token> tokens = BFParser.Parse(new string(validChars.ToArray()));

                    if (tokens == null)
                    {
                        Console.WriteLine("Unable to parse input.");
                    }
                    else
                    {
                        new ILBuilder(path, "bfoutput", 30000, tokens).Build();
                    }
                }
                catch (ParseException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
