using System;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class PerimeterLength
    {
        public static Length CalculatePerimeter(IProfile profile)
        {
            IPerimeter perimeter = new Profiles.Perimeter(profile);
            Length length = Length.Zero;
            for (int i = 0; i < perimeter.OuterEdge.Points.Count - 1; i++)
            {
                length += Distance(perimeter.OuterEdge.Points[i],
                    perimeter.OuterEdge.Points[i + 1]);
            }

            return length;
        }

        private static Length Distance(ILocalPoint2d p1, ILocalPoint2d p2)
        {
            LengthUnit unit = p1.Y.Unit;
            double area = Math.Pow((p1.Y.As(unit) - p2.Y.As(unit)), 2)
                        + Math.Pow((p1.Z.As(unit) - p2.Z.As(unit)), 2);
            return new Length(Math.Sqrt(area), unit);
        }
    }
}
