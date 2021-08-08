﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if NETCORE

using System;
using System.IO;
using System.Threading.Tasks;
using ImageMagick;
using ImageMagick.Formats;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        public partial class TheWriteAsyncMethod
        {
            public class WithFileInfo
            {
                [Fact]
                public async Task ShouldThrowExceptionWhenFileIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        await Assert.ThrowsAsync<ArgumentNullException>("file", () => image.WriteAsync((FileInfo)null));
                    }
                }

                [Fact]
                public async Task ShouldUseTheFileExtension()
                {
                    var readSettings = new MagickReadSettings
                    {
                        Format = MagickFormat.Png,
                    };

                    using (var input = new MagickImage(Files.CirclePNG, readSettings))
                    {
                        using (var tempFile = new TemporaryFile(".jpg"))
                        {
                            await input.WriteAsync(tempFile.FileInfo);

                            using (var output = new MagickImage(tempFile.FileInfo))
                            {
                                Assert.Equal(MagickFormat.Jpeg, output.Format);
                            }
                        }
                    }
                }
            }

            public class WithFileInfoAndMagickFormat
            {
                [Fact]
                public async Task ShouldThrowExceptionWhenFileIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        await Assert.ThrowsAsync<ArgumentNullException>("file", () => image.WriteAsync((FileInfo)null, MagickFormat.Bmp));
                    }
                }

                [Fact]
                public async Task ShouldUseTheSpecifiedFormat()
                {
                    using (var input = new MagickImage(Files.CirclePNG))
                    {
                        using (var tempfile = new TemporaryFile("foobar"))
                        {
                            await input.WriteAsync(tempfile.FileInfo, MagickFormat.Tiff);
                            Assert.Equal(MagickFormat.Png, input.Format);

                            using (var output = new MagickImage(tempfile.FileInfo))
                            {
                                Assert.Equal(MagickFormat.Tiff, output.Format);
                            }
                        }
                    }
                }
            }

            public class WithFileInfoAndWriteDefines
            {
                [Fact]
                public async Task ShouldThrowExceptionWhenFileIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        var defines = new JpegWriteDefines();

                        await Assert.ThrowsAsync<ArgumentNullException>("file", () => image.WriteAsync((FileInfo)null, defines));
                    }
                }

                [Fact]
                public async Task ShouldThrowExceptionWhenWriteDefinesIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        var file = new FileInfo(Files.CirclePNG);
                        await Assert.ThrowsAsync<ArgumentNullException>("defines", () => image.WriteAsync(file, null));
                    }
                }

                [Fact]
                public async Task ShouldUseTheSpecifiedFormat()
                {
                    using (var input = new MagickImage(Files.CirclePNG))
                    {
                        using (var tempfile = new TemporaryFile("foobar"))
                        {
                            var defines = new JpegWriteDefines
                            {
                                DctMethod = JpegDctMethod.Fast,
                            };

                            await input.WriteAsync(tempfile.FileInfo, defines);
                            Assert.Equal(MagickFormat.Png, input.Format);

                            using (var output = new MagickImage())
                            {
                                await output.ReadAsync(tempfile.FileInfo);

                                Assert.Equal(MagickFormat.Jpeg, output.Format);
                            }
                        }
                    }
                }
            }

            public class WithFileName
            {
                [Fact]
                public async Task ShouldThrowExceptionWhenFileIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        await Assert.ThrowsAsync<ArgumentNullException>("fileName", () => image.WriteAsync((string)null));
                    }
                }

                [Fact]
                public async Task ShouldSyncTheExifProfile()
                {
                    using (var input = new MagickImage(Files.FujiFilmFinePixS1ProPNG))
                    {
                        Assert.Equal(OrientationType.TopLeft, input.Orientation);

                        input.Orientation = OrientationType.RightTop;

                        using (var memStream = new MemoryStream())
                        {
                            await input.WriteAsync(memStream);

                            using (var output = new MagickImage(Files.FujiFilmFinePixS1ProPNG))
                            {
                                memStream.Position = 0;
                                await output.ReadAsync(memStream);

                                Assert.Equal(OrientationType.RightTop, output.Orientation);

                                var profile = output.GetExifProfile();

                                Assert.NotNull(profile);
                                var exifValue = profile.GetValue(ExifTag.Orientation);

                                Assert.NotNull(exifValue);
                                Assert.Equal((ushort)6, exifValue.Value);
                            }
                        }
                    }
                }
            }

            public class WithFileNameAndMagickFormat
            {
                [Fact]
                public async Task ShouldThrowExceptionWhenFileIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        await Assert.ThrowsAsync<ArgumentNullException>("fileName", () => image.WriteAsync((string)null, MagickFormat.Bmp));
                    }
                }

                [Fact]
                public async Task ShouldUseTheSpecifiedFormat()
                {
                    using (var input = new MagickImage(Files.CirclePNG))
                    {
                        using (var tempfile = new TemporaryFile("foobar"))
                        {
                            await input.WriteAsync(tempfile.FullName, MagickFormat.Tiff);
                            Assert.Equal(MagickFormat.Png, input.Format);

                            using (var output = new MagickImage(tempfile.FullName))
                            {
                                Assert.Equal(MagickFormat.Tiff, output.Format);
                            }
                        }
                    }
                }
            }

            public class WithFileNameAndWriteDefines
            {
                [Fact]
                public async Task ShouldThrowExceptionWhenFileNameIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        var defines = new JpegWriteDefines();

                        await Assert.ThrowsAsync<ArgumentNullException>("fileName", () => image.WriteAsync((string)null, defines));
                    }
                }

                [Fact]
                public async Task ShouldThrowExceptionWhenWriteDefinesIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        var file = new FileInfo(Files.CirclePNG);
                        await Assert.ThrowsAsync<ArgumentNullException>("defines", () => image.WriteAsync(file, null));
                    }
                }

                [Fact]
                public async Task ShouldUseTheSpecifiedFormat()
                {
                    using (var input = new MagickImage(Files.CirclePNG))
                    {
                        using (var tempfile = new TemporaryFile("foobar"))
                        {
                            var defines = new JpegWriteDefines
                            {
                                DctMethod = JpegDctMethod.Fast,
                            };

                            await input.WriteAsync(tempfile.FullName, defines);
                            Assert.Equal(MagickFormat.Png, input.Format);

                            using (var output = new MagickImage())
                            {
                                await output.ReadAsync(tempfile.FullName);

                                Assert.Equal(MagickFormat.Jpeg, output.Format);
                            }
                        }
                    }
                }
            }
        }
    }
}
#endif
