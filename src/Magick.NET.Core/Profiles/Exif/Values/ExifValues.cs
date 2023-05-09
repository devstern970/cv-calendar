﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace ImageMagick;

internal static partial class ExifValues
{
    public static ExifValue? Create(ExifTagValue tag)
        => CreateValue(tag);

    public static ExifValue? Create(ExifTag tag)
        => CreateValue((ExifTagValue)(ushort)tag);

    public static ExifValue? Create(ExifTagValue tag, ExifDataType dataType, uint numberOfComponents)
    {
        var isArray = numberOfComponents != 1;

        return dataType switch
        {
            ExifDataType.Byte => isArray ? new ExifByteArray(tag, dataType) : new ExifByte(tag, dataType),
            ExifDataType.Double => isArray ? new ExifDoubleArray(tag) : new ExifDouble(tag),
            ExifDataType.Float => isArray ? new ExifFloatArray(tag) : new ExifFloat(tag),
            ExifDataType.Long => isArray ? new ExifLongArray(tag) : new ExifLong(tag),
            ExifDataType.Rational => isArray ? new ExifRationalArray(tag) : new ExifRational(tag),
            ExifDataType.Short => isArray ? new ExifShortArray(tag) : new ExifShort(tag),
            ExifDataType.SignedByte => isArray ? new ExifSignedByteArray(tag) : new ExifSignedByte(tag),
            ExifDataType.SignedLong => isArray ? new ExifSignedLongArray(tag) : new ExifSignedLong(tag),
            ExifDataType.SignedRational => isArray ? new ExifSignedRationalArray(tag) : new ExifSignedRational(tag),
            ExifDataType.SignedShort => isArray ? new ExifSignedShortArray(tag) : new ExifSignedShort(tag),
            ExifDataType.String => new ExifString(tag),
            ExifDataType.Undefined => isArray ? new ExifByteArray(tag, dataType) : new ExifByte(tag, dataType),
            _ => null,
        };
    }

