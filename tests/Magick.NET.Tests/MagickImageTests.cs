﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageMagick;
using Xunit;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        [Fact]
        public void Test_Frame()
        {
            var frameSize = 100;

            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                var expectedWidth = frameSize + image.Width + frameSize;
                var expectedHeight = frameSize + image.Height + frameSize;

                image.Frame(frameSize, frameSize);
                Assert.Equal(expectedWidth, image.Width);
                Assert.Equal(expectedHeight, image.Height);
            }

            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                var expectedWidth = frameSize + image.Width + frameSize;
                var expectedHeight = frameSize + image.Height + frameSize;

                image.Frame(frameSize, frameSize, 6, 6);
                Assert.Equal(expectedWidth, image.Width);
                Assert.Equal(expectedHeight, image.Height);
            }

            Assert.Throws<MagickOptionErrorException>(() =>
            {
                using (var image = new MagickImage(Files.MagickNETIconPNG))
                {
                    image.Frame(6, 6, frameSize, frameSize);
                }
            });
        }

        [Fact]
        public void Test_GammaCorrect()
        {
            var first = new MagickImage(Files.InvitationTIF);
            first.GammaCorrect(2.0);

            var second = new MagickImage(Files.InvitationTIF);
            second.GammaCorrect(2.0, Channels.Red);

            Assert.False(first.Equals(second));

            first.Dispose();
            second.Dispose();
        }

        [Fact]
        public void Test_Grayscale()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.Grayscale(PixelIntensityMethod.Brightness);
                Assert.Equal(1, image.ChannelCount);
                Assert.Equal(PixelChannel.Red, image.Channels.First());

                ColorAssert.Equal(MagickColors.White, image, 220, 45);
                ColorAssert.Equal(new MagickColor("#929292"), image, 386, 379);
                ColorAssert.Equal(new MagickColor("#f5f5f5"), image, 405, 158);
            }
        }

        [Fact]
        public void Test_Histogram()
        {
            var image = new MagickImage();
            var histogram = image.Histogram();
            Assert.NotNull(histogram);
            Assert.Empty(histogram);

            image = new MagickImage(Files.RedPNG);
            histogram = image.Histogram();

            Assert.NotNull(histogram);
            Assert.Equal(3, histogram.Count);

            var red = new MagickColor(Quantum.Max, 0, 0);
            var alphaRed = new MagickColor(Quantum.Max, 0, 0, 0);
            var halfAlphaRed = new MagickColor("#FF000080");

            Assert.Equal(3, histogram.Count);
            Assert.Equal(50000, histogram[red]);
            Assert.Equal(30000, histogram[alphaRed]);
            Assert.Equal(40000, histogram[halfAlphaRed]);

            image.Dispose();
        }

        [Fact]
        public void Test_IEquatable()
        {
            var first = new MagickImage(MagickColors.Red, 10, 10);

            Assert.False(first == null);
            Assert.False(first.Equals(null));
            Assert.True(first.Equals(first));
            Assert.True(first.Equals((object)first));

            var second = new MagickImage(MagickColors.Red, 10, 10);

            Assert.True(first == second);
            Assert.True(first.Equals(second));
            Assert.True(first.Equals((object)second));

            second = new MagickImage(MagickColors.Green, 10, 10);

            Assert.True(first != second);
            Assert.False(first.Equals(second));

            first.Dispose();
            second.Dispose();

            first = null;
            Assert.True(first == null);
            Assert.False(first != null);
        }

        [Fact]
        public void Test_Implode()
        {
            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                ColorAssert.Equal(new MagickColor("#00000000"), image, 69, 45);

                image.Implode(0.5, PixelInterpolateMethod.Blend);

                ColorAssert.Equal(new MagickColor("#a8dff8"), image, 69, 45);

                image.Implode(-0.5, PixelInterpolateMethod.Background);

                ColorAssert.Equal(new MagickColor("#00000000"), image, 69, 45);
            }
        }

        [Fact]
        public void Test_Interlace()
        {
            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                Assert.Equal(Interlace.NoInterlace, image.Interlace);

                image.Interlace = Interlace.Png;

                using (var memStream = new MemoryStream())
                {
                    image.Write(memStream);
                    memStream.Position = 0;
                    using (var result = new MagickImage(memStream))
                    {
                        Assert.Equal(Interlace.Png, result.Interlace);
                    }
                }
            }
        }

        [Fact]
        public void Test_Kuwahara()
        {
            using (var image = new MagickImage(Files.NoisePNG))
            {
                image.Kuwahara(13.4, 2.5);
                image.ColorType = ColorType.Bilevel;

                ColorAssert.Equal(MagickColors.White, image, 216, 120);
                ColorAssert.Equal(MagickColors.Black, image, 39, 138);
            }
        }

        [Fact]
        public void Test_LevelColors()
        {
            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                image.LevelColors(MagickColors.Fuchsia, MagickColors.Goldenrod);
                ColorAssert.Equal(new MagickColor("#ffffbed54bc4"), image, 42, 75);
                ColorAssert.Equal(new MagickColor("#ffffffff0809"), image, 62, 75);
            }

            using (var first = new MagickImage(Files.MagickNETIconPNG))
            {
                first.LevelColors(MagickColors.Fuchsia, MagickColors.Goldenrod, Channels.Blue);
                first.InverseLevelColors(MagickColors.Fuchsia, MagickColors.Goldenrod, Channels.Blue);
                first.Alpha(AlphaOption.Background);

                using (var second = new MagickImage(Files.MagickNETIconPNG))
                {
                    second.Alpha(AlphaOption.Background);
#if Q8 || Q16
                    Assert.Equal(0.0, first.Compare(second, ErrorMetric.RootMeanSquared));
#else
                    Assert.InRange(first.Compare(second, ErrorMetric.RootMeanSquared), 0.0, 0.00000001);
#endif
                }
            }
        }

        [Fact]
        public void Test_LinearStretch()
        {
            using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
            {
                image.Scale(100, 100);

                image.LinearStretch((Percentage)1, (Percentage)1);
                using (var memStream = new MemoryStream())
                {
                    image.Format = MagickFormat.Histogram;
                    image.Write(memStream);
                    memStream.Position = 0;

                    using (var histogram = new MagickImage(memStream))
                    {
#if Q8
                        ColorAssert.Equal(MagickColors.Red, histogram, 65, 38);
                        ColorAssert.Equal(MagickColors.Lime, histogram, 135, 0);
                        ColorAssert.Equal(MagickColors.Blue, histogram, 209, 81);
#else
                        ColorAssert.Equal(MagickColors.Red, histogram, 34, 183);
                        ColorAssert.Equal(MagickColors.Lime, histogram, 122, 193);
                        ColorAssert.Equal(MagickColors.Blue, histogram, 210, 194);
#endif
                    }
                }

                image.LinearStretch((Percentage)10, (Percentage)90);
                using (var memStream = new MemoryStream())
                {
                    image.Format = MagickFormat.Histogram;
                    image.Write(memStream);
                    memStream.Position = 0;

                    using (var histogram = new MagickImage(memStream))
                    {
#if Q8
                        ColorAssert.Equal(MagickColors.Red, histogram, 96, 174);
                        ColorAssert.Equal(MagickColors.Lime, histogram, 212, 168);
                        ColorAssert.Equal(MagickColors.Blue, histogram, 194, 190);
#elif Q16
                        ColorAssert.Equal(MagickColors.Red, histogram, 221, 183);
                        ColorAssert.Equal(MagickColors.Lime, histogram, 11, 181);
                        ColorAssert.Equal(MagickColors.Blue, histogram, 45, 194);
#else
                        ColorAssert.Equal(MagickColors.Red, histogram, 221, 183);
                        ColorAssert.Equal(MagickColors.Lime, histogram, 12, 180);
                        ColorAssert.Equal(MagickColors.Blue, histogram, 45, 194);
#endif
                    }
                }
            }
        }

        [Fact]
        public void Test_LocalContrast()
        {
            using (var image = new MagickImage(Files.NoisePNG))
            {
                image.LocalContrast(5.0, (Percentage)75);
                image.Clamp();

                ColorAssert.Equal(MagickColors.Black, image, 81, 28);
                ColorAssert.Equal(MagickColors.Black, image, 245, 181);
                ColorAssert.Equal(MagickColors.White, image, 200, 135);
                ColorAssert.Equal(MagickColors.White, image, 200, 135);
            }
        }

        [Fact]
        public void Test_Magnify()
        {
            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                image.Magnify();
                Assert.Equal(256, image.Width);
                Assert.Equal(256, image.Height);
            }
        }

        [Fact]
        public void MeanShift_WithSize1_DoesNotChangeImage()
        {
            using (var input = new MagickImage(Files.FujiFilmFinePixS1ProPNG))
            {
                using (var output = input.Clone())
                {
                    output.MeanShift(1);

                    Assert.Equal(0.0, output.Compare(input, ErrorMetric.RootMeanSquared));
                }
            }
        }

        [Fact]
        public void MeanShift_WithSizeLargerThan1_ChangesImage()
        {
            using (var input = new MagickImage(Files.FujiFilmFinePixS1ProPNG))
            {
                using (var output = input.Clone())
                {
                    output.MeanShift(2, new Percentage(80));

                    Assert.InRange(output.Compare(input, ErrorMetric.RootMeanSquared), 0.019, 0.020);
                }
            }
        }

        [Fact]
        public void Test_MatteColor()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.MatteColor = MagickColors.PaleGoldenrod;
                image.Frame();

                ColorAssert.Equal(MagickColors.PaleGoldenrod, image, 10, 10);
                ColorAssert.Equal(MagickColors.PaleGoldenrod, image, 680, 520);
            }
        }

        [Fact]
        public void Test_Minify()
        {
            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                image.Minify();
                Assert.Equal(64, image.Width);
                Assert.Equal(64, image.Height);
            }
        }

        [Fact]
        public void Test_Morphology()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                Assert.Throws<MagickOptionErrorException>(() =>
                {
                    image.Morphology(MorphologyMethod.Smooth, "Magick");
                });

                image.Morphology(MorphologyMethod.Dilate, Kernel.Square, "1");

                image.Morphology(MorphologyMethod.Convolve, "3: 0.3,0.6,0.3 0.6,1.0,0.6 0.3,0.6,0.3");

                var settings = new MorphologySettings();
                settings.Method = MorphologyMethod.Convolve;
                settings.ConvolveBias = new Percentage(50);
                settings.Kernel = Kernel.DoG;
                settings.KernelArguments = "0x2";

                image.Read(Files.Builtin.Logo);

                Assert.Throws<ArgumentNullException>("settings", () =>
                {
                    image.Morphology(null);
                });

                image.Morphology(settings);

                var half = (QuantumType)((Quantum.Max / 2.0) + 0.5);
                ColorAssert.Equal(new MagickColor(half, half, half), image, 120, 160);
            }
        }

        [Fact]
        public void Test_MotionBlur()
        {
            using (var motionBlurred = new MagickImage(Files.Builtin.Logo))
            {
                motionBlurred.MotionBlur(4.0, 5.4, 10.6);

                using (var original = new MagickImage(Files.Builtin.Logo))
                {
                    Assert.InRange(motionBlurred.Compare(original, ErrorMetric.RootMeanSquared), 0.11019, 0.11020);
                }
            }
        }

        [Fact]
        public void Test_Normalize()
        {
            using (var images = new MagickImageCollection())
            {
                images.Add(new MagickImage("gradient:gray70-gray30", 100, 100));
                images.Add(new MagickImage("gradient:blue-navy", 50, 100));

                using (var colorRange = images.AppendHorizontally())
                {
                    ColorAssert.Equal(new MagickColor("gray70"), colorRange, 0, 0);
                    ColorAssert.Equal(new MagickColor("blue"), colorRange, 101, 0);

                    ColorAssert.Equal(new MagickColor("gray30"), colorRange, 0, 99);
                    ColorAssert.Equal(new MagickColor("navy"), colorRange, 101, 99);

                    colorRange.Normalize();

                    ColorAssert.Equal(new MagickColor("white"), colorRange, 0, 0);
                    ColorAssert.Equal(new MagickColor("blue"), colorRange, 101, 0);

#if Q8
                    ColorAssert.Equal(new MagickColor("gray40"), colorRange, 0, 99);
                    ColorAssert.Equal(new MagickColor("#0000b3"), colorRange, 101, 99);
#else
                    ColorAssert.Equal(new MagickColor("#662e662e662e"), colorRange, 0, 99);
                    ColorAssert.Equal(new MagickColor("#00000000b317"), colorRange, 101, 99);
#endif
                }
            }
        }

        [Fact]
        public void Test_OilPaint()
        {
            using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
            {
                image.OilPaint(2, 5);
                ColorAssert.Equal(new MagickColor("#6a7e85"), image, 180, 98);
            }
        }

        [Fact]
        public void Test_Opaque()
        {
            using (var image = new MagickImage(MagickColors.Red, 10, 10))
            {
                ColorAssert.Equal(MagickColors.Red, image, 0, 0);

                image.Opaque(MagickColors.Red, MagickColors.Yellow);
                ColorAssert.Equal(MagickColors.Yellow, image, 0, 0);

                image.InverseOpaque(MagickColors.Yellow, MagickColors.Red);
                ColorAssert.Equal(MagickColors.Yellow, image, 0, 0);

                image.InverseOpaque(MagickColors.Red, MagickColors.Red);
                ColorAssert.Equal(MagickColors.Red, image, 0, 0);
            }
        }

        [Fact]
        public void Test_Perceptible()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.Perceptible(Quantum.Max * 0.4);

                ColorAssert.Equal(new MagickColor("#f79868"), image, 300, 210);
                ColorAssert.Equal(new MagickColor("#666692"), image, 410, 405);
            }
        }

        [Fact]
        public void Test_Polaroid()
        {
            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                image.BorderColor = MagickColors.Red;
                image.BackgroundColor = MagickColors.Fuchsia;
                image.Settings.FontPointsize = 20;
                image.Polaroid("Magick.NET", 10, PixelInterpolateMethod.Bilinear);
                image.Clamp();

                ColorAssert.Equal(MagickColors.Black, image, 104, 163);
                ColorAssert.Equal(MagickColors.Red, image, 72, 156);
#if Q8
                ColorAssert.Equal(new MagickColor("#ff00ffbc"), image, 146, 196);
#else
                ColorAssert.Equal(new MagickColor("#ffff0000ffffbb9a"), image, 146, 196);
#endif
            }
        }

        [Fact]
        public void Test_Posterize()
        {
            using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
            {
                image.Posterize(5);

#if Q8
                ColorAssert.Equal(new MagickColor("#4080bf"), image, 300, 150);
                ColorAssert.Equal(new MagickColor("#404080"), image, 495, 270);
                ColorAssert.Equal(new MagickColor("#404040"), image, 445, 255);
#else
                ColorAssert.Equal(new MagickColor("#40008000bfff"), image, 300, 150);
                ColorAssert.Equal(new MagickColor("#400040008000"), image, 495, 270);
                ColorAssert.Equal(new MagickColor("#400040004000"), image, 445, 255);
#endif
            }
        }

        [Fact]
        public void Test_Profile()
        {
            using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
            {
                var profile = image.GetIptcProfile();
                Assert.NotNull(profile);
                image.RemoveProfile(profile.Name);
                profile = image.GetIptcProfile();
                Assert.Null(profile);

                using (var memStream = new MemoryStream())
                {
                    image.Write(memStream);
                    memStream.Position = 0;

                    using (var newImage = new MagickImage(memStream))
                    {
                        profile = newImage.GetIptcProfile();
                        Assert.Null(profile);
                    }
                }
            }
        }

        [Fact]
        public void Test_ProfileNames()
        {
            using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
            {
                var names = image.ProfileNames;
                Assert.NotNull(names);
                Assert.Equal("8bim,exif,icc,iptc,xmp", string.Join(",", names));
            }

            using (var image = new MagickImage(Files.RedPNG))
            {
                var names = image.ProfileNames;
                Assert.NotNull(names);
                Assert.Empty(names);
            }
        }

        [Fact]
        public void Test_Quantize()
        {
            var settings = new QuantizeSettings();
            settings.Colors = 8;

            Assert.Equal(DitherMethod.Riemersma, settings.DitherMethod);
            settings.DitherMethod = null;
            Assert.Null(settings.DitherMethod);
            settings.DitherMethod = DitherMethod.No;
            Assert.Equal(DitherMethod.No, settings.DitherMethod);
            settings.MeasureErrors = true;
            Assert.True(settings.MeasureErrors);

            using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
            {
                var errorInfo = image.Quantize(settings);
#if Q8
                Assert.InRange(errorInfo.MeanErrorPerPixel, 7.066, 7.067);
#else
                Assert.InRange(errorInfo.MeanErrorPerPixel, 1827.8, 1827.9);
#endif
                Assert.InRange(errorInfo.NormalizedMaximumError, 0.352, 0.354);
                Assert.InRange(errorInfo.NormalizedMeanError, 0.001, 0.002);
            }
        }

        [Fact]
        public void Test_RandomThreshold()
        {
            using (var image = new MagickImage(Files.TestPNG))
            {
                image.RandomThreshold((QuantumType)(Quantum.Max / 4), (QuantumType)(Quantum.Max / 2));

                ColorAssert.Equal(MagickColors.Black, image, 52, 52);
                ColorAssert.Equal(MagickColors.White, image, 75, 52);
                ColorAssert.Equal(MagickColors.Red, image, 31, 90);
                ColorAssert.Equal(MagickColors.Lime, image, 69, 90);
                ColorAssert.Equal(MagickColors.Blue, image, 120, 90);
            }
        }

        [Fact]
        public void Test_Raise_Lower()
        {
            using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
            {
                image.Raise(30);

                ColorAssert.Equal(new MagickColor("#6ee29508b532"), image, 29, 30);
                ColorAssert.Equal(new MagickColor("#2f2054867aac"), image, 570, 265);
            }

            using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
            {
                image.Lower(30);

                ColorAssert.Equal(new MagickColor("#2da153c773f1"), image, 29, 30);
                ColorAssert.Equal(new MagickColor("#706195c7bbed"), image, 570, 265);
            }
        }

        [Fact]
        public void Test_RegionMask()
        {
            using (var red = new MagickImage("xc:red", 100, 100))
            {
                using (var green = new MagickImage("xc:green", 100, 100))
                {
                    green.RegionMask(new MagickGeometry(10, 10, 50, 50));

                    green.Composite(red, CompositeOperator.SrcOver);

                    ColorAssert.Equal(MagickColors.Green, green, 0, 0);
                    ColorAssert.Equal(MagickColors.Red, green, 10, 10);
                    ColorAssert.Equal(MagickColors.Green, green, 60, 60);

                    green.RemoveRegionMask();

                    green.Composite(red, CompositeOperator.SrcOver);

                    ColorAssert.Equal(MagickColors.Red, green, 0, 0);
                    ColorAssert.Equal(MagickColors.Red, green, 10, 10);
                    ColorAssert.Equal(MagickColors.Red, green, 60, 60);
                }
            }
        }

        [Fact]
        public void Test_Resample()
        {
            using (var image = new MagickImage("xc:red", 100, 100))
            {
                image.Resample(new PointD(300));

                Assert.Equal(300, image.Density.X);
                Assert.Equal(300, image.Density.Y);
                Assert.NotEqual(100, image.Width);
                Assert.NotEqual(100, image.Height);
            }
        }

        [Fact]
        public void Test_Roll()
        {
            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                image.Roll(40, 60);

                var blue = new MagickColor("#a8dff8");
                ColorAssert.Equal(blue, image, 66, 103);
                ColorAssert.Equal(blue, image, 120, 86);
                ColorAssert.Equal(blue, image, 0, 82);
            }
        }

        [Fact]
        public void Test_Rotate()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                Assert.Equal(640, image.Width);
                Assert.Equal(480, image.Height);

                image.Rotate(90);

                Assert.Equal(480, image.Width);
                Assert.Equal(640, image.Height);
            }
        }

        [Fact]
        public void Test_RotationalBlur()
        {
            using (var image = new MagickImage(Files.TestPNG))
            {
                image.RotationalBlur(20);

#if Q8
                ColorAssert.Equal(new MagickColor("#fbfbfb2b"), image, 10, 10);
                ColorAssert.Equal(new MagickColor("#8b0303"), image, 13, 67);
                ColorAssert.Equal(new MagickColor(OpenCLValue.Get("#167516", "#167616")), image, 63, 67);
                ColorAssert.Equal(new MagickColor("#3131fc"), image, 125, 67);
#else
                ColorAssert.Equal(new MagickColor("#fbf7fbf7fbf72aab"), image, 10, 10);
                ColorAssert.Equal(new MagickColor("#8b2102990299"), image, 13, 67);
                ColorAssert.Equal(new MagickColor("#159275F21592"), image, 63, 67);
                ColorAssert.Equal(new MagickColor("#31853185fd47"), image, 125, 67);
#endif
            }

            using (var image = new MagickImage(Files.TestPNG))
            {
                image.RotationalBlur(20, Channels.RGB);

#if Q8
                ColorAssert.Equal(new MagickColor("#fbfbfb80"), image, 10, 10);
                ColorAssert.Equal(new MagickColor("#8b0303"), image, 13, 67);
                ColorAssert.Equal(new MagickColor(OpenCLValue.Get("#167516", "#167616")), image, 63, 67);
                ColorAssert.Equal(new MagickColor("#3131fc"), image, 125, 67);
#else
                ColorAssert.Equal(new MagickColor("#fbf7fbf7fbf78000"), image, 10, 10);
                ColorAssert.Equal(new MagickColor("#8b2102990299"), image, 13, 67);
                ColorAssert.Equal(new MagickColor("#159275f21592"), image, 63, 67);
                ColorAssert.Equal(new MagickColor("#31853185fd47"), image, 125, 67);
#endif
            }
        }

        [Fact]
        public void Test_Sample()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.Sample(400, 400);
                Assert.Equal(400, image.Width);
                Assert.Equal(300, image.Height);
            }
        }

        [Fact]
        public void Test_Scale()
        {
            using (var image = new MagickImage(Files.CirclePNG))
            {
                var color = MagickColor.FromRgba(255, 255, 255, 159);
                ColorAssert.Equal(color, image, image.Width / 2, image.Height / 2);

                image.Scale((Percentage)400);
                ColorAssert.Equal(color, image, image.Width / 2, image.Height / 2);
            }
        }

        [Fact]
        public void Test_Segment()
        {
            using (var image = new MagickImage(Files.TestPNG))
            {
                image.Segment();

                ColorAssert.Equal(new MagickColor("#008300"), image, 77, 30);
                ColorAssert.Equal(new MagickColor("#f9f9f9"), image, 79, 30);
                ColorAssert.Equal(new MagickColor("#00c2fe"), image, 128, 62);
            }
        }

        [Fact]
        public void Test_SelectiveBlur()
        {
            using (var image = new MagickImage(Files.NoisePNG))
            {
                image.SelectiveBlur(5.0, 2.0, Quantum.Max / 2);

                using (var original = new MagickImage(Files.NoisePNG))
                {
                    Assert.InRange(original.Compare(image, ErrorMetric.RootMeanSquared), 0.07775, 0.07779);
                }
            }
        }

        [Fact]
        public void Test_SepiaTone()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.SepiaTone();

