using MagmaWorks.Taxonomy.Materials;

namespace SectionPropertiesTests.TestUtility
{
    internal class MockMaterial : IMaterial
    {
        public MaterialType Type => MaterialType.Generic;

        public MockMaterial() { }
    }
}
