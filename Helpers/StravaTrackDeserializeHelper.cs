using MiniAppHakaton.Models.Geomethry;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MiniAppHakaton.Helpers
{
    public class StravaTrackDeserializeHelper
    {
        public List<Point> Test(string path)
        {
            var trackPoints = new List<Point>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode node in xRoot)
            {
                if (node.Name == "trk")
                {
                    foreach (XmlNode pointNode in node.ChildNodes)
                    {
                        if (node.Name == "trkpt")
                        {
                            trackPoints.Add(new Point
                            {
                                Lat = Double.Parse( pointNode.Attributes.GetNamedItem("lat").Value, CultureInfo.InvariantCulture),
                                Long = Double.Parse(pointNode.Attributes.GetNamedItem("lon").Value, CultureInfo.InvariantCulture)
                            });
                        }
                    }
                }
            }


            return trackPoints;
        }
    }
}
