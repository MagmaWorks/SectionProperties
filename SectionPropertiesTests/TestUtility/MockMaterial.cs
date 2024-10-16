using MagmaWorks.Taxonomy.Materials;

namespace SectionPropertiesTests.TestUtility
{
    internal class MockMaterial : IMaterial
    {
        public MaterialType Type => throw new NotImplementedException();

        public MockMaterial() { }
    }
}
