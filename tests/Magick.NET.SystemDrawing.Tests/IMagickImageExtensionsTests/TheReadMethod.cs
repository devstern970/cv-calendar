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

using System;
using System.Drawing;
using System.Drawing.Imaging;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.SystemDrawing.Tests
{
    public partial class IMagickImageExtensionsTests
    {
        [TestClass]
        public partial class TheReadMethod
        {
            [TestMethod]
            public void ShouldThrowExceptionWhenBitmapIsNull()
            {
                using (var image = new MagickImage())
                {
                    ExceptionAssert.Throws<ArgumentNullException>("bitmap", () => image.Read((Bitmap)null));
                }
            }

            [TestMethod]
            public void ShouldUsePngFormatWhenBitmapIsPng()
            {
                using (Bitmap bitmap = new Bitmap(Files.SnakewarePNG))
                {
                    using (var image = new MagickImage())
                    {
                        image.Read(bitmap);

                        Assert.AreEqual(286, image.Width);
                        Assert.AreEqual(67, image.Height);
                        Assert.AreEqual(MagickFormat.Png, image.Format);
                    }
                }
            }

            [TestMethod]
            public void ShouldUseBmpFormatWhenBitmapIsMemoryBmp()
            {
                using (Bitmap bitmap = new Bitmap(100, 50, PixelFormat.Format24bppRgb))
                {
                    Assert.AreEqual(bitmap.RawFormat, ImageFormat.MemoryBmp);

                    using (var image = new MagickImage())
                    {
                        image.Read(bitmap);

                        Assert.AreEqual(100, image.Width);
                        Assert.AreEqual(50, image.Height);
                        Assert.AreEqual(MagickFormat.Bmp3, image.Format);
                    }
                }
            }
        }
    }
}