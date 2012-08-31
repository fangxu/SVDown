using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lite
{
    class Video
    {
        public String url { get; set; }
        public String xmlUrl { get; set; }
        public String name { get; set; }
        public long timeLength { get; set; }
        public String frameCount { get; set; }
        public List<Durl> parts { get; set; }
        public String path { get; set; }
        public String saveName { get; set; }
        public float speed { get; set; }

        public Video(String url)
        {
            //http://v.iask.com/v_play.php?vid=75314790&uid=1648211320&pid=478&tid=&plid=4001&prid=ja_7_3485822616&referrer=http%3A%2F%2Fcontrol.video.sina.com.cn%2Fcontrol%2Fvideoset%2Findex.php&ran=0.4922798699699342&r=video.sina.com.cn
            this.url = url;
            xmlUrl = @"http://v.iask.com/v_play.php?vid=" +
                url.Substring(url.LastIndexOf('/') + 1, url.LastIndexOf('-') - url.LastIndexOf('/') - 1);
        }
    }
}
