using System.Collections.Generic;
using System.Linq;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    internal static class Perimeter
    {
        internal static OasysUnits.Area CalculateArea(IPerimeter profile)
        {
            IPerimeter perimeter = new Profiles.Perimeter(profile);
            OasysUnits.Area area = CalculatePartArea(perimeter.OuterEdge.Points);
            if (perimeter.VoidEdges != null)
            {
                foreach (ILocalPolygon2d hole in perimeter.VoidEdges)
                {
                    area -= CalculatePartArea(hole.Points);
                }
            }

            return area;
        }

        internal static ILocalPoint2d CalculateCentroid(IPerimeter profile)
        {
            IPerimeter perimeter = new Profiles.Perimeter(profile);
            if (perimeter.VoidEdges == null || perimeter.VoidEdges.Count == 0)
            {
                return CalculatePartCentroid(perimeter.OuterEdge.Points);
            }

            OasysUnits.Area edgeArea = CalculatePartArea(perimeter.OuterEdge.Points);
            ILocalPoint2d edgeCentroid = CalculatePartCentroid(perimeter.OuterEdge.Points);
            Volume qz = edgeArea * edgeCentroid.Y;
            Volume qy = edgeArea * edgeCentroid.Z;
            foreach (ILocalPolygon2d hole in perimeter.VoidEdges)
            {
                OasysUnits.Area holeArea = CalculatePartArea(hole.Points);
                ILocalPoint2d holeCentroid = CalculatePartCentroid(hole.Points);
                qz -= holeArea * holeCentroid.Y;
                qy -= holeArea * holeCentroid.Z;
                edgeArea -= holeArea;
            }

            return new LocalPoint2d()
            {
                Y = qz / edgeArea,
                Z = qy / edgeArea,
            };
        }

        private static OasysUnits.Area CalculatePartArea(IList<ILocalPoint2d> pts)
        {
            OasysUnits.Area res = OasysUnits.Area.Zero;
            OasysUnits.Area.TryParse($"0 {Length.GetAbbreviation(pts.FirstOrDefault().Y.Unit)}²", out res);

            for (int i = 0; i < pts.Count - 1; i++)
            {
                res += (pts[i].Y * pts[i + 1].Z - pts[i].Z * pts[i + 1].Y) / 2;
            }

            return res.Abs();
        }

        private static LocalPoint2d CalculatePartCentroid(IList<ILocalPoint2d> pts)
        {
            // Add the first point at the end of the array.
            int num_points = pts.Count;
            ILocalPoint2d[] points = new LocalPoint2d[num_points + 1];
            pts.CopyTo(points, 0);
            points[num_points] = pts[0];

            LengthUnit unit = pts.FirstOrDefault().Y.Unit;

            // Find the centroid.
            Length y = Length.Zero;
            Length z = Length.Zero;
            double second_factor;
            for (int i = 0; i < num_points; i++)
            {
                second_factor = points[i].Y.As(unit) * points[i + 1].Z.As(unit)
                              - points[i + 1].Y.As(unit) * points[i].Z.As(unit);
                y += (points[i].Y + points[i + 1].Y) * second_factor;
                z += (points[i].Z + points[i + 1].Z) * second_factor;
            }

            // Divide by 6 times the polygon's area.
            double area = CalculatePartArea(pts).Value;
            y /= 6 * area;
            z /= 6 * area;

            // If the values are negative, the polygon is
            // oriented clockwise so reverse the signs.
            if (IsClockwise(pts))
            {
                y = -y;
                z = -z;
            }

            return new LocalPoint2d(y, z);
        }

        private static bool IsClockwise(IList<ILocalPoint2d> pts)
        {
            OasysUnits.Area res = OasysUnits.Area.Zero;
            OasysUnits.Area.TryParse($"0 {Length.GetAbbreviation(pts.FirstOrDefault().Y.Unit)}²", out res);

            for (int i = 0; i < pts.Count - 1; i++)
            {
                res += (pts[i].Y * pts[i + 1].Z - pts[i].Z * pts[i + 1].Y) / 2;
            }

            return res.Value < 0;
        }
    }
}
