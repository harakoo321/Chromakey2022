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
    public partial class AddBackGround : Form
    {
        public AddBackGround()
        {
            InitializeComponent();
        }

        private void Selectimg_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void Addbg_Click(object sender, EventArgs e)
        {
            try
            {
                if(File.Exists(textBox1.Text) && textBox2.Text != "")
                {
                    XmlEditor xmlEditor = new XmlEditor("background.xml");
                    xmlEditor.XmlWrite(new System.Xml.Linq.XElement("picture",
                        new System.Xml.Linq.XElement("name", textBox2.Text),
                        new System.Xml.Linq.XElement("path", textBox1.Text)));
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
