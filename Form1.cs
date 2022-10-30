using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using Chromakey2022;

//System.Runtime.InteropServices.DllImportAttribute("winmm.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto);


namespace Chromakey_NakanoLab
{
    public partial class Form1 : Form
    {
        Chromakey ck; //このクラスはChromakey.csに記述されている。
        DateTime dt;
        private List<String> bgname;
        private List<String> bgpath;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            Xmlreader();
            ck = new Chromakey();
            for (int i = 0; i < bgpath.Count; i++)
            {
                ck.Setbgpath(bgpath[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //HSV初期設定
            numHlow.Value = 40;
            numHup.Value = 80;
            numSlow.Value = 80;
            numSup.Value = 255;
            numVlow.Value = 50;
            numVup.Value = 255;

            int n = ck.Numofcam();

            cBoxCam2.Items.Add("選択しない");

            for (int i = 0; i < n; i++)
            {
                cBoxCam1.Items.Add(i);
                cBoxCam2.Items.Add(i);
            }
            cBoxCam1.SelectedIndex = 0; //カメラが接続されてないときにエラー
            cBoxCam2.SelectedIndex = 0;

            for (int i = 0; i < bgname.Count; i++)
                lbBack.Items.Add(bgname[i]);

            btnCapture.Enabled = false;
            btnFlip.Enabled = false;
            btnPrint.Enabled = false;
            //アプリケーション終了時のイベントハンドラを追加
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            ck.Stop();
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
        }

        private void NumHdown_ValueChanged(object sender, EventArgs e)
        {
            numHup.Minimum = numHlow.Value + 1;
            ck.Hlow = (int)numHlow.Value;
        }

        private void NumHup_ValueChanged(object sender, EventArgs e)
        {
            numHlow.Maximum = numHup.Value - 1;
            ck.Hup = (int)numHup.Value;
        }

        private void NumSdown_ValueChanged(object sender, EventArgs e)
        {
            numSup.Minimum = numSlow.Value + 1;
            ck.Slow = (int)numSlow.Value;
        }

        private void NumSup_ValueChanged(object sender, EventArgs e)
        {
            numSlow.Maximum = numSup.Value - 1;
            ck.Sup = (int)numSup.Value;
        }

        private void NumVdown_ValueChanged(object sender, EventArgs e)
        {
            numVup.Minimum = numVlow.Value + 1;
            ck.Vlow = (int)numVlow.Value;
        }

        private void NumVup_ValueChanged(object sender, EventArgs e)
        {
            numVlow.Maximum = numVup.Value - 1;
            ck.Vup = (int)numVup.Value;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (cBoxCam1.SelectedIndex == (cBoxCam2.SelectedIndex - 1))
            {
                MessageBox.Show("同じカメラは選択できません");
                return;
            }

            btnFlip.Enabled = true;

            ck.Run(cBoxCam1.SelectedIndex, cBoxCam2.SelectedIndex - 1);
            btnStart.Enabled = false;
            btnCapture.Enabled = true;
            if (cBoxCam2.SelectedIndex != 0)
                lbBack.Items.Add("Camera2");
        }

        private void BtnFlip_Click(object sender, EventArgs e)
        {
            if (ck.flgFlip)
            {
                ck.flgFlip = false;
                btnFlip.Text = "Flip ON";
            }
            else
            {
                ck.flgFlip = true;
                btnFlip.Text = "Flip OFF";
            }
        }

        //private static extern int mciSendString(string command, System.Text.StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        //private string aliasName = "MediaFile";

        private void BtnSynthesis_Click(object sender, EventArgs e)
        {
            /*string fileName = "D:\\Chromakey:\\Chromakey2015:\\music:\\shutter.wav";
           string cmd;
           cmd = "open \"" + fileName + "\" alias " + aliasName;
           if (mciSendString(cmd, null, 0, IntPtr.Zero) != 0)
               return;
           cmd = "play " + aliasName;
           mciSendString(cmd, null, 0, IntPtr.Zero);
           */

            bmp = new Bitmap(ck.Image());
            bmp.Save("background/copy.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            btnPrint.Enabled = false;

            /*
           cmd = "stop " + aliasName;
           mciSendString(cmd, null, 0, IntPtr.Zero);
           cmd = "close " + aliasName;
           mciSendString(cmd, null, 0, IntPtr.Zero);
           */
        }

        private void BtnCapture_Click(object sender, EventArgs e)
        {
            /*string fileName = "D:\\Chromakey:\\Chromakey2015:\\music:\\shutter.wav";
            string cmd;
            cmd = "open \"" + fileName + "\" alias " + aliasName;
            if (mciSendString(cmd, null, 0, IntPtr.Zero) != 0)
                return;
            cmd = "play " + aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
            */

            bmp = new Bitmap(ck.Image());
            dt = DateTime.Now;
            bmp.Save("capture/" + dt.ToString("yyyyMMdd_HHmmss") + ".bmp");
            btnPrint.Enabled = true;

            /*
            cmd = "stop " + aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
            cmd = "close " + aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
            */
        }


        private void LbBack_SelectedIndexChanged(object sender, EventArgs e)
        {
            ck.bgIndex = lbBack.SelectedIndex;
        }


        private void Xmlreader()
        {
            string fn = "background.xml";
            bgname = new List<string>();
            bgpath = new List<string>();
            if (File.Exists(fn))
            {
                using (XmlTextReader reader = new XmlTextReader(fn))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.LocalName)
                            {
                                case "path":
                                    Console.WriteLine("Hello World!");
                                    bgpath.Add(reader.ReadString());
                                    break;
                                case "name":
                                    bgname.Add(reader.ReadString());
                                    break;
                            }
                        }
                    }
                    reader.Close();
                }
            }
        }


