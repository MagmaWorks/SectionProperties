using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Materials;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections;
using OasysUnits;
using OasysUnits.Units;
using Angle = MagmaWorks.Taxonomy.Profiles.Angle;

namespace SectionPropertiesTests.TestUtility
{
    public class MockHEB500 : IIParallelFlange
    {
        public Length FilletRadius => new Length(27, LengthUnit.Millimeter);
        public Length Height => new Length(500, LengthUnit.Millimeter);
        public Length Width => new Length(300, LengthUnit.Millimeter);
        public Length FlangeThickness => new Length(28, LengthUnit.Millimeter);
        public Length WebThickness => new Length(14.5, LengthUnit.Millimeter);

        public MockHEB500() { }
    }

    internal static class Sections
    {
        public static ISection CreateAngle()
        {
            var h = new Length(2.3, LengthUnit.Centimeter);
            var w = new Length(5.4, LengthUnit.Centimeter);
            var webThk = new Length(10.9, LengthUnit.Millimeter);
            var flangeThk = new Length(15, LengthUnit.Millimeter);
            IAngle prfl = new Angle(h, w, webThk, flangeThk);
            return MockSection(prfl);
        }

        public static ISection CreateC()
        {
            var h = new Length(200.3, LengthUnit.Millimeter);
            var w = new Length(100.4, LengthUnit.Millimeter);
            var webThk = new Length(10, LengthUnit.Millimeter);
            var flangeThk = new Length(10, LengthUnit.Millimeter);
            var lip = new Length(25, LengthUnit.Millimeter);
            IC prfl = new C(h, w, webThk, flangeThk, lip);
            return MockSection(prfl);
        }

        public static ISection CreateChannel()
        {
            var h = new Length(200.3, LengthUnit.Millimeter);
            var w = new Length(100.4, LengthUnit.Millimeter);
            var webThk = new Length(10, LengthUnit.Millimeter);
            var flangeThk = new Length(15, LengthUnit.Millimeter);
            IChannel prfl = new Channel(h, w, webThk, flangeThk);
            return MockSection(prfl);
        }

        public static ISection CreateCircle()
        {
            var dia = new Length(30.0, LengthUnit.Centimeter);
            ICircle prfl = new Circle(dia);
            return MockSection(prfl);
        }

        public static ISection CreateCircularHollow()
        {
            var dia = new Length(20, LengthUnit.Centimeter);
            var thk = new Length(10, LengthUnit.Millimeter);
            ICircularHollow prfl = new CircularHollow(dia, thk);
            return MockSection(prfl);
        }

        public static ISection CreateCruciform()
        {
            var h = new Length(2.3, LengthUnit.Centimeter);
            var w = new Length(5.4, LengthUnit.Centimeter);
            var flangeThk = new Length(15, LengthUnit.Millimeter);
            var webThk = new Length(10.9, LengthUnit.Millimeter);
            ICruciform prfl = new Cruciform(h, w, flangeThk, webThk);
            return MockSection(prfl);
        }

        public static ISection CreateCustomI()
        {
            var h = new Length(20, LengthUnit.Centimeter);
            var wTop = new Length(20, LengthUnit.Centimeter);
            var wBottom = new Length(25, LengthUnit.Centimeter);
            var webThk = new Length(5, LengthUnit.Centimeter);
            var topFlangeThk = new Length(7, LengthUnit.Centimeter);
            var bottomFlangeThk = new Length(3, LengthUnit.Centimeter);
            ICustomI prfl = new CustomI(h, wTop, wBottom, topFlangeThk, bottomFlangeThk, webThk);
            return MockSection(prfl);
        }

        public static ISection CreateDoubleAngle()
        {
            var h = new Length(2.3, LengthUnit.Centimeter);
            var w = new Length(5.4, LengthUnit.Centimeter);
            var webThk = new Length(10.9, LengthUnit.Millimeter);
            var flangeThk = new Length(15, LengthUnit.Millimeter);
            var dist = new Length(2.5, LengthUnit.Millimeter);
            IDoubleAngle prfl = new DoubleAngle(h, w, webThk, flangeThk, dist);
            return MockSection(prfl);
        }

        public static ISection CreateDoubleChannel()
        {
            var h = new Length(200.3, LengthUnit.Millimeter);
            var w = new Length(100.4, LengthUnit.Millimeter);
            var webThk = new Length(10, LengthUnit.Millimeter);
            var flangeThk = new Length(15, LengthUnit.Millimeter);
            var dist = new Length(2.5, LengthUnit.Millimeter);
            IDoubleChannel prfl = new DoubleChannel(h, w, webThk, flangeThk, dist);
            return MockSection(prfl);
        }

