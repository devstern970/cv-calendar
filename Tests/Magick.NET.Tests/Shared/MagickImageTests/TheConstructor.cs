﻿// Copyright 2013-2018 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
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
using System.IO;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        [TestClass]
        public partial class TheConstructor
        {
            [TestMethod]
            public void ShouldThrowExceptionWhenByteArrayIsNullAndPixelStorageSettingsIsSpecified()
            {
                ExceptionAssert.ThrowsArgumentNullException("data", () =>
                {
                    var pixelStorageSettings = new PixelStorageSettings();

                    new MagickImage((byte[])null, pixelStorageSettings);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenByteArrayIsEmptyAndPixelStorageSettingsIsSpecified()
            {
                ExceptionAssert.ThrowsArgumentException("data", () =>
                {
                    var pixelStorageSettings = new PixelStorageSettings();

                    new MagickImage(new byte[] { }, pixelStorageSettings);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenPixelStorageSettingsIsNullAndByteArrayIsSpecified()
            {
                ExceptionAssert.ThrowsArgumentNullException("pixelStorageSettings", () =>
                {
                    new MagickImage(new byte[] { 215 }, (PixelStorageSettings)null);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenFileInfoIsNullAndPixelStorageSettingsIsSpecified()
            {
                ExceptionAssert.ThrowsArgumentNullException("file", () =>
                {
                    var pixelStorageSettings = new PixelStorageSettings();

                    new MagickImage((FileInfo)null, pixelStorageSettings);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenPixelStorageSettingsIsNullAndFileInfoIsSpecified()
            {
                ExceptionAssert.ThrowsArgumentNullException("pixelStorageSettings", () =>
                {
                    new MagickImage(new FileInfo(Files.CirclePNG), (PixelStorageSettings)null);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenStreamIsNullAndPixelStorageSettingsIsSpecified()
            {
                ExceptionAssert.ThrowsArgumentNullException("stream", () =>
                {
                    var pixelStorageSettings = new PixelStorageSettings();

                    new MagickImage((Stream)null, pixelStorageSettings);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenStreamIsEmptyAndPixelStorageSettingsIsSpecified()
            {
                ExceptionAssert.ThrowsArgumentException("stream", () =>
                {
                    var pixelStorageSettings = new PixelStorageSettings();

                    new MagickImage(new MemoryStream(), pixelStorageSettings);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenPixelStorageSettingsIsNullAndStreamIsSpecified()
            {
                ExceptionAssert.ThrowsArgumentNullException("pixelStorageSettings", () =>
                {
                    new MagickImage(new MemoryStream(new byte[] { 215 }), (PixelStorageSettings)null);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenFileNameIsNullAndPixelStorageSettingsIsSpecified()
            {
                ExceptionAssert.ThrowsArgumentNullException("fileName", () =>
                {
                    var pixelStorageSettings = new PixelStorageSettings();

                    new MagickImage((string)null, pixelStorageSettings);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenPixelStorageSettingsIsNullAndFileNameIsSpecified()
            {
                ExceptionAssert.ThrowsArgumentNullException("pixelStorageSettings", () =>
                {
                    new MagickImage(Files.CirclePNG, (PixelStorageSettings)null);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenMappingIsNull()
            {
                ExceptionAssert.ThrowsArgumentException("pixelStorageSettings", () =>
                {
                    var settings = new PixelStorageSettings(1, 1, StorageType.Char, null);

                    new MagickImage(Files.CirclePNG, settings);
                }, "mapping");
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenMappingIsEmpty()
            {
                ExceptionAssert.ThrowsArgumentException("pixelStorageSettings", () =>
                {
                    var settings = new PixelStorageSettings(1, 1, StorageType.Char, string.Empty);

                    new MagickImage(Files.CirclePNG, settings);
                }, "mapping");
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenWidthIsNull()
            {
                ExceptionAssert.ThrowsArgumentException("pixelStorageSettings", () =>
                {
                    var settings = new PixelStorageSettings(1, 1, StorageType.Char, "RGBA");
                    settings.ReadSettings.Width = null;

                    new MagickImage(Files.CirclePNG, settings);
                }, "Width");
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenHeightIsNull()
            {
                ExceptionAssert.ThrowsArgumentException("pixelStorageSettings", () =>
                {
                    var settings = new PixelStorageSettings(1, 1, StorageType.Char, "RGBA");
                    settings.ReadSettings.Height = null;

                    new MagickImage(Files.CirclePNG, settings);
                }, "Height");
            }

            [TestMethod]
            public void ShouldReadByteArrayWithPixelStorageSettings()
            {
                byte[] data = new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0xf0, 0x3f,
                    0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0xf0, 0x3f,
                    0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0,
                };

                var pixelStorageSettings = new PixelStorageSettings(2, 1, StorageType.Double, PixelMapping.RGBA);

                using (IMagickImage image = new MagickImage(data, pixelStorageSettings))
                {
                    Assert.AreEqual(2, image.Width);
                    Assert.AreEqual(1, image.Height);

                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        Pixel pixel = pixels.GetPixel(0, 0);
                        Assert.AreEqual(4, pixel.Channels);
                        Assert.AreEqual(0, pixel.GetChannel(0));
                        Assert.AreEqual(0, pixel.GetChannel(1));
                        Assert.AreEqual(0, pixel.GetChannel(2));
                        Assert.AreEqual(Quantum.Max, pixel.GetChannel(3));

                        pixel = pixels.GetPixel(1, 0);
                        Assert.AreEqual(4, pixel.Channels);
                        Assert.AreEqual(0, pixel.GetChannel(0));
                        Assert.AreEqual(Quantum.Max, pixel.GetChannel(1));
                        Assert.AreEqual(0, pixel.GetChannel(2));
                        Assert.AreEqual(0, pixel.GetChannel(3));
                    }
                }
            }

            [TestMethod]
            public void ShouldReadFileInfoWithPixelStorageSettings()
            {
                var pixelStorageSettings = new PixelStorageSettings(1, 1, StorageType.Quantum, "R");

                var bytes = BitConverter.GetBytes(Quantum.Max);

                using (var temporyFile = new TemporaryFile(bytes))
                {
                    FileInfo file = temporyFile;
                    using (IMagickImage image = new MagickImage(file, pixelStorageSettings))
                    {
                        Assert.AreEqual(1, image.Width);
                        Assert.AreEqual(1, image.Height);
                        ColorAssert.AreEqual(MagickColors.White, image, 0, 0);
                    }
                }
            }

            [TestMethod]
            public void ShouldReadStreamWithPixelStorageSettings()
            {
                var pixelStorageSettings = new PixelStorageSettings(1, 1, StorageType.Double, "R");

                var bytes = BitConverter.GetBytes(1.0);

                using (var memoryStream = new MemoryStream(bytes))
                {
                    using (IMagickImage image = new MagickImage(memoryStream, pixelStorageSettings))
                    {
                        Assert.AreEqual(1, image.Width);
                        Assert.AreEqual(1, image.Height);
                        ColorAssert.AreEqual(MagickColors.White, image, 0, 0);
                    }
                }
            }

            [TestMethod]
            public void ShouldReadFileNameWithPixelStorageSettings()
            {
                var pixelStorageSettings = new PixelStorageSettings(1, 1, StorageType.Int32, "R");

                var bytes = BitConverter.GetBytes(4294967295U);

                using (var temporyFile = new TemporaryFile(bytes))
                {
                    var fileName = temporyFile.FullName;
                    using (IMagickImage image = new MagickImage(fileName, pixelStorageSettings))
                    {
                        Assert.AreEqual(1, image.Width);
                        Assert.AreEqual(1, image.Height);
                        ColorAssert.AreEqual(MagickColors.White, image, 0, 0);
                    }
                }
            }
        }
    }
}
