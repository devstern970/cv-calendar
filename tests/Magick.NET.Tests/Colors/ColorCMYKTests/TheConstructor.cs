﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
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
    public partial class ColorCMYKTests
    {
        public class TheConstructor
        {
            [Fact]
            public void ShouldThrowExceptionWhenColorIsNull()
            {
                Assert.Throws<ArgumentNullException>("color", () =>
                {
                    new ColorCMYK(null);
                });
            }

            [Fact]
            public void ShouldThrowExceptionWhenColorIsEmpty()
            {
                Assert.Throws<ArgumentException>("color", () =>
                {
                    new ColorCMYK(string.Empty);
                });
            }

            [Fact]
            public void ShouldThrowExceptionWhenColorDoesNotStartWithHash()
            {
                Assert.Throws<ArgumentException>("color", () =>
                {
                    new ColorCMYK("FFFFFF");
                });
            }

            [Fact]
            public void ShouldThrowExceptionWhenColorHasInvalidLength()
            {
                Assert.Throws<ArgumentException>("color", () =>
                {
                    new ColorCMYK("#FFFFF");
                });
            }

            [Fact]
            public void ShouldThrowExceptionWhenColorHasInvalidHexValue()
            {
                Assert.Throws<ArgumentException>("color", () =>
                {
                    new ColorCMYK("#FGF");
                });

                Assert.Throws<ArgumentException>("color", () =>
                {
                    new ColorCMYK("#GGFFFF");
                });

                Assert.Throws<ArgumentException>("color", () =>
                {
                    new ColorCMYK("#FFFG000000000000");
                });
            }

            [Fact]
            public void ShouldConvertPercentageToColor()
            {
                var color = new ColorCMYK((Percentage)0, (Percentage)100, (Percentage)0, (Percentage)100);
                Assert.Equal(0, color.C);
                Assert.Equal(Quantum.Max, color.M);
                Assert.Equal(0, color.Y);
                Assert.Equal(Quantum.Max, color.K);
                Assert.Equal(Quantum.Max, color.A);

                color = new ColorCMYK((Percentage)100, (Percentage)0, (Percentage)100, (Percentage)0, (Percentage)100);
                Assert.Equal(Quantum.Max, color.C);
                Assert.Equal(0, color.M);
                Assert.Equal(Quantum.Max, color.Y);
                Assert.Equal(0, color.K);
                Assert.Equal(Quantum.Max, color.A);
            }

            [Fact]
            public void ShouldConvertHexValueToColor()
            {
                var color = new ColorCMYK("#0ff0");
                Assert.Equal(0, color.C);
                Assert.Equal(Quantum.Max, color.M);
                Assert.Equal(Quantum.Max, color.Y);
                Assert.Equal(0, color.K);
                Assert.Equal(Quantum.Max, color.A);

                color = new ColorCMYK("#ff00ff00");
                Assert.Equal(Quantum.Max, color.C);
                Assert.Equal(0, color.M);
                Assert.Equal(Quantum.Max, color.Y);
                Assert.Equal(0, color.K);
                Assert.Equal(Quantum.Max, color.A);

                color = new ColorCMYK("#0000ffff0000ffff");
                Assert.Equal(0, color.C);
                Assert.Equal(Quantum.Max, color.M);
                Assert.Equal(0, color.Y);
                Assert.Equal(Quantum.Max, color.K);
                Assert.Equal(Quantum.Max, color.A);
            }
        }
    }
}
