using MagmaWorks.Taxonomy.Materials;

namespace SectionPropertiesTests.TestUtility
{
    internal class MockMaterial : IMaterial
    {
        public MaterialType Type { get; set; }

        public MockMaterial(MaterialType type = MaterialType.Generic)
        {
            Type = type;
        }
    }
}
