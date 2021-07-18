﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using System.IO;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageCollectionTests
    {
        public class TheWarningEvent
        {
            [Fact]
            public void ShouldRaiseEventsForWarnings()
            {
                var count = 0;
                EventHandler<WarningEventArgs> warningDelegate = (sender, arguments) =>
                {
                    Assert.NotNull(sender);
                    Assert.NotNull(arguments);
                    Assert.NotNull(arguments.Message);
                    Assert.NotNull(arguments.Exception);
                    Assert.NotEqual(string.Empty, arguments.Message);

                    count++;
                };

                var bytes = File.ReadAllBytes(Files.EightBimTIF);
                bytes[229] = 1;

                using (var collection = new MagickImageCollection())
                {
                    collection.Warning += warningDelegate;
                    collection.Read(bytes);

                    Assert.NotEqual(0, count);

                    var expectedCount = count;
                    collection.Warning -= warningDelegate;
                    collection.Read(bytes);

                    Assert.Equal(expectedCount, count);
                }
            }
        }
    }
}
