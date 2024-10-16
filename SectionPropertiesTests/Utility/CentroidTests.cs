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
            IProfile section = TestUtility.Sections.CreateAngle().Profile;

            // Act
            ILocalPoint2d pt = Centroid.CalculateCentroid(section);

            // Assert
            Assert.Equal(24.9055, pt.Y.Millimeters, 4);
            Assert.Equal(8.6177, pt.Z.Millimeters, 4);
        }

        [Fact]
        public void C()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateC().Profile;

            // Act
            ILocalPoint2d pt = Centroid.CalculateCentroid(section);

            // Assert
            Assert.Equal(33.6747, pt.Y.Millimeters, 4);
            Assert.Equal(0, pt.Z.Millimeters);
        }

        [Fact]
        public void Channel()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateChannel().Profile;

            // Act
            ILocalPoint2d pt = Centroid.CalculateCentroid(section);

            // Assert
            Assert.Equal(33.8743, pt.Y.Millimeters, 4);
            Assert.Equal(0, pt.Z.Millimeters);
        }

        [Fact]
        public void Tee()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateTee().Profile;

            // Act
            ILocalPoint2d pt = Centroid.CalculateCentroid(section);

            // Assert
            Assert.Equal(0, pt.Y.Millimeters);
            Assert.Equal(-62.748, pt.Z.Millimeters, 3);
        }

        [Fact]
        public void Trapezoid()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateTrapezoid().Profile;

            // Act
            ILocalPoint2d pt = Centroid.CalculateCentroid(section);

            // Assert
            Assert.Equal(0, pt.Y.Millimeters);
            Assert.Equal(-6.65537, pt.Z.Millimeters, 5);
        }

        [Fact]
        public void Z()
        {
            // Assemble
            IProfile section = TestUtility.Sections.CreateZ().Profile;

            // Act
            ILocalPoint2d pt = Centroid.CalculateCentroid(section);

            // Assert
            Assert.Equal(-29.7872, pt.Y.Millimeters, 4);
            Assert.Equal(-20.2128, pt.Z.Millimeters, 4);
        }

        [Fact]
        public void PerimeterWithVoid()
        {
            // Assemble
            IPerimeter section = (IPerimeter)TestUtility.Sections.PerimeterVoided().Profile;

            // Act
            ILocalPoint2d pt = Centroid.CalculateCentroid(section);

            // Assert
            Assert.Equal(0, pt.Y.Value);
            Assert.Equal(-0.666666666666667, pt.Z.Centimeters, 12);
        }

        [Fact]
        public void Perimeter()
        {
            // Assemble
            IPerimeter section = (IPerimeter)TestUtility.Sections.Perimeter().Profile;

            // Act
            ILocalPoint2d pt = Centroid.CalculateCentroid(section);

            // Assert
            Assert.Equal(0, pt.Y.Value, 12);
            Assert.Equal(-134.5679, pt.Z.Millimeters, 5);
        }
    }
}
