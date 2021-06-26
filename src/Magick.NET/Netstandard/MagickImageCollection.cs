﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if NETSTANDARD
using System.IO;
using System.Threading.Tasks;

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
    /// <content />
    public sealed partial class MagickImageCollection : IMagickImageCollection<QuantumType>
    {
        /// <summary>
        /// Read all image frames.
        /// </summary>
        /// <param name="stream">The stream to read the image data from.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task ReadAsync(Stream stream)
            => ReadAsync(stream, null);

        /// <summary>
        /// Read all image frames.
        /// </summary>
        /// <param name="stream">The stream to read the image data from.</param>
        /// <param name="format">The format to use.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task ReadAsync(Stream stream, MagickFormat format)
            => ReadAsync(stream, new MagickReadSettings { Format = format });

        /// <summary>
        /// Read all image frames.
        /// </summary>
        /// <param name="stream">The stream to read the image data from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task ReadAsync(Stream stream, IMagickReadSettings<QuantumType>? readSettings)
        {
            Throw.IfNull(nameof(stream), stream);

            using (var memStream = new MemoryStream())
            {
                await stream.CopyToAsync(memStream).ConfigureAwait(false);

                memStream.Position = 0;
                Clear();
                AddImages(memStream, readSettings, false);
            }
        }

        /// <summary>
        /// Writes the imagse to the specified stream. If the output image's file format does not
        /// allow multi-image files multiple files will be written.
        /// </summary>
        /// <param name="stream">The stream to write the images to.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task WriteAsync(Stream stream)
        {
            Throw.IfNull(nameof(stream), stream);

            if (_images.Count == 0)
                return;

            var settings = _images[0].GetSettings().Clone();
            settings.FileName = null;

            try
            {
                AttachImages();

                var bytes = ToByteArray();
                await stream.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            }
            finally
            {
                DetachImages();
            }
        }

        /// <summary>
        /// Writes the imagse to the specified stream. If the output image's file format does not
        /// allow multi-image files multiple files will be written.
        /// </summary>
        /// <param name="stream">The stream to write the images to.</param>
        /// <param name="defines">The defines to set.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task WriteAsync(Stream stream, IWriteDefines defines)
        {
            SetDefines(defines);
            SetFormat(defines.Format);
            return WriteAsync(stream);
        }

        /// <summary>
        /// Writes the image to the specified stream.
        /// </summary>
        /// <param name="stream">The stream to write the image data to.</param>
        /// <param name="format">The format to use.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task WriteAsync(Stream stream, MagickFormat format)
        {
            SetFormat(format);
            return WriteAsync(stream);
        }
    }
}

#endif
