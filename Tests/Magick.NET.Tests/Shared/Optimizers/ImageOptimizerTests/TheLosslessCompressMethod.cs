﻿using System.IO;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests.Shared.Optimizers.ImageOptimizerTests
{
    public partial class ImageOptimizerTests
    {
        public class TheLosslessCompressMethod
        {
            [TestClass]
            public class WithFile : ImageOptimizerTestHelper
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenFileIsNull()
                {
                    var optimizer = new ImageOptimizer();
                    ExceptionAssert.ThrowsArgumentNullException("file", () =>
                    {
                        optimizer.LosslessCompress((FileInfo)null);
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenFileIsEmpty()
                {
                    var optimizer = new ImageOptimizer();
                    using (TemporaryFile file = new TemporaryFile("empty"))
                    {
                        ExceptionAssert.Throws<MagickMissingDelegateErrorException>(() =>
                        {
                            optimizer.LosslessCompress(file);
                        });
                    }
                }

                [TestMethod]
                public void ShouldMakeFileSmallerWhenFileIsCompressibleGifFile()
                {
                    var optimizer = new ImageOptimizer();
                    AssertCompress(Files.FujiFilmFinePixS1ProGIF, true, (FileInfo file) =>
                    {
                        return optimizer.LosslessCompress(file);
                    });
                }

                [TestMethod]
                public void ShouldNotMakeFileSmallerWhenFileIsUnCompressibleGifFile()
                {
                    var optimizer = new ImageOptimizer();
                    AssertCompress(Files.RoseSparkleGIF, false, (FileInfo file) =>
                    {
                        return optimizer.LosslessCompress(file);
                    });
                }
            }

            [TestClass]
            public class WithFileName : ImageOptimizerTestHelper
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenFileNameIsNull()
                {
                    var optimizer = new ImageOptimizer();
                    ExceptionAssert.ThrowsArgumentNullException("fileName", () =>
                    {
                        optimizer.LosslessCompress((string)null);
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenFileNameIsEmpty()
                {
                    var optimizer = new ImageOptimizer();
                    ExceptionAssert.ThrowsArgumentException("fileName", () =>
                    {
                        optimizer.LosslessCompress(string.Empty);
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenFileNameIsInvalid()
                {
                    var optimizer = new ImageOptimizer();
                    ExceptionAssert.Throws<MagickBlobErrorException>(() =>
                    {
                        optimizer.LosslessCompress(Files.Missing);
                    }, "error/blob.c/OpenBlob");
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenFileIsUnsupportedFormat()
                {
                    var optimizer = new ImageOptimizer();
                    ExceptionAssert.Throws<MagickCorruptImageErrorException>(() =>
                    {
                        optimizer.LosslessCompress(Files.InvitationTif);
                    }, "Invalid format");
                }

                [TestMethod]
                public void ShouldMakeFileSmallerWhenFileNameIsCompressibleJpgFile()
                {
                    var optimizer = new ImageOptimizer();
                    AssertCompress(Files.ImageMagickJPG, true, (string file) =>
                    {
                        return optimizer.LosslessCompress(file);
                    });
                }

                [TestMethod]
                public void ShouldNotMakeFileSmallerWhenFileNameIsUncompressiblePngFile()
                {
                    var optimizer = new ImageOptimizer();
                    AssertCompress(Files.MagickNETIconPNG, false, (string file) =>
                    {
                        return optimizer.LosslessCompress(file);
                    });
                }

                [TestMethod]
                public void ShouldNotThrowExceptionWhenIgnoringUnsupportedFileName()
                {
                    var optimizer = new ImageOptimizer { IgnoreUnsupportedFormats = true };
                    var compressionSuccess = optimizer.LosslessCompress(Files.InvitationTif);
                    Assert.IsFalse(compressionSuccess);
                }
            }

            [TestClass]
            public class WithStream : ImageOptimizerTestHelper
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenStreamIsNull()
                {
                    var optimizer = new ImageOptimizer();
                    ExceptionAssert.ThrowsArgumentNullException("stream", () =>
                    {
                        optimizer.LosslessCompress((Stream)null);
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenStreamCannotRead()
                {
                    var optimizer = new ImageOptimizer();
                    using (TestStream stream = new TestStream(false, true, true))
                    {
                        ExceptionAssert.ThrowsArgumentException("stream", () =>
                        {
                            optimizer.LosslessCompress(stream);
                        });
                    }
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenStreamCannotWrite()
                {
                    var optimizer = new ImageOptimizer();
                    using (TestStream stream = new TestStream(true, false, true))
                    {
                        ExceptionAssert.ThrowsArgumentException("stream", () =>
                        {
                            optimizer.LosslessCompress(stream);
                        });
                    }
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenStreamCannotSeek()
                {
                    var optimizer = new ImageOptimizer();
                    using (TestStream stream = new TestStream(true, true, false))
                    {
                        ExceptionAssert.ThrowsArgumentException("stream", () =>
                        {
                            optimizer.LosslessCompress(stream);
                        });
                    }
                }

                [TestMethod]
                public void ShouldMakeFileSmallerWhenStreamIsCompressiblePngFile()
                {
                    var optimizer = new ImageOptimizer();
                    AssertCompress(Files.SnakewarePNG, true, (Stream file) =>
                    {
                        return optimizer.LosslessCompress(file);
                    });
                }

                [TestMethod]
                public void ShouldNotMakeFileSmallerWhenStreamIsCompressibleJpgFile()
                {
                    var optimizer = new ImageOptimizer();
                    AssertCompress(Files.LetterJPG, false, (Stream file) =>
                    {
                        return optimizer.LosslessCompress(file);
                    });
                }

                [TestMethod]
                public void ShouldNotThrowExceptionWhenIgnoringUnsupportedStream()
                {
                    var optimizer = new ImageOptimizer { IgnoreUnsupportedFormats = true };
                    using (FileStream fileStream = OpenFile(Files.InvitationTif))
                    {
                        var compressionSuccess = optimizer.LosslessCompress(fileStream);
                        Assert.IsFalse(compressionSuccess);
                    }
                }
            }
        }
    }
}