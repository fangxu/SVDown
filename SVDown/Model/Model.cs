using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SVDown.View;

namespace SVDown.Model
{
    public class Model : IModel
    {
        private HashSet<Video> videos;
        private IList<IView> observers;
        private MainForm form;

        public Model(MainForm form)
        {
            videos = new HashSet<Video>(new SynonymComparer());
            observers = new List<IView>();
            this.form = form;
        }

        public void addVideo(Video v)
        {
            videos.Add(v);
            notifyObserver();
        }

        public void removeVideo(Video v)
        {
            videos.Remove(v);
        }

        public void clearVideo()
        {
            videos.Clear();
        }

        public HashSet<Video> getVideos()
        {
            return videos;
        }

        public void addObserver(IView iv)
        {
            observers.Add(iv);
        }

        public void removeObserver(IView iv)
        {
            observers.Remove(iv);
        }

        public void notifyObserver()
        {
            foreach (IView iv in observers)
            {
                //iv.updateView();
                form.BeginInvoke(new MainForm.updateListView(form.updateView));
            }
        }


        public void setVideo(Video v)
        {
            videos.Remove(v);
            videos.Add(v);
            notifyObserver();

        }


        public void updated()
        {
            notifyObserver();
        }
    }


    public class SynonymComparer : IEqualityComparer<Video>
    {

        public bool Equals(Video x, Video y)
        {
            return String.Equals(x.url,y.url);
        }

        public int GetHashCode(Video obj)
        {
            return StringComparer.CurrentCulture.GetHashCode(obj.url);
        }
    }
}
