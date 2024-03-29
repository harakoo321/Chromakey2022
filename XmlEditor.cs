﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Chromakey2022
{
    //xmlファイルを編集するためのクラス
    public class XmlEditor
    {
        private XElement xml;
        private string filename;
        public XmlEditor(string filename)
        {
            this.filename = filename;
            if (!File.Exists(this.filename)) //指定したxmlファイルが無ければ作成
            {
                 new XDocument(new XDeclaration("1.0", "utf-8", "true"), new XElement("root")).Save(this.filename);
            }
            xml = XElement.Load(this.filename);
        }

        //xmlファイルに追記するためのメソッド
        public void XmlAdd(XElement data)
        {
            xml.Add(data);
            xml.Save(filename);
        }

        //指定したタグの要素を配列に格納するメソッド
        public void XmlReadItem(List<string> datalist, string tag)
        {
            datalist.Clear();   //データを格納する配列のクリア
            IEnumerable<string> infos = from item in xml.Elements().Elements(tag) select item.Value; //指定したタグの要素を取得

            foreach (string info in infos)
            {
                datalist.Add(info);
            }
        }

        //指定した要素の削除
        public void XmlRemove(string tag)
        {
            var emp = from p in xml.Descendants("picture") where p.Element("name").Value == tag select p;
            emp.Remove();
            xml.Save(filename);
        }
    }
}
