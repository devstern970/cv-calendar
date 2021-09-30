﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class ColorMonoTests
    {
        public class TheGetHashCodeMethod
        {
            [Fact]
            public void ShouldReturnDifferentValueWhenChannelChanged()
            {
                var first = new ColorMono(true);
                var hashCode = first.GetHashCode();

                first.IsBlack = false;
                Assert.NotEqual(hashCode, first.GetHashCode());
            }
        }
    }
}
