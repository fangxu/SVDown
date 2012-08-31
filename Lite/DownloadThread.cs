using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

namespace Lite
{
    class DownloadThread
    {
        public const int BUF_SIZE = 2048;
        private Durl durl;
        private String pathName;
        private Video video;

        private long hadReceved;
        //private String saveName;

        public DownloadThread(Durl durl, String pathName)
        {
            this.durl = durl;
            this.pathName = pathName;
        }
        public DownloadThread(Video video)
        {
            this.video = video;
            pathName = video.path + video.name;
        }
        public void recive()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(durl.url);
            request.Timeout = 30 * 1000;
            Stream rs = request.GetResponse().GetResponseStream();
            byte[] buf = new byte[BUF_SIZE];
            int len = 0;
            FileStream fs = new FileStream(pathName + durl.order + ".flv", FileMode.OpenOrCreate, FileAccess.Write);
            while ((len = rs.Read(buf, 0, BUF_SIZE)) != 0)
            {
                fs.Write(buf, 0, len);
            }
            fs.Flush();
            fs.Close();
            rs.Close();
        }

        public void reciveVideo()
        {
            Thread t = new Thread(new ThreadStart(caculateSpeed));
            t.IsBackground = true;
            t.Start();
            int len;           
            foreach (Durl d in video.parts)
            {                
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(d.url);
                request.Timeout = 30 * 1000;
                Stream rs = request.GetResponse().GetResponseStream();
                Console.WriteLine(d.order + ":" + d.lenght);
                byte[] buf = new byte[BUF_SIZE];
                len = 0;
                
                FileStream fs = new FileStream(pathName + d.order + ".flv", FileMode.OpenOrCreate, FileAccess.Write);
                while ((len = rs.Read(buf, 0, BUF_SIZE)) != 0)
                {
                    fs.Write(buf, 0, len);
                    hadReceved += len;                    
                }                
                fs.Flush();
                fs.Close();
                rs.Close();
            }
        }
        public void caculateSpeed()
        {
            while (true)
            {
                video.speed = (float)hadReceved / (1024 * 2);
                hadReceved = 0;
                Thread.Sleep(2 * 1000);
            }

        }
    }
}
