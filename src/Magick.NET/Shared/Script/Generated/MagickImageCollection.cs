// Copyright 2013-2019 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
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
        private IMagickImage ExecuteCollection(XmlElement element, IMagickImageCollection collection)
        {
            switch(element.Name[0])
            {
                case 'c':
                {
                    switch(element.Name[2])
                    {
                        case 'a':
                        {
                            return ExecuteCoalesce(collection);
                        }
                        case 'm':
                        {
                            return ExecuteCombine(element, collection);
                        }
                    }
                    break;
                }
                case 'd':
                {
                    return ExecuteDeconstruct(collection);
                }
                case 'm':
                {
                    switch(element.Name[1])
                    {
                        case 'a':
                        {
                            return ExecuteMap(element, collection);
                        }
                        case 'o':
                        {
                            switch(element.Name[2])
                            {
                                case 'r':
                                {
                                    return ExecuteMorph(element, collection);
                                }
                                case 'n':
                                {
                                    return ExecuteMontage(element, collection);
                                }
                                case 's':
                                {
                                    return ExecuteMosaic(collection);
                                }
                            }
                            break;
                        }
                        case 'e':
                        {
                            return ExecuteMerge(collection);
                        }
                    }
                    break;
                }
                case 'o':
                {
                    if (element.Name.Length == 8)
                    {
                        return ExecuteOptimize(collection);
                    }
                    switch(element.Name[8])
                    {
                        case 'P':
                        {
                            return ExecuteOptimizePlus(collection);
                        }
                        case 'T':
                        {
                            return ExecuteOptimizeTransparency(collection);
                        }
                    }
                    break;
                }
                case 'q':
                {
                    return ExecuteQuantize(element, collection);
                }
                case 'r':
                {
                    switch(element.Name[2])
                    {
                        case 'P':
                        {
                            return ExecuteRePage(collection);
                        }
                        case 'v':
                        {
                            return ExecuteReverse(collection);
                        }
                    }
                    break;
                }
                case 't':
                {
                    return ExecuteTrimBounds(collection);
                }
                case 'a':
                {
                    switch(element.Name[6])
                    {
                        case 'H':
                        {
                            return ExecuteAppendHorizontally(collection);
                        }
                        case 'V':
                        {
                            return ExecuteAppendVertically(collection);
                        }
                    }
                    break;
                }
                case 'e':
                {
                    return ExecuteEvaluate(element, collection);
                }
                case 'f':
                {
                    return ExecuteFlatten(element, collection);
                }
                case 'p':
                {
                    return ExecutePolynomial(element, collection);
                }
                case 's':
                {
                    switch(element.Name[5])
                    {
                        case 'H':
                        {
                            return ExecuteSmushHorizontal(element, collection);
                        }
                        case 'V':
                        {
                            return ExecuteSmushVertical(element, collection);
                        }
                    }
                    break;
                }
            }
            throw new NotSupportedException(element.Name);
        }
        private static IMagickImage ExecuteCoalesce(IMagickImageCollection collection)
        {
            collection.Coalesce();
            return null;
        }
        private static IMagickImage ExecuteDeconstruct(IMagickImageCollection collection)
        {
            collection.Deconstruct();
            return null;
        }
        private IMagickImage ExecuteMap(XmlElement element, IMagickImageCollection collection)
        {
            Hashtable arguments = new Hashtable();
            foreach (XmlElement elem in element.SelectNodes("*"))
            {
                if (elem.Name == "image")
                    arguments["image"] = CreateMagickImage(elem);
                else if (elem.Name == "settings")
                    arguments["settings"] = CreateQuantizeSettings(elem);
            }
            if (OnlyContains(arguments, "image"))
                {
                    collection.Map((IMagickImage)arguments["image"]);
                    return null;
                }
            else if (OnlyContains(arguments, "image", "settings"))
                {
                    collection.Map((IMagickImage)arguments["image"], (QuantizeSettings)arguments["settings"]);
                    return null;
                }
            else
                throw new ArgumentException("Invalid argument combination for 'map', allowed combinations are: [image] [image, settings]");
        }
        private IMagickImage ExecuteMorph(XmlElement element, IMagickImageCollection collection)
        {
            Int32 frames_ = GetValue<Int32>(element, "frames");
            collection.Morph(frames_);
            return null;
        }
        private static IMagickImage ExecuteOptimize(IMagickImageCollection collection)
        {
            collection.Optimize();
            return null;
        }
        private static IMagickImage ExecuteOptimizePlus(IMagickImageCollection collection)
        {
            collection.OptimizePlus();
            return null;
        }
        private static IMagickImage ExecuteOptimizeTransparency(IMagickImageCollection collection)
        {
            collection.OptimizeTransparency();
            return null;
        }
        private IMagickImage ExecuteQuantize(XmlElement element, IMagickImageCollection collection)
        {
            Hashtable arguments = new Hashtable();
            foreach (XmlElement elem in element.SelectNodes("*"))
            {
                arguments[elem.Name] = CreateQuantizeSettings(elem);
            }
            if (arguments.Count == 0)
                {
                    collection.Quantize();
                    return null;
                }
            else if (OnlyContains(arguments, "settings"))
                {
                    collection.Quantize((QuantizeSettings)arguments["settings"]);
                    return null;
                }
            else
                throw new ArgumentException("Invalid argument combination for 'quantize', allowed combinations are: [] [settings]");
        }
        private static IMagickImage ExecuteRePage(IMagickImageCollection collection)
        {
            collection.RePage();
            return null;
        }
        private static IMagickImage ExecuteReverse(IMagickImageCollection collection)
        {
            collection.Reverse();
            return null;
        }
        private static IMagickImage ExecuteTrimBounds(IMagickImageCollection collection)
        {
            collection.TrimBounds();
            return null;
        }
        private static IMagickImage ExecuteAppendHorizontally(IMagickImageCollection collection)
        {
            return collection.AppendHorizontally();
        }
        private static IMagickImage ExecuteAppendVertically(IMagickImageCollection collection)
        {
            return collection.AppendVertically();
        }
        private IMagickImage ExecuteCombine(XmlElement element, IMagickImageCollection collection)
        {
            Hashtable arguments = new Hashtable();
            foreach (XmlAttribute attribute in element.Attributes)
            {
                arguments[attribute.Name] = GetValue<ColorSpace>(attribute);
            }
            if (arguments.Count == 0)
                return collection.Combine();
            else if (OnlyContains(arguments, "colorSpace"))
                return collection.Combine((ColorSpace)arguments["colorSpace"]);
            else
                throw new ArgumentException("Invalid argument combination for 'combine', allowed combinations are: [] [colorSpace]");
        }
        private IMagickImage ExecuteEvaluate(XmlElement element, IMagickImageCollection collection)
        {
            EvaluateOperator evaluateOperator_ = GetValue<EvaluateOperator>(element, "evaluateOperator");
            return collection.Evaluate(evaluateOperator_);
        }
        private IMagickImage ExecuteFlatten(XmlElement element, IMagickImageCollection collection)
        {
            Hashtable arguments = new Hashtable();
            foreach (XmlAttribute attribute in element.Attributes)
            {
                arguments[attribute.Name] = GetValue<MagickColor>(attribute);
            }
            if (arguments.Count == 0)
                return collection.Flatten();
            else if (OnlyContains(arguments, "backgroundColor"))
                return collection.Flatten((MagickColor)arguments["backgroundColor"]);
            else
                throw new ArgumentException("Invalid argument combination for 'flatten', allowed combinations are: [] [backgroundColor]");
        }
        private static IMagickImage ExecuteMerge(IMagickImageCollection collection)
        {
            return collection.Merge();
        }
        private IMagickImage ExecuteMontage(XmlElement element, IMagickImageCollection collection)
        {
            MontageSettings settings_ = CreateMontageSettings(element["settings"]);
            return collection.Montage(settings_);
        }
        private static IMagickImage ExecuteMosaic(IMagickImageCollection collection)
        {
            return collection.Mosaic();
        }
        private IMagickImage ExecutePolynomial(XmlElement element, IMagickImageCollection collection)
        {
            Double[] terms_ = GetDoubleArray(element["terms"]);
            return collection.Polynomial(terms_);
        }
        private IMagickImage ExecuteSmushHorizontal(XmlElement element, IMagickImageCollection collection)
        {
            Int32 offset_ = GetValue<Int32>(element, "offset");
            return collection.SmushHorizontal(offset_);
        }
        private IMagickImage ExecuteSmushVertical(XmlElement element, IMagickImageCollection collection)
        {
            Int32 offset_ = GetValue<Int32>(element, "offset");
            return collection.SmushVertical(offset_);
        }
    }
}
