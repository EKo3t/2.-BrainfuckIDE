using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainFuckIDE
{
    public partial class IDEForm
    {
        private void addNewFile_click(object sender, EventArgs e)
        {

            TabPage tabPage = CreateTab();
            AddTabPage(tabPage);
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cutButton_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            Paste();
        }     
    }
}
