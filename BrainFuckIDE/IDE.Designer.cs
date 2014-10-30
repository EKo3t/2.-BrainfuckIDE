namespace BrainFuckIDE
{
    partial class IDEForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDEForm));
            this.CompileProgram = new System.Windows.Forms.Button();
            this.ExecuteCode = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.newFile = new System.Windows.Forms.ToolStripButton();
            this.openFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutButton = new System.Windows.Forms.ToolStripButton();
            this.copyButton = new System.Windows.Forms.ToolStripButton();
            this.PasteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.textEditor = new System.Windows.Forms.TabControl();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.DebugCells = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.DebugButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DebugCells)).BeginInit();
            this.SuspendLayout();
            // 
            // CompileProgram
            // 
            this.CompileProgram.Location = new System.Drawing.Point(79, 250);
            this.CompileProgram.Name = "CompileProgram";
            this.CompileProgram.Size = new System.Drawing.Size(101, 31);
            this.CompileProgram.TabIndex = 0;
            this.CompileProgram.Text = "Compile";
            this.CompileProgram.UseVisualStyleBackColor = true;
            this.CompileProgram.Click += new System.EventHandler(this.Compile_Click);
            // 
            // ExecuteCode
            // 
            this.ExecuteCode.Location = new System.Drawing.Point(186, 250);
            this.ExecuteCode.Name = "ExecuteCode";
            this.ExecuteCode.Size = new System.Drawing.Size(118, 31);
            this.ExecuteCode.TabIndex = 1;
            this.ExecuteCode.Text = "ExecuteCode";
            this.ExecuteCode.UseVisualStyleBackColor = true;
            this.ExecuteCode.Click += new System.EventHandler(this.RunProgram_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 187);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(383, 57);
            this.output.TabIndex = 2;
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFile,
            this.openFileButton,
            this.saveFileButton,
            this.toolStripSeparator,
            this.cutButton,
            this.copyButton,
            this.PasteButton,
            this.toolStripSeparator1});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(732, 25);
            this.tools.TabIndex = 4;
            this.tools.Text = "toolStrip1";
            // 
            // newFile
            // 
            this.newFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFile.Image = ((System.Drawing.Image)(resources.GetObject("newFile.Image")));
            this.newFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFile.Name = "newFile";
            this.newFile.Size = new System.Drawing.Size(23, 22);
            this.newFile.Text = "&Создать";
            this.newFile.Click += new System.EventHandler(this.addNewFile_click);
            // 
            // openFileButton
            // 
            this.openFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileButton.Image = ((System.Drawing.Image)(resources.GetObject("openFileButton.Image")));
            this.openFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(23, 22);
            this.openFileButton.Text = "&Открыть";
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveFileButton.Image = ((System.Drawing.Image)(resources.GetObject("saveFileButton.Image")));
            this.saveFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(23, 22);
            this.saveFileButton.Text = "&Сохранить";
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutButton
            // 
            this.cutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutButton.Image = ((System.Drawing.Image)(resources.GetObject("cutButton.Image")));
            this.cutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(23, 22);
            this.cutButton.Text = "&Cut";
            this.cutButton.Click += new System.EventHandler(this.cutButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyButton.Image = ((System.Drawing.Image)(resources.GetObject("copyButton.Image")));
            this.copyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(23, 22);
            this.copyButton.Text = "&Copy";
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // PasteButton
            // 
            this.PasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PasteButton.Image = ((System.Drawing.Image)(resources.GetObject("PasteButton.Image")));
            this.PasteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PasteButton.Name = "PasteButton";
            this.PasteButton.Size = new System.Drawing.Size(23, 22);
            this.PasteButton.Text = "&Paste";
            this.PasteButton.Click += new System.EventHandler(this.PasteButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // textEditor
            // 
            this.textEditor.Location = new System.Drawing.Point(12, 28);
            this.textEditor.MinimumSize = new System.Drawing.Size(383, 153);
            this.textEditor.Name = "textEditor";
            this.textEditor.SelectedIndex = 0;
            this.textEditor.Size = new System.Drawing.Size(383, 153);
            this.textEditor.TabIndex = 3;
            this.textEditor.SelectedIndexChanged += new System.EventHandler(this.textEditor_SelectedIndexChanged);
            this.textEditor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textEditor_MouseClick);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            this.openFile.Filter = "Text Files|*.txt|Brainfuck Files|*.brf";
            // 
            // saveFile
            // 
            this.saveFile.FileName = "saveFile";
            this.saveFile.Filter = "Text Files|*.txt|Brainfuck Files|*.brf";
            // 
            // DebugCells
            // 
            this.DebugCells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DebugCells.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Value});
            this.DebugCells.Location = new System.Drawing.Point(401, 31);
            this.DebugCells.Name = "DebugCells";
            this.DebugCells.Size = new System.Drawing.Size(212, 213);
            this.DebugCells.TabIndex = 5;
            this.DebugCells.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DebugCells_CellBeginEdit);
            this.DebugCells.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DebugCells_CellEndEdit);
            // 
            // Index
            // 
            this.Index.Frozen = true;
            this.Index.HeaderText = "Index";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Width = 70;
            // 
            // Value
            // 
            this.Value.Frozen = true;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(398, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "F10 - to debug";
            // 
            // DebugButton
            // 
            this.DebugButton.Location = new System.Drawing.Point(619, 31);
            this.DebugButton.Name = "DebugButton";
            this.DebugButton.Size = new System.Drawing.Size(75, 23);
            this.DebugButton.TabIndex = 7;
            this.DebugButton.Text = "Debug";
            this.DebugButton.UseVisualStyleBackColor = true;
            this.DebugButton.Click += new System.EventHandler(this.DebugButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(619, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "StopDebug";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // IDEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 296);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DebugButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DebugCells);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.textEditor);
            this.Controls.Add(this.output);
            this.Controls.Add(this.ExecuteCode);
            this.Controls.Add(this.CompileProgram);
            this.MinimumSize = new System.Drawing.Size(748, 334);
            this.Name = "IDEForm";
            this.Text = "BrainfuckIDE";
            this.Load += new System.EventHandler(this.IDEForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IDEForm_KeyDown);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DebugCells)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CompileProgram;
        private System.Windows.Forms.Button ExecuteCode;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton newFile;
        private System.Windows.Forms.ToolStripButton openFileButton;
        private System.Windows.Forms.ToolStripButton saveFileButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutButton;
        private System.Windows.Forms.ToolStripButton copyButton;
        private System.Windows.Forms.ToolStripButton PasteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl textEditor;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.DataGridView DebugCells;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DebugButton;
        private System.Windows.Forms.Button button2;
    }
}

