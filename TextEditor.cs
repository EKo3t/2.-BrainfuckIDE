using System;
using System.Windows.Forms;
using System.Drawing.Text;

namespace BrainfuckIDE
{
    public partial class TextEditor : Form
    {
        public TextEditor()
        {
            InitializeComponent();
        }

        private TextualTabControl mulTextTabControl = new TextualTabControl();

        #region Editor and General

        #endregion

        #region MainMenu

        #endregion

        #region Toolbar

        #endregion

        #region contextmenu

        #endregion

        #region Methods

        #endregion

        #region file

        public void New()
        {
            Document.Clear();
        }

        public void Open()
        {
            if (openWork.ShowDialog() == DialogResult.OK)
            {
                Document.LoadFile(openWork.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        public void Save()
        {

            if (saveWork.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document.SaveFile(saveWork.FileName,
                        RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void Exit()
        {
            Application.Exit();
        }

        #endregion

        #region edit

        public void Undo()
        {
            Document.Undo();
        }

        private void Redo()
        {
            Document.Redo();
        }

        private void Cut()
        {
            Document.Cut();
        }

        private void Paste()
        {
            Document.Paste();
        }

        private void SelectAll()
        {
            Document.SelectAll();
        }

        private void Copy()
        {
            Document.Copy();
        }

        private void ClearAll()
        {
            Document.Clear();
        }

        #endregion

        #region tools

        private void Customise()
        {
            ColorDialog myDialog = new ColorDialog();
            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                mainMenu.BackColor = myDialog.Color;
                Status.BackColor = myDialog.Color;
                Tools.BackColor = myDialog.Color;
            }
        }

        #endregion

        #region fileclick

        private void file_New_Click(object sender, EventArgs e)
        {
            New();
        }

        private void file_Open_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void file_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void file_Exit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        #endregion

        #region editclick

        private void edit_Undo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void edit_Redo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void edit_Cut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void edit_Copy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void edit_Paste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void edit_SelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        #endregion

        private void tools_Customise_Click(object sender, EventArgs e)
        {
            Customise();
        }

        #region rcmenuclick

        private void rc_Undo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void rc_Redo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void rc_Cut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void rc_Copy_Click(object sender, EventArgs e)
        {

            Copy();
        }

        private void rc_Paste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        #endregion

        #region toolbarclick

        private void tb_New_Click(object sender, EventArgs e)
        {
            New();
        }

        private void tb_Open_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void tb_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tb_Cut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void tb_Copy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void tb_Paste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        #endregion

        private void tb_ZoomIn_Click(object sender, EventArgs e)
        {

        }

        private void tb_ZoomOut_Click(object sender, EventArgs e)
        {
            const double precision = 1E-8;
            if (Math.Abs(Document.ZoomFactor - 1) < precision)
            {
                return;
            }
            else
                Document.ZoomFactor = Document.ZoomFactor - 1;
        }

        private void tb_UpperCase_Click(object sender, EventArgs e)
        {
            Document.SelectedText = Document.SelectedText.ToUpper();
        }

        private void tb_LowerCase_Click(object sender, EventArgs e)
        {
            Document.SelectedText = Document.SelectedText.ToLower();
        }

        private void Timer_Tick_1(object sender, EventArgs e)
        {
            charCount.Text = "Characters in the current document: " + Document.TextLength.ToString();
            status_ZoomFactor.Text = Document.ZoomFactor.ToString();
        }
    }
}
