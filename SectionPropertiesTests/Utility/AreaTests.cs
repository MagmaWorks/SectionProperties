using MagmaWorks.Taxonomy.Profiles;
using Utility = MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;

namespace SectionPropertiesTests
{
    public class AreaTests
    {
        [Fact]
        public void Angle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateAngle().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal((23-15)*10.9+54*15, area.SquareMillimeters, 12);
        }

        [Fact]
        public void C()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateC().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(4111, area.SquareMillimeters, 12);
        }

        [Fact]
        public void Channel()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateChannel().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(2 * 100.4*15 + (200.3-2*15)*10, area.SquareMillimeters, 10);
        }

        [Fact]
        public void Circle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCircle().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(0.25 * Math.PI * 300 * 300, area.SquareMillimeters, 12);
        }

        [Fact]
        public void CircularHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCircularHollow().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(0.25 * Math.PI * 200 * 200 - 0.25 * Math.PI * 180 * 180, area.SquareMillimeters, 10);
        }

        [Fact]
        public void Cruciform()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCruciform().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(23*10.9+54*15-10.9*15, area.SquareMillimeters, 12);
        }

        [Fact]
        public void CustomI()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCustomI().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(20*7+25*3+(20-7-3)*5, area.SquareCentimeters, 12);
        }

        [Fact]
        public void DoubleAngle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateDoubleAngle().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(2*((23 - 15) * 10.9 + 54 * 15), area.SquareMillimeters, 12);
        }

        [Fact]
        public void DoubleChannel()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateDoubleChannel().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(2*(2 * 100.4 * 15 + (200.3 - 2 * 15) * 10), area.SquareMillimeters, 10);
        }

        [Fact]
        public void Ellipse()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateEllipse().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(16964.6, area.SquareMillimeters, 3);
        }

        [Fact]
        public void EllipseHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateEllipseHollow().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(16964.6 - 10868.3, area.SquareMillimeters, 1);
        }

        [Fact]
        public void ParallelFlange()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateIParallelFlange().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(23863.77896, area.SquareMillimeters, 5);
        }

        [Fact]
        public void I()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateI().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(2*504*15 + (203-2*15)*10.9, area.SquareMillimeters, 12);
        }

        [Fact]
        public void Rectangle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRectangle().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(23 * 54, area.SquareMillimeters, 12);
        }

        [Fact]
        public void RoundedRectangle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRoundedRectangle().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(489, area.SquareCentimeters, 0);
        }

        [Fact]
        public void RoundedRectangularHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRoundedRectangularHollow().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(11979, area.SquareMillimeters, 10);
        }

        [Fact]
        public void Tee()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateTee().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(100.4 * 15 + (200.3 - 15) * 10, area.SquareMillimeters, 12);
        }

        [Fact]
        public void Trapezoid()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateTrapezoid().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(0.5*(100.4+150.4)*200.3, area.SquareMillimeters, 10);
        }

        [Fact]
        public void Z()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateZ().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(18800, area.SquareMillimeters, 12);
        }


        [Fact]
        public void PerimeterWithVoid()
        {
            // Assemble
            IProfile section = TestUtility.Sections.PerimeterVoided().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(16 * 11 - 4 * 14, area.SquareCentimeters, 12);
        }

        [Fact]
        public void Perimeter()
        {
            // Assemble
            IProfile section = TestUtility.Sections.Perimeter().Profile;

            // Act
            OasysUnits.Area area = Utility.Area.CalculateArea(section);

            // Assert
            Assert.Equal(540000, area.SquareMillimeters);
        }
    }
}
