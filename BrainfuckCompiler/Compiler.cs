using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BrainfuckCompiler
{
    public static class Compiler
    {
        public static void StartCompiler()
        {
            string path = @"F:/TestFile.txt";
            string sourceCode = CompilerUtils.GetSourceCode(path);
            if (!CompilerUtils.CheckSourceBasics(sourceCode))
            {
                Console.WriteLine("Incorrect Source Code");
                return;
            }
            CompilerUtils.BuildAssembly(sourceCode);
        }

    }
}
