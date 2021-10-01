﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class DrawableAffineTests
    {
        public class TheResetMethod
        {
            [Fact]
            public void ShouldSetThePropertiesToTheDefaultValue()
            {
                var affine = new DrawableAffine();

                affine.ScaleX = 2.0;
                affine.ScaleY = 3.0;
                affine.ShearX = 4.0;
                affine.ShearY = 5.0;
                affine.TranslateX = 6.0;
                affine.TranslateY = 7.0;

                affine.Reset();

                Assert.Equal(1.0, affine.ScaleX);
                Assert.Equal(1.0, affine.ScaleY);
                Assert.Equal(0.0, affine.ShearX);
                Assert.Equal(0.0, affine.ShearY);
                Assert.Equal(0.0, affine.TranslateX);
                Assert.Equal(0.0, affine.TranslateY);
            }
        }
    }
}
