using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrainfuckCompiler;

namespace BrainFuckIDE
{
    public partial class IDEForm : Form
    {
        public IDEForm()
        {
            InitializeComponent();
        }

        private void RunProgram_Click(object sender, EventArgs e)
        {
            Compiler.StartCompiler();     
        }
    }
}
