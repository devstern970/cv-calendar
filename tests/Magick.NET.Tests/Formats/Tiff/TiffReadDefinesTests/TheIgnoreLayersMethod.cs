﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using ImageMagick.Formats;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class TiffReadDefinesTests
    {
        public class TheIgnoreLayersMethod
        {
            [Fact]
            public void ShouldSetTheDefine()
            {
                using (var image = new MagickImage())
                {
                    image.Settings.SetDefines(new TiffReadDefines
                    {
                        IgnoreLayers = true,
                    });

                    Assert.Equal("true", image.Settings.GetDefine(MagickFormat.Tiff, "ignore-layers"));
                }
            }
        }
    }
}
