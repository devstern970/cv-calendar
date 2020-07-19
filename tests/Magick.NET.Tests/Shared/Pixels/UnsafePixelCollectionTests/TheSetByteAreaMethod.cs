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
    public partial class UnsafePixelCollectionTests
    {
        [TestClass]
        public class TheSetByteAreaMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionWhenArrayIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        pixels.SetByteArea(10, 10, 1000, 1000, null);
                    }
                }
            }

            [TestMethod]
            public void ShouldNotThrowExceptionWhenArrayHasInvalidSize()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        pixels.SetByteArea(10, 10, 1000, 1000, new byte[] { 0, 0, 0, 0 });
                    }
                }
            }

            [TestMethod]
            public void ShouldNotThrowExceptionWhenArrayHasTooManyValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        var values = new byte[(113 * 108 * image.ChannelCount) + image.ChannelCount];
                        pixels.SetByteArea(10, 10, 113, 108, values);
                    }
                }
            }

            [TestMethod]
            public void ShouldChangePixelsWhenArrayHasMaxNumberOfValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        var values = new byte[113 * 108 * image.ChannelCount];
                        pixels.SetByteArea(10, 10, 113, 108, values);

                        ColorAssert.AreEqual(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }

            [TestMethod]
            public void ShouldNotThrowExceptionWhenArrayIsSpecifiedAndGeometryIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        pixels.SetByteArea(null, new byte[] { 0 });
                    }
                }
            }

            [TestMethod]
            public void ShouldChangePixelsWhenGeometryAndArrayAreSpecified()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        var values = new byte[113 * 108 * image.ChannelCount];
                        pixels.SetByteArea(new MagickGeometry(10, 10, 113, 108), values);

                        ColorAssert.AreEqual(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }
        }
    }
}