using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
    public struct result
    {
        public string commands;
        public StringBuilder resultStr;
        public int ptr;
        public int i;

        public void ClearResult()
        {
            commands = "";
            resultStr = new StringBuilder("");
            ptr = 0;
            i = 0;
        }
    }
}
