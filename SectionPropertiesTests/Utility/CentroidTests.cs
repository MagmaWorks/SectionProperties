using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;

namespace SectionPropertiesTests
{
    public class CentroidTests
    {
        [Fact]
        public void Angle()
        {
            // Assemble
            IProfile section = Sections.CreateAngle().Profile;

            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section);

            // Assert
            Assert.Equal(24.9055, pt.Y.Millimeters, 4);
            Assert.Equal(8.6177, pt.Z.Millimeters, 4);
        }

        [Fact]
        public void DoubleAngle()
        {
            // Assemble
            IProfile section = Sections.CreateDoubleAngle().Profile;

            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section);

            // Assert
            Assert.Equal(0, pt.Y.Millimeters, 4);
            Assert.Equal(8.6177, pt.Z.Millimeters, 4);
        }

        [Fact]
        public void C()
        {
            // Assemble
            IProfile section = Sections.CreateC().Profile;

            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section);

            // Assert
            Assert.Equal(33.6747, pt.Y.Millimeters, 4);
            Assert.Equal(0, pt.Z.Millimeters, 12);
        }

        [Fact]
        public void Channel()
        {
            // Assemble
            IProfile section = Sections.CreateChannel().Profile;

            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section);

            // Assert
            Assert.Equal(33.8743, pt.Y.Millimeters, 4);
            Assert.Equal(0, pt.Z.Millimeters);
        }

        [Fact]
        public void CustomI()
        {
            // Assemble
            IProfile section = Sections.CreateCustomI().Profile;

            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section);

            // Assert
            Assert.Equal(0, pt.Y.Millimeters);
            Assert.Equal(6.50943, pt.Z.Millimeters, 5);
        }

        [Fact]
        public void Tee()
        {
            // Assemble
            IProfile section = Sections.CreateTee().Profile;

            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section);

            // Assert
            Assert.Equal(0, pt.Y.Millimeters);
            Assert.Equal(-62.748, pt.Z.Millimeters, 3);
        }

        [Fact]
        public void Trapezoid()
        {
            // Assemble
            IProfile section = Sections.CreateTrapezoid().Profile;

            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section);

            // Assert
            Assert.Equal(0, pt.Y.Millimeters);
            Assert.Equal(-6.65537, pt.Z.Millimeters, 5);
        }

        [Fact]
        public void Z()
        {
            // Assemble
            IProfile section = Sections.CreateZ().Profile;

            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section);

            // Assert
            Assert.Equal(-29.7872, pt.Y.Millimeters, 4);
            Assert.Equal(-20.2128, pt.Z.Millimeters, 4);
        }

        [Fact]
        public void PerimeterWithVoid()
        {
            // Assemble
            IPerimeter section = (IPerimeter)Sections.PerimeterVoided().Profile;

            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section);

            // Assert
            Assert.Equal(0, pt.Y.Value);
            Assert.Equal(-0.666666666666667, pt.Z.Centimeters, 12);
        }

        [Fact]
        public void Perimeter()
        {
            // Assemble
            IPerimeter section = (IPerimeter)Sections.Perimeter().Profile;

            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section);

            // Assert
            Assert.Equal(0, pt.Y.Value, 12);
            Assert.Equal(-134.5679, pt.Z.Millimeters, 5);
        }

        [Theory]
        [MemberData(nameof(DoubleSymmetricProfiles))]
        public void DoubleSymmetricProfile(ISection section)
        {
            // Act
            ILocalPoint2d pt = Centroids.CalculateCentroid(section.Profile);

            // Assert
            Assert.Equal(0, pt.Y.Value, 12);
            Assert.Equal(0, pt.Z.Value, 12);
        }

        public static IEnumerable<object[]> DoubleSymmetricProfiles =>
            new List<object[]>
            {
            new object[] { Sections.CreateCircularHollow() },
            new object[] { Sections.CreateCircle() },
            new object[] { Sections.CreateCruciform() },
            new object[] { Sections.CreateEllipse() },
            new object[] { Sections.CreateEllipseHollow() },
            new object[] { Sections.CreateIParallelFlange() },
            new object[] { Sections.CreateI() },
            new object[] { Sections.CreateRectangularHollow() },
            new object[] { Sections.CreateRoundedRectangularHollow() },
            new object[] { Sections.CreateRoundedRectangle() },
            new object[] { Sections.CreateRectangle() },
            new object[] { Sections.CreateDoubleChannel() },
            };
    }
}
