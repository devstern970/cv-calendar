// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System.Collections.Generic;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ImageMagick;
[System.CodeDom.Compiler.GeneratedCode("Magick.NET.FileGenerator", "")]
public sealed partial class Paths
{
    /// <summary>
    /// Applies the PathArcAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="coordinates">The coordinates to use.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> ArcAbs(params PathArc[] coordinates)
    {
        _paths.Add(new PathArcAbs(coordinates));
        return this;
    }

    /// <summary>
    /// Applies the PathArcAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="coordinates">The coordinates to use.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> ArcAbs(IEnumerable<PathArc> coordinates)
    {
        _paths.Add(new PathArcAbs(coordinates));
        return this;
    }

    /// <summary>
    /// Applies the PathArcRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="coordinates">The coordinates to use.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> ArcRel(params PathArc[] coordinates)
    {
        _paths.Add(new PathArcRel(coordinates));
        return this;
    }

    /// <summary>
    /// Applies the PathArcRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="coordinates">The coordinates to use.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> ArcRel(IEnumerable<PathArc> coordinates)
    {
        _paths.Add(new PathArcRel(coordinates));
        return this;
    }

    /// <summary>
    /// Applies the PathClose operation to the <see cref="Paths" />.
    /// </summary>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> Close()
    {
        _paths.Add(new PathClose());
        return this;
    }

    /// <summary>
    /// Applies the PathCurveToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="controlPointStart">Coordinate of control point for curve beginning.</param>
    /// <param name="controlPointEnd">Coordinate of control point for curve ending.</param>
    /// <param name="end">Coordinate of the end of the curve.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> CurveToAbs(PointD controlPointStart, PointD controlPointEnd, PointD end)
    {
        _paths.Add(new PathCurveToAbs(controlPointStart, controlPointEnd, end));
        return this;
    }

