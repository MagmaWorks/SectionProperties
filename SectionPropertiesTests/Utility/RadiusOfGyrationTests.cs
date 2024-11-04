using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;
using Utility = MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;

namespace SectionPropertiesTests
{
    public class RadiusOfGyrationTests
    {
        [Fact]
        public void Angle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateAngle().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(5.38983, Ryy.Millimeters, 5);
            Assert.Equal(16.1584, Rzz.Millimeters, 4);
        }

        [Fact]
        public void C()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateC().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(78.1934, Ryy.Millimeters, 4);
            Assert.Equal(34.4471, Rzz.Millimeters, 4);
        }

        [Fact]
        public void Channel()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateChannel().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(79.8028, Ryy.Millimeters, 0);
            Assert.Equal(31.7964, Rzz.Millimeters, 0);
        }

        [Fact]
        public void Circle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCircle().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(75, Ryy.Millimeters, 0);
            Assert.Equal(75, Rzz.Millimeters, 0);
        }

        [Fact]
        public void CircularHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCircularHollow().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(67.2681, Ryy.Millimeters, 4);
            Assert.Equal(67.2681, Rzz.Millimeters, 4);
        }

        [Fact]
        public void Cruciform()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCruciform().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(5.0822, Ryy.Millimeters, 4);
            Assert.Equal(14.844, Rzz.Millimeters, 4);
        }

        [Fact]
        public void CustomI()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCustomI().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(68.5869, Ryy.Millimeters, 4);
            Assert.Equal(57.2221, Rzz.Millimeters, 4);
        }

        [Fact]
        public void DoubleAngle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateDoubleAngle().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(5.38983, Ryy.Millimeters, 5);
            Assert.Equal(30.744, Rzz.Millimeters, 3);
        }

        [Fact]
        public void DoubleChannel()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateDoubleChannel().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(79.8028, Ryy.Millimeters, 4);
            Assert.Equal(47.44406, Rzz.Millimeters, 4);
        }

        [Fact]
        public void Ellipse()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateEllipse().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(30.0, Ryy.Millimeters, 0);
            Assert.Equal(45.0, Rzz.Millimeters, 0);
        }

        [Fact]
        public void EllipseHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateEllipseHollow().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(39.6695, Ryy.Millimeters, 4);
            Assert.Equal(55.5074, Rzz.Millimeters, 4);
        }

        [Fact]
        public void ParallelFlange()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateIParallelFlange().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(211.923, Ryy.Millimeters, 3);
            Assert.Equal(72.7323, Rzz.Millimeters, 4);
        }

        [Fact]
        public void I()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateI().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(90.2742, Ryy.Millimeters, 4);
            Assert.Equal(137.193, Rzz.Millimeters, 3);
        }

        [Fact]
        public void Rectangle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRectangle().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(6.63953, Ryy.Millimeters, 5);
            Assert.Equal(15.5885, Rzz.Millimeters, 4);
        }

        [Fact]
        public void RectangularHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRectangularHollow().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(86.6992, Ryy.Millimeters, 4);
            Assert.Equal(177.898, Rzz.Millimeters, 3);
        }

        [Fact]
        public void RoundedRectangle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRoundedRectangle().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(70.7767, Ryy.Millimeters, 4);
            Assert.Equal(56.8459, Rzz.Millimeters, 4);
        }

        [Fact]
        public void RoundedRectangularHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRoundedRectangularHollow().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(169.65, Ryy.Millimeters, 2);
            Assert.Equal(260.85, Rzz.Millimeters, 2);
        }

        [Fact]
        public void Tee()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateTee().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(63.7779, Ryy.Millimeters, 0);
            Assert.Equal(19.5247, Rzz.Millimeters, 0);
        }

        [Fact]
        public void Trapezoid()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateTrapezoid().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(57.4373, Ryy.Millimeters, 4);
            Assert.Equal(36.9122, Rzz.Millimeters, 4);
        }

        [Fact]
        public void Z()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateZ().Profile;

            // Act
            Length Ryy = Utility.RadiusOfGyration.CalculateRadiusOfGyrationYy(section);
            Length Rzz = Utility.RadiusOfGyration.CalculateRadiusOfGyrationZz(section);

            // Assert
            Assert.Equal(158.548, Ryy.Millimeters, 3);
            Assert.Equal(119.793, Rzz.Millimeters, 3);
        }
    }
}
