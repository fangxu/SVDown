﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVDown.Model
{
    class Durl
    {
        private int order;
        private long length;
        private String url;

        public System.String Url
        {
            get { return url; }
            set { url = value; }
        }
        public long Length
        {
            get { return length; }
            set { length = value; }
        }
        public int Order
        {
            get { return order; }
            set { order = value; }
        }
    }
}
