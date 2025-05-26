using MagmaWorks.Taxonomy.Profiles;
using Utility = MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;

namespace SectionPropertiesTests
{
    public class SectionModulusTests
    {
        [Fact]
        public void Angle()
        {
            // Assemble
            IProfile section = Sections.CreateAngle().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(1812.22, Wyy.CubicMillimeters, 2);
            Assert.Equal(8051.47, Wzz.CubicMillimeters, 2);
        }

        [Fact]
        public void C()
        {
            // Assemble
            IProfile section = Sections.CreateC().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(250978, Wyy.CubicMillimeters, 0);
            Assert.Equal(73107.6, Wzz.CubicMillimeters, 1);
        }

        [Fact]
        public void Channel()
        {
            // Assemble
            IProfile section = Sections.CreateChannel().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(299825, Wyy.CubicMillimeters, 0);
            Assert.Equal(71655.5, Wzz.CubicMillimeters, 1);
        }

        [Fact]
        public void Circle()
        {
            // Assemble
            IProfile section = Sections.CreateCircle().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            double expected = Math.PI / 32 * Math.Pow(300, 3);
            Assert.Equal(expected, Wyy.CubicMillimeters, 0);
            Assert.Equal(expected, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void CircularHollow()
        {
            // Assemble
            IProfile section = Sections.CreateCircularHollow().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            double expected = Math.PI / 32.0 * (Math.Pow(200.0, 4) - Math.Pow(180.0, 4)) / 200.0;
            Assert.Equal(expected, Wyy.CubicMillimeters, 0);
            Assert.Equal(expected, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void Cruciform()
        {
            // Assemble
            IProfile section = Sections.CreateCruciform().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(2015.09, Wyy.CubicMillimeters, 2);
            Assert.Equal(7321.98, Wzz.CubicMillimeters, 2);
        }

        [Fact]
        public void CustomI()
        {
            // Assemble
            IProfile section = Sections.CreateCustomI().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(1.170417E+6, Wyy.CubicMillimeters, 0);
            Assert.Equal(694167, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void DoubleAngle()
        {
            // Assemble
            IProfile section = Sections.CreateDoubleAngle().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(3624.45, Wyy.CubicMillimeters, 2);
            Assert.Equal(30698.2, Wzz.CubicMillimeters, 1);
        }

        [Fact]
        public void DoubleChannel()
        {
            // Assemble
            IProfile section = Sections.CreateDoubleChannel().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(599649, Wyy.CubicMillimeters, 0);
            Assert.Equal(208818, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void Ellipse()
        {
            // Assemble
            IProfile section = Sections.CreateEllipse().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(254469, Wyy.CubicMillimeters, 0);
            Assert.Equal(381704, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void EllipseHollow()
        {
            // Assemble
            IProfile section = Sections.CreateEllipseHollow().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(159893, Wyy.CubicMillimeters, 0);
            Assert.Equal(208701, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void ParallelFlange()
        {
            // Assemble
            IProfile section = Sections.CreateIParallelFlange().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(4287, Wyy.CubicMillimeters / 1000, 0);
            Assert.Equal(841.6, Wzz.CubicMillimeters / 1000, 1);
        }

        [Fact]
        public void I()
        {
            // Assemble
            IProfile section = Sections.CreateI().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(1.365388E+6, Wyy.CubicMillimeters, 0);
            Assert.Equal(1.270154E+6, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void Rectangle()
        {
            // Assemble
            IProfile section = Sections.CreateRectangle().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(1.0 / 6 * 54 * 23 * 23, Wyy.CubicMillimeters, 10);
            Assert.Equal(1.0 / 6 * 23 * 54 * 54, Wzz.CubicMillimeters, 10);
        }

        [Fact]
        public void RectangularHollow()
        {
            // Assemble
            IProfile section = Sections.CreateRectangularHollow().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(1.106211E+6, Wyy.CubicMillimeters, 0);
            Assert.Equal(1.875929E+6, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void RoundedRectangle()
        {
            // Assemble
            IProfile section = Sections.CreateRoundedRectangle().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(1960735, Wyy.CubicMillimeters, 0);
            Assert.Equal(1581052, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void RoundedRectangularHollow()
        {
            // Assemble
            IProfile section = Sections.CreateRoundedRectangularHollow().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(1723904, Wyy.CubicMillimeters, 0);
            Assert.Equal(2328744, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void Tee()
        {
            // Assemble
            IProfile section = Sections.CreateTee().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(99330.6, Wyy.CubicMillimeters, 1);
            Assert.Equal(25508, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void Trapezoid()
        {
            // Assemble
            IProfile section = Sections.CreateTrapezoid().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(775843, Wyy.CubicMillimeters, 0);
            Assert.Equal(455094, Wzz.CubicMillimeters, 0);
        }

        [Fact]
        public void Z()
        {
            // Assemble
            IProfile section = Sections.CreateZ().Profile;

            // Act
            SectionModulus Wyy = Utility.SectionModuli.CalculateSectionModulusYy(section);
            SectionModulus Wzz = Utility.SectionModuli.CalculateSectionModulusZz(section);

            // Assert
            Assert.Equal(2.146042E+6, Wyy.CubicMillimeters, 0);
            Assert.Equal(1078294, Wzz.CubicMillimeters, 0);
        }
    }
}
