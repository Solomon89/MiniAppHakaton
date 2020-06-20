using MiniAppHakaton.Models.Geomethry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace MiniAppHakaton.Helpers
{
    public class StravaTrackDeserializeHelper
    {
        public Point Test(string path)
        {
            var point = new Point();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                }
                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // если узел - company
                    if (childnode.Name == "company")
                    {
                    }
                    // если узел age
                    if (childnode.Name == "age")
                    {
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
