﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class DrawableStrokeAntialiasTests
    {
        public class TheEnabledProperty
        {
            [Fact]
            public void ShouldReturnDrawableStrokeAntialiasThatIsEnabled()
            {
                var result = DrawableStrokeAntialias.Enabled;

                Assert.True(result.IsEnabled);
            }
        }
    }
}
