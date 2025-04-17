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
            IProfile section = Sections.CreateAngle().Profile;

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
            IProfile section = Sections.CreateC().Profile;

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
            IProfile section = Sections.CreateChannel().Profile;

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
            IProfile section = Sections.CreateCircle().Profile;

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
            IProfile section = Sections.CreateCircularHollow().Profile;

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
            IProfile section = Sections.CreateCruciform().Profile;

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
            IProfile section = Sections.CreateCustomI().Profile;

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
            IProfile section = Sections.CreateDoubleAngle().Profile;

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
            IProfile section = Sections.CreateDoubleChannel().Profile;

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
            IProfile section = Sections.CreateEllipse().Profile;

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
            IProfile section = Sections.CreateEllipseHollow().Profile;

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
            IProfile section = Sections.CreateIParallelFlange().Profile;

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
            IProfile section = Sections.CreateI().Profile;

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
            IProfile section = Sections.CreateRectangle().Profile;

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
            IProfile section = Sections.CreateRectangularHollow().Profile;

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
            IProfile section = Sections.CreateRoundedRectangle().Profile;

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
            IProfile section = Sections.CreateRoundedRectangularHollow().Profile;

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
            IProfile section = Sections.CreateTee().Profile;

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
            IProfile section = Sections.CreateTrapezoid().Profile;

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
            IProfile section = Sections.CreateZ().Profile;

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
            IProfile section = Sections.Perimeter().Profile;

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
