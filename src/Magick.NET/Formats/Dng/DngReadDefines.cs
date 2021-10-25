﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick.Formats
{
    /// <summary>
    /// Class for defines that are used when a <see cref="MagickFormat.Dng"/> image is read.
    /// </summary>
    public sealed class DngReadDefines : ReadDefinesCreator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DngReadDefines"/> class.
        /// </summary>
        public DngReadDefines()
          : base(MagickFormat.Dng)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating wether auto brightness should be used (dng:no-auto-bright).
        /// </summary>
        public bool? DisableAutoBrightness { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the interpolation quality (dng:interpolation-quality).
        /// </summary>
        public DngInterpolation? InterpolationQuality { get; set; }

        /// <summary>
        /// Gets or sets the output color (dng:output-color).
        /// </summary>
        public DngOutputColor? OutputColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wether the embedded thumbnail should be read (dng:read-thumbnail).
        /// </summary>
        public bool? ReadThumbnail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wether auto whitebalance should be used (dng:use-auto-wb).
        /// </summary>
        public bool? UseAutoWhitebalance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wether the whitebalance of the camera should be used (dng:use-camera-wb).
        /// </summary>
        public bool? UseCameraWhitebalance { get; set; }

        /// <summary>
        /// Gets the defines that should be set as a define on an image.
        /// </summary>
        public override IEnumerable<IDefine> Defines
        {
            get
            {
                if (InterpolationQuality.HasValue)
                    yield return CreateDefine("interpolation-quality", (int)InterpolationQuality.Value);

                if (DisableAutoBrightness.HasValue)
                    yield return CreateDefine("no-auto-bright", DisableAutoBrightness.Value);

                if (OutputColor.HasValue)
                    yield return CreateDefine("output-color", (int)OutputColor.Value);

                if (ReadThumbnail.HasValue)
                    yield return CreateDefine("read-thumbnail", ReadThumbnail.Value);

                if (UseCameraWhitebalance.HasValue)
                    yield return CreateDefine("use-camera-wb", UseCameraWhitebalance.Value);

                if (UseAutoWhitebalance.HasValue)
                    yield return CreateDefine("use-auto-wb", UseAutoWhitebalance.Value);
            }
        }
    }
}
