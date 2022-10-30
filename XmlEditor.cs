using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chromakey2022
{
    internal class XmlEditor
    {
        private XElement xml;
        private string filename;
        public XmlEditor(string filename)
        {
            this.filename = filename;
            xml = XElement.Load(this.filename);
        }

        public void XmlWrite(XElement data)
        {
            xml.Add(data);
            xml.Save(filename);
        }
    }
}
