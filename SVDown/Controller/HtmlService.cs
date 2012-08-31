using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;
using SVDown.Model;
using SVDown.Utils;

namespace SVDown.Services
{
    class HtmlService
    {
        private const int BUF_SIZE = 2048;
        public static String GetHtmlString(String url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 30 * 1000;
            Stream rs = request.GetResponse().GetResponseStream();
            byte[] buf = new byte[BUF_SIZE];
            int len = 0;
            StringBuilder sb = new StringBuilder();
            while ((len = rs.Read(buf, 0, BUF_SIZE)) != 0)
            {
                sb.Append(Encoding.UTF8.GetString(buf, 0, len));
            }
            return sb.ToString();
        }

        public static Stream GetHtmlStream(String url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 30 * 1000;
            return request.GetResponse().GetResponseStream();
        }

//         public static Video GetVideo(String url)
//         {
//             return XML.GetVideo(GetHtmlStream(url));
//         }
        //http://video.sina.com.cn/v/b/64416884-1648211320.html
        public static void ParserVideo(Video video)
        {
            String url = video.url;
            url = url.Substring(url.LastIndexOf('/')+1, url.LastIndexOf('-') - url.LastIndexOf('/')-1);
            String xmlUrl = @"http://v.iask.com/v_play.php?vid=" + url;
            XML.GetVideo(GetHtmlStream(xmlUrl),video);
        }
    }
}
