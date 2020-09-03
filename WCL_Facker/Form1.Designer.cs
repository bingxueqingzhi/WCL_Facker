namespace WCL_Facker
{
    partial class fmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxLogFilePath = new System.Windows.Forms.TextBox();
            this.btnGetLogFilePath = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnFacker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxLogFilePath
            // 
            this.tbxLogFilePath.Location = new System.Drawing.Point(13, 13);
            this.tbxLogFilePath.Name = "tbxLogFilePath";
            this.tbxLogFilePath.ReadOnly = true;
            this.tbxLogFilePath.Size = new System.Drawing.Size(700, 21);
            this.tbxLogFilePath.TabIndex = 0;
            // 
            // btnGetLogFilePath
            // 
            this.btnGetLogFilePath.Location = new System.Drawing.Point(719, 13);
            this.btnGetLogFilePath.Name = "btnGetLogFilePath";
            this.btnGetLogFilePath.Size = new System.Drawing.Size(53, 21);
            this.btnGetLogFilePath.TabIndex = 1;
            this.btnGetLogFilePath.Text = "...";
            this.btnGetLogFilePath.UseVisualStyleBackColor = true;
            this.btnGetLogFilePath.Click += new System.EventHandler(this.btnGetLogFilePath_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(719, 40);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(53, 21);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnFacker
            // 
            this.btnFacker.Location = new System.Drawing.Point(719, 67);
            this.btnFacker.Name = "btnFacker";
            this.btnFacker.Size = new System.Drawing.Size(53, 21);
            this.btnFacker.TabIndex = 3;
            this.btnFacker.Text = "Facker";
            this.btnFacker.UseVisualStyleBackColor = true;
            this.btnFacker.Click += new System.EventHandler(this.btnFacker_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnFacker);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnGetLogFilePath);
            this.Controls.Add(this.tbxLogFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "fmMain";
            this.Text = "WCL Facker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxLogFilePath;
        private System.Windows.Forms.Button btnGetLogFilePath;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnFacker;
    }
}

