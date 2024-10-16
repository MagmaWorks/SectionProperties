using MagmaWorks.Taxonomy.Profiles;

namespace SectionPropertiesTests
{
    public class AreaTests
    {
        [Fact]
        public void CalculateAreaWithVoidTest()
        {
            // Assemble
            IPerimeter section = (IPerimeter)TestUtility.Sections.PerimeterVoided().Profile;

            // Act
            OasysUnits.Area area = MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(16 * 11 - 4 * 14, area.SquareCentimeters, 12);
        }

        [Fact]
        public void CalculateAreaFromTTest()
        {
            // Assemble
            IPerimeter section = (IPerimeter)TestUtility.Sections.Perimeter().Profile;

            // Act
            OasysUnits.Area area = MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(540000, area.SquareMillimeters);
        }
    }
}
