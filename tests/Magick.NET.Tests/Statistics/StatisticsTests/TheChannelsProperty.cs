﻿// Copyright 2013-2021 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System.Linq;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class StatisticsTests
    {
        public class TheChannelsProperty
        {
            [Fact]
            public void ShouldReturnTheCorrectChannels()
            {
                using (var image = new MagickImage(Files.MagickNETIconPNG))
                {
                    var statistics = image.Statistics();

                    var channels = statistics.Channels.ToList();

                    Assert.Equal(5, channels.Count);
                    Assert.Contains(PixelChannel.Red, channels);
                    Assert.Contains(PixelChannel.Green, channels);
                    Assert.Contains(PixelChannel.Blue, channels);
                    Assert.Contains(PixelChannel.Alpha, channels);
                    Assert.Contains(PixelChannel.Composite, channels);
                }
            }
        }
    }
}
