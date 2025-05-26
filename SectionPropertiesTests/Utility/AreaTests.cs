using MagmaWorks.Taxonomy.Profiles;
using Utility = MagmaWorks.Taxonomy.Sections.Properties.Utility;

namespace SectionPropertiesTests
{
    public class AreaTests
    {
        [Fact]
        public void Angle()
        {
            // Assemble
            IProfile section = Sections.CreateAngle().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal((23 - 15) * 10.9 + 54 * 15, area.SquareMillimeters, 12);
        }

        [Fact]
        public void C()
        {
            // Assemble
            IProfile section = Sections.CreateC().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(4111, area.SquareMillimeters, 12);
        }

        [Fact]
        public void Channel()
        {
            // Assemble
            IProfile section = Sections.CreateChannel().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(2 * 100.4 * 15 + (200.3 - 2 * 15) * 10, area.SquareMillimeters, 10);
        }

        [Fact]
        public void Circle()
        {
            // Assemble
            IProfile section = Sections.CreateCircle().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(0.25 * Math.PI * 300 * 300, area.SquareMillimeters, 12);
        }

        [Fact]
        public void CircularHollow()
        {
            // Assemble
            IProfile section = Sections.CreateCircularHollow().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(0.25 * Math.PI * 200 * 200 - 0.25 * Math.PI * 180 * 180, area.SquareMillimeters, 10);
        }

        [Fact]
        public void Cruciform()
        {
            // Assemble
            IProfile section = Sections.CreateCruciform().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(23 * 10.9 + 54 * 15 - 10.9 * 15, area.SquareMillimeters, 12);
        }

        [Fact]
        public void CustomI()
        {
            // Assemble
            IProfile section = Sections.CreateCustomI().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(20 * 7 + 25 * 3 + (20 - 7 - 3) * 5, area.SquareCentimeters, 12);
        }

        [Fact]
        public void DoubleAngle()
        {
            // Assemble
            IProfile section = Sections.CreateDoubleAngle().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(2 * ((23 - 15) * 10.9 + 54 * 15), area.SquareMillimeters, 12);
        }

        [Fact]
        public void DoubleChannel()
        {
            // Assemble
            IProfile section = Sections.CreateDoubleChannel().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(2 * (2 * 100.4 * 15 + (200.3 - 2 * 15) * 10), area.SquareMillimeters, 10);
        }

        [Fact]
        public void Ellipse()
        {
            // Assemble
            IProfile section = Sections.CreateEllipse().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(16964.6, area.SquareMillimeters, 3);
        }

        [Fact]
        public void EllipseHollow()
        {
            // Assemble
            IProfile section = Sections.CreateEllipseHollow().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(16964.6 - 10868.3, area.SquareMillimeters, 1);
        }

        [Fact]
        public void ParallelFlange()
        {
            // Assemble
            IProfile section = Sections.CreateIParallelFlange().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(23863.77896, area.SquareMillimeters, 5);
        }

        [Fact]
        public void I()
        {
            // Assemble
            IProfile section = Sections.CreateI().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(2 * 504 * 15 + (203 - 2 * 15) * 10.9, area.SquareMillimeters, 12);
        }

        [Fact]
        public void Rectangle()
        {
            // Assemble
            IProfile section = Sections.CreateRectangle().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(23 * 54, area.SquareMillimeters, 12);
        }

        [Fact]
        public void RectangularHollow()
        {
            // Assemble
            IProfile section = Sections.CreateRectangularHollow().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(20.3 * 50.4 - (20.3 - 2 * 1.09) * (50.4 - 2 * 1.09), area.SquareCentimeters, 12);
        }

        [Fact]
        public void RoundedRectangle()
        {
            // Assemble
            IProfile section = Sections.CreateRoundedRectangle().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(489, area.SquareCentimeters, 0);
        }

        [Fact]
        public void RoundedRectangularHollow()
        {
            // Assemble
            IProfile section = Sections.CreateRoundedRectangularHollow().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(11979, area.SquareMillimeters, 9);
        }

        [Fact]
        public void Tee()
        {
            // Assemble
            IProfile section = Sections.CreateTee().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(100.4 * 15 + (200.3 - 15) * 10, area.SquareMillimeters, 12);
        }

        [Fact]
        public void Trapezoid()
        {
            // Assemble
            IProfile section = Sections.CreateTrapezoid().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(0.5 * (100.4 + 150.4) * 200.3, area.SquareMillimeters, 10);
        }

        [Fact]
        public void Z()
        {
            // Assemble
            IProfile section = Sections.CreateZ().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(18800, area.SquareMillimeters, 12);
        }


        [Fact]
        public void PerimeterWithVoid()
        {
            // Assemble
            IProfile section = Sections.PerimeterVoided().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(16 * 11 - 4 * 14, area.SquareCentimeters, 12);
        }

        [Fact]
        public void Perimeter()
        {
            // Assemble
            IProfile section = Sections.Perimeter().Profile;

            // Act
            Area area = Utility.Areas.CalculateArea(section);

            // Assert
            Assert.Equal(540000, area.SquareMillimeters);
        }
    }
}