    private static ExifValue? CreateValue(ExifTagValue tag)
        => tag switch
        {
            ExifTagValue.FaxProfile => new ExifByte(ExifTag.FaxProfile, ExifDataType.Byte),
            ExifTagValue.ModeNumber => new ExifByte(ExifTag.ModeNumber, ExifDataType.Byte),
            ExifTagValue.GPSAltitudeRef => new ExifByte(ExifTag.GPSAltitudeRef, ExifDataType.Byte),

            ExifTagValue.ClipPath => new ExifByteArray(ExifTag.ClipPath, ExifDataType.Byte),
            ExifTagValue.VersionYear => new ExifByteArray(ExifTag.VersionYear, ExifDataType.Byte),
            ExifTagValue.XMP => new ExifByteArray(ExifTag.XMP, ExifDataType.Byte),
            ExifTagValue.CFAPattern2 => new ExifByteArray(ExifTag.CFAPattern2, ExifDataType.Byte),
            ExifTagValue.TIFFEPStandardID => new ExifByteArray(ExifTag.TIFFEPStandardID, ExifDataType.Byte),
            ExifTagValue.XPTitle => new ExifByteArray(ExifTag.XPTitle, ExifDataType.Byte),
            ExifTagValue.XPComment => new ExifByteArray(ExifTag.XPComment, ExifDataType.Byte),
            ExifTagValue.XPAuthor => new ExifByteArray(ExifTag.XPAuthor, ExifDataType.Byte),
            ExifTagValue.XPKeywords => new ExifByteArray(ExifTag.XPKeywords, ExifDataType.Byte),
            ExifTagValue.XPSubject => new ExifByteArray(ExifTag.XPSubject, ExifDataType.Byte),
            ExifTagValue.GPSVersionID => new ExifByteArray(ExifTag.GPSVersionID, ExifDataType.Byte),

            ExifTagValue.PixelScale => new ExifDoubleArray(ExifTag.PixelScale),
            ExifTagValue.IntergraphMatrix => new ExifDoubleArray(ExifTag.IntergraphMatrix),
            ExifTagValue.ModelTiePoint => new ExifDoubleArray(ExifTag.ModelTiePoint),
            ExifTagValue.ModelTransform => new ExifDoubleArray(ExifTag.ModelTransform),

            ExifTagValue.SubfileType => new ExifLong(ExifTag.SubfileType),
            ExifTagValue.SubIFDOffset => new ExifLong(ExifTag.SubIFDOffset),
            ExifTagValue.GPSIFDOffset => new ExifLong(ExifTag.GPSIFDOffset),
            ExifTagValue.T4Options => new ExifLong(ExifTag.T4Options),
            ExifTagValue.T6Options => new ExifLong(ExifTag.T6Options),
            ExifTagValue.XClipPathUnits => new ExifLong(ExifTag.XClipPathUnits),
            ExifTagValue.YClipPathUnits => new ExifLong(ExifTag.YClipPathUnits),
            ExifTagValue.ProfileType => new ExifLong(ExifTag.ProfileType),
            ExifTagValue.CodingMethods => new ExifLong(ExifTag.CodingMethods),
            ExifTagValue.T82ptions => new ExifLong(ExifTag.T82ptions),
            ExifTagValue.JPEGInterchangeFormat => new ExifLong(ExifTag.JPEGInterchangeFormat),
            ExifTagValue.JPEGInterchangeFormatLength => new ExifLong(ExifTag.JPEGInterchangeFormatLength),
            ExifTagValue.MDFileTag => new ExifLong(ExifTag.MDFileTag),
            ExifTagValue.StandardOutputSensitivity => new ExifLong(ExifTag.StandardOutputSensitivity),
            ExifTagValue.RecommendedExposureIndex => new ExifLong(ExifTag.RecommendedExposureIndex),
            ExifTagValue.ISOSpeed => new ExifLong(ExifTag.ISOSpeed),
            ExifTagValue.ISOSpeedLatitudeyyy => new ExifLong(ExifTag.ISOSpeedLatitudeyyy),
            ExifTagValue.ISOSpeedLatitudezzz => new ExifLong(ExifTag.ISOSpeedLatitudezzz),
            ExifTagValue.FaxRecvParams => new ExifLong(ExifTag.FaxRecvParams),
            ExifTagValue.FaxRecvTime => new ExifLong(ExifTag.FaxRecvTime),
            ExifTagValue.ImageNumber => new ExifLong(ExifTag.ImageNumber),

            ExifTagValue.FreeOffsets => new ExifLongArray(ExifTag.FreeOffsets),
            ExifTagValue.FreeByteCounts => new ExifLongArray(ExifTag.FreeByteCounts),
            ExifTagValue.ColorResponseUnit => new ExifLongArray(ExifTag.ColorResponseUnit),
            ExifTagValue.TileOffsets => new ExifLongArray(ExifTag.TileOffsets),
            ExifTagValue.SMinSampleValue => new ExifLongArray(ExifTag.SMinSampleValue),
            ExifTagValue.SMaxSampleValue => new ExifLongArray(ExifTag.SMaxSampleValue),
            ExifTagValue.JPEGQTables => new ExifLongArray(ExifTag.JPEGQTables),
            ExifTagValue.JPEGDCTables => new ExifLongArray(ExifTag.JPEGDCTables),
            ExifTagValue.JPEGACTables => new ExifLongArray(ExifTag.JPEGACTables),
            ExifTagValue.StripRowCounts => new ExifLongArray(ExifTag.StripRowCounts),
            ExifTagValue.IntergraphRegisters => new ExifLongArray(ExifTag.IntergraphRegisters),
            ExifTagValue.TimeZoneOffset => new ExifLongArray(ExifTag.TimeZoneOffset),

            ExifTagValue.ImageWidth => new ExifNumber(ExifTag.ImageWidth),
            ExifTagValue.ImageLength => new ExifNumber(ExifTag.ImageLength),
            ExifTagValue.RowsPerStrip => new ExifNumber(ExifTag.RowsPerStrip),
            ExifTagValue.StripByteCounts => new ExifNumber(ExifTag.StripByteCounts),
            ExifTagValue.TileWidth => new ExifNumber(ExifTag.TileWidth),
            ExifTagValue.TileLength => new ExifNumber(ExifTag.TileLength),
            ExifTagValue.BadFaxLines => new ExifNumber(ExifTag.BadFaxLines),
            ExifTagValue.ConsecutiveBadFaxLines => new ExifNumber(ExifTag.ConsecutiveBadFaxLines),
            ExifTagValue.PixelXDimension => new ExifNumber(ExifTag.PixelXDimension),
            ExifTagValue.PixelYDimension => new ExifNumber(ExifTag.PixelYDimension),

            ExifTagValue.StripOffsets => new ExifNumberArray(ExifTag.StripOffsets),
            ExifTagValue.TileByteCounts => new ExifNumberArray(ExifTag.TileByteCounts),
            ExifTagValue.ImageLayer => new ExifNumberArray(ExifTag.ImageLayer),

            ExifTagValue.XPosition => new ExifRational(ExifTag.XPosition),
            ExifTagValue.YPosition => new ExifRational(ExifTag.YPosition),
            ExifTagValue.XResolution => new ExifRational(ExifTag.XResolution),
            ExifTagValue.YResolution => new ExifRational(ExifTag.YResolution),
            ExifTagValue.BatteryLevel => new ExifRational(ExifTag.BatteryLevel),
            ExifTagValue.ExposureTime => new ExifRational(ExifTag.ExposureTime),
            ExifTagValue.FNumber => new ExifRational(ExifTag.FNumber),
            ExifTagValue.MDScalePixel => new ExifRational(ExifTag.MDScalePixel),
            ExifTagValue.CompressedBitsPerPixel => new ExifRational(ExifTag.CompressedBitsPerPixel),
            ExifTagValue.ApertureValue => new ExifRational(ExifTag.ApertureValue),
            ExifTagValue.MaxApertureValue => new ExifRational(ExifTag.MaxApertureValue),
            ExifTagValue.SubjectDistance => new ExifRational(ExifTag.SubjectDistance),
            ExifTagValue.FocalLength => new ExifRational(ExifTag.FocalLength),
            ExifTagValue.FlashEnergy2 => new ExifRational(ExifTag.FlashEnergy2),
            ExifTagValue.FocalPlaneXResolution2 => new ExifRational(ExifTag.FocalPlaneXResolution2),
            ExifTagValue.FocalPlaneYResolution2 => new ExifRational(ExifTag.FocalPlaneYResolution2),
            ExifTagValue.ExposureIndex2 => new ExifRational(ExifTag.ExposureIndex2),
            ExifTagValue.Humidity => new ExifRational(ExifTag.Humidity),
            ExifTagValue.Pressure => new ExifRational(ExifTag.Pressure),
            ExifTagValue.Acceleration => new ExifRational(ExifTag.Acceleration),
            ExifTagValue.FlashEnergy => new ExifRational(ExifTag.FlashEnergy),
            ExifTagValue.FocalPlaneXResolution => new ExifRational(ExifTag.FocalPlaneXResolution),
            ExifTagValue.FocalPlaneYResolution => new ExifRational(ExifTag.FocalPlaneYResolution),
            ExifTagValue.ExposureIndex => new ExifRational(ExifTag.ExposureIndex),
            ExifTagValue.DigitalZoomRatio => new ExifRational(ExifTag.DigitalZoomRatio),
            ExifTagValue.GPSAltitude => new ExifRational(ExifTag.GPSAltitude),
            ExifTagValue.GPSDOP => new ExifRational(ExifTag.GPSDOP),
            ExifTagValue.GPSSpeed => new ExifRational(ExifTag.GPSSpeed),
            ExifTagValue.GPSTrack => new ExifRational(ExifTag.GPSTrack),
            ExifTagValue.GPSImgDirection => new ExifRational(ExifTag.GPSImgDirection),
            ExifTagValue.GPSDestBearing => new ExifRational(ExifTag.GPSDestBearing),
            ExifTagValue.GPSDestDistance => new ExifRational(ExifTag.GPSDestDistance),

            ExifTagValue.WhitePoint => new ExifRationalArray(ExifTag.WhitePoint),
            ExifTagValue.PrimaryChromaticities => new ExifRationalArray(ExifTag.PrimaryChromaticities),
            ExifTagValue.YCbCrCoefficients => new ExifRationalArray(ExifTag.YCbCrCoefficients),
            ExifTagValue.ReferenceBlackWhite => new ExifRationalArray(ExifTag.ReferenceBlackWhite),
            ExifTagValue.GPSLatitude => new ExifRationalArray(ExifTag.GPSLatitude),
            ExifTagValue.GPSLongitude => new ExifRationalArray(ExifTag.GPSLongitude),
            ExifTagValue.GPSTimestamp => new ExifRationalArray(ExifTag.GPSTimestamp),
            ExifTagValue.GPSDestLatitude => new ExifRationalArray(ExifTag.GPSDestLatitude),
            ExifTagValue.GPSDestLongitude => new ExifRationalArray(ExifTag.GPSDestLongitude),
            ExifTagValue.LensInfo => new ExifRationalArray(ExifTag.LensInfo),

            ExifTagValue.OldSubfileType => new ExifShort(ExifTag.OldSubfileType),
            ExifTagValue.Compression => new ExifShort(ExifTag.Compression),
            ExifTagValue.PhotometricInterpretation => new ExifShort(ExifTag.PhotometricInterpretation),
            ExifTagValue.Thresholding => new ExifShort(ExifTag.Thresholding),
            ExifTagValue.CellWidth => new ExifShort(ExifTag.CellWidth),
            ExifTagValue.CellLength => new ExifShort(ExifTag.CellLength),
            ExifTagValue.FillOrder => new ExifShort(ExifTag.FillOrder),
            ExifTagValue.Orientation => new ExifShort(ExifTag.Orientation),
            ExifTagValue.SamplesPerPixel => new ExifShort(ExifTag.SamplesPerPixel),
            ExifTagValue.PlanarConfiguration => new ExifShort(ExifTag.PlanarConfiguration),
            ExifTagValue.GrayResponseUnit => new ExifShort(ExifTag.GrayResponseUnit),
            ExifTagValue.ResolutionUnit => new ExifShort(ExifTag.ResolutionUnit),
            ExifTagValue.CleanFaxData => new ExifShort(ExifTag.CleanFaxData),
            ExifTagValue.InkSet => new ExifShort(ExifTag.InkSet),
            ExifTagValue.NumberOfInks => new ExifShort(ExifTag.NumberOfInks),
            ExifTagValue.DotRange => new ExifShort(ExifTag.DotRange),
            ExifTagValue.Indexed => new ExifShort(ExifTag.Indexed),
            ExifTagValue.OPIProxy => new ExifShort(ExifTag.OPIProxy),
            ExifTagValue.JPEGProc => new ExifShort(ExifTag.JPEGProc),
            ExifTagValue.JPEGRestartInterval => new ExifShort(ExifTag.JPEGRestartInterval),
            ExifTagValue.YCbCrPositioning => new ExifShort(ExifTag.YCbCrPositioning),
            ExifTagValue.Rating => new ExifShort(ExifTag.Rating),
            ExifTagValue.RatingPercent => new ExifShort(ExifTag.RatingPercent),
            ExifTagValue.ExposureProgram => new ExifShort(ExifTag.ExposureProgram),
            ExifTagValue.Interlace => new ExifShort(ExifTag.Interlace),
            ExifTagValue.SelfTimerMode => new ExifShort(ExifTag.SelfTimerMode),
            ExifTagValue.SensitivityType => new ExifShort(ExifTag.SensitivityType),
            ExifTagValue.MeteringMode => new ExifShort(ExifTag.MeteringMode),
            ExifTagValue.LightSource => new ExifShort(ExifTag.LightSource),
            ExifTagValue.FocalPlaneResolutionUnit2 => new ExifShort(ExifTag.FocalPlaneResolutionUnit2),
            ExifTagValue.SensingMethod2 => new ExifShort(ExifTag.SensingMethod2),
            ExifTagValue.Flash => new ExifShort(ExifTag.Flash),
            ExifTagValue.ColorSpace => new ExifShort(ExifTag.ColorSpace),
            ExifTagValue.FocalPlaneResolutionUnit => new ExifShort(ExifTag.FocalPlaneResolutionUnit),
            ExifTagValue.SensingMethod => new ExifShort(ExifTag.SensingMethod),
            ExifTagValue.CustomRendered => new ExifShort(ExifTag.CustomRendered),
            ExifTagValue.ExposureMode => new ExifShort(ExifTag.ExposureMode),
            ExifTagValue.WhiteBalance => new ExifShort(ExifTag.WhiteBalance),
            ExifTagValue.FocalLengthIn35mmFilm => new ExifShort(ExifTag.FocalLengthIn35mmFilm),
            ExifTagValue.SceneCaptureType => new ExifShort(ExifTag.SceneCaptureType),
            ExifTagValue.GainControl => new ExifShort(ExifTag.GainControl),
            ExifTagValue.Contrast => new ExifShort(ExifTag.Contrast),
            ExifTagValue.Saturation => new ExifShort(ExifTag.Saturation),
            ExifTagValue.Sharpness => new ExifShort(ExifTag.Sharpness),
            ExifTagValue.SubjectDistanceRange => new ExifShort(ExifTag.SubjectDistanceRange),
            ExifTagValue.GPSDifferential => new ExifShort(ExifTag.GPSDifferential),

            ExifTagValue.BitsPerSample => new ExifShortArray(ExifTag.BitsPerSample),
            ExifTagValue.MinSampleValue => new ExifShortArray(ExifTag.MinSampleValue),
            ExifTagValue.MaxSampleValue => new ExifShortArray(ExifTag.MaxSampleValue),
            ExifTagValue.GrayResponseCurve => new ExifShortArray(ExifTag.GrayResponseCurve),
            ExifTagValue.ColorMap => new ExifShortArray(ExifTag.ColorMap),
            ExifTagValue.ExtraSamples => new ExifShortArray(ExifTag.ExtraSamples),
            ExifTagValue.PageNumber => new ExifShortArray(ExifTag.PageNumber),
            ExifTagValue.TransferFunction => new ExifShortArray(ExifTag.TransferFunction),
            ExifTagValue.Predictor => new ExifShortArray(ExifTag.Predictor),
            ExifTagValue.HalftoneHints => new ExifShortArray(ExifTag.HalftoneHints),
            ExifTagValue.SampleFormat => new ExifShortArray(ExifTag.SampleFormat),
            ExifTagValue.TransferRange => new ExifShortArray(ExifTag.TransferRange),
            ExifTagValue.DefaultImageColor => new ExifShortArray(ExifTag.DefaultImageColor),
            ExifTagValue.JPEGLosslessPredictors => new ExifShortArray(ExifTag.JPEGLosslessPredictors),
            ExifTagValue.JPEGPointTransforms => new ExifShortArray(ExifTag.JPEGPointTransforms),
            ExifTagValue.YCbCrSubsampling => new ExifShortArray(ExifTag.YCbCrSubsampling),
            ExifTagValue.CFARepeatPatternDim => new ExifShortArray(ExifTag.CFARepeatPatternDim),
            ExifTagValue.IntergraphPacketData => new ExifShortArray(ExifTag.IntergraphPacketData),
            ExifTagValue.ISOSpeedRatings => new ExifShortArray(ExifTag.ISOSpeedRatings),
            ExifTagValue.SubjectArea => new ExifShortArray(ExifTag.SubjectArea),
            ExifTagValue.SubjectLocation => new ExifShortArray(ExifTag.SubjectLocation),

            ExifTagValue.ShutterSpeedValue => new ExifSignedRational(ExifTag.ShutterSpeedValue),
            ExifTagValue.BrightnessValue => new ExifSignedRational(ExifTag.BrightnessValue),
            ExifTagValue.ExposureBiasValue => new ExifSignedRational(ExifTag.ExposureBiasValue),
            ExifTagValue.AmbientTemperature => new ExifSignedRational(ExifTag.AmbientTemperature),
            ExifTagValue.WaterDepth => new ExifSignedRational(ExifTag.WaterDepth),
            ExifTagValue.CameraElevationAngle => new ExifSignedRational(ExifTag.CameraElevationAngle),
            ExifTagValue.Decode => new ExifSignedRationalArray(ExifTag.Decode),

            ExifTagValue.ImageDescription => new ExifString(ExifTag.ImageDescription),
            ExifTagValue.Make => new ExifString(ExifTag.Make),
            ExifTagValue.Model => new ExifString(ExifTag.Model),
            ExifTagValue.Software => new ExifString(ExifTag.Software),
            ExifTagValue.DateTime => new ExifString(ExifTag.DateTime),
            ExifTagValue.Artist => new ExifString(ExifTag.Artist),
            ExifTagValue.HostComputer => new ExifString(ExifTag.HostComputer),
            ExifTagValue.Copyright => new ExifString(ExifTag.Copyright),
            ExifTagValue.DocumentName => new ExifString(ExifTag.DocumentName),
            ExifTagValue.PageName => new ExifString(ExifTag.PageName),
            ExifTagValue.InkNames => new ExifString(ExifTag.InkNames),
            ExifTagValue.TargetPrinter => new ExifString(ExifTag.TargetPrinter),
            ExifTagValue.ImageID => new ExifString(ExifTag.ImageID),
            ExifTagValue.MDLabName => new ExifString(ExifTag.MDLabName),
            ExifTagValue.MDSampleInfo => new ExifString(ExifTag.MDSampleInfo),
            ExifTagValue.MDPrepDate => new ExifString(ExifTag.MDPrepDate),
            ExifTagValue.MDPrepTime => new ExifString(ExifTag.MDPrepTime),
            ExifTagValue.MDFileUnits => new ExifString(ExifTag.MDFileUnits),
            ExifTagValue.SEMInfo => new ExifString(ExifTag.SEMInfo),
            ExifTagValue.SpectralSensitivity => new ExifString(ExifTag.SpectralSensitivity),
            ExifTagValue.DateTimeOriginal => new ExifString(ExifTag.DateTimeOriginal),
            ExifTagValue.DateTimeDigitized => new ExifString(ExifTag.DateTimeDigitized),
            ExifTagValue.SubsecTime => new ExifString(ExifTag.SubsecTime),
            ExifTagValue.SubsecTimeOriginal => new ExifString(ExifTag.SubsecTimeOriginal),
            ExifTagValue.SubsecTimeDigitized => new ExifString(ExifTag.SubsecTimeDigitized),
            ExifTagValue.RelatedSoundFile => new ExifString(ExifTag.RelatedSoundFile),
            ExifTagValue.FaxSubaddress => new ExifString(ExifTag.FaxSubaddress),
            ExifTagValue.OffsetTime => new ExifString(ExifTag.OffsetTime),
            ExifTagValue.OffsetTimeOriginal => new ExifString(ExifTag.OffsetTimeOriginal),
            ExifTagValue.OffsetTimeDigitized => new ExifString(ExifTag.OffsetTimeDigitized),
            ExifTagValue.SecurityClassification => new ExifString(ExifTag.SecurityClassification),
            ExifTagValue.ImageHistory => new ExifString(ExifTag.ImageHistory),
            ExifTagValue.ImageUniqueID => new ExifString(ExifTag.ImageUniqueID),
            ExifTagValue.OwnerName => new ExifString(ExifTag.OwnerName),
            ExifTagValue.SerialNumber => new ExifString(ExifTag.SerialNumber),
            ExifTagValue.LensMake => new ExifString(ExifTag.LensMake),
            ExifTagValue.LensModel => new ExifString(ExifTag.LensModel),
            ExifTagValue.LensSerialNumber => new ExifString(ExifTag.LensSerialNumber),
            ExifTagValue.GDALMetadata => new ExifString(ExifTag.GDALMetadata),
            ExifTagValue.GDALNoData => new ExifString(ExifTag.GDALNoData),
            ExifTagValue.GPSLatitudeRef => new ExifString(ExifTag.GPSLatitudeRef),
            ExifTagValue.GPSLongitudeRef => new ExifString(ExifTag.GPSLongitudeRef),
            ExifTagValue.GPSSatellites => new ExifString(ExifTag.GPSSatellites),
            ExifTagValue.GPSStatus => new ExifString(ExifTag.GPSStatus),
            ExifTagValue.GPSMeasureMode => new ExifString(ExifTag.GPSMeasureMode),
            ExifTagValue.GPSSpeedRef => new ExifString(ExifTag.GPSSpeedRef),
            ExifTagValue.GPSTrackRef => new ExifString(ExifTag.GPSTrackRef),
            ExifTagValue.GPSImgDirectionRef => new ExifString(ExifTag.GPSImgDirectionRef),
            ExifTagValue.GPSMapDatum => new ExifString(ExifTag.GPSMapDatum),
            ExifTagValue.GPSDestLatitudeRef => new ExifString(ExifTag.GPSDestLatitudeRef),
            ExifTagValue.GPSDestLongitudeRef => new ExifString(ExifTag.GPSDestLongitudeRef),
            ExifTagValue.GPSDestBearingRef => new ExifString(ExifTag.GPSDestBearingRef),
            ExifTagValue.GPSDestDistanceRef => new ExifString(ExifTag.GPSDestDistanceRef),
            ExifTagValue.GPSDateStamp => new ExifString(ExifTag.GPSDateStamp),

            ExifTagValue.FileSource => new ExifByte(ExifTag.FileSource, ExifDataType.Undefined),
            ExifTagValue.SceneType => new ExifByte(ExifTag.SceneType, ExifDataType.Undefined),
            ExifTagValue.JPEGTables => new ExifByteArray(ExifTag.JPEGTables, ExifDataType.Undefined),
            ExifTagValue.OECF => new ExifByteArray(ExifTag.OECF, ExifDataType.Undefined),
            ExifTagValue.ExifVersion => new ExifByteArray(ExifTag.ExifVersion, ExifDataType.Undefined),
            ExifTagValue.ComponentsConfiguration => new ExifByteArray(ExifTag.ComponentsConfiguration, ExifDataType.Undefined),
            ExifTagValue.MakerNote => new ExifByteArray(ExifTag.MakerNote, ExifDataType.Undefined),
            ExifTagValue.UserComment => new ExifByteArray(ExifTag.UserComment, ExifDataType.Undefined),
            ExifTagValue.FlashpixVersion => new ExifByteArray(ExifTag.FlashpixVersion, ExifDataType.Undefined),
            ExifTagValue.SpatialFrequencyResponse => new ExifByteArray(ExifTag.SpatialFrequencyResponse, ExifDataType.Undefined),
            ExifTagValue.SpatialFrequencyResponse2 => new ExifByteArray(ExifTag.SpatialFrequencyResponse2, ExifDataType.Undefined),
            ExifTagValue.Noise => new ExifByteArray(ExifTag.Noise, ExifDataType.Undefined),
            ExifTagValue.CFAPattern => new ExifByteArray(ExifTag.CFAPattern, ExifDataType.Undefined),
            ExifTagValue.DeviceSettingDescription => new ExifByteArray(ExifTag.DeviceSettingDescription, ExifDataType.Undefined),
            ExifTagValue.ImageSourceData => new ExifByteArray(ExifTag.ImageSourceData, ExifDataType.Undefined),
            ExifTagValue.GPSProcessingMethod => new ExifByteArray(ExifTag.GPSProcessingMethod, ExifDataType.Undefined),
            ExifTagValue.GPSAreaInformation => new ExifByteArray(ExifTag.GPSAreaInformation, ExifDataType.Undefined),
            _ => null,
        };
}
