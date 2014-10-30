using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
    public class Interpreter
    {
        private const int BUFSIZE = 65535;
        public int[] buf = new int[BUFSIZE];
        private int ptr { get; set; }
        private bool echo { get; set; }
 
        public Interpreter()
        {
            ptr = 0;
            Reset();
        }
 
        public void Reset()
        {
            Array.Clear(buf, 0, buf.Length);
        }

        private string Interpret(string s, InputData inputData)
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
                            ptr++;
                            if (ptr >= BUFSIZE)
                            {
                                ptr = 0;
                            }
                            break;
                        }
                    case '<':
                        {
                            ptr--;
                            if (ptr < 0)
                            {
                                ptr = BUFSIZE - 1;
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
                            buf[ptr]++;
                            break;
                        }
                    case '-':
                        {
                            buf[ptr]--;
                            break;
                        }
                    case '[':
                        {
                            if (buf[ptr] == 0)
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
                        String input;
                        do
                        {
                            input = inputData.callInputBox("Enter char: ");
                        } while (input.Length != 1);

                        buf[ptr] = input[0];
                        break;
                    }
                }
                i++; 
            }
            return result.ToString();
        }

        public result DebugProgram(result debugResult, InputData inputData)
        {
            switch (debugResult.commands[debugResult.i])
            {
                case '>':
                {
                    debugResult.ptr++;
                    if (debugResult.ptr >= BUFSIZE)
                    {
                        debugResult.ptr = 0;
                    }
                    break;
                }
                case '<':
                {
                    debugResult.ptr--;
                    if (debugResult.ptr < 0)
                    {
                        debugResult.ptr = BUFSIZE - 1;
                    }
                    break;
                }
                case '.':
                {
                    debugResult.resultStr.Append((char)buf[debugResult.ptr]);
                    break;
                }
                case '+':
                {
                    buf[debugResult.ptr]++;
                    break;
                }
                case '-':
                {
                    buf[debugResult.ptr]--;
                    break;
                }
                case '[':
                {
                    if (buf[debugResult.ptr] == 0)
                    {
                        int loop = 1;
                        while (loop > 0)
                        {
                            debugResult.i++;
                            char c = debugResult.commands[debugResult.i];
                            if (c == '[')
                            {
                                loop++;
                            }
                            else if (c == ']')
                            {
                                loop--;
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
                        debugResult.i--;
                        char c = debugResult.commands[debugResult.i];
                        if (c == '[')
                        {
                            loop--;
                        }
                        else if (c == ']')
                        {
                            loop++;
                        }
                    }
                    debugResult.i--;
                    break;
                }
                case ',':
                {
                    String input;
                    do
                    {
                        input = inputData.callInputBox("Enter char: ");
                    } while (input.Length != 1);

                    buf[ptr] = input[0];
                    break;
                }
            }
            return debugResult;
        }

        public static string RunInterpreter(string sourceCode, InputData inputData)
        {
            var bf = new Interpreter();
            return bf.Interpret(sourceCode, inputData);
        }

    }
}
