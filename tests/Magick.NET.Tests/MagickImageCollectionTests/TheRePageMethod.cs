﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests;

public partial class MagickImageCollectionTests
{
    public class TheRePageMethod
    {
        [Fact]
        public void ShouldResetThePagePropertyOfAllTheImages()
        {
            using (var images = new MagickImageCollection(Files.RoseSparkleGIF))
            {
                images[0].Page = new MagickGeometry("0x0+10+20");
                images[1].Page = new MagickGeometry("0x0+30+40");
                images[2].Page = new MagickGeometry("0x0+50+60");

                Assert.Equal(10, images[0].Page.X);
                Assert.Equal(20, images[0].Page.Y);
                Assert.Equal(30, images[1].Page.X);
                Assert.Equal(40, images[1].Page.Y);
                Assert.Equal(50, images[2].Page.X);
                Assert.Equal(60, images[2].Page.Y);

                images.RePage();

                Assert.Equal(0, images[0].Page.X);
                Assert.Equal(0, images[0].Page.Y);
                Assert.Equal(0, images[1].Page.X);
                Assert.Equal(0, images[1].Page.Y);
                Assert.Equal(0, images[2].Page.X);
                Assert.Equal(0, images[2].Page.Y);
            }
        }

        [Fact]
        public void ShouldNotChangeThePageSettings()
        {
            using (var images = new MagickImageCollection())
            {
                images.Add(new MagickImage(MagickColors.Purple, 1, 1));

                images[0].Page = new MagickGeometry("0x0+10+20");
                images[0].Settings.Page = new MagickGeometry("0x0+10+20");

                images.RePage();

                Assert.Equal(0, images[0].Page.X);
                Assert.Equal(0, images[0].Page.Y);

                Assert.Equal(10, images[0].Settings.Page.X);
                Assert.Equal(20, images[0].Settings.Page.Y);
            }
        }
    }
}
