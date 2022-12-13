namespace Chromakey_NakanoLab
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHup = new System.Windows.Forms.Label();
            this.lblHlow = new System.Windows.Forms.Label();
            this.lblHue = new System.Windows.Forms.Label();
            this.lblSat = new System.Windows.Forms.Label();
            this.lblVal = new System.Windows.Forms.Label();
            this.lbBack = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.Button();
            this.cBoxCam1 = new System.Windows.Forms.ComboBox();
            this.lblCam1 = new System.Windows.Forms.Label();
            this.lblCam2 = new System.Windows.Forms.Label();
            this.cBoxCam2 = new System.Windows.Forms.ComboBox();
            this.btnFlip = new System.Windows.Forms.Button();
            this.btnSynthesis = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showInFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRotateL = new System.Windows.Forms.Button();
            this.btnRotateR = new System.Windows.Forms.Button();
            this.lblRotate = new System.Windows.Forms.Label();
            this.lblScale = new System.Windows.Forms.Label();
            this.btnScaleUp = new System.Windows.Forms.Button();
            this.btnScaleDown = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTranslate = new System.Windows.Forms.Label();
            this.btnTransE = new System.Windows.Forms.Button();
            this.btnTransW = new System.Windows.Forms.Button();
            this.btnTransS = new System.Windows.Forms.Button();
            this.btnTransN = new System.Windows.Forms.Button();
            this.btnrenew = new System.Windows.Forms.Button();
            this.AddBackGround = new System.Windows.Forms.Button();
            this.hue_upper = new System.Windows.Forms.TrackBar();
            this.hue_lower = new System.Windows.Forms.TrackBar();
            this.saturation_lower = new System.Windows.Forms.TrackBar();
            this.saturation_upper = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.value_lower = new System.Windows.Forms.TrackBar();
            this.value_upper = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hue_upper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hue_lower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturation_lower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturation_upper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_lower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_upper)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHup
            // 
            this.lblHup.AutoSize = true;
            this.lblHup.Location = new System.Drawing.Point(218, 246);
            this.lblHup.Name = "lblHup";
            this.lblHup.Size = new System.Drawing.Size(35, 12);
            this.lblHup.TabIndex = 1;
            this.lblHup.Text = "Upper";
            // 
            // lblHlow
            // 
            this.lblHlow.AutoSize = true;
            this.lblHlow.Location = new System.Drawing.Point(218, 264);
            this.lblHlow.Name = "lblHlow";
            this.lblHlow.Size = new System.Drawing.Size(35, 12);
            this.lblHlow.TabIndex = 3;
            this.lblHlow.Text = "Lower";
            // 
            // lblHue
            // 
            this.lblHue.AutoSize = true;
            this.lblHue.Location = new System.Drawing.Point(12, 255);
            this.lblHue.Name = "lblHue";
            this.lblHue.Size = new System.Drawing.Size(29, 12);
            this.lblHue.TabIndex = 4;
            this.lblHue.Text = "色相";
            // 
            // lblSat
            // 
            this.lblSat.AutoSize = true;
            this.lblSat.Location = new System.Drawing.Point(12, 318);
            this.lblSat.Name = "lblSat";
            this.lblSat.Size = new System.Drawing.Size(29, 12);
            this.lblSat.TabIndex = 5;
            this.lblSat.Text = "彩度";
            // 
            // lblVal
            // 
            this.lblVal.AutoSize = true;
            this.lblVal.Location = new System.Drawing.Point(12, 385);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(29, 12);
            this.lblVal.TabIndex = 10;
            this.lblVal.Text = "明度";
            // 
            // lbBack
            // 
            this.lbBack.ContextMenuStrip = this.contextMenuStrip1;
            this.lbBack.FormattingEnabled = true;
            this.lbBack.ItemHeight = 12;
            this.lbBack.Location = new System.Drawing.Point(12, 29);
            this.lbBack.Name = "lbBack";
            this.lbBack.Size = new System.Drawing.Size(235, 196);
            this.lbBack.TabIndex = 4;
            this.lbBack.SelectedIndexChanged += new System.EventHandler(this.LbBack_SelectedIndexChanged);
            this.lbBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LbBack_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            this.RemoveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.RemoveToolStripMenuItem.Text = "削除";
            this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.LbBack_RemoveToolStripMenuItem_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(253, 71);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(154, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // cBoxCam1
            // 
            this.cBoxCam1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCam1.FormattingEnabled = true;
            this.cBoxCam1.Location = new System.Drawing.Point(253, 45);
            this.cBoxCam1.Name = "cBoxCam1";
            this.cBoxCam1.Size = new System.Drawing.Size(74, 20);
            this.cBoxCam1.TabIndex = 1;
            // 
            // lblCam1
            // 
            this.lblCam1.AutoSize = true;
            this.lblCam1.Location = new System.Drawing.Point(254, 27);
            this.lblCam1.Name = "lblCam1";
            this.lblCam1.Size = new System.Drawing.Size(50, 12);
            this.lblCam1.TabIndex = 17;
            this.lblCam1.Text = "Camera1";
            // 
            // lblCam2
            // 
            this.lblCam2.AutoSize = true;
            this.lblCam2.Location = new System.Drawing.Point(331, 27);
            this.lblCam2.Name = "lblCam2";
            this.lblCam2.Size = new System.Drawing.Size(50, 12);
            this.lblCam2.TabIndex = 18;
            this.lblCam2.Text = "Camera2";
            // 
            // cBoxCam2
            // 
            this.cBoxCam2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCam2.FormattingEnabled = true;
            this.cBoxCam2.Location = new System.Drawing.Point(333, 45);
            this.cBoxCam2.Name = "cBoxCam2";
            this.cBoxCam2.Size = new System.Drawing.Size(74, 20);
            this.cBoxCam2.TabIndex = 2;
            // 
            // btnFlip
            // 
            this.btnFlip.Location = new System.Drawing.Point(253, 100);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(154, 23);
            this.btnFlip.TabIndex = 5;
            this.btnFlip.Text = "Flip ON";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.BtnFlip_Click);
            // 
            // btnSynthesis
            // 
            this.btnSynthesis.Location = new System.Drawing.Point(253, 129);
            this.btnSynthesis.Name = "btnSynthesis";
            this.btnSynthesis.Size = new System.Drawing.Size(154, 23);
            this.btnSynthesis.TabIndex = 34;
            this.btnSynthesis.Text = "Synthesis";
            this.btnSynthesis.UseVisualStyleBackColor = true;
            this.btnSynthesis.Click += new System.EventHandler(this.BtnSynthesis_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(253, 158);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(154, 23);
            this.btnCapture.TabIndex = 19;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.BtnCapture_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(253, 187);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(154, 23);
            this.btnPrint.TabIndex = 20;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "ファイル";
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureToolStripMenuItem1,
            this.showInFolderToolStripMenuItem,
            this.printToolStripMenuItem});
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.captureToolStripMenuItem.Text = "キャプチャ";
            // 
            // captureToolStripMenuItem1
            // 
            this.captureToolStripMenuItem1.Name = "captureToolStripMenuItem1";
            this.captureToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.captureToolStripMenuItem1.Text = "キャプチャする";
            this.captureToolStripMenuItem1.Click += new System.EventHandler(this.CaptureToolStripMenuItem1_Click);
            // 
            // showInFolderToolStripMenuItem
            // 
            this.showInFolderToolStripMenuItem.Name = "showInFolderToolStripMenuItem";
            this.showInFolderToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.showInFolderToolStripMenuItem.Text = "フォルダを開く";
            this.showInFolderToolStripMenuItem.Click += new System.EventHandler(this.ShowInFolderToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.printToolStripMenuItem.Text = "印刷";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.ExitToolStripMenuItem.Text = "終了";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // btnRotateL
            // 
            this.btnRotateL.Location = new System.Drawing.Point(332, 255);
            this.btnRotateL.Name = "btnRotateL";
            this.btnRotateL.Size = new System.Drawing.Size(75, 23);
            this.btnRotateL.TabIndex = 22;
            this.btnRotateL.Text = "左回転";
            this.btnRotateL.UseVisualStyleBackColor = true;
            this.btnRotateL.Click += new System.EventHandler(this.BtnRotateL_Click);
            // 
            // btnRotateR
            // 
            this.btnRotateR.Location = new System.Drawing.Point(431, 255);
            this.btnRotateR.Name = "btnRotateR";
            this.btnRotateR.Size = new System.Drawing.Size(75, 23);
            this.btnRotateR.TabIndex = 23;
            this.btnRotateR.Text = "右回転";
            this.btnRotateR.UseVisualStyleBackColor = true;
            this.btnRotateR.Click += new System.EventHandler(this.BtnRotateR_Click);
            // 
            // lblRotate
            // 
            this.lblRotate.AutoSize = true;
            this.lblRotate.Location = new System.Drawing.Point(278, 260);
            this.lblRotate.Name = "lblRotate";
            this.lblRotate.Size = new System.Drawing.Size(48, 12);
            this.lblRotate.TabIndex = 24;
            this.lblRotate.Text = "Rotation";
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(284, 289);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(42, 12);
            this.lblScale.TabIndex = 27;
            this.lblScale.Text = "Scaling";
            // 
            // btnScaleUp
            // 
            this.btnScaleUp.Location = new System.Drawing.Point(431, 284);
            this.btnScaleUp.Name = "btnScaleUp";
            this.btnScaleUp.Size = new System.Drawing.Size(75, 23);
            this.btnScaleUp.TabIndex = 26;
            this.btnScaleUp.Text = "拡大";
            this.btnScaleUp.UseVisualStyleBackColor = true;
            this.btnScaleUp.Click += new System.EventHandler(this.BtnScaleUp_Click);
            // 
            // btnScaleDown
            // 
            this.btnScaleDown.Location = new System.Drawing.Point(332, 284);
            this.btnScaleDown.Name = "btnScaleDown";
            this.btnScaleDown.Size = new System.Drawing.Size(75, 23);
            this.btnScaleDown.TabIndex = 25;
            this.btnScaleDown.Text = "縮小";
            this.btnScaleDown.UseVisualStyleBackColor = true;
            this.btnScaleDown.Click += new System.EventHandler(this.BtnScaleDown_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(431, 417);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 28;
            this.btnReset.Text = "リセット";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // lblTranslate
            // 
            this.lblTranslate.AutoSize = true;
            this.lblTranslate.Location = new System.Drawing.Point(266, 347);
            this.lblTranslate.Name = "lblTranslate";
            this.lblTranslate.Size = new System.Drawing.Size(62, 12);
            this.lblTranslate.TabIndex = 31;
            this.lblTranslate.Text = "Translation";
            // 
            // btnTransE
            // 
            this.btnTransE.Location = new System.Drawing.Point(431, 342);
            this.btnTransE.Name = "btnTransE";
            this.btnTransE.Size = new System.Drawing.Size(75, 23);
            this.btnTransE.TabIndex = 30;
            this.btnTransE.Text = "右移動";
            this.btnTransE.UseVisualStyleBackColor = true;
            this.btnTransE.Click += new System.EventHandler(this.BtnTransE_Click);
            // 
            // btnTransW
            // 
            this.btnTransW.Location = new System.Drawing.Point(332, 342);
            this.btnTransW.Name = "btnTransW";
            this.btnTransW.Size = new System.Drawing.Size(75, 23);
            this.btnTransW.TabIndex = 29;
            this.btnTransW.Text = "左移動";
            this.btnTransW.UseVisualStyleBackColor = true;
            this.btnTransW.Click += new System.EventHandler(this.BtnTransW_Click);
            // 
            // btnTransS
            // 
            this.btnTransS.Location = new System.Drawing.Point(383, 369);
            this.btnTransS.Name = "btnTransS";
            this.btnTransS.Size = new System.Drawing.Size(75, 23);
            this.btnTransS.TabIndex = 33;
            this.btnTransS.Text = "下移動";
            this.btnTransS.UseVisualStyleBackColor = true;
            this.btnTransS.Click += new System.EventHandler(this.BtnTransS_Click);
            // 
            // btnTransN
            // 
            this.btnTransN.Location = new System.Drawing.Point(383, 315);
            this.btnTransN.Name = "btnTransN";
            this.btnTransN.Size = new System.Drawing.Size(75, 23);
            this.btnTransN.TabIndex = 32;
            this.btnTransN.Text = "上移動";
            this.btnTransN.UseVisualStyleBackColor = true;
            this.btnTransN.Click += new System.EventHandler(this.BtnTransN_Click);
            // 
            // btnrenew
            // 
            this.btnrenew.Location = new System.Drawing.Point(332, 417);
            this.btnrenew.Name = "btnrenew";
            this.btnrenew.Size = new System.Drawing.Size(75, 23);
            this.btnrenew.TabIndex = 35;
            this.btnrenew.Text = "更新";
            this.btnrenew.UseVisualStyleBackColor = true;
            this.btnrenew.Click += new System.EventHandler(this.Btnrenew_Click);
            // 
            // AddBackGround
            // 
            this.AddBackGround.Location = new System.Drawing.Point(253, 217);
            this.AddBackGround.Name = "AddBackGround";
            this.AddBackGround.Size = new System.Drawing.Size(154, 23);
            this.AddBackGround.TabIndex = 36;
            this.AddBackGround.Text = "Add Background";
            this.AddBackGround.UseVisualStyleBackColor = true;
            this.AddBackGround.Click += new System.EventHandler(this.AddBackGround_Click);
            // 
            // hue_upper
            // 
            this.hue_upper.Location = new System.Drawing.Point(47, 231);
            this.hue_upper.Maximum = 255;
            this.hue_upper.Name = "hue_upper";
            this.hue_upper.Size = new System.Drawing.Size(165, 45);
            this.hue_upper.TabIndex = 37;
            this.hue_upper.Value = 255;
            this.hue_upper.ValueChanged += new System.EventHandler(this.Hue_UpperChanged);
            // 
            // hue_lower
            // 
            this.hue_lower.Location = new System.Drawing.Point(47, 261);
            this.hue_lower.Maximum = 255;
            this.hue_lower.Name = "hue_lower";
            this.hue_lower.Size = new System.Drawing.Size(165, 45);
            this.hue_lower.TabIndex = 38;
            this.hue_lower.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.hue_lower.ValueChanged += new System.EventHandler(this.Hue_LowerChanged);
            // 
            // saturation_lower
            // 
            this.saturation_lower.Location = new System.Drawing.Point(47, 323);
            this.saturation_lower.Maximum = 255;
            this.saturation_lower.Name = "saturation_lower";
            this.saturation_lower.Size = new System.Drawing.Size(165, 45);
            this.saturation_lower.TabIndex = 42;
            this.saturation_lower.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.saturation_lower.ValueChanged += new System.EventHandler(this.Saturation_LowerChanged);
            // 
            // saturation_upper
            // 
            this.saturation_upper.Location = new System.Drawing.Point(47, 293);
            this.saturation_upper.Maximum = 255;
            this.saturation_upper.Name = "saturation_upper";
            this.saturation_upper.Size = new System.Drawing.Size(165, 45);
            this.saturation_upper.TabIndex = 41;
            this.saturation_upper.Value = 255;
            this.saturation_upper.ValueChanged += new System.EventHandler(this.Saturation_UpperChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "Lower";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "Upper";
            // 
            // value_lower
            // 
            this.value_lower.Location = new System.Drawing.Point(47, 390);
            this.value_lower.Maximum = 255;
            this.value_lower.Name = "value_lower";
            this.value_lower.Size = new System.Drawing.Size(165, 45);
            this.value_lower.TabIndex = 46;
            this.value_lower.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.value_lower.ValueChanged += new System.EventHandler(this.Value_LowerChanged);
            // 
            // value_upper
            // 
            this.value_upper.Location = new System.Drawing.Point(47, 360);
            this.value_upper.Maximum = 255;
            this.value_upper.Name = "value_upper";
            this.value_upper.Size = new System.Drawing.Size(165, 45);
            this.value_upper.TabIndex = 45;
            this.value_upper.Value = 255;
            this.value_upper.ValueChanged += new System.EventHandler(this.Value_UpperChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "Lower";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 375);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 43;
            this.label4.Text = "Upper";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 452);
            this.Controls.Add(this.value_lower);
            this.Controls.Add(this.value_upper);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.saturation_lower);
            this.Controls.Add(this.saturation_upper);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hue_lower);
            this.Controls.Add(this.hue_upper);
            this.Controls.Add(this.AddBackGround);
            this.Controls.Add(this.btnrenew);
            this.Controls.Add(this.btnSynthesis);
            this.Controls.Add(this.btnTransS);
            this.Controls.Add(this.btnTransN);
            this.Controls.Add(this.lblTranslate);
            this.Controls.Add(this.btnTransE);
            this.Controls.Add(this.btnTransW);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.btnScaleUp);
            this.Controls.Add(this.btnScaleDown);
            this.Controls.Add(this.lblRotate);
            this.Controls.Add(this.btnRotateR);
            this.Controls.Add(this.btnRotateL);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnFlip);
            this.Controls.Add(this.cBoxCam2);
            this.Controls.Add(this.lblCam2);
            this.Controls.Add(this.lblCam1);
            this.Controls.Add(this.cBoxCam1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbBack);
            this.Controls.Add(this.lblVal);
            this.Controls.Add(this.lblSat);
            this.Controls.Add(this.lblHue);
            this.Controls.Add(this.lblHlow);
            this.Controls.Add(this.lblHup);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Chromakey NakanoLAB";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hue_upper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hue_lower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturation_lower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturation_upper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_lower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_upper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHup;
        private System.Windows.Forms.Label lblHlow;
        private System.Windows.Forms.Label lblHue;
        private System.Windows.Forms.Label lblSat;
        private System.Windows.Forms.Label lblVal;
        private System.Windows.Forms.ListBox lbBack;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cBoxCam1;
        private System.Windows.Forms.Label lblCam1;
        private System.Windows.Forms.Label lblCam2;
        private System.Windows.Forms.ComboBox cBoxCam2;
        private System.Windows.Forms.Button btnFlip;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showInFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.Button btnRotateL;
        private System.Windows.Forms.Button btnRotateR;
        private System.Windows.Forms.Label lblRotate;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.Button btnScaleUp;
        private System.Windows.Forms.Button btnScaleDown;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTranslate;
        private System.Windows.Forms.Button btnTransE;
        private System.Windows.Forms.Button btnTransW;
        private System.Windows.Forms.Button btnTransS;
        private System.Windows.Forms.Button btnTransN;
        private System.Windows.Forms.Button btnSynthesis;
        private System.Windows.Forms.Button btnrenew;
        private System.Windows.Forms.Button AddBackGround;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
        private System.Windows.Forms.TrackBar hue_upper;
        private System.Windows.Forms.TrackBar hue_lower;
        private System.Windows.Forms.TrackBar saturation_lower;
        private System.Windows.Forms.TrackBar saturation_upper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar value_lower;
        private System.Windows.Forms.TrackBar value_upper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

