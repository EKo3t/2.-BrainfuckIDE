using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BrainfuckCompiler;
using BrainfuckInterpreter;

namespace BrainFuckIDE
{
    public partial class IDEForm : Form
    {
        public IDEForm()
        {
            InitializeComponent();
            CheckNullTabs();
        }

        private void RunProgram_Click(object sender, EventArgs e)
        {
            output.Clear();
            Compiler.StartCompiler();
            RichTextBox richTextBox = new RichTextBox();
            richTextBox = (RichTextBox)textEditor.SelectedTab.Controls[0];
            string sourceCode = richTextBox.Text;
            string result = Interpreter.RunInterpreter(sourceCode);
            output.Text = result;
        }

        private void Compile_Click(object sender, EventArgs e)
        {
            Compiler.StartCompiler();
        }

        private TabPage CreateTab(string name = "", RichTextBox richTextBoxParam = null)
        {
            TabPage tabPage = new TabPage();
            RichTextBox richTextBox;
            if (richTextBoxParam == null)
            {
                richTextBox = new RichTextBox();
            }
            else
            {
                richTextBox = richTextBoxParam;
            }
            tabPage.Controls.Add(richTextBox);
            if (name == "")
            {
                tabPage.Text = "Page: " + (textEditor.TabCount + 1);
                tabPage.Tag = "Page: " + (textEditor.TabCount + 1);
            }
            else
            {
                tabPage.Text = name;
                tabPage.Tag = name;
            }
            richTextBox.Dock = DockStyle.Fill;
            return tabPage;
        }

        private void AddTabPage(TabPage tabPage)
        {
            textEditor.TabPages.Add(tabPage);
            textEditor.SelectedTab = tabPage;
        }

        private void CheckNullTabs()
        {
            if (textEditor.TabCount == 0)
            {
                TabPage tabPage = CreateTab("Untitled");
                AddTabPage(tabPage);
            }            
        }

        private void textEditor_TabIndexChanged(object sender, EventArgs e)
        {
            CheckNullTabs();
        }

        private RichTextBox GetRichTextBoxFromSelectedTab()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox = (RichTextBox)textEditor.SelectedTab.Controls[0];
            return richTextBox;
        }

        #region toolbarmethods
        void Open()
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                RichTextBox richTextBox = new RichTextBox();
                string name;
                richTextBox.LoadFile(name = openFile.FileName, RichTextBoxStreamType.PlainText);
                TabPage tabPage = CreateTab(name, richTextBox);
                tabPage.Controls.Add(richTextBox);
                AddTabPage(tabPage);
            }
        }

        private void Save()
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RichTextBox richTextBox = GetRichTextBoxFromSelectedTab();
                    richTextBox.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText);
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

        #endregion

        #region ToolBarClicks
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
        #endregion

    }
}
