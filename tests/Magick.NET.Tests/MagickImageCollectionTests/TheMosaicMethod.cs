﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageCollectionTests
    {
        public class TheMosaicMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenCollectionIsEmpty()
            {
                using (var images = new MagickImageCollection())
                {
                    Assert.Throws<InvalidOperationException>(() => images.Mosaic());
                }
            }

            [Fact]
            public void ShouldMergeTheImages()
            {
                using (var images = new MagickImageCollection())
                {
                    images.Add(Files.SnakewarePNG);
                    images.Add(Files.ImageMagickJPG);

                    using (var mosaic = images.Mosaic())
                    {
                        Assert.Equal(286, mosaic.Width);
                        Assert.Equal(118, mosaic.Height);
                    }
                }
            }
        }
    }
}
