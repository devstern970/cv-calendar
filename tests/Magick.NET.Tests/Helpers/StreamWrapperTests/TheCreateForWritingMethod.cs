﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class StreamWrapperTests
    {
        public class TheCreateForWritingMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenStreamIsNotWritable()
            {
                using var stream = TestStream.ThatCannotWrite();

                var exception = Assert.Throws<ArgumentException>("stream", () => StreamWrapper.CreateForWriting(stream));
                Assert.Contains("writable", exception.Message);
            }

            [Fact]
            public void ShouldOnlySetReaderWhenStreamIsNotReadable()
            {
                using var stream = TestStream.ThatCannotRead();
                var streamWrapper = StreamWrapper.CreateForWriting(stream);
            }
        }
    }
}
