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
using System.IO;
using System.Linq;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageInfoTests
    {
        public class TheReadCollectionMethod
        {
            public class WithByteArray
            {
                [Fact]
                public void ShouldThrowExceptionWhenDataIsNull()
                {
                    Assert.Throws<ArgumentNullException>("data", () => MagickImageInfo.ReadCollection((byte[])null).ToArray());
                }

                [Fact]
                public void ShouldThrowExceptionWhenDataIsEmpty()
                {
                    Assert.Throws<ArgumentException>("data", () => MagickImageInfo.ReadCollection(new byte[0]).ToArray());
                }
            }

            public class WithByteArrayAndOffset
            {
                [Fact]
                public void ShouldThrowExceptionWhenArrayIsNull()
                {
                    Assert.Throws<ArgumentNullException>("data", () => MagickImageInfo.ReadCollection(null, 0, 0).ToArray());
                }

                [Fact]
                public void ShouldThrowExceptionWhenArrayIsEmpty()
                {
                    Assert.Throws<ArgumentException>("data", () => MagickImageInfo.ReadCollection(new byte[] { }, 0, 0).ToArray());
                }

                [Fact]
                public void ShouldThrowExceptionWhenOffsetIsNegative()
                {
                    Assert.Throws<ArgumentException>("offset", () => MagickImageInfo.ReadCollection(new byte[] { 215 }, -1, 0).ToArray());
                }

                [Fact]
                public void ShouldThrowExceptionWhenCountIsZero()
                {
                    Assert.Throws<ArgumentException>("count", () => MagickImageInfo.ReadCollection(new byte[] { 215 }, 0, 0).ToArray());
                }

                [Fact]
                public void ShouldThrowExceptionWhenCountIsNegative()
                {
                    Assert.Throws<ArgumentException>("count", () => MagickImageInfo.ReadCollection(new byte[] { 215 }, 0, -1).ToArray());
                }
            }

            public class WithFileInfo
            {
                [Fact]
                public void ShouldThrowExceptionWhenFileIsNull()
                {
                    Assert.Throws<ArgumentNullException>("file", () => MagickImageInfo.ReadCollection((FileInfo)null).ToArray());
                }
            }

            public class WithFileName
            {
                [Fact]
                public void ShouldThrowExceptionWhenFileNameIsNull()
                {
                    Assert.Throws<ArgumentNullException>("fileName", () => MagickImageInfo.ReadCollection((string)null).ToArray());
                }

                [Fact]
                public void ShouldThrowExceptionWhenFileNameIsEmpty()
                {
                    Assert.Throws<ArgumentException>("fileName", () => MagickImageInfo.ReadCollection(string.Empty).ToArray());
                }

                [Fact]
                public void ShouldThrowExceptionWhenFileNameIsInvalid()
                {
                    var exception = Assert.Throws<MagickBlobErrorException>(() =>
                    {
                        MagickImageInfo.ReadCollection(Files.Missing).ToArray();
                    });

                    Assert.Contains("error/blob.c/OpenBlob", exception.Message);
                }

                [Fact]
                public void ShouldReturnEnumerableWithCorrectCount()
                {
                    var info = MagickImageInfo.ReadCollection(Files.RoseSparkleGIF);
                    Assert.Equal(3, info.Count());
                }

                [Fact]
                public void ShouldReturnTheCorrectInformation()
                {
                    var info = MagickImageInfo.ReadCollection(Files.InvitationTIF);

                    IMagickImageInfo first = info.First();
                    Assert.Equal(ColorSpace.sRGB, first.ColorSpace);
                    Assert.Equal(CompressionMethod.Zip, first.Compression);
                    Assert.EndsWith("Invitation.tif", first.FileName);
                    Assert.Equal(MagickFormat.Tiff, first.Format);
                    Assert.Equal(700, first.Height);
                    Assert.Equal(350, first.Density.X);
                    Assert.Equal(350, first.Density.Y);
                    Assert.Equal(DensityUnit.PixelsPerInch, first.Density.Units);
                    Assert.Equal(Interlace.NoInterlace, first.Interlace);
                    Assert.Equal(827, first.Width);
                    Assert.Equal(0, first.Quality);
                }
            }

            public class WithStream
            {
                [Fact]
                public void ShouldThrowExceptionWhenStreamIsNull()
                {
                    Assert.Throws<ArgumentNullException>("stream", () => MagickImageInfo.ReadCollection((Stream)null).ToArray());
                }
            }
        }
    }
}
