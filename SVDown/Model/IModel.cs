using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SVDown.View;

namespace SVDown.Model
{
    public interface IModel
    {
        void addVideo(Video v);
        void removeVideo(Video v);
        void clearVideo();
        HashSet<Video> getVideos();
        void setVideo(Video v);
        void updated();

        //Observer
        void addObserver(IView iv);
        void removeObserver(IView iv);
        void notifyObserver();
    }
}
