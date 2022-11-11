using System;
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
    public class XmlEditor
    {
        private XElement xml;
        private string filename;
        public XmlEditor(string filename)
        {
            this.filename = filename;
            if (!File.Exists(this.filename))
            {
                 new XDocument(new XDeclaration("1.0", "utf-8", "true"), new XElement("root")).Save(this.filename);
            }
            xml = XElement.Load(this.filename);
        }

        public void XmlWrite(XElement data)
        {
            xml.Add(data);
            xml.Save(filename);
        }

        public void XmlRead(List<string> data, string tag)
        {
            data.Clear();
            IEnumerable<string> infos = from item in xml.Elements().Elements(tag) select item.Value;

            foreach (string info in infos)
            {
                data.Add(info);
            }
        }
    }
}