        private void BtnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("プロパティから名刺サイズに選択してください。\nまた，縁無しにしないと全範囲印刷されません。");
            //PrintDocumentオブジェクトの作成
            System.Drawing.Printing.PrintDocument pd =
                new System.Drawing.Printing.PrintDocument();

            pd.DefaultPageSettings.PaperSize = new PaperSize("meishi", 216, 358);
            //PrintPageイベントハンドラの追加
            pd.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(Pd_PrintPage);

            //PrintDialogクラスの作成
            PrintDialog pdlg = new PrintDialog();
            //PrintDocumentを指定
            pdlg.Document = pd;
            //印刷の選択ダイアログを表示する
            if (pdlg.ShowDialog() == DialogResult.OK)
            {
                //OKがクリックされた時は印刷する
                pd.Print();
            }


        }

        private void Pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //画像を読み込む
            Image img = Image.FromFile("capture/" + dt.ToString("yyyyMMdd_HHmmss") + ".bmp");
            //画像を描画する
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            e.Graphics.DrawImage(img, 1, 29, 216, 288); //216:288=3:4
            //次のページがないことを通知する
            e.HasMorePages = false;
            //後始末をする
            img.Dispose();
        }

        private void CaptureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!btnCapture.Enabled)
            {
                MessageBox.Show("カメラをスタートしないとキャプチャできません。");
                return;
            }
            bmp = new Bitmap(ck.Image());
            dt = DateTime.Now;
            bmp.Save("capture/" + dt.ToString("yyyyMMdd_HHmmss") + ".bmp");
            btnPrint.Enabled = true;
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!btnPrint.Enabled)
            {
                MessageBox.Show("キャプチャ後にプリントできます。");
                return;
            }
            MessageBox.Show("プロパティから名刺サイズに選択してください。\nまた，縁無しにしないと全範囲印刷されません。");
            //PrintDocumentオブジェクトの作成
            System.Drawing.Printing.PrintDocument pd =
                new System.Drawing.Printing.PrintDocument();

            pd.DefaultPageSettings.PaperSize = new PaperSize("meishi", 216, 358);
            //PrintPageイベントハンドラの追加
            pd.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(Pd_PrintPage);

            //PrintDialogクラスの作成
            PrintDialog pdlg = new PrintDialog();
            //PrintDocumentを指定
            pdlg.Document = pd;
            //印刷の選択ダイアログを表示する
            if (pdlg.ShowDialog() == DialogResult.OK)
            {
                //OKがクリックされた時は印刷する
                pd.Print();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowInFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("capture");
        }

        //リセット
        private void BtnReset_Click(object sender, EventArgs e)
        {
            ck.Scale = 1.0;
            ck.Rotate = 0.0;
            ck.TransX = 0.0;
            ck.TransY = 0.0;
        }

        //更新
        private void Btnrenew_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Close();
            frm1.Show();
            //Xmlreader();
        }

        //縮尺
        private void BtnScaleDown_Click(object sender, EventArgs e)
        {
            ck.Scale -= 0.1;
        }

        private void BtnScaleUp_Click(object sender, EventArgs e)
        {
            ck.Scale += 0.1;
        }

        //回転
        private void BtnRotateL_Click(object sender, EventArgs e)
        {
            ck.Rotate += 10.0;
        }

        private void BtnRotateR_Click(object sender, EventArgs e)
        {
            ck.Rotate -= 10.0;
        }

        //移動
        private void BtnTransW_Click(object sender, EventArgs e)
        {
            ck.TransX -= 20;
        }

        private void BtnTransE_Click(object sender, EventArgs e)
        {
            ck.TransX += 20;
        }

        private void BtnTransN_Click(object sender, EventArgs e)
        {
            ck.TransY -= 20;
        }

        private void BtnTransS_Click(object sender, EventArgs e)
        {
            ck.TransY += 20;
        }

        private void AddBackGround_Click(object sender, EventArgs e)
        {
            using (AddBackGround addbackground = new AddBackGround())
            {
                if(addbackground.ShowDialog() == DialogResult.OK)
                {
                    Xmlreader();
                    lbBack.Items.Add(bgname[bgname.Count - 1]);
                    ck.Setbgpath(bgpath[bgpath.Count - 1]);
                }
            }
        }
    }
}
      
