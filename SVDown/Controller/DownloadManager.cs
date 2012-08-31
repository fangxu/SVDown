using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVDown.Model;
using SVDown.Services;
using System.Threading;

namespace SVDown.Controller
{
    public class DownloadManager
    {
        private IModel model;
        public DownloadManager(IModel im)
        {
            this.model = im;
        }
        public void startDownload()
        {
            foreach (Video v in model.getVideos())
            {
                HtmlService.ParserVideo(v);
                Thread t = new Thread(new ThreadStart(new DownloadService(model,v).reciveVideo));
                t.IsBackground = true;
                t.Start();
            }
        }        
    }
}
