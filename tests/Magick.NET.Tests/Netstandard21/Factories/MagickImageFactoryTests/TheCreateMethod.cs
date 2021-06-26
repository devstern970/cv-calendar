﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if NETCORE

using System;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageFactoryTests
    {
        public partial class TheCreateMethod
        {
            public class WithSpan
            {
                [Fact]
                public void ShouldThrowExceptionWhenSpanIsEmpty()
                {
                    var factory = new MagickImageFactory();

                    Assert.Throws<ArgumentException>("data", () => factory.Create(Span<byte>.Empty));
                }

                [Fact]
                public void ShouldCreateMagickImage()
                {
                    var factory = new MagickImageFactory();
                    var data = FileHelper.ReadAllBytes(Files.ImageMagickJPG);

                    using (var image = factory.Create(new Span<byte>(data)))
                    {
                        Assert.IsType<MagickImage>(image);
                        Assert.Equal(123, image.Width);
                    }
                }
            }

            public class WithByteSpanAndMagickReadSettings
            {
                [Fact]
                public void ShouldThrowExceptionWhenSpanIsEmpty()
                {
                    var factory = new MagickImageFactory();
                    var settings = new MagickReadSettings();

                    Assert.Throws<ArgumentException>("data", () => factory.Create(Span<byte>.Empty, settings));
                }

                [Fact]
                public void ShouldNotThrowExceptionWhenSettingsIsNull()
                {
                    var factory = new MagickImageFactory();

                    var bytes = FileHelper.ReadAllBytes(Files.CirclePNG);
                    using (var image = factory.Create(new Span<byte>(bytes), (MagickReadSettings)null))
                    {
                    }
                }

                [Fact]
                public void ShouldCreateMagickImage()
                {
                    var factory = new MagickImageFactory();
                    var data = FileHelper.ReadAllBytes(Files.ImageMagickJPG);
                    var readSettings = new MagickReadSettings
                    {
                        BackgroundColor = MagickColors.Goldenrod,
                    };

                    using (var image = factory.Create(new Span<byte>(data), readSettings))
                    {
                        Assert.IsType<MagickImage>(image);
                        Assert.Equal(123, image.Width);
                        Assert.Equal(MagickColors.Goldenrod, image.Settings.BackgroundColor);
                    }
                }
            }

            public class WithByteSpanAndPixelReadSettings
            {
                [Fact]
                public void ShouldThrowExceptionWhenSpanIsEmpty()
                {
                    var factory = new MagickImageFactory();
                    var settings = new PixelReadSettings();

                    Assert.Throws<ArgumentException>("data", () => factory.Create(Span<byte>.Empty, settings));
                }

                [Fact]
                public void ShouldThrowExceptionWhenSettingsIsNull()
                {
                    var factory = new MagickImageFactory();

                    var bytes = FileHelper.ReadAllBytes(Files.CirclePNG);
                    Assert.Throws<ArgumentNullException>("settings", () => factory.Create(new Span<byte>(bytes), (PixelReadSettings)null));
                }

                [Fact]
                public void ShouldCreateMagickImage()
                {
                    var factory = new MagickImageFactory();
                    var data = new byte[]
                    {
                        0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0xf0, 0x3f,
                        0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0xf0, 0x3f,
                        0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0, 0,
                    };

                    var settings = new PixelReadSettings(2, 1, StorageType.Double, PixelMapping.RGBA);

                    using (var image = factory.Create(new Span<byte>(data), settings))
                    {
                        Assert.IsType<MagickImage>(image);
                        Assert.Equal(2, image.Width);
                    }
                }
            }
        }
    }
}

#endif
