using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Materials;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections;
using OasysUnits;
using OasysUnits.Units;

namespace SectionPropertiesTests.TestUtility
{
    internal static class ConcreteSections
    {
        internal static ConcreteSection Perimeter()
        {
            LengthUnit unit = LengthUnit.Millimeter;
            IMaterial material = new MockMaterial(MaterialType.Concrete);
            IProfile profile = PerimeterRectangle400x750();
            double link = 10;
            double cover = 25;
            var rebars = new List<ILongitudinalReinforcement>()
            {
                Rebar(12, -200, 375, link, cover),
                Rebar(12, 200, 375, link, cover),
                Rebar(20, -200, -375, link, cover),
                Rebar(20, -51.666667, -330),
                Rebar(20, 51.666667, -330),
                Rebar(20, 200, -375, link, cover),
            };

            return new ConcreteSection(profile, material, Bar(link), new Length(cover, unit), rebars);
        }

        internal static ConcreteSection Rectangle()
        {
            LengthUnit unit = LengthUnit.Millimeter;
            IMaterial material = new MockMaterial(MaterialType.Concrete);
            IProfile profile = Rectangle400x750();
            double link = 10;
            double cover = 25;
            var rebars = new List<ILongitudinalReinforcement>()
            {
                Rebar(12, -200, 375, link, cover),
                Rebar(12, 200, 375, link, cover),
                Rebar(20, -200, -375, link, cover),
                Rebar(20, -51.666667, -330),
                Rebar(20, 51.666667, -330),
                Rebar(20, 200, -375, link, cover),
            };

            return new ConcreteSection(profile, material, Bar(link), new Length(cover, unit), rebars);
        }

        private static LongitudinalReinforcement Rebar(double dia, double edgeY, double edgeZ, double link, double cover)
        {
            LengthUnit unit = LengthUnit.Millimeter;
            double posY = edgeY > 0
                ? edgeY - link - cover - dia / 2
                : edgeY + link + cover + dia / 2;
            double posZ = edgeZ > 0
                ? edgeZ - link - cover - dia / 2
                : edgeZ + link + cover + dia / 2;
            return new LongitudinalReinforcement(Bar(dia),
                    new LocalPoint2d()
                    {
                        Y = new Length(posY, unit),
                        Z = new Length(posZ, unit)
                    });
        }

        private static LongitudinalReinforcement Rebar(double dia, double posY, double posZ)
        {
            LengthUnit unit = LengthUnit.Millimeter;
            return new LongitudinalReinforcement(Bar(dia),
                    new LocalPoint2d()
                    {
                        Y = new Length(posY, unit),
                        Z = new Length(posZ, unit)
                    });
        }

        private static Rebar Bar(double dia)
        {
            Length diameter = new Length(dia, LengthUnit.Millimeter);
            return new Rebar(new MockMaterial(MaterialType.Reinforcement), diameter);
        }

        private static Perimeter PerimeterRectangle400x750()
        {
            LengthUnit unit = LengthUnit.Millimeter;
            var solidEdge = new LocalPolyline2d(new List<ILocalPoint2d>()
            {
                new LocalPoint2d() { Y = new Length(-200, unit), Z = new Length(-375, unit)},
                new LocalPoint2d() { Y = new Length(200, unit), Z = new Length(-375, unit)},
                new LocalPoint2d() { Y = new Length(200, unit), Z = new Length(375, unit)},
                new LocalPoint2d() { Y = new Length(-200, unit), Z = new Length(375, unit)},
            });

            return new Perimeter(solidEdge);
        }

        private static Rectangle Rectangle400x750()
        {
            LengthUnit unit = LengthUnit.Millimeter;
            Length width = new Length(400, unit);
            Length height = new Length(750, unit);
            return new Rectangle(width, height);
        }

        private static Circle CircleD550()
        {
            LengthUnit unit = LengthUnit.Millimeter;
            Length diameter = new Length(550, unit);
            return new Circle(diameter);
        }

        private static Tee Tee800x500()
        {
            LengthUnit unit = LengthUnit.Millimeter;
            Length width = new Length(800, unit);
            Length height = new Length(500, unit);
            Length flange = new Length(150, unit);
            Length web = new Length(90, unit);
            return new Tee(height, width, flange, web);
        }
    }
}
