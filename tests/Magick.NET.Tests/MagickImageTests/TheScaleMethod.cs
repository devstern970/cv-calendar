﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        public class TheScaleMethod
        {

            [Fact]
            public void ShouldThrowExceptionWhenGeometryIsNull()
            {
                using (var image = new MagickImage())
                {
                    Assert.Throws<ArgumentNullException>("geometry", () => image.Scale(null));
                }
            }

            [Fact]
            public void ShouldResizeTheImage()
            {
                using (var image = new MagickImage(Files.Builtin.Logo))
                {
                    image.Scale(400, 400);
                    Assert.Equal(400, image.Width);
                    Assert.Equal(300, image.Height);
                }
            }

            [Fact]
            public void ShouldUseTheSpecifiedGeometry()
            {
                using (var image = new MagickImage(Files.Builtin.Logo))
                {
                    image.Scale(new MagickGeometry(300, 300));
                    Assert.Equal(300, image.Width);
                    Assert.Equal(225, image.Height);
                }
            }

            [Fact]
            public void ShouldUseTheSpecifiedPercentage()
            {
                using (var image = new MagickImage(Files.Builtin.Logo))
                {
                    image.Scale(new Percentage(50));
                    Assert.Equal(320, image.Width);
                    Assert.Equal(240, image.Height);
                }
            }

            [Fact]
            public void ShouldUseSimpleResizeAlgorithm()
            {
                using (var image = new MagickImage(Files.CirclePNG))
                {
                    var color = MagickColor.FromRgba(255, 255, 255, 159);
                    ColorAssert.Equal(color, image, image.Width / 2, image.Height / 2);

                    image.Scale((Percentage)400);
                    ColorAssert.Equal(color, image, image.Width / 2, image.Height / 2);
                }
            }
        }
    }
}
