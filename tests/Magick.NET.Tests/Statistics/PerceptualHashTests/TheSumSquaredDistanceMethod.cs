﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests;

public partial class PerceptualHashTests
{
    public class TheSumSquaredDistanceMethod
    {
        [Fact]
        public void ShouldReturnTheDifference()
        {
            using var image = new MagickImage(Files.ImageMagickJPG);
            var phash = image.PerceptualHash();

            using var other = new MagickImage(Files.MagickNETIconPNG);
            other.HasAlpha = false;

            Assert.Equal(3, other.ChannelCount);

            var otherPhash = other.PerceptualHash();

#if Q8
            OpenCLValue.Assert(394.74, 394.90, phash.SumSquaredDistance(otherPhash), 0.01);
#elif Q16
            OpenCLValue.Assert(395.35, 395.39, phash.SumSquaredDistance(otherPhash), 0.02);
#else
            OpenCLValue.Assert(395.60, 395.68, phash.SumSquaredDistance(otherPhash), 0.02);
#endif
        }
    }
}
