using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
    public class InputData
    {
        public delegate String CallInputBox(String prompt);

        public CallInputBox callInputBox { get; set; }
    }
}
