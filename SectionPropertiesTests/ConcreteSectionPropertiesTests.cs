namespace SectionPropertiesTests
{
    public class ConcreteSectionPropertiesTests
    {
        [Fact]
        public void TotalReinforcementAreaTest()
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Perimeter();

            // Act
            var props = new ConcreteSectionProperties(setion);

            // Assert
            double expected = 2 * Math.PI / 4 * Math.Pow(12, 2)
                + 4 * Math.PI / 4 * Math.Pow(20, 2);
            Assert.Equal(expected, props.TotalReinforcementArea.SquareMillimeters, 9);
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
            Assert.Equal(expected, props.CrossSectionalShearReinforcementArea.SquareMillimeters, 9);
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
            // values updated after moving corner rebars inwards for link mandrel diameter
            // manual expected calc above = 162114600.39354497
            double expected2 = 160289615.94092032;
            Assert.Equal(expected2, props.ReinforcementSecondMomentOfAreaYy.MillimetersToTheFourth, 9);
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
            // values updated after moving corner rebars inwards for link mandrel diameter
            // manual expected calc above = 22524493.290912069
            double expected2 = 21668244.005340151;
            Assert.Equal(expected2, props.ReinforcementSecondMomentOfAreaZz.MillimetersToTheFourth, 9);
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
            expected = Math.Sqrt(expected);
            // values updated after moving corner rebars inwards for link mandrel diameter
            // manual expected calc above = 330.64741321299999
            double expected2 = 328.78103516099998;
            Assert.Equal(expected2, props.ReinforcementRadiusOfGyrationYy.Millimeters, 9);
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
            expected = Math.Sqrt(expected);
            // values updated after moving corner rebars inwards for link mandrel diameter
            // manual expected calc above = 123.248482094
            double expected2 = 120.883193053;
            Assert.Equal(expected2, props.ReinforcementRadiusOfGyrationZz.Millimeters, 9);
        }

        [Theory]
        // values updated after moving corner rebars inwards for link mandrel diameter
        [InlineData(703.53553390599996, SectionFace.Bottom)] 
        [InlineData(704.89949493699999, SectionFace.Top)]
        [InlineData(309.958285165, SectionFace.Right)]
        [InlineData(309.958285165, SectionFace.Left)]
        public void EffectiveDepthTest(double expected, SectionFace face)
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Rectangle();

            // Act
            var props = new ConcreteSectionProperties(setion);
            Length d = props.EffectiveDepth(face);

            // Assert
            Assert.Equal(expected, d.Millimeters, 9);
        }

        [Theory]
        [InlineData(new double[] { 20, 20, 20, 20 }, SectionFace.Bottom)]
        [InlineData(new double[] { 12, 12 }, SectionFace.Top)]
        [InlineData(new double[] { 12, 20, 20 }, SectionFace.Right)]
        [InlineData(new double[] { 12, 20, 20 }, SectionFace.Left)]
        public void ReinforcementAreaTest(double[] expectedDiameters, SectionFace face)
        {
            // Assemble
            ConcreteSection setion = ConcreteSections.Rectangle();

            // Act
            var props = new ConcreteSectionProperties(setion);
            Area d = props.ReinforcementArea(face);

            // Assert
            double expected = 0;
            foreach (double dia in expectedDiameters)
            {
                expected += Math.PI / 4 * Math.Pow(dia, 2);
            }

            Assert.Equal(expected, d.SquareMillimeters, 9);
        }
    }
}
