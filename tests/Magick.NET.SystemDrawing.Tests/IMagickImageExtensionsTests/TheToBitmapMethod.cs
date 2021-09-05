﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using ImageMagick;
using Xunit;

namespace Magick.NET.SystemDrawing.Tests
{
    public partial class IMagickImageExtensionsTests
    {
        public class TheToBitmapMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenImageFormatIsExif()
            {
                AssertUnsupportedImageFormat(ImageFormat.Exif);
            }

            [Fact]
            public void ShouldThrowExceptionWhenImageFormatIsEmf()
            {
                AssertUnsupportedImageFormat(ImageFormat.Emf);
            }

            [Fact]
            public void ShouldThrowExceptionWhenImageFormatIsWmf()
            {
                AssertUnsupportedImageFormat(ImageFormat.Wmf);
            }

            [Fact]
            public void ShouldReturnBitmapWhenFormatIsBmp()
            {
                AssertSupportedImageFormat(ImageFormat.Bmp);
            }

            [Fact]
            public void ShouldReturnBitmapWhenFormatIsGif()
            {
                AssertSupportedImageFormat(ImageFormat.Gif);
            }

            [Fact]
            public void ShouldReturnBitmapWhenFormatIsIcon()
            {
                AssertSupportedImageFormat(ImageFormat.Icon);
            }

            [Fact]
            public void ShouldReturnBitmapWhenFormatIsJpeg()
            {
                AssertSupportedImageFormat(ImageFormat.Jpeg);
            }

            [Fact]
            public void ShouldReturnBitmapWhenFormatIsPng()
            {
                AssertSupportedImageFormat(ImageFormat.Png);
            }

            [Fact]
            public void ShouldReturnBitmapWhenFormatIsTiff()
            {
                AssertSupportedImageFormat(ImageFormat.Tiff);
            }

            [Fact]
            public void ShouldChangeTheColorSpaceToSrgb()
            {
                using (var image = new MagickImage(ToMagickColor(Color.Red), 1, 1))
                {
                    image.ColorSpace = ColorSpace.YCbCr;

                    using (var bitmap = image.ToBitmap())
                    {
                        ColorAssert.Equal(MagickColors.Red, ToMagickColor(bitmap.GetPixel(0, 0)));
                    }

                    Assert.Equal(ColorSpace.YCbCr, image.ColorSpace);
                }
            }

            [Fact]
            public void ShouldBeAbleToConvertGrayImage()
            {
                using (var image = new MagickImage(ToMagickColor(Color.Magenta), 5, 1))
                {
                    image.ColorType = ColorType.Bilevel;
                    image.ClassType = ClassType.Direct;

                    Assert.Equal(ColorSpace.Gray, image.ColorSpace);

                    using (var bitmap = image.ToBitmap())
                    {
#if Q8
                        var expected = new MagickColor("#494949ff");
#else
                        var expected = MagickColors.Black;
#endif
                        for (var i = 0; i < image.Width; i++)
                            ColorAssert.Equal(expected, ToMagickColor(bitmap.GetPixel(i, 0)));
                    }
                }
            }

            [Fact]
            public void ShouldBeAbleToConvertRgbImage()
            {
                using (var image = new MagickImage(ToMagickColor(Color.Magenta), 5, 1))
                {
                    using (var bitmap = image.ToBitmap())
                    {
                        for (var i = 0; i < image.Width; i++)
                            ColorAssert.Equal(MagickColors.Magenta, ToMagickColor(bitmap.GetPixel(i, 0)));
                    }
                }
            }

            [Fact]
            public void ShouldBeAbleToConvertRgbaImage()
            {
                using (var image = new MagickImage(ToMagickColor(Color.Magenta), 5, 1))
                {
                    image.Alpha(AlphaOption.On);

                    using (var bitmap = image.ToBitmap())
                    {
                        var color = MagickColors.Magenta;
                        color.A = Quantum.Max;

                        for (var i = 0; i < image.Width; i++)
                            ColorAssert.Equal(color, ToMagickColor(bitmap.GetPixel(i, 0)));
                    }
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenImageFormatIsNull()
            {
                using (var image = new MagickImage(ToMagickColor(Color.Red), 1, 1))
                {
                    Assert.Throws<ArgumentNullException>("imageFormat", () => image.ToBitmapWithDensity(null));
                }
            }

            private void AssertUnsupportedImageFormat(ImageFormat imageFormat)
            {
                using (var image = new MagickImage(MagickColors.Red, 10, 10))
                {
                    Assert.Throws<NotSupportedException>(() =>
                    {
                        image.ToBitmap(imageFormat);
                    });
                }
            }

            private void AssertSupportedImageFormat(ImageFormat imageFormat)
            {
                using (var image = new MagickImage(MagickColors.Red, 10, 10))
                {
                    using (var bitmap = image.ToBitmap(imageFormat))
                    {
                        Assert.Equal(imageFormat, bitmap.RawFormat);

                        // Cannot test JPEG due to rounding issues.
                        if (imageFormat != ImageFormat.Jpeg)
                        {
                            ColorAssert.Equal(MagickColors.Red, ToMagickColor(bitmap.GetPixel(0, 0)));
                            ColorAssert.Equal(MagickColors.Red, ToMagickColor(bitmap.GetPixel(5, 5)));
                            ColorAssert.Equal(MagickColors.Red, ToMagickColor(bitmap.GetPixel(9, 9)));
                        }
                    }
                }
            }

            private MagickColor ToMagickColor(Color color)
            {
                var result = new MagickColor();
                result.SetFromColor(color);
                return result;
            }
        }
    }
}
