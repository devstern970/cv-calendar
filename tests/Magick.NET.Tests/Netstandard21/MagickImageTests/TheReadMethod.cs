﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if NETCORE

using System;
using System.IO;
using System.Text;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        public partial class TheReadMethod
        {
            public class WithSpan
            {
                [Fact]
                public void ShouldThrowExceptionWhenSpanIsEmpty()
                {
                    using (var image = new MagickImage())
                    {
                        Assert.Throws<ArgumentException>("data", () => image.Read(Span<byte>.Empty));
                    }
                }

                [Fact]
                public void ShouldReadImage()
                {
                    using (var image = new MagickImage())
                    {
                        var bytes = FileHelper.ReadAllBytes(Files.SnakewarePNG);
                        image.Read(new Span<byte>(bytes));
                        Assert.Equal(286, image.Width);
                        Assert.Equal(67, image.Height);
                    }
                }
            }

            public class WithSpanAndMagickFormat
            {
                [Fact]
                public void ShouldThrowExceptionWhenSpanIsEmpty()
                {
                    using (var image = new MagickImage())
                    {
                        Assert.Throws<ArgumentException>("data", () => image.Read(Span<byte>.Empty, MagickFormat.Png));
                    }
                }

                [Fact]
                public void ShouldUseTheCorrectReaderWhenFormatIsSet()
                {
                    var bytes = Encoding.ASCII.GetBytes("%PDF-");

                    using (var image = new MagickImage())
                    {
                        var exception = Assert.Throws<MagickCorruptImageErrorException>(() =>
                        {
                            image.Read(new Span<byte>(bytes), MagickFormat.Png);
                        });

                        Assert.Contains("ReadPNGImage", exception.Message);
                    }
                }

                [Fact]
                public void ShouldResetTheFormatAfterReadingBytes()
                {
                    var bytes = FileHelper.ReadAllBytes(Files.CirclePNG);

                    using (var image = new MagickImage())
                    {
                        image.Read(new Span<byte>(bytes), MagickFormat.Png);

                        Assert.Equal(MagickFormat.Unknown, image.Settings.Format);
                    }
                }
            }

            public class WithSpanAndMagickReadSettings
            {
                [Fact]
                public void ShouldThrowExceptionWhenSpanIsEmpty()
                {
                    var settings = new MagickReadSettings();

                    using (var image = new MagickImage())
                    {
                        Assert.Throws<ArgumentException>("data", () => image.Read(Span<byte>.Empty, settings));
                    }
                }

                [Fact]
                public void ShouldNotThrowExceptionWhenSettingsIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        var bytes = FileHelper.ReadAllBytes(Files.CirclePNG);
                        image.Read(new Span<byte>(bytes), null);
                    }
                }

                [Fact]
                public void ShouldUseTheCorrectReaderWhenFormatIsSet()
                {
                    var bytes = Encoding.ASCII.GetBytes("%PDF-");
                    var settings = new MagickReadSettings
                    {
                        Format = MagickFormat.Png,
                    };

                    using (var image = new MagickImage())
                    {
                        var exception = Assert.Throws<MagickCorruptImageErrorException>(() => image.Read(new Span<byte>(bytes), settings));

                        Assert.Contains("ReadPNGImage", exception.Message);
                    }
                }

                [Fact]
                public void ShouldResetTheFormatAfterReadingBytes()
                {
                    var readSettings = new MagickReadSettings
                    {
                        Format = MagickFormat.Png,
                    };

                    var bytes = FileHelper.ReadAllBytes(Files.CirclePNG);

                    using (var image = new MagickImage())
                    {
                        image.Read(new Span<byte>(bytes), readSettings);

                        Assert.Equal(MagickFormat.Unknown, image.Settings.Format);
                    }
                }
            }

            public partial class WithStream
            {
                [Fact]
                public void ShouldReadImageFromMemoryStreamWhereBufferIsPubliclyVisible()
                {
                    var data = FileHelper.ReadAllBytes(Files.CirclePNG);
                    var testBuffer = new byte[data.Length + 10];
                    data.CopyTo(testBuffer, index: 10);

                    using (var stream = new MemoryStream(testBuffer, index: 10, count: testBuffer.Length - 10, false, true))
                    {
                        using (var image = new MagickImage())
                        {
                            image.Read(stream);
                        }
                    }
                }
            }
        }
    }
}

#endif
