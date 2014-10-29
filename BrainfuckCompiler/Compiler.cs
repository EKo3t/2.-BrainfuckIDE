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
        public static bool StartCompiler(string path)
        {
            string sourceCode = CompilerUtils.GetSourceCode(path);
            if (!CompilerUtils.CheckSourceBasics(sourceCode))
            {
                Console.WriteLine("Incorrect Source Code");
                return false;
            }
            string name = path.Substring( path.LastIndexOf('\\') + 1);
            name = name.Substring(0,name.LastIndexOf('.')+1);
            name = name + "exe";
            CompilerUtils.BuildAssembly(sourceCode, name);
            return true;
        }
    }
}
