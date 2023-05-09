﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.IO;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests;

public partial class MagickImageTests
{
    public class TheColorTypeProperty
    {
        [Fact]
        public void ShouldReturnTheCorrectColorType()
        {
            using (var image = new MagickImage(Files.WireframeTIF))
            {
                Assert.Equal(ColorType.TrueColor, image.ColorType);
            }
        }

        [Fact]
        public void ShouldReturnTheCorrectColorTypeWhenThisWasChanged()
        {
            using (var image = new MagickImage(Files.WireframeTIF))
            {
                using (var memStream = new MemoryStream())
                {
                    image.Write(memStream);
                    memStream.Position = 0;

                    using (var result = new MagickImage(memStream))
                    {
                        Assert.Equal(ColorType.Grayscale, result.ColorType);
                    }
                }
            }
        }
    }
}
