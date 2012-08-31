using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVDown.Model
{
    class Video
    {
        private String result;
        private long timeLength;
        private String frameCount;
        private String vName;
        IList<Durl> parts;

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