        public static ISection CreateEllipse()
        {
            var h = new Length(12, LengthUnit.Centimeter);
            var w = new Length(18, LengthUnit.Centimeter);
            IEllipse prfl = new Ellipse(h, w);
            return MockSection(prfl);
        }

        public static ISection CreateEllipseHollow()
        {
            var h = new Length(12, LengthUnit.Centimeter);
            var w = new Length(18, LengthUnit.Centimeter);
            var thk = new Length(14.3, LengthUnit.Millimeter);
            IEllipseHollow prfl = new EllipseHollow(h, w, thk);
            return MockSection(prfl);
        }

        public static ISection CreateIParallelFlange()
        {
            IIParallelFlange prfl = new MockHEB500();
            return MockSection(prfl);
        }

        public static ISection CreateI()
        {
            var h = new Length(20.3, LengthUnit.Centimeter);
            var w = new Length(50.4, LengthUnit.Centimeter);
            var flangeThk = new Length(15, LengthUnit.Millimeter);
            var webThk = new Length(10.9, LengthUnit.Millimeter);
            II prfl = new I(h, w, flangeThk, webThk);
            return MockSection(prfl);
        }

        public static ISection CreateRectangle()
        {
            var h = new Length(2.3, LengthUnit.Centimeter);
            var w = new Length(5.4, LengthUnit.Centimeter);
            IRectangle prfl = new Rectangle(h, w);
            return MockSection(prfl);
        }

        public static ISection CreateRectangularHollow()
        {
            var h = new Length(20.3, LengthUnit.Centimeter);
            var w = new Length(50.4, LengthUnit.Centimeter);
            var thk = new Length(10.9, LengthUnit.Millimeter);
            IRectangularHollow prfl = new RectangularHollow(h, w, thk);
            return MockSection(prfl);
        }

        public static ISection CreateRoundedRectangle()
        {
            var h = new Length(25, LengthUnit.Centimeter);
            var w = new Length(20, LengthUnit.Centimeter);
            var h1 = new Length(20, LengthUnit.Centimeter);
            var w1 = new Length(10, LengthUnit.Centimeter);
            IRoundedRectangle prfl = new RoundedRectangle(h, w, h1, w1);
            return MockSection(prfl);
        }

        public static ISection CreateRoundedRectangularHollow()
        {
            var h = new Length(40, LengthUnit.Centimeter);
            var w = new Length(70, LengthUnit.Centimeter);
            var h1 = new Length(30, LengthUnit.Centimeter);
            var w1 = new Length(50, LengthUnit.Centimeter);
            var thk = new Length(5.5, LengthUnit.Millimeter);
            IRoundedRectangularHollow prfl = new RoundedRectangularHollow(h, w, h1, w1, thk);
            return MockSection(prfl);
        }

        public static ISection CreateTee()
        {
            var h = new Length(200.3, LengthUnit.Millimeter);
            var w = new Length(100.4, LengthUnit.Millimeter);
            var webThk = new Length(10, LengthUnit.Millimeter);
            var flangeThk = new Length(15, LengthUnit.Millimeter);
            ITee prfl = new Tee(h, w, flangeThk, webThk);
            return MockSection(prfl);
        }

        public static ISection CreateTrapezoid()
        {
            var h = new Length(200.3, LengthUnit.Millimeter);
            var wTop = new Length(100.4, LengthUnit.Millimeter);
            var wBottom = new Length(150.4, LengthUnit.Millimeter);
            ITrapezoid prfl = new Trapezoid(h, wTop, wBottom);
            return MockSection(prfl);
        }

        public static ISection CreateZ()
        {
            var h = new Length(40, LengthUnit.Centimeter);
            var wTop = new Length(20, LengthUnit.Centimeter);
            var wBottom = new Length(30, LengthUnit.Centimeter);
            var thk = new Length(20, LengthUnit.Millimeter);
            var topLip = new Length(60, LengthUnit.Millimeter);
            var bottomLip = new Length(60, LengthUnit.Millimeter);
            IZ prfl = new Z(h, wTop, wBottom, thk, topLip, bottomLip);
            return MockSection(prfl);
        }

