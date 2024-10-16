using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Materials;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections;
using OasysUnits.Units;
using OasysUnits;
using Angle = MagmaWorks.Taxonomy.Profiles.Angle;

namespace SectionPropertiesTests.TestUtility
{
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

