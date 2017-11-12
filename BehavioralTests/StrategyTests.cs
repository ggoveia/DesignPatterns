using Behavioral.Strategy;
using Moq;
using System;
using Xunit;

namespace BehavioralTests
{
    public class StrategyTests
    {
        [Fact]
        public void CompressByRar()
        {
            ICompressionStrategy rarCompression = new RarCompression();

            var result = rarCompression.Compress();

            Assert.Equal(result, "RAR Compression done successfully");
           
        }

        [Fact]
        public void CompressByZip() {

            ICompressionStrategy zipCompresstion = new ZipCompression();

            var result = zipCompresstion.Compress();

            Assert.Equal(result, "ZIP Compression done successfully");
        }

        [Fact]
        public void ArchiveByCompressing() {

            var compressionStrategy = new Mock<ICompressionStrategy>();
            compressionStrategy.Setup(c => c.Compress()).Returns("Compression Done Successfully");
           
            ICompressionContext compressionContext = new CompressionContext(compressionStrategy.Object);
            compressionContext.CreateArchive();

            compressionStrategy.Verify(c => c.Compress());
        }

        [Fact]
        public void ClientCanArquive() {

           var compreensionContext = new Mock<ICompressionContext>();
            compreensionContext.Setup(c => c.CreateArchive());

            var client = Client.NewClient(compreensionContext.Object);
            client.ArquiveFile();

            compreensionContext.Verify(c => c.CreateArchive());
        }
     }
}
