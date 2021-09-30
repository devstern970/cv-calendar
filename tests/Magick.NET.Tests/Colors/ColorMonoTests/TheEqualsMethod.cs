﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class ColorMonoTests
    {
        public class TheEqualsMethod
        {
            [Fact]
            public void ShouldReturnFalseWhenOtherIsNull()
            {
                var color = new ColorMono(true);

                Assert.False(color.Equals(null));
            }

            [Fact]
            public void ShouldReturnFalseWhenOtherAsObjectIsNull()
            {
                var color = new ColorMono(true);

                Assert.False(color.Equals((object)null));
            }

            [Fact]
            public void ShouldReturnTrueWhenOtherIsEqual()
            {
                var color = new ColorMono(false);
                var other = new ColorMono(false);

                Assert.True(color.Equals(other));
            }

            [Fact]
            public void ShouldReturnTrueWhenOtherAsObjectIsEqual()
            {
                var color = new ColorMono(false);
                var other = new ColorMono(false);

                Assert.True(color.Equals((object)other));
            }

            [Fact]
            public void ShouldReturnFalseWhenOtherIsNotEqual()
            {
                var color = new ColorMono(true);
                var other = new ColorMono(false);

                Assert.False(color.Equals(other));
            }

            [Fact]
            public void ShouldReturnFalseWhenOtherAsObjectIsNotEqual()
            {
                var color = new ColorMono(true);
                var other = new ColorMono(false);

                Assert.False(color.Equals((object)other));
            }
        }
    }
}
