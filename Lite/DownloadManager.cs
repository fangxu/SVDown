using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lite
{
    class DownloadManager
    {
        private Video video;
        private Form1 form;
        Thread t;
        Thread updateThread;
        public DownloadManager(Form1 form, Video video)
        {
            this.form = form;
            this.video = video;
        }

        public void Start()
        {
            t = new Thread(new ThreadStart(new DownloadThread(video).reciveVideo));
            t.IsBackground = true;
            t.Start();
            updateThread = new Thread(new ThreadStart(update));
            updateThread.IsBackground = true;
            updateThread.Start();
        }

        public void update()
        {
            while (true)
            {
                form.BeginInvoke(new Form1.Title(form.updateTitle), 
                    new object[] { video.speed.ToString()+"KB/s" });
                Thread.Sleep(1000);
            }

        }

        public void Stop()
        {
            t.Abort();
            updateThread.Abort();
        }
    }
}
