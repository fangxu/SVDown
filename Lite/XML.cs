using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.IO;
using System.Net;

namespace Lite
{
    class XML
    {

        public static void parserVideo(Video video)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(video.xmlUrl);
            request.Timeout = 30 * 1000;
            Stream rs= request.GetResponse().GetResponseStream();
            XmlReader reader = XmlReader.Create(rs);
            String tag = null;
            List<Durl> parts = new List<Durl>();
            //Video video = new Video();
            Durl durl = null;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text:

                        switch (tag)
                        {
                            case "result":
                                //video.Result = reader.Value;
                                break;
                            case "timelength":
                                video.timeLength = long.Parse(reader.Value);
                                break;
                            case "framecount":
                                video.frameCount = reader.Value;
                                break;
//                             case "vname":
//                                 video.Name = reader.Value;
//                                 break;
                            case "order":
                                if (durl != null)
                                {
                                    durl.order = int.Parse(reader.Value);
                                }
                                break;
                            case "length":
                                if (durl != null)
                                {
                                    durl.lenght = long.Parse(reader.Value);
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
                            video.parts = parts;
                        }
                        break;
                    case XmlNodeType.CDATA:
                        if (tag == "vname")
                        {
                            video.name = reader.Value;
                        }
                        if (tag == "url" && durl != null)
                        {
                            durl.url = reader.Value;
                        }
                        break;
                }
            }
            //return video;
        }
    }
}
