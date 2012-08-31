using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Test.Utils
{
    class FlvHeader
    {
        private byte[] signature;
        private byte version;
        private byte typeflag;
        private int dataoffset;
        private byte[] length;

        public FlvHeader(Stream stream)
        {
            signature = new byte[3];
            version = 0;
            typeflag = 0;
            dataoffset = 0;
            length = new byte[4];

            byte[] buffer = new byte[4];
            stream.Read(signature, 0, 3);
            stream.Read(buffer, 0, 1);
            version = buffer[0];
            stream.Read(buffer, 0, 1);
            typeflag = buffer[0];
            stream.Read(length, 0, 4);
        }


        public bool IsFlv
        {
            get
            {
                if (signature == null || signature.Length != 3)
                    return false;
                return (signature[0] == 0x46) &&
                    (signature[1] == 0x4C) &&
                    (signature[2] == 0x56);
            }
        }
        public int Version
        {
            get { return version; }
        }
        public bool HasVideo
        {
            get { return (typeflag & 0x1) == 0x1; }
        }
        public bool HasAudio
        {
            get { return (typeflag & 0x4) == 0x4; }
        }
        public int Length
        {
            get
            {
                return dataoffset;
            }
        }
    }
}