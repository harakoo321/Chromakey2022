using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromakey2022
{
    //背景画像を追加するためのダイアログ
    public partial class AddBackGround : Form
    {
        private XmlEditor xmlEditor;
        public AddBackGround(XmlEditor xmlEditor)
        {
            InitializeComponent();
            this.xmlEditor = xmlEditor;
        }

        //ファイルの選択
        private void Selectimg_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File|*.bmp;*.png;*.jpg;*.jpeg";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                img_path.Text = openFileDialog1.FileName;
            }
        }

        //追加
        private void Addbg_Click(object sender, EventArgs e)
        {
            try
            {
                if(File.Exists(img_path.Text) && img_name.Text != "")
                {
                    xmlEditor.XmlAdd(new System.Xml.Linq.XElement("picture",
                        new System.Xml.Linq.XElement("name", img_name.Text),
                        new System.Xml.Linq.XElement("path", img_path.Text)));

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("ファイルのパスが正しくないか、画像名が入力されていません。", "エラー", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("background.xmlが存在しません。", "エラー", MessageBoxButtons.OK);
                Close();
            }
        }
    }
}
