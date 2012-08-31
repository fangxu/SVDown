using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SVDown;
using SVDown.Model;
using System.Net;
using System.IO;

namespace SVDown.Services
{
    class DownloadService
    {
        private const int BUF_SIZE = 2048;

        private MainForm form;
        private Durl durl;
        private String filePath;
        private Video video;
        private IModel im;
        public DownloadService(MainForm form, Durl durl,String filePath)
        {
            this.durl = durl;
            this.form = form;
            this.filePath = filePath;
        }

        public DownloadService(IModel im,Video video)
        {
            this.video = video;
            this.im = im;
        }

        public void reciveVideo()
        {
            foreach (Durl d in video.Parts)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(d.Url);
                request.Timeout = 30 * 1000;
                Stream rs = request.GetResponse().GetResponseStream();
                byte[] buf = new byte[BUF_SIZE];
                int len = 0;
                FileStream fs = new FileStream(video.Path+"\\"+video.SaveName + d.Order + ".flv", FileMode.OpenOrCreate, FileAccess.Write);
                while ((len = rs.Read(buf, 0, BUF_SIZE)) != 0)
                {
                    fs.Write(buf, 0, len);
                }
                fs.Flush();
                fs.Close();
                rs.Close();
                d.ok = true;
                video.process++;
                im.updated();
            }
        }

        public void recivePart()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(durl.Url);
            request.Timeout = 30 * 1000;
            Stream rs = request.GetResponse().GetResponseStream();
            byte[] buf = new byte[BUF_SIZE];
            int len = 0;
            FileStream fs = new FileStream(filePath + durl.Order + ".flv", FileMode.OpenOrCreate, FileAccess.Write);
            while ((len=rs.Read(buf,0,BUF_SIZE))!=0)
            {
                fs.Write(buf, 0, len);
            }
            fs.Flush();
            fs.Close();
            rs.Close();
        }
    }
}
