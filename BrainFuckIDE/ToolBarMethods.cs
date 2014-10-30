using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainFuckIDE
{
    public partial class IDEForm : Form
    {
        void Open()
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                RichTextBoxWPath richTextBox = new RichTextBoxWPath();
                string name;
                richTextBox.LoadFile(name = openFile.FileName, RichTextBoxStreamType.PlainText);
                TabPage tabPage = CreateTab(name, richTextBox);
                tabPage.Controls.Add(richTextBox);
                AddTabPage(tabPage);
                richTextBox.Path = name;
            }
        }

        private void Save()
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RichTextBoxWPath richTextBox = GetRichTextBoxFromSelectedTab();
                    string name;
                    richTextBox.SaveFile(name = saveFile.FileName, RichTextBoxStreamType.PlainText);
                    richTextBox.Path = name;
                    name = name.Substring(name.LastIndexOf("\\") + 1);
                    textEditor.SelectedTab.Text = name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void Undo()
        {
            GetRichTextBoxFromSelectedTab().Undo();
        }

        void Redo()
        {
            GetRichTextBoxFromSelectedTab().Redo();
        }

        void Cut()
        {
            GetRichTextBoxFromSelectedTab().Cut();
        }

        void Copy()
        {
            GetRichTextBoxFromSelectedTab().Copy();
        }

        void Paste()
        {
            GetRichTextBoxFromSelectedTab().Paste();
        }


    }
}