        public static ISection PerimeterVoided()
        {
            LengthUnit unit = LengthUnit.Centimeter;
            var solidEdge = new LocalPolygon2d(new List<ILocalPoint2d>()
            {
                new LocalPoint2d() { Y = new Length(-8, unit), Z = new Length(-5, unit)},
                new LocalPoint2d() { Y = new Length(-8, unit), Z = new Length(6, unit)},
                new LocalPoint2d() { Y = new Length(8, unit), Z = new Length(6, unit)},
                new LocalPoint2d() { Y = new Length(8, unit), Z = new Length(-5, unit)},
                new LocalPoint2d() { Y = new Length(-8, unit), Z = new Length(-5, unit)},
            });
            var voidEdge = new LocalPolygon2d(new List<ILocalPoint2d>()
            {
                new LocalPoint2d() { Y = new Length(-7, unit), Z = new Length(5, unit)},
                new LocalPoint2d() { Y = new Length(7, unit), Z = new Length(5, unit)},
                new LocalPoint2d() { Y = new Length(7, unit), Z = new Length(1, unit)},
                new LocalPoint2d() { Y = new Length(-7, unit), Z = new Length(1, unit)},
                new LocalPoint2d() { Y = new Length(-7, unit), Z = new Length(5, unit)},
            });

            IPerimeter profile = new Perimeter(solidEdge, new List<ILocalPolygon2d>() { voidEdge });
            return MockSection(profile);
        }

        public static ISection Perimeter()
        {
            LengthUnit unit = LengthUnit.Millimeter;
            var solidEdge = new LocalPolygon2d(new List<ILocalPoint2d>()
            {
                new LocalPoint2d() { Y = new Length(-650, unit), Z = new Length(200, unit)},
                new LocalPoint2d() { Y = new Length(650, unit), Z = new Length(200, unit)},
                new LocalPoint2d() { Y = new Length(650, unit), Z = new Length(0, unit)},
                new LocalPoint2d() { Y = new Length(350, unit), Z = new Length(0, unit)},
                new LocalPoint2d() { Y = new Length(150, unit), Z = new Length(-200, unit)},
                new LocalPoint2d() { Y = new Length(150, unit), Z = new Length(-800, unit)},
                new LocalPoint2d() { Y = new Length(-150, unit), Z = new Length(-800, unit)},
                new LocalPoint2d() { Y = new Length(-150, unit), Z = new Length(-200, unit)},
                new LocalPoint2d() { Y = new Length(-350, unit), Z = new Length(0, unit)},
                new LocalPoint2d() { Y = new Length(-650, unit), Z = new Length(0, unit)},
                new LocalPoint2d() { Y = new Length(-650, unit), Z = new Length(200, unit)},
            });

            IPerimeter profile = new Perimeter(solidEdge);
            return MockSection(profile);
        }

        public static ISection CreateRectangleShaped()
        {
            LengthUnit unit = LengthUnit.Millimeter;
            var solidEdge = new LocalPolygon2d(new List<ILocalPoint2d>()
            {
                new LocalPoint2d() { Y = new Length(-50, unit), Z = new Length(-250, unit)},
                new LocalPoint2d() { Y = new Length(50, unit), Z = new Length(-250, unit)},
                new LocalPoint2d() { Y = new Length(50, unit), Z = new Length(250, unit)},
                new LocalPoint2d() { Y = new Length(-50, unit), Z = new Length(250, unit)},
                new LocalPoint2d() { Y = new Length(-50, unit), Z = new Length(-250, unit)},
            });

            IPerimeter profile = new Perimeter(solidEdge);
            return MockSection(profile);
        }

        public static ISection CreateZShaped()
        {
            LengthUnit unit = LengthUnit.Meter;
            var solidEdge = new LocalPolygon2d(new List<ILocalPoint2d>()
            {
                new LocalPoint2d() { Y = new Length(0.75, unit), Z = new Length(0, unit)},
                new LocalPoint2d() { Y = new Length(2, unit), Z = new Length(0, unit)},
                new LocalPoint2d() { Y = new Length(2, unit), Z = new Length(0.5, unit)},
                new LocalPoint2d() { Y = new Length(1.25, unit), Z = new Length(0.5, unit)},
                new LocalPoint2d() { Y = new Length(1.25, unit), Z = new Length(1.5, unit)},
                new LocalPoint2d() { Y = new Length(0, unit), Z = new Length(1.5, unit)},
                new LocalPoint2d() { Y = new Length(0, unit), Z = new Length(1.0, unit)},
                new LocalPoint2d() { Y = new Length(0.75, unit), Z = new Length(1.0, unit)},
                new LocalPoint2d() { Y = new Length(0.75, unit), Z = new Length(0, unit)},
            });

            IPerimeter profile = new Perimeter(solidEdge);
            return MockSection(profile);
        }

        private static ISection MockSection<T>(T profile) where T : IProfile
        {
            IMaterial material = new MockMaterial();
            return new Section(material, profile);
        }
    }
}

