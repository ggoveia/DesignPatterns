using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.Strategy
{
    public class ZipCompression : ICompressionStrategy
    {
        public string Compress()
        {
            return "ZIP Compression done successfully";
        }
    }
}
