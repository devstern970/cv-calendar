﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Drawing.Imaging;
using ImageMagick;
using Xunit;

namespace Magick.NET.SystemDrawing.Tests;

public partial class ImageFormatExtensionsTests
{
    public class TheToFormatMethod
    {
        [Fact]
        public void ShouldReturnTheCorrectMagickFormatForBmp()
        {
            var format = ImageFormat.Bmp.ToFormat();
            Assert.Equal(MagickFormat.Bmp, format);
        }

        [Fact]
        public void ShouldReturnTheCorrectMagickFormatForMemoryBmp()
        {
            var format = ImageFormat.MemoryBmp.ToFormat();
            Assert.Equal(MagickFormat.Bmp, format);
        }

        [Fact]
        public void ShouldReturnTheCorrectMagickFormatForGif()
        {
            var format = ImageFormat.Gif.ToFormat();
            Assert.Equal(MagickFormat.Gif, format);
        }

        [Fact]
        public void ShouldReturnTheCorrectMagickFormatForIcon()
        {
            var format = ImageFormat.Icon.ToFormat();
            Assert.Equal(MagickFormat.Icon, format);
        }

        [Fact]
        public void ShouldReturnTheCorrectMagickFormatForJpeg()
        {
            var format = ImageFormat.Jpeg.ToFormat();
            Assert.Equal(MagickFormat.Jpeg, format);
        }

        [Fact]
        public void ShouldReturnTheCorrectMagickFormatForPng()
        {
            var format = ImageFormat.Png.ToFormat();
            Assert.Equal(MagickFormat.Png, format);
        }

        [Fact]
        public void ShouldReturnTheCorrectMagickFormatForTiff()
        {
            var format = ImageFormat.Tiff.ToFormat();
            Assert.Equal(MagickFormat.Tiff, format);
        }
    }
}
