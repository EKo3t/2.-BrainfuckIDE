using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        }

        private void RunProgram_Click(object sender, EventArgs e)
        {
            output.Clear();
            RichTextBoxWPath richTextBox = new RichTextBoxWPath();
            richTextBox = (RichTextBoxWPath)textEditor.SelectedTab.Controls[0];
            string sourceCode = richTextBox.Text;
            string result = Interpreter.RunInterpreter(sourceCode);
            output.Text = result;
        }

        private void Compile_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBoxWPath richTextBox = new RichTextBoxWPath();
                richTextBox = (RichTextBoxWPath)textEditor.SelectedTab.Controls[0];
                if (richTextBox.Path != "")
                {
                    Compiler.StartCompiler(richTextBox.Path);                    
                }
                else
                {
                    MessageBox.Show("Please, Save first, then repeat attempt");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please, Save first, then repeat attempt");
                return;
            }

        }

        private TabPage CreateTab(string name = "", RichTextBoxWPath richTextBoxParam = null)
        {
            TabPage tabPage = new TabPage();
            RichTextBoxWPath richTextBox;
            if (richTextBoxParam == null)
            {
                richTextBox = new RichTextBoxWPath();
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
                tabPage.Text = name.Substring(name.LastIndexOf("\\")+1);
                tabPage.Tag = name;
            }
            richTextBox.Dock = DockStyle.Fill;
            return tabPage;
        }

        private void AddTabPage(TabPage tabPage)
        {
            textEditor.TabPages.Add(tabPage);
            textEditor.SelectedTab = tabPage;
            RichTextBoxWPath richTextBox = (RichTextBoxWPath) tabPage.Controls[0];
            richTextBox.Path = tabPage.Name;
        }

        private void CheckNullTabs()
        {
            if (textEditor.TabCount == 0)
            {
                TabPage tabPage = CreateTab("Untitled");
                AddTabPage(tabPage);
            }            
        }

        private RichTextBoxWPath GetRichTextBoxFromSelectedTab()
        {
            RichTextBoxWPath richTextBox = new RichTextBoxWPath();
            richTextBox = (RichTextBoxWPath)textEditor.SelectedTab.Controls[0];
            return richTextBox;
        }

        #region toolbarmethods
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

        private void textEditor_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var tabControl = sender as TabControl;
                var tabs = tabControl.TabPages;

                if (e.Button == MouseButtons.Middle)
                {
                    var result = tabs.Cast<TabPage>()
                            .Where((t, i) => tabControl.GetTabRect(i).Contains(e.Location))
                            .First();
                    int index = result.TabIndex;
                    tabs.Remove(result);
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void textEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckNullTabs();
        }

        private void IDEForm_Load(object sender, EventArgs e)
        {
            CheckNullTabs();
            BringToFront();
            Focus();
            KeyPreview = true;
        }

        public struct result
        {
            private StringBuilder resultStr;
            private int ptr;
            private bool ended;
            private int i;
        }

        private void Debugger(bool beginNew)
        {
    /*        if (beginNew)
            {
                IDEForm.result structResult = new IDEForm.result();
                Interpreter bfInterpreter = new Interpreter();
                RichTextBox richTextBox = GetRichTextBoxFromSelectedTab();
                int i = 0;
                int right = richTextBox.TextLength;
                var result = new StringBuilder("");
            }
            while (i < right)
            {
                bfInterpreter.DebugProgram(richTextBox.Text);
                i++;
            }*/
        }

        private void IDEForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F10")
            {                
                Debugger(true);
            }
            if (e.KeyCode.ToString() == "F11")
            {
                Debugger(false);
            }
        }

        public delegate string InputText();

        public string ReadFromWindow()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Prompt", "Title", "Default", -1, -1);
            return input;
        }
    }
}
