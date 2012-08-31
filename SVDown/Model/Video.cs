using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVDown.Model
{
    public enum Status
    {
        waitting,
        downloading,
        stoped,
        done
    }

    public class Video
    {
        public int order { get; set; }
        private String result;
        private long timeLength;
        private String frameCount;
        private String vName;
        IList<Durl> parts;
        private Status status;
        private String path;
        private String saveName;
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int process { get; set; }
        public String url { get; set; }

        public Video()
        {
            this.start = DateTime.Now;
        }

        public Video(string url, string saveName, string path):this()
        {
            this.url = url;
            this.saveName = saveName;
            this.path = path;
                       
        }
        public System.String Path
        {
            get { return path; }
            set { path = value; }
        }

        public System.String SaveName
        {
            get { return saveName; }
            set { saveName = value; }
        }
        public SVDown.Model.Status Status
        {
            get { return status; }
            set { status = value; }
        }
        public IList<Durl> Parts
        {
            get { return parts; }
            set { parts = value; }
        }
        public System.String Name
        {
            get { return vName; }
            set { vName = value; }
        }
        public System.String FrameCount
        {
            get { return frameCount; }
            set { frameCount = value; }
        }
        public System.String Result
        {
            get { return result; }
            set { result = value; }
        }

        public long TimeLength
        {
            get { return timeLength; }
            set { timeLength = value; }
        }
    }
}
