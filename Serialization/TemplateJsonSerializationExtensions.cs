﻿using MagmaWorks.Taxonomy.Sections.SectionProperties;
using Newtonsoft.Json;

namespace MagmaWorks.Template.Serialization.Extensions
{
    public static class TemplateJsonSerializationExtensions
    {
        public static string ToJson<T>(this T sectionProperties) where T : IGeometricalProperties
        {
            return JsonConvert.SerializeObject(sectionProperties, Formatting.Indented, TemplateJsonSerializer.Settings);
        }

        public static T FromJson<T>(this string json) where T : IGeometricalProperties
        {
            return JsonConvert.DeserializeObject<T>(json, TemplateJsonSerializer.Settings);
        }
    }
}
