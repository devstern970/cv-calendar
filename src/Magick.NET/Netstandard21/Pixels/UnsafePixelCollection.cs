﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if NETSTANDARD2_1

using System;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ImageMagick
{
    internal sealed partial class UnsafePixelCollection : PixelCollection, IUnsafePixelCollection<QuantumType>
    {
        public override void SetArea(IMagickGeometry geometry, ReadOnlySpan<QuantumType> values)
        {
            if (geometry != null)
                base.SetArea(geometry, values);
        }
    }
}

#endif
