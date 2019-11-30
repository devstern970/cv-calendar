﻿// Copyright 2013-2019 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

namespace ImageMagick
{
    internal static class ExifTags
    {
        public static ExifParts GetPart(ExifTag tag)
        {
            switch ((ExifTagValue)(ushort)tag)
            {
                case ExifTagValue.SubfileType:
                case ExifTagValue.OldSubfileType:
                case ExifTagValue.ImageWidth:
                case ExifTagValue.ImageLength:
                case ExifTagValue.BitsPerSample:
                case ExifTagValue.Compression:
                case ExifTagValue.PhotometricInterpretation:
                case ExifTagValue.Thresholding:
                case ExifTagValue.CellWidth:
                case ExifTagValue.CellLength:
                case ExifTagValue.FillOrder:
                case ExifTagValue.DocumentName:
                case ExifTagValue.ImageDescription:
                case ExifTagValue.Make:
                case ExifTagValue.Model:
                case ExifTagValue.StripOffsets:
                case ExifTagValue.Orientation:
                case ExifTagValue.SamplesPerPixel:
                case ExifTagValue.RowsPerStrip:
                case ExifTagValue.StripByteCounts:
                case ExifTagValue.MinSampleValue:
                case ExifTagValue.MaxSampleValue:
                case ExifTagValue.XResolution:
                case ExifTagValue.YResolution:
                case ExifTagValue.PlanarConfiguration:
                case ExifTagValue.PageName:
                case ExifTagValue.XPosition:
                case ExifTagValue.YPosition:
                case ExifTagValue.FreeOffsets:
                case ExifTagValue.FreeByteCounts:
                case ExifTagValue.GrayResponseUnit:
                case ExifTagValue.GrayResponseCurve:
                case ExifTagValue.T4Options:
                case ExifTagValue.T6Options:
                case ExifTagValue.ResolutionUnit:
                case ExifTagValue.PageNumber:
                case ExifTagValue.ColorResponseUnit:
                case ExifTagValue.TransferFunction:
                case ExifTagValue.Software:
                case ExifTagValue.DateTime:
                case ExifTagValue.Artist:
                case ExifTagValue.HostComputer:
                case ExifTagValue.Predictor:
                case ExifTagValue.WhitePoint:
                case ExifTagValue.PrimaryChromaticities:
                case ExifTagValue.ColorMap:
                case ExifTagValue.HalftoneHints:
                case ExifTagValue.TileWidth:
                case ExifTagValue.TileLength:
                case ExifTagValue.TileOffsets:
                case ExifTagValue.TileByteCounts:
                case ExifTagValue.BadFaxLines:
                case ExifTagValue.CleanFaxData:
                case ExifTagValue.ConsecutiveBadFaxLines:
                case ExifTagValue.InkSet:
                case ExifTagValue.InkNames:
                case ExifTagValue.NumberOfInks:
                case ExifTagValue.DotRange:
                case ExifTagValue.TargetPrinter:
                case ExifTagValue.ExtraSamples:
                case ExifTagValue.SampleFormat:
                case ExifTagValue.SMinSampleValue:
                case ExifTagValue.SMaxSampleValue:
                case ExifTagValue.TransferRange:
                case ExifTagValue.ClipPath:
                case ExifTagValue.XClipPathUnits:
                case ExifTagValue.YClipPathUnits:
                case ExifTagValue.Indexed:
                case ExifTagValue.JPEGTables:
                case ExifTagValue.OPIProxy:
                case ExifTagValue.ProfileType:
                case ExifTagValue.FaxProfile:
                case ExifTagValue.CodingMethods:
                case ExifTagValue.VersionYear:
                case ExifTagValue.ModeNumber:
                case ExifTagValue.Decode:
                case ExifTagValue.DefaultImageColor:
                case ExifTagValue.T82ptions:
                case ExifTagValue.JPEGProc:
                case ExifTagValue.JPEGInterchangeFormat:
                case ExifTagValue.JPEGInterchangeFormatLength:
                case ExifTagValue.JPEGRestartInterval:
                case ExifTagValue.JPEGLosslessPredictors:
                case ExifTagValue.JPEGPointTransforms:
                case ExifTagValue.JPEGQTables:
                case ExifTagValue.JPEGDCTables:
                case ExifTagValue.JPEGACTables:
                case ExifTagValue.YCbCrCoefficients:
                case ExifTagValue.YCbCrPositioning:
                case ExifTagValue.YCbCrSubsampling:
                case ExifTagValue.ReferenceBlackWhite:
                case ExifTagValue.StripRowCounts:
                case ExifTagValue.XMP:
                case ExifTagValue.Rating:
                case ExifTagValue.RatingPercent:
                case ExifTagValue.ImageID:
                case ExifTagValue.CFARepeatPatternDim:
                case ExifTagValue.CFAPattern2:
                case ExifTagValue.BatteryLevel:
                case ExifTagValue.Copyright:
                case ExifTagValue.MDFileTag:
                case ExifTagValue.MDScalePixel:
                case ExifTagValue.MDLabName:
                case ExifTagValue.MDSampleInfo:
                case ExifTagValue.MDPrepDate:
                case ExifTagValue.MDPrepTime:
                case ExifTagValue.MDFileUnits:
                case ExifTagValue.PixelScale:
                case ExifTagValue.IntergraphPacketData:
                case ExifTagValue.IntergraphRegisters:
                case ExifTagValue.IntergraphMatrix:
                case ExifTagValue.ModelTiePoint:
                case ExifTagValue.SEMInfo:
                case ExifTagValue.ModelTransform:
                case ExifTagValue.ImageLayer:
                case ExifTagValue.FaxRecvParams:
                case ExifTagValue.FaxSubaddress:
                case ExifTagValue.FaxRecvTime:
                case ExifTagValue.ImageSourceData:
                case ExifTagValue.XPTitle:
                case ExifTagValue.XPComment:
                case ExifTagValue.XPAuthor:
                case ExifTagValue.XPKeywords:
                case ExifTagValue.XPSubject:
                case ExifTagValue.GDALMetadata:
                case ExifTagValue.GDALNoData:
                    return ExifParts.IfdTags;

                case ExifTagValue.ExposureTime:
                case ExifTagValue.FNumber:
                case ExifTagValue.ExposureProgram:
                case ExifTagValue.SpectralSensitivity:
                case ExifTagValue.ISOSpeedRatings:
                case ExifTagValue.OECF:
                case ExifTagValue.Interlace:
                case ExifTagValue.TimeZoneOffset:
                case ExifTagValue.SelfTimerMode:
                case ExifTagValue.SensitivityType:
                case ExifTagValue.StandardOutputSensitivity:
                case ExifTagValue.RecommendedExposureIndex:
                case ExifTagValue.ISOSpeed:
                case ExifTagValue.ISOSpeedLatitudeyyy:
                case ExifTagValue.ISOSpeedLatitudezzz:
                case ExifTagValue.ExifVersion:
                case ExifTagValue.DateTimeOriginal:
                case ExifTagValue.DateTimeDigitized:
                case ExifTagValue.OffsetTime:
                case ExifTagValue.OffsetTimeOriginal:
                case ExifTagValue.OffsetTimeDigitized:
                case ExifTagValue.ComponentsConfiguration:
                case ExifTagValue.CompressedBitsPerPixel:
                case ExifTagValue.ShutterSpeedValue:
                case ExifTagValue.ApertureValue:
                case ExifTagValue.BrightnessValue:
                case ExifTagValue.ExposureBiasValue:
                case ExifTagValue.MaxApertureValue:
                case ExifTagValue.SubjectDistance:
                case ExifTagValue.MeteringMode:
                case ExifTagValue.LightSource:
                case ExifTagValue.Flash:
                case ExifTagValue.FocalLength:
                case ExifTagValue.FlashEnergy2:
                case ExifTagValue.SpatialFrequencyResponse2:
                case ExifTagValue.Noise:
                case ExifTagValue.FocalPlaneXResolution2:
                case ExifTagValue.FocalPlaneYResolution2:
                case ExifTagValue.FocalPlaneResolutionUnit2:
                case ExifTagValue.ImageNumber:
                case ExifTagValue.SecurityClassification:
                case ExifTagValue.ImageHistory:
                case ExifTagValue.SubjectArea:
                case ExifTagValue.ExposureIndex2:
                case ExifTagValue.TIFFEPStandardID:
                case ExifTagValue.SensingMethod2:
                case ExifTagValue.MakerNote:
                case ExifTagValue.UserComment:
                case ExifTagValue.SubsecTime:
                case ExifTagValue.SubsecTimeOriginal:
                case ExifTagValue.SubsecTimeDigitized:
                case ExifTagValue.AmbientTemperature:
                case ExifTagValue.Humidity:
                case ExifTagValue.Pressure:
                case ExifTagValue.WaterDepth:
                case ExifTagValue.Acceleration:
                case ExifTagValue.CameraElevationAngle:
                case ExifTagValue.FlashpixVersion:
                case ExifTagValue.ColorSpace:
                case ExifTagValue.PixelXDimension:
                case ExifTagValue.PixelYDimension:
                case ExifTagValue.RelatedSoundFile:
                case ExifTagValue.FlashEnergy:
                case ExifTagValue.SpatialFrequencyResponse:
                case ExifTagValue.FocalPlaneXResolution:
                case ExifTagValue.FocalPlaneYResolution:
                case ExifTagValue.FocalPlaneResolutionUnit:
                case ExifTagValue.SubjectLocation:
                case ExifTagValue.ExposureIndex:
                case ExifTagValue.SensingMethod:
                case ExifTagValue.FileSource:
                case ExifTagValue.SceneType:
                case ExifTagValue.CFAPattern:
                case ExifTagValue.CustomRendered:
                case ExifTagValue.ExposureMode:
                case ExifTagValue.WhiteBalance:
                case ExifTagValue.DigitalZoomRatio:
                case ExifTagValue.FocalLengthIn35mmFilm:
                case ExifTagValue.SceneCaptureType:
                case ExifTagValue.GainControl:
                case ExifTagValue.Contrast:
                case ExifTagValue.Saturation:
                case ExifTagValue.Sharpness:
                case ExifTagValue.DeviceSettingDescription:
                case ExifTagValue.SubjectDistanceRange:
                case ExifTagValue.ImageUniqueID:
                case ExifTagValue.OwnerName:
                case ExifTagValue.SerialNumber:
                case ExifTagValue.LensInfo:
                case ExifTagValue.LensMake:
                case ExifTagValue.LensModel:
                case ExifTagValue.LensSerialNumber:
                    return ExifParts.ExifTags;

                case ExifTagValue.GPSVersionID:
                case ExifTagValue.GPSLatitudeRef:
                case ExifTagValue.GPSLatitude:
                case ExifTagValue.GPSLongitudeRef:
                case ExifTagValue.GPSLongitude:
                case ExifTagValue.GPSAltitudeRef:
                case ExifTagValue.GPSAltitude:
                case ExifTagValue.GPSTimestamp:
                case ExifTagValue.GPSSatellites:
                case ExifTagValue.GPSStatus:
                case ExifTagValue.GPSMeasureMode:
                case ExifTagValue.GPSDOP:
                case ExifTagValue.GPSSpeedRef:
                case ExifTagValue.GPSSpeed:
                case ExifTagValue.GPSTrackRef:
                case ExifTagValue.GPSTrack:
                case ExifTagValue.GPSImgDirectionRef:
                case ExifTagValue.GPSImgDirection:
                case ExifTagValue.GPSMapDatum:
                case ExifTagValue.GPSDestLatitudeRef:
                case ExifTagValue.GPSDestLatitude:
                case ExifTagValue.GPSDestLongitudeRef:
                case ExifTagValue.GPSDestLongitude:
                case ExifTagValue.GPSDestBearingRef:
                case ExifTagValue.GPSDestBearing:
                case ExifTagValue.GPSDestDistanceRef:
                case ExifTagValue.GPSDestDistance:
                case ExifTagValue.GPSProcessingMethod:
                case ExifTagValue.GPSAreaInformation:
                case ExifTagValue.GPSDateStamp:
                case ExifTagValue.GPSDifferential:
                    return ExifParts.GpsTags;

                case ExifTagValue.Unknown:
                case ExifTagValue.SubIFDOffset:
                case ExifTagValue.GPSIFDOffset:
                default:
                    return ExifParts.None;
            }
        }
    }
}