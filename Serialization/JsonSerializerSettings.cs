using Newtonsoft.Json;

namespace MagmaWorks.Taxonomy.Serialization.Sections.SectionProperties
{
    public static class SectionPropertiesJsonSerializer
    {
        public static JsonSerializerSettings Settings
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    Converters = {
                        new OasysUnits.Serialization.JsonNet.OasysUnitsIQuantityJsonConverter(),
                    },
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
                };
                return settings;
            }
        }
    }
}
