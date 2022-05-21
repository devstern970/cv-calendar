﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageCollectionTests
    {
        public class TheSmushHorizontalMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenCollectionIsEmpty()
            {
                using (var images = new MagickImageCollection())
                {
                    Assert.Throws<InvalidOperationException>(() => images.SmushHorizontal(1));
                }
            }

            [Fact]
            public void ShouldSmushTheImagesHorizontally()
            {
                using (var images = new MagickImageCollection())
                {
                    images.AddRange(Files.RoseSparkleGIF);

                    using (var image = images.SmushHorizontal(20))
                    {
                        Assert.Equal((70 * 3) + (20 * 2), image.Width);
                        Assert.Equal(46, image.Height);
                    }
                }
            }
        }
    }
}
