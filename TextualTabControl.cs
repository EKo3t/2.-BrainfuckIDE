using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainfuckIDE
{
    class TextualTabControl : TabControl
    {
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.Controls.Add(CreateRichTextBox());
        }

        private RichTextBox CreateRichTextBox()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Multiline = true;
            richTextBox.Dock = DockStyle.Fill;
            return richTextBox;
        }

        public string SelectedRichTextBox
        {
            get { return this.SelectedTab.Controls[0].Text; }
        }

        public bool IsSelectedRichTextBoxMultiline
        {
            get { return ((TextBox) this.SelectedTab.Controls[0]).Multiline; }
        }
    }
}
