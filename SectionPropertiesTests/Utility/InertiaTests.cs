using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;
using Utility = MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;

namespace SectionPropertiesTests
{
    public class InertiaTests
    {
        [Fact]
        public void ParallelFlangeYy()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateIParallelFlange().Profile;

            // Act
            AreaMomentOfInertia inertia = Utility.Inertia.CalculateInertiaYy(section);

            // Assert
            Assert.Equal(1072, inertia.MillimetersToTheFourth / Math.Pow(10, 6), 0);
        }

        [Fact]
        public void ParallelFlangeZz()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateIParallelFlange().Profile;

            // Act
            AreaMomentOfInertia inertia = Utility.Inertia.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(126.2, inertia.MillimetersToTheFourth / Math.Pow(10, 6), 1);
        }
    }
}
