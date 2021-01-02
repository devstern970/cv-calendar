﻿// Copyright 2013-2021 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public class TheRgbCoder
    {
#if Q8
        private readonly byte[] _bytes = new byte[] { 1, 2, 3, 4 };
#else
        private readonly byte[] _bytes = new byte[] { 1, 0, 2, 0, 3, 0, 4, 0 };
#endif

        private readonly MagickReadSettings _settings = new MagickReadSettings
        {
            Width = 1,
            Height = 1,
        };

        [Fact]
        public void ShouldSetTheCorrectValueForTheAlphaChannel()
        {
            _settings.Format = MagickFormat.Rgba;
            using (var image = new MagickImage(_bytes, _settings))
            {
                using (var pixels = image.GetPixels())
                {
                    var pixel = pixels.GetPixel(0, 0);
                    Assert.Equal(4, pixel.Channels);
                    Assert.Equal(1, pixel.GetChannel(0));
                    Assert.Equal(2, pixel.GetChannel(1));
                    Assert.Equal(3, pixel.GetChannel(2));
                    Assert.Equal(4, pixel.GetChannel(3));
                }
            }
        }

        [Fact]
        public void ShouldSetTheCorrectValueForTheOpacityChannel()
        {
            _settings.Format = MagickFormat.Rgbo;
            using (var image = new MagickImage(_bytes, _settings))
            {
                using (var pixels = image.GetPixels())
                {
                    var pixel = pixels.GetPixel(0, 0);
                    Assert.Equal(4, pixel.Channels);
                    Assert.Equal(1, pixel.GetChannel(0));
                    Assert.Equal(2, pixel.GetChannel(1));
                    Assert.Equal(3, pixel.GetChannel(2));
                    Assert.Equal(Quantum.Max - 4, pixel.GetChannel(3));
                }
            }
        }
    }
}