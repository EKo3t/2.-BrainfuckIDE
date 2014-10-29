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
            debugResult.ClearResult();
            DebugCells.RowCount = 30000;
            for (int ind = 0; ind < DebugCells.RowCount; ind++)
            {
                DebugCells.Rows[ind].Cells[0].Value = (int)ind + 1;
            }
        }

        public Interpreter bfInterpreter = new Interpreter();
        public result debugResult = new result();

        private void SelectCharacter(RichTextBoxWPath rtBoxWPath, int index, Color color)
        {
            rtBoxWPath.SelectionColor = color;
            rtBoxWPath.SelectionStart = index;
            rtBoxWPath.SelectionLength = 1;
        }

        private void Debugger(bool ended)
        {
            if (!ended)
            {
                for (int ind = 0; ind < DebugCells.RowCount; ind++)
                {
                    DebugCells.Rows[ind].Cells[1].Value = bfInterpreter.buf[ind];
                }
                RichTextBoxWPath richTextBox = GetRichTextBoxFromSelectedTab();
                if (debugResult.commands == "")
                    debugResult.commands = richTextBox.Text;
                int right = richTextBox.TextLength;
                if (debugResult.i - 1 >= 0)
                    SelectCharacter(richTextBox, debugResult.i-1, Color.Black);

                SelectCharacter(richTextBox, debugResult.i, Color.Red);
                if (debugResult.i < right)
                {
                    debugResult = bfInterpreter.DebugProgram(debugResult);
                    debugResult.i++;
                }
                if (debugResult.commands[debugResult.i] == '.')
                {
                    output.Clear();
                    output.Text = debugResult.resultStr.ToString();
                }
            }
            if (ended)
            {
                debugResult.ClearResult();
                Interpreter bfInterpreter = new Interpreter();
            }
        }

        private void IDEForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F10")
            {                
                Debugger(false);
            }
            if (e.KeyCode.ToString() == "F11")
            {
                Debugger(true);
            }
        }

        public delegate string InputText();

        public string ReadFromWindow()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Prompt", "Title", "Default", -1, -1);
            return input;
        }

        private void DebugCells_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = (DataGridViewCell) sender;

        }


    }
}
