﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.IO;
using System.Threading.Tasks;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests;

public partial class ThePdfCoder
{
    [Fact]
    public void ShouldReadFileMultithreadedCorrectly()
    {
        if (!Ghostscript.IsAvailable)
            return;

        var results = new Task[3];

        for (var i = 0; i < results.Length; ++i)
        {
            results[i] = Task.Run(() =>
            {
                using var image = new MagickImage();
                image.Read(Files.Coders.CartoonNetworkStudiosLogoAI);

                Assert.Equal(765, image.Width);
                Assert.Equal(361, image.Height);
                Assert.Equal(MagickFormat.Ai, image.Format);
            });
        }

        for (var i = 0; i < results.Length; ++i)
        {
            results[i].Wait();
        }
    }

    [Fact]
    public void ShouldWriteTiffImageInCorrectColor()
    {
        if (!Ghostscript.IsAvailable)
            return;

        using var input = new MagickImage(Files.Coders.PixelTIF);
        using var memorystream = new MemoryStream();
        input.Write(memorystream, MagickFormat.Tiff);
        memorystream.Position = 0;

        using var output = new MagickImage(memorystream);

        ColorAssert.Equal(MagickColors.White, output, 0, 0);
    }

    [Fact]
    public void ShouldReturnTheCorrectFormatForAiFile()
    {
        if (!Ghostscript.IsAvailable)
            return;

        using (var image = new MagickImage(Files.Coders.CartoonNetworkStudiosLogoAI))
        {
            Assert.Equal(765, image.Width);
            Assert.Equal(361, image.Height);
            Assert.Equal(MagickFormat.Ai, image.Format);
        }
    }
}
