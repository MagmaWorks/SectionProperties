using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;

namespace SectionPropertiesTests
{
    public class PerimeterTests
    {
        [Fact]
        public void CalculatePerimeterTest()
        {
            // Assemble
            IPerimeter section = (IPerimeter)Sections.PerimeterVoided().Profile;

            // Act
            Length length = PerimeterLengths.CalculatePerimeter(section);

            // Assert
            Assert.Equal((11 + 16) * 2, length.Centimeters);
        }
    }
}
