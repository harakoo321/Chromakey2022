namespace Chromakey2022
{
    partial class AddBackGround
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Selectimg = new System.Windows.Forms.Button();
            this.Addbg = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ファイルのパス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "画像名";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 19);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(86, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(294, 19);
            this.textBox2.TabIndex = 3;
            // 
            // Selectimg
            // 
            this.Selectimg.AutoSize = true;
            this.Selectimg.Location = new System.Drawing.Point(386, 11);
            this.Selectimg.Name = "Selectimg";
            this.Selectimg.Size = new System.Drawing.Size(83, 23);
            this.Selectimg.TabIndex = 4;
            this.Selectimg.Text = "ファイルの選択";
            this.Selectimg.UseVisualStyleBackColor = true;
            this.Selectimg.Click += new System.EventHandler(this.Selectimg_Click);
            // 
            // Addbg
            // 
            this.Addbg.Location = new System.Drawing.Point(386, 36);
            this.Addbg.Name = "Addbg";
            this.Addbg.Size = new System.Drawing.Size(83, 23);
            this.Addbg.TabIndex = 5;
            this.Addbg.Text = "追加";
            this.Addbg.UseVisualStyleBackColor = true;
            this.Addbg.Click += new System.EventHandler(this.Addbg_Click);
            // 
            // AddBackGround
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Addbg);
            this.Controls.Add(this.Selectimg);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBackGround";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "背景画像の追加";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Selectimg;
        private System.Windows.Forms.Button Addbg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}