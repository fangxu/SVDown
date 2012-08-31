using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Test.Utils;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("t31.flv",FileMode.Open,FileAccess.Read);
            FlvHeader header = new FlvHeader(fs);
            //Console.WriteLine(b);
            fs.Close();
            Console.Read();
        }
    }

    class Test
    {
        private IList<int> list;
        public Test()
        {
            list = new List<int>();
            list.Add(12);
            list.Add(34);
        }

        public IList<int> getList()
        {
            return list;
        }
    }
}
