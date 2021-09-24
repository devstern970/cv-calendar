﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class EnumHelperTests
    {
        public class TheConvertFlagsMethod
        {
            [Fact]
            public void ShouldReturnTheNamesOfTheFlags()
            {
                var blueRed = Channels.Blue | Channels.Red;

                var result = EnumHelper.ConvertFlags(blueRed);

                Assert.Equal("None,Red,Yellow", result);
            }
        }
    }
}
