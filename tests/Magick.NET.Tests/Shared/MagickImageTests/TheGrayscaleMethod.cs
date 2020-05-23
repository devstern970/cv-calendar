﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        [TestClass]
        public class TheGrayscaleMethod
        {
            [TestMethod]
            public void ShouldUseTheDefaultPixelIntensityMethod()
            {
                using (var imageA = new MagickImage(MagickColors.Purple, 1, 1))
                {
                    imageA.Grayscale();

                    using (var imageB = new MagickImage(MagickColors.Purple, 1, 1))
                    {
                        imageB.Grayscale(PixelIntensityMethod.Brightness);

                        Assert.AreNotEqual(0.0, imageA.Compare(imageB, ErrorMetric.RootMeanSquared));
                    }
                }
            }

            [TestMethod]
            public void ShouldNotRoundWhenHdriEnabled()
            {
                using (var image = new MagickImage(MagickColors.Black, 1, 1))
                {
                    image.Grayscale(PixelIntensityMethod.Average);

                    using (var pixels = image.GetPixels())
                    {
                        var pixel = pixels.GetValue(0, 0);

                        Assert.AreEqual(0, pixel[0]);
                    }
                }
            }
        }
    }
}
