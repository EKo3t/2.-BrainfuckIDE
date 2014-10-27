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
            this.RunProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RunProgram
            // 
            this.RunProgram.Location = new System.Drawing.Point(423, 107);
            this.RunProgram.Name = "RunProgram";
            this.RunProgram.Size = new System.Drawing.Size(101, 31);
            this.RunProgram.TabIndex = 0;
            this.RunProgram.Text = "ExecuteCode";
            this.RunProgram.UseVisualStyleBackColor = true;
            this.RunProgram.Click += new System.EventHandler(this.RunProgram_Click);
            // 
            // IDEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 296);
            this.Controls.Add(this.RunProgram);
            this.Name = "IDEForm";
            this.Text = "BrainfuckIDE";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RunProgram;
    }
}

