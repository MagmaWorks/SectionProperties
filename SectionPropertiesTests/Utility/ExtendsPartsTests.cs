using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts;

namespace SectionPropertiesTests
{
    public class ExtendsPartsTests
    {
        [Fact]
        public void Angle()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateAngle().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(5.4, domain.Max.Y.Centimeters, 12);
            Assert.Equal(0, domain.Min.Y.Centimeters, 12);
            Assert.Equal(2.3, domain.Max.Z.Centimeters, 12);
            Assert.Equal(0, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void C()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateC().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

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
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateChannel().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

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
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateCircle().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(30 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-30 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(30 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-30 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void CircularHollow()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateCircularHollow().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(20 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-20 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(20 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-20 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void Cruciform()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateCruciform().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(5.4 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-5.4 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(2.3 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-2.3 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void CustomI()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateCustomI().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(25.0 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-25.0 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(20.0 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-20.0 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void DoubleAngle()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateDoubleAngle().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(5.4 + 0.25 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-5.4 - 0.25 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(2.3, domain.Max.Z.Centimeters, 12);
            Assert.Equal(0, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void DoubleChannel()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateDoubleChannel().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

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
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateEllipse().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(18 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-18 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(12 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-12 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void EllipseHollow()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateEllipseHollow().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(18 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-18 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(12 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-12 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void ParallelFlange()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateIParallelFlange().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(30 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-30 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(50 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-50 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void I()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateI().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(50.4 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-50.4 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(20.3 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-20.3 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void Rectangle()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateRectangle().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(5.4 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-5.4 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(2.3 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-2.3 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void RectangularHollow()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateRectangularHollow().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(50.4 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-50.4 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(20.3 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-20.3 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void RoundedRectangle()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateRoundedRectangle().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(20.0 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-20.0 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(25.0 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-25.0 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void RoundedRectangularHollow()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateRoundedRectangularHollow().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(70.0 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-70.0 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(40.0 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-40.0 / 2, domain.Min.Z.Centimeters, 12);
        }

        [Fact]
        public void Tee()
        {
            // Assemble
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateTee().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

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
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateTrapezoid().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

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
            List<IPart> parts = ProfileParts.GetParts(TestUtility.Sections.CreateZ().Profile);

            // Act
            ILocalDomain2d domain = Extends.GetDomain(parts);

            // Assert
            Assert.Equal(20.0 - 2.0 / 2, domain.Max.Y.Centimeters, 12);
            Assert.Equal(-30.0 + 2.0 / 2, domain.Min.Y.Centimeters, 12);
            Assert.Equal(40.0 / 2, domain.Max.Z.Centimeters, 12);
            Assert.Equal(-40.0 / 2, domain.Min.Z.Centimeters, 12);
        }
    }
}
