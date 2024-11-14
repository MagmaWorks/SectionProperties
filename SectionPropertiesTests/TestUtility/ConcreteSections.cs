using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using OasysUnits.Units;
using OasysUnits;

namespace SectionPropertiesTests.TestUtility
{
    internal static class ConcreteSections
    {
        private static Perimeter PerimeterRectangle400x750()
        {
            LengthUnit unit = LengthUnit.Millimeter;
            var solidEdge = new LocalPolygon2d(new List<ILocalPoint2d>()
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
    }
}
