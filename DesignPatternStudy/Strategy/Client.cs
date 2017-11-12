using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.Strategy
{
    public class Client
    {
        private ICompressionContext _compressionContext;
       

        public static Client NewClient(ICompressionContext compressionContext)
        {
           return new Client(compressionContext);
        }

        private Client(ICompressionContext compressionContext)
        {            
            _compressionContext = compressionContext;           
        }

        public void ArquiveFile()
        {
          _compressionContext.CreateArchive();
        }
    }
}
