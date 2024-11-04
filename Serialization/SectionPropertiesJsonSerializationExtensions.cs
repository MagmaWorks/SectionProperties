using MagmaWorks.Taxonomy.Sections.SectionProperties;
using Newtonsoft.Json;

namespace MagmaWorks.Taxonomy.Serialization.Sections.SectionProperties.Extensions
{
    public static class SectionPropertiesJsonSerializationExtensions
    {
        public static string ToJson<T>(this T sectionProperties) where T : ISectionProperties
        {
            return JsonConvert.SerializeObject(sectionProperties, Formatting.Indented, SectionPropertiesJsonSerializer.Settings);
        }

        public static T FromJson<T>(this string json) where T : ISectionProperties 
        {
            return JsonConvert.DeserializeObject<T>(json, SectionPropertiesJsonSerializer.Settings);
        }
    }
}
