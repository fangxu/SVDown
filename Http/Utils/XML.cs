using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SVDown.Model;
using System.Xml;
using System.IO;

namespace SVDown.Utils
{
    class XML
    {
        public static Video GetVideo(Stream xmlStream)
        {
            XmlReader reader = XmlReader.Create(xmlStream);
            String tag = null;
            IList<Durl> parts = new List<Durl>();
            Video video = new Video();
            Durl durl = null;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text:

                        switch (tag)
                        {
                            case "result":
                                video.Result = reader.Value;
                                break;
                            case "timelength":
                                video.TimeLength = long.Parse(reader.Value);
                                break;
                            case "framecount":
                                video.FrameCount = reader.Value;
                                break;
//                             case "vname":
//                                 video.Name = reader.Value;
//                                 break;
                            case "order":
                                if (durl != null)
                                {
                                    durl.Order = int.Parse(reader.Value);
                                }
                                break;
                            case "length":
                                if (durl != null)
                                {
                                    durl.Length = long.Parse(reader.Value);
                                }
                                break;
                        }
                        break;
                    case XmlNodeType.Element:
                        tag = reader.Name;
                        if (tag == "durl" && durl == null)
                        {
                            durl = new Durl();
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.Name == "durl" && durl != null)
                        {
                            parts.Add(durl);
                            durl = null;
                        }
                        if (reader.Name == "video")
                        {
                            video.Parts = parts;
                        }
                        break;
                    case XmlNodeType.CDATA:
                        if (tag == "vname")
                        {
                            video.Name = reader.Value;
                        }
                        if (tag == "url" && durl != null)
                        {
                            durl.Url = reader.Value;
                        }
                        break;
                }
            }
            return video;
        }
    }
}
