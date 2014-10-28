using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
    public class Interpreter
    {
        private static string VER = "0.0.0.1";
        private static readonly int BUFSIZE = 65535;
        private int[] buf = new int[BUFSIZE];
        private int ptr { get; set; }
        private bool echo { get; set; }
 
        private Interpreter()
        {
            ptr = 0;
            Reset();
        }
 
        private static void PrintHelp()
        {
            Console.WriteLine("BrainFuck Interpreter " + VER);
            Console.WriteLine("https://helloacm.com");
            Console.WriteLine("Parameter: -h: Print Help");
            Console.WriteLine("Parameter: -e: Enable Echo Input Text");
            Console.WriteLine("Parameter: -d: Disable Echo Input Text");
            Console.WriteLine("Parameter: -p: Enable Keyboard Input");
            Console.WriteLine("Parameter: -v: Print Version");
            Console.WriteLine("Parameter: FileName");
        }
 
        private void Reset()
        {
            Array.Clear(buf, 0, buf.Length);
        }
 
        private string Interpret(string s)
        {
            int i = 0;
            int right = s.Length;
            var result = new StringBuilder("");
            while (i < right)
            {
                switch (s[i])
                {
                    case '>':
                        {
                            this.ptr++;
                            if (this.ptr >= BUFSIZE)
                            {
                                this.ptr = 0;
                            }
                            break;
                        }
                    case '<':
                        {
                            this.ptr--;
                            if (this.ptr < 0)
                            {
                                this.ptr = BUFSIZE - 1;
                            }
                            break;
                        }
                    case '.':
                        {
                            result.Append((char) buf[ptr]);
                            break;
                        }
                    case '+':
                        {
                            this.buf[this.ptr]++;
                            break;
                        }
                    case '-':
                        {
                            this.buf[this.ptr]--;
                            break;
                        }
                    case '[':
                        {
                            if (this.buf[this.ptr] == 0)
                            {
                                int loop = 1;
                                while (loop > 0)
                                {
                                    i ++;
                                    char c = s[i];
                                    if (c == '[')
                                    {
                                        loop ++;
                                    }
                                    else
                                    if (c == ']')
                                    {
                                        loop --;
                                    }
                                }
                            }
                            break;
                        }
                    case ']':
                        {
                            int loop = 1;
                            while (loop > 0)
                            {
                                i --;
                                char c = s[i];
                                if (c == '[')
                                {
                                    loop --;
                                }
                                else
                                if (c == ']')
                                {
                                    loop ++;
                                }
                            }
                            i --;
                            break;
                        }
                    case ',':
                        {
                            // read a key
                            ConsoleKeyInfo key = Console.ReadKey(this.echo);
                            this.buf[this.ptr] = (int)key.KeyChar;
                            break;
                        }
                }
                i++; 
            }
            return result.ToString();
        }
 
        public static string RunInterpreter(string path)
        {
            var bf = new Interpreter();
            if (File.Exists(path))
                return bf.Interpret(File.ReadAllText(path));
            else
                return "File Open Error: ";
        }
    }
}
