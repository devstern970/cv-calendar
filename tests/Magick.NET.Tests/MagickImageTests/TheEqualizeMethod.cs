﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        public class TheEqualizeMethod
        {
            [Fact]
            public void ShouldApplyHistogramEqualizationToTheImage()
            {
                using (var image = new MagickImage(Files.SnakewarePNG))
                {
                    image.Equalize();

                    ColorAssert.Equal(MagickColors.White, image, 105, 25);
                    ColorAssert.Equal(new MagickColor("#0000"), image, 105, 60);
                }
            }
        }
    }
}
