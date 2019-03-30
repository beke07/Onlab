using System;
using System.Collections.Generic;
using System.Text;

namespace Onlab.Dal.Entities
{
    public class Image : EntityBase
    { 
        public string Name { get; set; }

        public byte[] Data { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
