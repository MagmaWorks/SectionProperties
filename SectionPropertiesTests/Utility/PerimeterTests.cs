using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;
using OasysUnits;

namespace SectionPropertiesTests
{
    public class PerimeterTests
    {
        [Fact]
        public void CalculatePerimeterTest()
        {
            // Assemble
            IPerimeter section = (IPerimeter)TestUtility.Sections.PerimeterVoided().Profile;

            // Act
            Length length = PerimeterLength.CalculatePerimeter(section);

            // Assert
            Assert.Equal((11 + 16) * 2, length.Centimeters);
        }
    }
}
