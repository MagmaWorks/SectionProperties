using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;

namespace SectionPropertiesTests
{
    public class ExtendsTests
    {
        [Fact]
        public void Angle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateAngle().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(5.4, domain.Max.Y.Centimeters);
            Assert.Equal(0, domain.Min.Y.Centimeters);
            Assert.Equal(2.3, domain.Max.Z.Centimeters);
            Assert.Equal(0, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void C()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateC().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(10.04, domain.Max.Y.Centimeters, 12);
            Assert.Equal(0, domain.Min.Y.Centimeters, 12);
            Assert.Equal(20.03 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-20.03 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void Channel()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateChannel().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(10.04, domain.Max.Y.Centimeters, 12);
            Assert.Equal(0, domain.Min.Y.Centimeters, 12);
            Assert.Equal(20.03 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-20.03 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void Circle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCircle().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(30 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-30 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(30 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-30 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void CircularHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCircularHollow().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(20 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-20 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(20 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-20 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void Cruciform()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCruciform().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(5.4 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-5.4 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(2.3 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-2.3 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void CustomI()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateCustomI().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(25.0 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-25.0 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(20.0 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-20.0 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void DoubleAngle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateDoubleAngle().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(5.4 + 0.25 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-5.4 - 0.25 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(2.3, domain.Max.Z.Centimeters);
            Assert.Equal(0, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void DoubleChannel()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateDoubleChannel().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(10.04 + 0.25 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-10.04 - 0.25 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(20.03 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-20.03 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void Ellipse()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateEllipse().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(18 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-18 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(12 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-12 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void EllipseHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateEllipseHollow().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(18 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-18 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(12 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-12 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void ParallelFlange()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateIParallelFlange().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(30 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-30 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(50 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-50 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void I()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateI().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(50.4 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-50.4 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(20.3 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-20.3 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void Rectangle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRectangle().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(5.4 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-5.4 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(2.3 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-2.3 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void RectangularHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRectangularHollow().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(50.4 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-50.4 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(20.3 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-20.3 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void RoundedRectangle()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRoundedRectangle().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(20.0 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-20.0 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(25.0 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-25.0 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void RoundedRectangularHollow()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateRoundedRectangularHollow().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(70.0 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-70.0 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(40.0 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-40.0 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void Tee()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateTee().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(10.04 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-10.04 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(0, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-20.03, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void Trapezoid()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateTrapezoid().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(15.04 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-15.04 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(20.03 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-20.03 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void Z()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateZ().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(20 - 2.0 / 2, domain.Max.Y.Centimeters);
            Assert.Equal(-30 + 2.0 / 2, domain.Min.Y.Centimeters);
            Assert.Equal(40.0 / 2, domain.Max.Z.Centimeters);
            Assert.Equal(-40.0 / 2, domain.Min.Z.Centimeters);
        }

        [Fact]
        public void Perimeter()
        {
            // Assemble
            IProfile section = TestUtility.Sections.Perimeter().Profile;

            // Act
            ILocalDomain2d domain = Extends.GetDomain(section);

            // Assert
            Assert.Equal(650, domain.Max.Y.Millimeters);
            Assert.Equal(-650, domain.Min.Y.Millimeters);
            Assert.Equal(200, domain.Max.Z.Millimeters);
            Assert.Equal(-800, domain.Min.Z.Millimeters);
        }
    }
}
