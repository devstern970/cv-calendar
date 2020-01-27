// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
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
// <auto-generated/>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;

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
    public sealed partial class MagickScript
    {
        IReadDefines CreateIReadDefines(XmlElement parent)
        {
            return CreateIDefines(parent) as IReadDefines;
        }
        private IDefines CreateIDefines(XmlElement parent)
        {
            if (parent == null)
                return null;
            XmlElement element = (XmlElement)parent.FirstChild;
            if (element == null)
                return null;
            switch(element.Name[0])
            {
                case 'b':
                {
                    return CreateBmpWriteDefines(element);
                }
                case 'c':
                {
                    return CreateCaptionReadDefines(element);
                }
                case 'd':
                {
                    switch(element.Name[3])
                    {
                        case 'R':
                        {
                            return CreateDdsReadDefines(element);
                        }
                        case 'W':
                        {
                            return CreateDdsWriteDefines(element);
                        }
                    }
                    break;
                }
                case 'j':
                {
                    switch(element.Name[2])
                    {
                        case '2':
                        {
                            switch(element.Name[3])
                            {
                                case 'R':
                                {
                                    return CreateJp2ReadDefines(element);
                                }
                                case 'W':
                                {
                                    return CreateJp2WriteDefines(element);
                                }
                            }
                            break;
                        }
                        case 'e':
                        {
                            switch(element.Name[4])
                            {
                                case 'R':
                                {
                                    return CreateJpegReadDefines(element);
                                }
                                case 'W':
                                {
                                    return CreateJpegWriteDefines(element);
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
                case 'p':
                {
                    switch(element.Name[1])
                    {
                        case 'd':
                        {
                            return CreatePdfReadDefines(element);
                        }
                        case 'n':
                        {
                            return CreatePngReadDefines(element);
                        }
                        case 's':
                        {
                            switch(element.Name[3])
                            {
                                case 'R':
                                {
                                    return CreatePsdReadDefines(element);
                                }
                                case 'W':
                                {
                                    return CreatePsdWriteDefines(element);
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
                case 't':
                {
                    switch(element.Name[4])
                    {
                        case 'R':
                        {
                            return CreateTiffReadDefines(element);
                        }
                        case 'W':
                        {
                            return CreateTiffWriteDefines(element);
                        }
                    }
                    break;
                }
            }
            throw new NotSupportedException(element.Name);
        }
        private IDefines CreateBmpWriteDefines(XmlElement element)
        {
            if (element == null)
                return null;
            BmpWriteDefines result = new BmpWriteDefines();
            result.Subtype = GetValue<Nullable<ImageMagick.Defines.BmpSubtype>>(element, "subtype");
            return result;
        }
        private IDefines CreateCaptionReadDefines(XmlElement element)
        {
            if (element == null)
                return null;
            CaptionReadDefines result = new CaptionReadDefines();
            result.MaxFontPointsize = GetValue<Nullable<Double>>(element, "maxFontPointsize");
            return result;
        }
        private IDefines CreateDdsReadDefines(XmlElement element)
        {
            if (element == null)
                return null;
            DdsReadDefines result = new DdsReadDefines();
            result.SkipMipmaps = GetValue<Nullable<Boolean>>(element, "skipMipmaps");
            return result;
        }
        private IDefines CreateDdsWriteDefines(XmlElement element)
        {
            if (element == null)
                return null;
            DdsWriteDefines result = new DdsWriteDefines();
            result.ClusterFit = GetValue<Nullable<Boolean>>(element, "clusterFit");
            result.Compression = GetValue<Nullable<ImageMagick.Defines.DdsCompression>>(element, "compression");
            result.FastMipmaps = GetValue<Nullable<Boolean>>(element, "fastMipmaps");
            result.Mipmaps = GetValue<Nullable<Int32>>(element, "mipmaps");
            result.MipmapsFromCollection = GetValue<Nullable<Boolean>>(element, "mipmapsFromCollection");
            result.Raw = GetValue<Nullable<Boolean>>(element, "raw");
            result.WeightByAlpha = GetValue<Nullable<Boolean>>(element, "weightByAlpha");
            return result;
        }
        private IDefines CreateJp2ReadDefines(XmlElement element)
        {
            if (element == null)
                return null;
            Jp2ReadDefines result = new Jp2ReadDefines();
            result.QualityLayers = GetValue<Nullable<Int32>>(element, "qualityLayers");
            result.ReduceFactor = GetValue<Nullable<Int32>>(element, "reduceFactor");
            return result;
        }
        private IDefines CreateJp2WriteDefines(XmlElement element)
        {
            if (element == null)
                return null;
            Jp2WriteDefines result = new Jp2WriteDefines();
            result.NumberResolutions = GetValue<Nullable<Int32>>(element, "numberResolutions");
            result.ProgressionOrder = GetValue<Nullable<ImageMagick.Defines.Jp2ProgressionOrder>>(element, "progressionOrder");
            result.Quality = GetSingleArray(element["quality"]);
            result.Rate = GetSingleArray(element["rate"]);
            return result;
        }
        private IDefines CreateJpegReadDefines(XmlElement element)
        {
            if (element == null)
                return null;
            JpegReadDefines result = new JpegReadDefines();
            result.BlockSmoothing = GetValue<Nullable<Boolean>>(element, "blockSmoothing");
            result.Colors = GetValue<Nullable<Int32>>(element, "colors");
            result.DctMethod = GetValue<Nullable<ImageMagick.Defines.DctMethod>>(element, "dctMethod");
            result.FancyUpsampling = GetValue<Nullable<Boolean>>(element, "fancyUpsampling");
            result.Size = GetValue<MagickGeometry>(element, "size");
            result.SkipProfiles = GetValue<Nullable<ImageMagick.Defines.ProfileTypes>>(element, "skipProfiles");
            return result;
        }
        private IDefines CreateJpegWriteDefines(XmlElement element)
        {
            if (element == null)
                return null;
            JpegWriteDefines result = new JpegWriteDefines();
            result.ArithmeticCoding = GetValue<Nullable<Boolean>>(element, "arithmeticCoding");
            result.DctMethod = GetValue<Nullable<ImageMagick.Defines.DctMethod>>(element, "dctMethod");
            result.Extent = GetValue<Nullable<Int32>>(element, "extent");
            result.OptimizeCoding = GetValue<Nullable<Boolean>>(element, "optimizeCoding");
            result.QuantizationTables = GetValue<String>(element, "quantizationTables");
            result.SamplingFactor = GetValue<Nullable<ImageMagick.Defines.SamplingFactor>>(element, "samplingFactor");
            return result;
        }
        private IDefines CreatePdfReadDefines(XmlElement element)
        {
            if (element == null)
                return null;
            PdfReadDefines result = new PdfReadDefines();
            result.FitPage = GetValue<MagickGeometry>(element, "fitPage");
            result.Password = GetValue<String>(element, "password");
            result.UseCropBox = GetValue<Nullable<Boolean>>(element, "useCropBox");
            result.UseTrimBox = GetValue<Nullable<Boolean>>(element, "useTrimBox");
            return result;
        }
        private IDefines CreatePngReadDefines(XmlElement element)
        {
            if (element == null)
                return null;
            PngReadDefines result = new PngReadDefines();
            result.ChunkCacheMax = GetValue<Nullable<Int64>>(element, "chunkCacheMax");
            result.ChunkMallocMax = GetValue<Nullable<Int64>>(element, "chunkMallocMax");
            result.IgnoreCrc = GetValue<Boolean>(element, "ignoreCrc");
            result.PreserveiCCP = GetValue<Boolean>(element, "preserveiCCP");
            result.SkipProfiles = GetValue<Nullable<ImageMagick.Defines.ProfileTypes>>(element, "skipProfiles");
            result.SwapBytes = GetValue<Boolean>(element, "swapBytes");
            return result;
        }
        private IDefines CreatePsdReadDefines(XmlElement element)
        {
            if (element == null)
                return null;
            PsdReadDefines result = new PsdReadDefines();
            result.AlphaUnblend = GetValue<Nullable<Boolean>>(element, "alphaUnblend");
            return result;
        }
        private IDefines CreatePsdWriteDefines(XmlElement element)
        {
            if (element == null)
                return null;
            PsdWriteDefines result = new PsdWriteDefines();
            result.AdditionalInfo = GetValue<PsdAdditionalInfo>(element, "additionalInfo");
            return result;
        }
        private IDefines CreateTiffReadDefines(XmlElement element)
        {
            if (element == null)
                return null;
            TiffReadDefines result = new TiffReadDefines();
            result.IgnoreExifPoperties = GetValue<Nullable<Boolean>>(element, "ignoreExifPoperties");
            result.IgnoreTags = GetStringArray(element["ignoreTags"]);
            return result;
        }
        private IDefines CreateTiffWriteDefines(XmlElement element)
        {
            if (element == null)
                return null;
            TiffWriteDefines result = new TiffWriteDefines();
            result.Alpha = GetValue<Nullable<ImageMagick.Defines.TiffAlpha>>(element, "alpha");
            result.Endian = GetValue<Nullable<Endian>>(element, "endian");
            result.FillOrder = GetValue<Nullable<Endian>>(element, "fillOrder");
            result.RowsPerStrip = GetValue<Nullable<Int32>>(element, "rowsPerStrip");
            result.TileGeometry = GetValue<MagickGeometry>(element, "tileGeometry");
            return result;
        }
    }
}
