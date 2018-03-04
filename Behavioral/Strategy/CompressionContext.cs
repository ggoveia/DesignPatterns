using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.Strategy
{
    public class CompressionContext : ICompressionContext
    {
        ICompressionStrategy compressionStrategy;

        public CompressionContext(ICompressionStrategy compressionStrategy)
        {
            this.compressionStrategy = compressionStrategy;
        }

        public void CreateArchive()
        {
            Console.Write(compressionStrategy.Compress());
        }
    }
}
