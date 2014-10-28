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
            this.tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompileProgram
            // 
            this.CompileProgram.Location = new System.Drawing.Point(271, 257);
            this.CompileProgram.Name = "CompileProgram";
            this.CompileProgram.Size = new System.Drawing.Size(101, 31);
            this.CompileProgram.TabIndex = 0;
            this.CompileProgram.Text = "Compile";
            this.CompileProgram.UseVisualStyleBackColor = true;
            this.CompileProgram.Click += new System.EventHandler(this.Compile_Click);
            // 
            // ExecuteCode
            // 
            this.ExecuteCode.Location = new System.Drawing.Point(378, 257);
            this.ExecuteCode.Name = "ExecuteCode";
            this.ExecuteCode.Size = new System.Drawing.Size(118, 31);
            this.ExecuteCode.TabIndex = 1;
            this.ExecuteCode.Text = "ExecuteCode";
            this.ExecuteCode.UseVisualStyleBackColor = true;
            this.ExecuteCode.Click += new System.EventHandler(this.RunProgram_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(204, 194);
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
            this.tools.Size = new System.Drawing.Size(718, 25);
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
            this.textEditor.Location = new System.Drawing.Point(204, 35);
            this.textEditor.MinimumSize = new System.Drawing.Size(383, 153);
            this.textEditor.Name = "textEditor";
            this.textEditor.SelectedIndex = 0;
            this.textEditor.Size = new System.Drawing.Size(383, 153);
            this.textEditor.TabIndex = 3;
            this.textEditor.TabIndexChanged += new System.EventHandler(this.textEditor_TabIndexChanged);
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
            // IDEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 296);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.textEditor);
            this.Controls.Add(this.output);
            this.Controls.Add(this.ExecuteCode);
            this.Controls.Add(this.CompileProgram);
            this.MinimumSize = new System.Drawing.Size(734, 334);
            this.Name = "IDEForm";
            this.Text = "BrainfuckIDE";
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
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
    }
}