    /// <summary>
    /// Applies the PathCurveToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x1">X coordinate of control point for curve beginning.</param>
    /// <param name="y1">Y coordinate of control point for curve beginning.</param>
    /// <param name="x2">X coordinate of control point for curve ending.</param>
    /// <param name="y2">Y coordinate of control point for curve ending.</param>
    /// <param name="x">X coordinate of the end of the curve.</param>
    /// <param name="y">Y coordinate of the end of the curve.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> CurveToAbs(double x1, double y1, double x2, double y2, double x, double y)
    {
        _paths.Add(new PathCurveToAbs(x1, y1, x2, y2, x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathCurveToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="controlPointStart">Coordinate of control point for curve beginning.</param>
    /// <param name="controlPointEnd">Coordinate of control point for curve ending.</param>
    /// <param name="end">Coordinate of the end of the curve.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> CurveToRel(PointD controlPointStart, PointD controlPointEnd, PointD end)
    {
        _paths.Add(new PathCurveToRel(controlPointStart, controlPointEnd, end));
        return this;
    }

    /// <summary>
    /// Applies the PathCurveToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x1">X coordinate of control point for curve beginning.</param>
    /// <param name="y1">Y coordinate of control point for curve beginning.</param>
    /// <param name="x2">X coordinate of control point for curve ending.</param>
    /// <param name="y2">Y coordinate of control point for curve ending.</param>
    /// <param name="x">X coordinate of the end of the curve.</param>
    /// <param name="y">Y coordinate of the end of the curve.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> CurveToRel(double x1, double y1, double x2, double y2, double x, double y)
    {
        _paths.Add(new PathCurveToRel(x1, y1, x2, y2, x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathLineToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="coordinates">The coordinates to use.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> LineToAbs(params PointD[] coordinates)
    {
        _paths.Add(new PathLineToAbs(coordinates));
        return this;
    }

    /// <summary>
    /// Applies the PathLineToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="coordinates">The coordinates to use.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> LineToAbs(IEnumerable<PointD> coordinates)
    {
        _paths.Add(new PathLineToAbs(coordinates));
        return this;
    }

    /// <summary>
    /// Applies the PathLineToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <param name="y">The Y coordinate.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> LineToAbs(double x, double y)
    {
        _paths.Add(new PathLineToAbs(x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathLineToHorizontalAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> LineToHorizontalAbs(double x)
    {
        _paths.Add(new PathLineToHorizontalAbs(x));
        return this;
    }

    /// <summary>
    /// Applies the PathLineToHorizontalRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> LineToHorizontalRel(double x)
    {
        _paths.Add(new PathLineToHorizontalRel(x));
        return this;
    }

    /// <summary>
    /// Applies the PathLineToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="coordinates">The coordinates to use.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> LineToRel(params PointD[] coordinates)
    {
        _paths.Add(new PathLineToRel(coordinates));
        return this;
    }

    /// <summary>
    /// Applies the PathLineToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="coordinates">The coordinates to use.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> LineToRel(IEnumerable<PointD> coordinates)
    {
        _paths.Add(new PathLineToRel(coordinates));
        return this;
    }

    /// <summary>
    /// Applies the PathLineToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <param name="y">The Y coordinate.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> LineToRel(double x, double y)
    {
        _paths.Add(new PathLineToRel(x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathLineToVerticalAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="y">The Y coordinate.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> LineToVerticalAbs(double y)
    {
        _paths.Add(new PathLineToVerticalAbs(y));
        return this;
    }

    /// <summary>
    /// Applies the PathLineToVerticalRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="y">The Y coordinate.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> LineToVerticalRel(double y)
    {
        _paths.Add(new PathLineToVerticalRel(y));
        return this;
    }

    /// <summary>
    /// Applies the PathMoveToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="coordinate">The coordinate to use.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> MoveToAbs(PointD coordinate)
    {
        _paths.Add(new PathMoveToAbs(coordinate));
        return this;
    }

    /// <summary>
    /// Applies the PathMoveToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <param name="y">The Y coordinate.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> MoveToAbs(double x, double y)
    {
        _paths.Add(new PathMoveToAbs(x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathMoveToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="coordinate">The coordinate to use.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> MoveToRel(PointD coordinate)
    {
        _paths.Add(new PathMoveToRel(coordinate));
        return this;
    }

    /// <summary>
    /// Applies the PathMoveToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <param name="y">The Y coordinate.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> MoveToRel(double x, double y)
    {
        _paths.Add(new PathMoveToRel(x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathQuadraticCurveToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="controlPoint">Coordinate of control point.</param>
    /// <param name="end">Coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> QuadraticCurveToAbs(PointD controlPoint, PointD end)
    {
        _paths.Add(new PathQuadraticCurveToAbs(controlPoint, end));
        return this;
    }

    /// <summary>
    /// Applies the PathQuadraticCurveToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x1">X coordinate of control point.</param>
    /// <param name="y1">Y coordinate of control point.</param>
    /// <param name="x">X coordinate of final point.</param>
    /// <param name="y">Y coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> QuadraticCurveToAbs(double x1, double y1, double x, double y)
    {
        _paths.Add(new PathQuadraticCurveToAbs(x1, y1, x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathQuadraticCurveToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="controlPoint">Coordinate of control point.</param>
    /// <param name="end">Coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> QuadraticCurveToRel(PointD controlPoint, PointD end)
    {
        _paths.Add(new PathQuadraticCurveToRel(controlPoint, end));
        return this;
    }

    /// <summary>
    /// Applies the PathQuadraticCurveToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x1">X coordinate of control point.</param>
    /// <param name="y1">Y coordinate of control point.</param>
    /// <param name="x">X coordinate of final point.</param>
    /// <param name="y">Y coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> QuadraticCurveToRel(double x1, double y1, double x, double y)
    {
        _paths.Add(new PathQuadraticCurveToRel(x1, y1, x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathSmoothCurveToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="controlPoint">Coordinate of second point.</param>
    /// <param name="end">Coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> SmoothCurveToAbs(PointD controlPoint, PointD end)
    {
        _paths.Add(new PathSmoothCurveToAbs(controlPoint, end));
        return this;
    }

    /// <summary>
    /// Applies the PathSmoothCurveToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x2">X coordinate of second point.</param>
    /// <param name="y2">Y coordinate of second point.</param>
    /// <param name="x">X coordinate of final point.</param>
    /// <param name="y">Y coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> SmoothCurveToAbs(double x2, double y2, double x, double y)
    {
        _paths.Add(new PathSmoothCurveToAbs(x2, y2, x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathSmoothCurveToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="controlPoint">Coordinate of second point.</param>
    /// <param name="end">Coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> SmoothCurveToRel(PointD controlPoint, PointD end)
    {
        _paths.Add(new PathSmoothCurveToRel(controlPoint, end));
        return this;
    }

    /// <summary>
    /// Applies the PathSmoothCurveToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x2">X coordinate of second point.</param>
    /// <param name="y2">Y coordinate of second point.</param>
    /// <param name="x">X coordinate of final point.</param>
    /// <param name="y">Y coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> SmoothCurveToRel(double x2, double y2, double x, double y)
    {
        _paths.Add(new PathSmoothCurveToRel(x2, y2, x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathSmoothQuadraticCurveToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="end">Coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> SmoothQuadraticCurveToAbs(PointD end)
    {
        _paths.Add(new PathSmoothQuadraticCurveToAbs(end));
        return this;
    }

    /// <summary>
    /// Applies the PathSmoothQuadraticCurveToAbs operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x">X coordinate of final point.</param>
    /// <param name="y">Y coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> SmoothQuadraticCurveToAbs(double x, double y)
    {
        _paths.Add(new PathSmoothQuadraticCurveToAbs(x, y));
        return this;
    }

    /// <summary>
    /// Applies the PathSmoothQuadraticCurveToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="end">Coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> SmoothQuadraticCurveToRel(PointD end)
    {
        _paths.Add(new PathSmoothQuadraticCurveToRel(end));
        return this;
    }

    /// <summary>
    /// Applies the PathSmoothQuadraticCurveToRel operation to the <see cref="Paths" />.
    /// </summary>
    /// <param name="x">X coordinate of final point.</param>
    /// <param name="y">Y coordinate of final point.</param>
    /// <returns>The <see cref="Paths" /> instance.</returns>
    public IPaths<QuantumType> SmoothQuadraticCurveToRel(double x, double y)
    {
        _paths.Add(new PathSmoothQuadraticCurveToRel(x, y));
        return this;
    }

}
