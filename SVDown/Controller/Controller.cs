using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SVDown.View;
using SVDown.Model;

namespace SVDown.Controller
{
    class Controller : IController
    {
        private IView view;
        private IModel model;
        private DownloadManager dm;
        public Controller(IView iv, IModel im)
        {
            this.model = im;
            this.view = iv;
            dm = new DownloadManager(model);
        }

        public void setModel(Model.IModel im)
        {
            this.model = im;
        }

        public void setView(View.IView iv)
        {
            this.view = iv;
        }        

        public void newTask(string url, string saveName, string path)
        {
            model.addVideo(new Video(url, saveName, path));
        }

        public void startDownload()
        {
            dm.startDownload();
        }
    }
}
