﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using System.IO;
using System.Xml;
using ImageMagick;
using ImageMagick.Configuration;
using Xunit;
using Xunit.Abstractions;

[assembly: TestCollectionOrderer("Magick.NET.Tests.TestCollectionOrderer", "Magick.NET.Tests")]

namespace Magick.NET.Tests
{
    public sealed class TestCollectionOrderer : ITestCollectionOrderer
    {
        public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
        {
            Ghostscript.Initialize();

            var configFiles = ConfigurationFiles.Default;
            configFiles.Policy.Data = ModifyPolicy(configFiles.Policy.Data);
            configFiles.Type.Data = CreateTypeData();

            var path = Path.Combine(Path.GetTempPath(), "Magick.NET.Tests");
            Cleanup.DeleteDirectory(path);
            Directory.CreateDirectory(path);

            MagickNET.Initialize(configFiles, path);

            // OpenCL should be disabled by default this is a hack to check that.
            if (OpenCL.IsEnabled)
                return null;

            OpenCL.IsEnabled = true;

            return testCollections;
        }

        /// <summary>
        /// Used by <see cref="MagickNETTests.ThePolicy.ShouldCauseAnExceptionWhenThePalmCoderIsDisabled"/>.
        /// and <see cref="MagickNETTests.ThePolicy.ShouldCauseAnExceptionWhenTheSunModuleIsDisabled"/>.
        /// </summary>
        /// <param name="data">The current policy.</param>
        /// <returns>The new policy.</returns>
        private static string ModifyPolicy(string data)
        {
            var settings = new XmlReaderSettings()
            {
                DtdProcessing = DtdProcessing.Ignore,
            };

            var doc = new XmlDocument();
            using (var stringReader = new StringReader(data))
            {
                using (var reader = XmlReader.Create(stringReader, settings))
                {
                    doc.Load(reader);
                }
            }

            SetPolicyRights(doc, "coder", "PALM", "none");
            SetPolicyRights(doc, "module", "{SUN,JPEG}", "none");
            SetPolicyRights(doc, "module", "{JPEG}", "read | write");

            return doc.OuterXml;
        }

        private static void SetPolicyRights(XmlDocument doc, string domain, string pattern, string rights)
        {
            var policy = doc.CreateElement("policy");
            SetAttribute(policy, "domain", domain);
            SetAttribute(policy, "rights", rights);
            SetAttribute(policy, "pattern", pattern);

            doc.DocumentElement.AppendChild(policy);
        }

        private static void SetAttribute(XmlElement element, string name, string value)
        {
            var attribute = element.OwnerDocument.CreateAttribute(name);
            attribute.Value = value;

            element.Attributes.Append(attribute);
        }

        private static string CreateTypeData() => $@"
<?xml version=""1.0""?>
<typemap>
<type format=""ttf"" name=""Arial"" fullname=""Arial"" family=""Arial"" glyphs=""{Files.Fonts.Arial}""/>
<type format=""ttf"" name=""CourierNew"" fullname=""Courier New"" family=""Courier New"" glyphs=""{Files.Fonts.CourierNew}""/>
</typemap>
";
    }
}
