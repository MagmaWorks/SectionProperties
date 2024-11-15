using MagmaWorks.Taxonomy.Sections;
using MagmaWorks.Taxonomy.Sections.SectionProperties;
using SectionPropertiesTests.TestUtility;

namespace SectionPropertiesTests
{
    public class ConcreteSectionPropertiesTests
    {
        [Fact]
        public void ReinforcementAreaTest()
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Perimeter();

            // Act
            var props = new ConcreteSectionProperties(setion);

            // Assert
            double expected = 2 * Math.PI / 4 * Math.Pow(12, 2)
                + 4 * Math.PI / 4 * Math.Pow(20, 2);
            Assert.Equal(expected, props.ReinforcemenArea.SquareMillimeters, 9);
        }

        [Fact]
        public void ConcreteAreaTest()
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Rectangle();

            // Act
            var props = new ConcreteSectionProperties(setion);

            // Assert
            double expectedReinforcementArea = 2 * Math.PI / 4 * Math.Pow(12, 2)
                + 4 * Math.PI / 4 * Math.Pow(20, 2);
            double expected = 400 * 750 - expectedReinforcementArea;
            Assert.Equal(expected, props.ConcreteArea.SquareMillimeters, 9);
        }

        [Fact]
        public void GeometricReinforcementRatioTest()
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Perimeter();

            // Act
            var props = new ConcreteSectionProperties(setion);

            // Assert
            double expectedReinforcementArea = 2 * Math.PI / 4 * Math.Pow(12, 2)
                + 4 * Math.PI / 4 * Math.Pow(20, 2);
            double expectedConcreteArea = 400 * 750 - expectedReinforcementArea;
            double expected = expectedReinforcementArea / expectedConcreteArea;
            Assert.Equal(expected, props.GeometricReinforcementRatio.DecimalFractions, 9);
        }

        [Fact]
        public void ShearReinforcementAreaTest()
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Rectangle();

            // Act
            var props = new ConcreteSectionProperties(setion);

            // Assert
            double expected = 2 * Math.PI / 4 * Math.Pow(10, 2);
            Assert.Equal(expected, props.ShearReinforcementArea.SquareMillimeters, 9);
        }

        [Fact]
        public void ReinforcementSecondMomentOfAreaYyTest()
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Perimeter();

            // Act
            var props = new ConcreteSectionProperties(setion);

            // Assert
            double expected = 2 * (Math.PI / 64 * Math.Pow(12, 4)
                + (Math.PI / 4 * Math.Pow(12, 2) * Math.Pow(334, 2)));
            expected += 4 * (Math.PI / 64 * Math.Pow(20, 4)
                + (Math.PI / 4 * Math.Pow(20, 2) * Math.Pow(330, 2)));
            Assert.Equal(expected, props.ReinforcementSecondMomentOfAreaYy.MillimetersToTheFourth, 9);
        }

        [Fact]
        public void ReinforcementSecondMomentOfAreaZzTest()
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Rectangle();

            // Act
            var props = new ConcreteSectionProperties(setion);

            // Assert
            double expected = 2 * (Math.PI / 64 * Math.Pow(12, 4)
                + (Math.PI / 4 * Math.Pow(12, 2) * Math.Pow(159, 2)));
            expected += 2 * (Math.PI / 64 * Math.Pow(20, 4)
                + (Math.PI / 4 * Math.Pow(20, 2) * Math.Pow(155, 2)));
            expected += 2 * (Math.PI / 64 * Math.Pow(20, 4)
                + (Math.PI / 4 * Math.Pow(20, 2) * Math.Pow(51.666667, 2)));
            Assert.Equal(expected, props.ReinforcementSecondMomentOfAreaZz.MillimetersToTheFourth, 9);
        }

        [Fact]
        public void ReinforcementRadiusOfGyrationYyTest()
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Perimeter();

            // Act
            var props = new ConcreteSectionProperties(setion);

            // Assert
            double expected = 2 * (Math.PI / 64 * Math.Pow(12, 4)
                + (Math.PI / 4 * Math.Pow(12, 2) * Math.Pow(334, 2)));
            expected += 4 * (Math.PI / 64 * Math.Pow(20, 4)
                + (Math.PI / 4 * Math.Pow(20, 2) * Math.Pow(330, 2)));
            expected /= 2 * Math.PI / 4 * Math.Pow(12, 2)
                + 4 * Math.PI / 4 * Math.Pow(20, 2);
            Assert.Equal(Math.Sqrt(expected), props.ReinforcementRadiusOfGyrationYy.Millimeters, 9);
        }

        [Fact]
        public void ReinforcementRadiusOfGyrationZzTest()
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Rectangle();

            // Act
            var props = new ConcreteSectionProperties(setion);

            // Assert
            double expected = 2 * (Math.PI / 64 * Math.Pow(12, 4)
                + (Math.PI / 4 * Math.Pow(12, 2) * Math.Pow(159, 2)));
            expected += 2 * (Math.PI / 64 * Math.Pow(20, 4)
                + (Math.PI / 4 * Math.Pow(20, 2) * Math.Pow(155, 2)));
            expected += 2 * (Math.PI / 64 * Math.Pow(20, 4)
                + (Math.PI / 4 * Math.Pow(20, 2) * Math.Pow(51.666667, 2)));
            expected /= 2 * Math.PI / 4 * Math.Pow(12, 2)
                + 4 * Math.PI / 4 * Math.Pow(20, 2);
            Assert.Equal(Math.Sqrt(expected), props.ReinforcementRadiusOfGyrationZz.Millimeters, 9);
        }
    }
}
