using MiniAppHakaton.Models.Geomethry;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MiniAppHakaton.Helpers
{
    public class StravaTrackDeserializeHelper
    {
        public List<Point> XMLToListOfPoints(string path)
        {
            var trackPoints = new List<Point>();
            XmlDocument xDoc =  new XmlDocument();
            xDoc.Load(path);

            XmlNodeList points = xDoc.ChildNodes[1].ChildNodes[1].ChildNodes[4].ChildNodes;

            foreach (XmlNode point in points)
            {
                trackPoints.Add(new Point
                {
                    Lat = Double.Parse(point.Attributes.GetNamedItem("lat").Value, CultureInfo.InvariantCulture),
                    Lon = Double.Parse(point.Attributes.GetNamedItem("lon").Value, CultureInfo.InvariantCulture)
                });
            }

            return trackPoints;
        }
    }
}
