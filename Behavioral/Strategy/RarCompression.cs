using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.Strategy
{
    public class RarCompression : ICompressionStrategy
    {
        public string Compress()
        {
            return "RAR Compression done successfully";
        }
    }
}
