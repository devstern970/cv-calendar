﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using System.IO;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class BytesTests
    {
        public class TheCreateMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenStreamIsNull()
            {
                Assert.Throws<ArgumentNullException>("stream", () => Bytes.Create(null));
            }

            [Fact]
            public void ShouldThrowExceptionWhenStreamPositionIsNotZero()
            {
                using (var memStream = new MemoryStream(new byte[] { 42 }))
                {
                    memStream.Position = 10;

                    Assert.Throws<ArgumentException>("stream", () => Bytes.Create(memStream));
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenStreamIsEmpty()
            {
                using (var memStream = new MemoryStream())
                {
                    Assert.Throws<ArgumentException>("stream", () => Bytes.Create(memStream));
                }
            }

            [Fact]
            public void ShouldSetPropertiesWhenStreamIsEmptyAndAllowEmptyStreamIsSet()
            {
                using (var memStream = new MemoryStream())
                {
                    var bytes = Bytes.Create(memStream, allowEmptyStream: true);

                    Assert.Equal(0, bytes.Length);
                    Assert.NotNull(bytes.GetData());
                    Assert.Empty(bytes.GetData());
                }
            }

            [Fact]
            public void ShouldSetPropertiesWhenStreamIsFileStream()
            {
                using (var fileStream = File.OpenRead(Files.ImageMagickJPG))
                {
                    var bytes = Bytes.Create(fileStream);

                    Assert.Equal(18749, bytes.Length);
                    Assert.NotNull(bytes.GetData());
                    Assert.Equal(18749, bytes.GetData().Length);
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenStreamCannotRead()
            {
                using (var stream = new TestStream(false, true, true))
                {
                    Assert.Throws<ArgumentException>("stream", () =>
                    {
                        Bytes.Create(stream);
                    });
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenStreamIsTooLong()
            {
                using (var stream = new TestStream(true, true, true))
                {
                    stream.SetLength(long.MaxValue);

                    Assert.Throws<ArgumentException>("length", () =>
                    {
                        Bytes.Create(stream);
                    });
                }
            }
        }
    }
}
