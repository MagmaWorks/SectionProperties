using MagmaWorks.Taxonomy.Profiles;
using Utility = MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;

namespace SectionPropertiesTests
{
    public class InertiaTests
    {
        [Fact]
        public void Angle()
        {
            // Assemble
            IProfile section = Sections.CreateAngle().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(26063.9, Iyy.MillimetersToTheFourth, 1);
            Assert.Equal(234253, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void C()
        {
            // Assemble
            IProfile section = Sections.CreateC().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(25.135479E+6, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(4.878127E+6, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void Channel()
        {
            // Assemble
            IProfile section = Sections.CreateChannel().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(30.027431E+6, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(4.76693E+6, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void Circle()
        {
            // Assemble
            IProfile section = Sections.CreateCircle().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            double expected = Math.PI / 64 * Math.Pow(300, 4);
            Assert.Equal(expected, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(expected, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void CircularHollow()
        {
            // Assemble
            IProfile section = Sections.CreateCircularHollow().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            double expected = Math.PI / 64 * (Math.Pow(200, 4) - Math.Pow(180, 4));
            Assert.Equal(expected, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(expected, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void Cruciform()
        {
            // Assemble
            IProfile section = Sections.CreateCruciform().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(23173.6, Iyy.MillimetersToTheFourth, 1);
            Assert.Equal(197693, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void CustomI()
        {
            // Assemble
            IProfile section = Sections.CreateCustomI().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(12466, Iyy.CentimetersToTheFourth, 0);
            Assert.Equal(8677.08, Izz.CentimetersToTheFourth, 2);
        }

        [Fact]
        public void DoubleAngle()
        {
            // Assemble
            IProfile section = Sections.CreateDoubleAngle().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(52127.9, Iyy.MillimetersToTheFourth, 1);
            Assert.Equal(1696076.77, Izz.MillimetersToTheFourth, 2);
        }

        [Fact]
        public void DoubleChannel()
        {
            // Assemble
            IProfile section = Sections.CreateDoubleChannel().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(60.054861E+6, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(21226357, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void Ellipse()
        {
            // Assemble
            IProfile section = Sections.CreateEllipse().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(15.26814E+6, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(34.353316E+6, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void EllipseHollow()
        {
            // Assemble
            IProfile section = Sections.CreateEllipseHollow().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(9.593552E+6, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(18.783133E+6, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void ParallelFlange()
        {
            // Assemble
            IProfile section = Sections.CreateIParallelFlange().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(1072, Iyy.MillimetersToTheFourth / Math.Pow(10, 6), 0);
            Assert.Equal(126.2, Izz.MillimetersToTheFourth / Math.Pow(10, 6), 1);
        }

        [Fact]
        public void I()
        {
            // Assemble
            IProfile section = Sections.CreateI().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(138.586913E+6, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(320.078830E+6, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void Rectangle()
        {
            // Assemble
            IProfile section = Sections.CreateRectangle().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(1.0 / 12 * 54 * 23 * 23 * 23, Iyy.MillimetersToTheFourth, 10);
            Assert.Equal(1.0 / 12 * 23 * 54 * 54 * 54, Izz.MillimetersToTheFourth, 10);
        }

        [Fact]
        public void RectangularHollow()
        {
            // Assemble
            IProfile section = Sections.CreateRectangularHollow().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(112.280434E+6, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(472.734150E+6, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void RoundedRectangle()
        {
            // Assemble
            IProfile section = Sections.CreateRoundedRectangle().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(245091834, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(158105180, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void RoundedRectangularHollow()
        {
            // Assemble
            IProfile section = Sections.CreateRoundedRectangularHollow().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(344780828, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(815060305, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void Tee()
        {
            // Assemble
            IProfile section = Sections.CreateTee().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(13.663128E+6, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(1.280502E+6, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void Trapezoid()
        {
            // Assemble
            IProfile section = Sections.CreateTrapezoid().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(82864206, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(34223092, Izz.MillimetersToTheFourth, 0);
        }

        [Fact]
        public void Z()
        {
            // Assemble
            IProfile section = Sections.CreateZ().Profile;

            // Act
            AreaMomentOfInertia Iyy = Utility.Inertiae.CalculateInertiaYy(section);
            AreaMomentOfInertia Izz = Utility.Inertiae.CalculateInertiaZz(section);

            // Assert
            Assert.Equal(472.585816E+6, Iyy.MillimetersToTheFourth, 0);
            Assert.Equal(280585816, Izz.MillimetersToTheFourth, 0);
        }
    }
}