#if Q8
                ColorAssert.Equal(new MagickColor("#472400"), image, 243, 45);
                ColorAssert.Equal(new MagickColor("#522e00"), image, 394, 394);
                ColorAssert.Equal(new MagickColor("#e4bb7c"), image, 477, 373);
#elif Q16
                ColorAssert.Equal(new MagickColor(OpenCLValue.Get("#45be23e80000", "#475f24bf0000")), image, 243, 45);
                ColorAssert.Equal(new MagickColor(OpenCLValue.Get("#50852d680000", "#52672e770000")), image, 394, 394);
                ColorAssert.Equal(new MagickColor(OpenCLValue.Get("#e273b8c17a35", "#e5adbb627bf2")), image, 477, 373);
#else
                ColorAssert.Equal(new MagickColor(OpenCLValue.Get("#45be23e90001", "#475f24bf0000")), image, 243, 45);
                ColorAssert.Equal(new MagickColor(OpenCLValue.Get("#50862d690001", "#52672e770000")), image, 394, 394);
                ColorAssert.Equal(new MagickColor(OpenCLValue.Get("#e274b8c17a35", "#e5adbb627bf2")), image, 477, 373);
#endif
            }
        }

        [Fact]
        public void Test_SetAttenuate()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.SetAttenuate(5.6);
                Assert.Equal("5.6", image.GetArtifact("attenuate"));
            }
        }

        [Fact]
        public void Test_SetClippingPath()
        {
            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                Assert.False(image.HasClippingPath);

                using (var path = new MagickImage(Files.InvitationTIF))
                {
                    var clippingPath = path.GetClippingPath();

                    image.SetClippingPath(clippingPath);

                    Assert.True(image.HasClippingPath);

                    image.SetClippingPath(clippingPath, "test");

                    Assert.NotNull(image.GetClippingPath("test"));
                    Assert.Null(image.GetClippingPath("#2"));
                }
            }
        }

        [Fact]
        public void Test_Shade()
        {
            using (var image = new MagickImage())
            {
                image.Settings.FontPointsize = 90;
                image.Read("label:Magick.NET");

                image.Shade();

                ColorAssert.Equal(new MagickColor("#7fff7fff7fff"), image, 64, 48);
                ColorAssert.Equal(MagickColors.Black, image, 118, 48);
                ColorAssert.Equal(new MagickColor("#7fff7fff7fff"), image, 148, 48);
            }

            using (var image = new MagickImage())
            {
                image.Settings.FontPointsize = 90;
                image.Read("label:Magick.NET");

                image.Shade(10, 20, false, Channels.Composite);

                ColorAssert.Equal(new MagickColor("#000000000000578e"), image, 64, 48);
                ColorAssert.Equal(new MagickColor("#0000000000000000"), image, 118, 48);
                ColorAssert.Equal(new MagickColor("#578e578e578e578e"), image, 148, 48);
            }
        }

        [Fact]
        public void Test_Shadow()
        {
            using (var image = new MagickImage())
            {
                image.Settings.BackgroundColor = MagickColors.Transparent;
                image.Settings.FontPointsize = 60;
                image.Read("label:Magick.NET");

                var width = image.Width;
                var height = image.Height;

                image.Shadow(2, 2, 5, new Percentage(50), MagickColors.Red);

                Assert.Equal(width + 20, image.Width);
                Assert.Equal(height + 20, image.Height);

                using (var pixels = image.GetPixels())
                {
                    var pixel = pixels.GetPixel(90, 9);
                    Assert.Equal(0, pixel.ToColor().A);

                    pixel = pixels.GetPixel(34, 55);
#if Q8
                    Assert.Equal(68, pixel.ToColor().A);
#else
                    Assert.InRange(pixel.ToColor().A, 17057, 17058);
#endif
                }
            }
        }

        [Fact]
        public void Test_Shave()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.Shave(20, 40);

                Assert.Equal(600, image.Width);
                Assert.Equal(400, image.Height);
            }
        }

        [Fact]
        public void Test_Signature()
        {
            using (var image = new MagickImage())
            {
                Assert.Equal(0, image.Width);
                Assert.Equal(0, image.Height);
                Assert.Equal("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", image.Signature);
            }
        }

        [Fact]
        public void Test_SparseColors()
        {
            var settings = new MagickReadSettings();
            settings.Width = 600;
            settings.Height = 60;

            using (var image = new MagickImage("xc:", settings))
            {
                Assert.Throws<ArgumentNullException>("args", () =>
                {
                    image.SparseColor(Channels.Red, SparseColorMethod.Barycentric, null);
                });

                var args = new List<SparseColorArg>();

                Assert.Throws<ArgumentException>("args", () =>
                {
                    image.SparseColor(Channels.Blue, SparseColorMethod.Barycentric, args);
                });

                using (var pixels = image.GetPixels())
                {
                    ColorAssert.Equal(pixels.GetPixel(0, 0).ToColor(), pixels.GetPixel(599, 59).ToColor());
                }

                Assert.Throws<ArgumentNullException>("color", () =>
                {
                    args.Add(new SparseColorArg(0, 0, null));
                });

                args.Add(new SparseColorArg(0, 0, MagickColors.SkyBlue));
                args.Add(new SparseColorArg(-600, 60, MagickColors.SkyBlue));
                args.Add(new SparseColorArg(600, 60, MagickColors.Black));

                image.SparseColor(SparseColorMethod.Barycentric, args);

                using (var pixels = image.GetPixels())
                {
                    ColorAssert.NotEqual(pixels.GetPixel(0, 0).ToColor(), pixels.GetPixel(599, 59).ToColor());
                }

                Assert.Throws<ArgumentException>("channels", () =>
                {
                    image.SparseColor(Channels.Black, SparseColorMethod.Barycentric, args);
                });
            }
        }

        [Fact]
        public void Test_Sketch()
        {
            using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
            {
                image.Resize(400, 400);

                image.Sketch();
                image.ColorType = ColorType.Bilevel;

                ColorAssert.Equal(MagickColors.White, image, 63, 100);
                ColorAssert.Equal(MagickColors.White, image, 150, 175);
            }
        }

        [Fact]
        public void Test_Solarize()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.Solarize();

                ColorAssert.Equal(MagickColors.Black, image, 125, 125);
                ColorAssert.Equal(new MagickColor("#007f7f"), image, 122, 143);
                ColorAssert.Equal(new MagickColor("#2e6935"), image, 435, 240);
            }
        }

        [Fact]
        public void Test_Splice()
        {
            using (var image = new MagickImage(Files.SnakewarePNG))
            {
                image.BackgroundColor = MagickColors.Fuchsia;
                image.Splice(new MagickGeometry(105, 50, 10, 20));

                Assert.Equal(296, image.Width);
                Assert.Equal(87, image.Height);
                ColorAssert.Equal(MagickColors.Fuchsia, image, 105, 50);
                ColorAssert.Equal(new MagickColor("#0000"), image, 115, 70);
            }
        }

        [Fact]
        public void Test_Spread()
        {
            using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
            {
                image.Spread(10);

                using (var original = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
                {
                    Assert.InRange(original.Compare(image, ErrorMetric.RootMeanSquared), 0.120, 0.123);
                }
            }
        }

        [Fact]
        public void Test_Statistic()
        {
            using (var image = new MagickImage(Files.NoisePNG))
            {
                image.Statistic(StatisticType.Minimum, 10, 1);

                ColorAssert.Equal(MagickColors.Black, image, 42, 119);
                ColorAssert.Equal(new MagickColor("#eeeeeeeeeeee"), image, 90, 120);
                ColorAssert.Equal(new MagickColor("#999999999999"), image, 90, 168);
            }
        }

        [Fact]
        public void Test_Stereo()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.Flop();

                using (var rightImage = new MagickImage(Files.Builtin.Logo))
                {
                    image.Stereo(rightImage);

                    ColorAssert.Equal(new MagickColor("#2222ffffffff"), image, 250, 375);
                    ColorAssert.Equal(new MagickColor("#ffff3e3e9292"), image, 380, 375);
                }
            }
        }

        [Fact]
        public void Test_Swirl()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.Alpha(AlphaOption.Deactivate);

                ColorAssert.Equal(MagickColors.Red, image, 287, 74);
                ColorAssert.NotEqual(MagickColors.White, image, 363, 333);

                image.Swirl(60);

                ColorAssert.NotEqual(MagickColors.Red, image, 287, 74);
                ColorAssert.Equal(MagickColors.White, image, 363, 333);
            }
        }

        [Fact]
        public void Test_SubImageSearch()
        {
            using (var images = new MagickImageCollection())
            {
                images.Add(new MagickImage(MagickColors.Green, 2, 2));
                images.Add(new MagickImage(MagickColors.Red, 2, 2));

                using (var combined = images.AppendHorizontally())
                {
                    using (var searchResult = combined.SubImageSearch(new MagickImage(MagickColors.Red, 1, 1), ErrorMetric.RootMeanSquared))
                    {
                        Assert.NotNull(searchResult);
                        Assert.NotNull(searchResult.SimilarityImage);
                        Assert.NotNull(searchResult.BestMatch);
                        Assert.Equal(0.0, searchResult.SimilarityMetric);
                        Assert.Equal(2, searchResult.BestMatch.X);
                        Assert.Equal(0, searchResult.BestMatch.Y);
                        Assert.Equal(1, searchResult.BestMatch.Width);
                        Assert.Equal(1, searchResult.BestMatch.Height);
                    }
                }
            }
        }

        [Fact]
        public void Test_Texture()
        {
            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                using (var canvas = new MagickImage(MagickColors.Fuchsia, 300, 300))
                {
                    canvas.Texture(image);

                    ColorAssert.Equal(MagickColors.Fuchsia, canvas, 72, 68);
                    ColorAssert.Equal(new MagickColor("#a8a8dfdff8f8"), canvas, 299, 48);
                    ColorAssert.Equal(new MagickColor("#a8a8dfdff8f8"), canvas, 160, 299);
                }
            }
        }

        [Fact]
        public void Test_Tile()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                using (var checkerboard = new MagickImage(Files.Patterns.Checkerboard))
                {
                    image.Opaque(MagickColors.White, MagickColors.Transparent);
                    image.Tile(checkerboard, CompositeOperator.DstOver);

                    ColorAssert.Equal(new MagickColor("#66"), image, 578, 260);
                }
            }
        }

        [Fact]
        public void Test_Tint()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.Settings.FillColor = MagickColors.Gold;
                image.Tint("1x2");
                image.Clamp();

                ColorAssert.Equal(new MagickColor("#dee500000000"), image, 400, 205);
                ColorAssert.Equal(MagickColors.Black, image, 400, 380);
            }
        }

        [Fact]
        public void Test_Threshold()
        {
            using (var image = new MagickImage(Files.ImageMagickJPG))
            {
                using (var memStream = new MemoryStream())
                {
                    image.Threshold(new Percentage(80));
                    image.Settings.Compression = CompressionMethod.Group4;
                    image.Format = MagickFormat.Pdf;
                    image.Write(memStream);
                }
            }
        }

        [Fact]
        public void Test_Thumbnail()
        {
            using (var image = new MagickImage(Files.SnakewarePNG))
            {
                image.Thumbnail(100, 100);
                Assert.Equal(100, image.Width);
                Assert.Equal(23, image.Height);
            }
        }

        [Fact]
        public void Test_ToByteArray()
        {
            using (var image = new MagickImage(Files.SnakewarePNG))
            {
                var bytes = image.ToByteArray(MagickFormat.Dds);

                image.Read(bytes);
                Assert.Equal(CompressionMethod.DXT5, image.Compression);
                Assert.Equal(MagickFormat.Dds, image.Format);

                bytes = image.ToByteArray(MagickFormat.Jpg);

                image.Read(bytes);
                Assert.Equal(MagickFormat.Jpeg, image.Format);

                bytes = image.ToByteArray(MagickFormat.Dds);

                image.Read(bytes);
                Assert.Equal(CompressionMethod.DXT1, image.Compression);
                Assert.Equal(MagickFormat.Dds, image.Format);
            }
        }

        [Fact]
        public void Test_ToString()
        {
            using (var image = new MagickImage(Files.Builtin.Wizard))
            {
                Assert.Equal("Gif 480x640 8-bit sRGB", image.ToString());
            }

            using (var image = new MagickImage(Files.TestPNG))
            {
                Assert.Equal("Png 150x100 16-bit sRGB", image.ToString());
            }
        }

        [Fact]
        public void Test_TotalColors()
        {
            using (var image = new MagickImage())
            {
                Assert.Equal(0, image.TotalColors);

                image.Read(Files.Builtin.Logo);
                Assert.NotEqual(0, image.TotalColors);
            }
        }

        [Fact]
        public void Test_Transparent()
        {
            var red = new MagickColor("red");
            var transparentRed = new MagickColor("red");
            transparentRed.A = 0;

            using (var image = new MagickImage(Files.RedPNG))
            {
                ColorAssert.Equal(red, image, 0, 0);

                image.Transparent(red);

                ColorAssert.Equal(transparentRed, image, 0, 0);
                ColorAssert.NotEqual(transparentRed, image, image.Width - 1, 0);
            }

            using (var image = new MagickImage(Files.RedPNG))
            {
                ColorAssert.Equal(red, image, 0, 0);

                image.InverseTransparent(red);

                ColorAssert.NotEqual(transparentRed, image, 0, 0);
                ColorAssert.Equal(transparentRed, image, image.Width - 1, 0);
            }
        }

        [Fact]
        public void Test_TransparentChroma()
        {
            using (var image = new MagickImage(Files.TestPNG))
            {
                image.TransparentChroma(MagickColors.Black, MagickColors.WhiteSmoke);

                ColorAssert.Equal(new MagickColor("#3962396239620000"), image, 50, 50);
                ColorAssert.Equal(new MagickColor("#0000"), image, 32, 80);
                ColorAssert.Equal(new MagickColor("#f6def6def6deffff"), image, 132, 42);
                ColorAssert.Equal(new MagickColor("#0000808000000000"), image, 74, 79);
            }

            using (var image = new MagickImage(Files.TestPNG))
            {
                image.InverseTransparentChroma(MagickColors.Black, MagickColors.WhiteSmoke);

                ColorAssert.Equal(new MagickColor("#396239623962ffff"), image, 50, 50);
                ColorAssert.Equal(new MagickColor("#000f"), image, 32, 80);
                ColorAssert.Equal(new MagickColor("#f6def6def6de0000"), image, 132, 42);
                ColorAssert.Equal(new MagickColor("#000080800000ffff"), image, 74, 79);
            }
        }

        [Fact]
        public void Test_Transpose()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.Transpose();

                Assert.Equal(480, image.Width);
                Assert.Equal(640, image.Height);

                ColorAssert.Equal(MagickColors.Red, image, 61, 292);
                ColorAssert.Equal(new MagickColor("#f5f5eeee3636"), image, 104, 377);
                ColorAssert.Equal(new MagickColor("#eded1f1f2424"), image, 442, 391);
            }
        }

        [Fact]
        public void Test_Transverse()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.Transverse();

                Assert.Equal(480, image.Width);
                Assert.Equal(640, image.Height);

                ColorAssert.Equal(MagickColors.Red, image, 330, 508);
                ColorAssert.Equal(new MagickColor("#f5f5eeee3636"), image, 288, 474);
                ColorAssert.Equal(new MagickColor("#cdcd20202727"), image, 30, 123);
            }
        }

        [Fact]
        public void Test_UniqueColors()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                using (var uniqueColors = image.UniqueColors())
                {
                    Assert.Equal(1, uniqueColors.Height);
                    Assert.Equal(256, uniqueColors.Width);
                }
            }
        }

        [Fact]
        public void Test_UnsharpMask()
        {
            using (var image = new MagickImage(Files.NoisePNG))
            {
                image.UnsharpMask(7.0, 3.0);

                using (var original = new MagickImage(Files.NoisePNG))
                {
#if Q8 || Q16
                    Assert.InRange(original.Compare(image, ErrorMetric.RootMeanSquared), 0.06476, 0.06478);
#else
                    Assert.InRange(original.Compare(image, ErrorMetric.RootMeanSquared), 0.10234, 0.10235);
#endif
                }
            }
        }

        [Fact]
        public void Test_Vignette()
        {
            using (var image = new MagickImage(Files.Builtin.Logo))
            {
                image.BackgroundColor = MagickColors.Aqua;
                image.Vignette();

                ColorAssert.Equal(new MagickColor("#6480ffffffff"), image, 292, 0);
                ColorAssert.Equal(new MagickColor("#91acffffffff"), image, 358, 479);
            }
        }

        [Fact]
        public void Test_VirtualPixelMethod()
        {
            using (var image = new MagickImage())
            {
                Assert.Equal(VirtualPixelMethod.Undefined, image.VirtualPixelMethod);
                image.VirtualPixelMethod = VirtualPixelMethod.Random;
                Assert.Equal(VirtualPixelMethod.Random, image.VirtualPixelMethod);
            }
        }

        [Fact]
        public void Test_Wave()
        {
            using (var image = new MagickImage(Files.TestPNG))
            {
                image.Wave();

                using (var original = new MagickImage(Files.TestPNG))
                {
                    Assert.InRange(original.Compare(image, ErrorMetric.RootMeanSquared), 0.62619, 0.62623);
                }
            }
        }

        [Fact]
        public void Test_WaveletDenoise()
        {
            using (var image = new MagickImage(Files.NoisePNG))
            {
#if Q8
                var color = new MagickColor("#dd");
#elif Q16
                var color = new MagickColor(OpenCLValue.Get("#dea4dea4dea4", "#deb5deb5deb5"));
#else
                var color = new MagickColor(OpenCLValue.Get("#dea5dea5dea5", "#deb5deb5deb5"));
#endif

                ColorAssert.NotEqual(color, image, 130, 123);

                image.ColorType = ColorType.TrueColor;
                image.WaveletDenoise((Percentage)25);

                ColorAssert.Equal(color, image, 130, 123);
            }
        }

        [Fact]
        public void Test_WhiteThreshold()
        {
            using (var image = new MagickImage(Files.MagickNETIconPNG))
            {
                image.WhiteThreshold(new Percentage(10));
                ColorAssert.Equal(MagickColors.White, image, 43, 74);
                ColorAssert.Equal(MagickColors.White, image, 60, 74);
            }
        }
    }
}
