// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace ImageMagick.Drawing;

/// <summary>
/// Sets the font pointsize to use when annotating with text.
/// </summary>
public sealed class DrawableFontPointSize : IDrawableFontPointSize, IDrawingWand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DrawableFontPointSize"/> class.
    /// </summary>
    /// <param name="pointSize">The point size.</param>
    public DrawableFontPointSize(double pointSize)
    {
        PointSize = pointSize;
    }

    /// <summary>
    /// Gets the point size.
    /// </summary>
    public double PointSize { get; }

    /// <summary>
    /// Draws this instance with the drawing wand.
    /// </summary>
    /// <param name="wand">The want to draw on.</param>
    void IDrawingWand.Draw(DrawingWand wand)
        => wand?.FontPointSize(PointSize);
}
