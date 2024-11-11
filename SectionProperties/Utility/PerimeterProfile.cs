using System;
using System.Collections.Generic;
using System.Linq;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    internal static class PerimeterProfile
    {
        internal static OasysUnits.Area CalculateArea(IPerimeter perimeter)
        {
            OasysUnits.Area area = CalculatePartArea(perimeter.OuterEdge.Points);
            if (perimeter.VoidEdges == null || perimeter.VoidEdges.Count == 0)
            {
                return area;
            }

            foreach (ILocalPolygon2d hole in perimeter.VoidEdges)
            {
                area -= CalculatePartArea(hole.Points);
            }

            return area;
        }

        internal static ILocalPoint2d CalculateCentroid(IPerimeter perimeter)
        {
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

        internal static Length CalculateRadiusOfGyrationYy(IPerimeter perimeter)
        {
            OasysUnits.Area area = CalculateArea(perimeter);
            AreaMomentOfInertia inertia = CalculateInertiaYy(perimeter);
            return RadiusOfGyration.CalculateRadiusOfGyration(area, inertia);
        }

        internal static Length CalculateRadiusOfGyrationZz(IPerimeter perimeter)
        {
            OasysUnits.Area area = CalculateArea(perimeter);
            AreaMomentOfInertia inertia = CalculateInertiaZz(perimeter);
            return RadiusOfGyration.CalculateRadiusOfGyration(area, inertia);
        }

        internal static AreaMomentOfInertia CalculateInertiaYy(IPerimeter perimeter)
        {
            IPerimeter centredOnElasticCentroid = MoveToElasticCentroid(perimeter);
            AreaMomentOfInertia inertia = CalculatePartInertiaYy(centredOnElasticCentroid.OuterEdge.Points);
            if (centredOnElasticCentroid.VoidEdges == null || centredOnElasticCentroid.VoidEdges.Count == 0)
            {
                return inertia;
            }

            foreach (ILocalPolygon2d hole in centredOnElasticCentroid.VoidEdges)
            {
                inertia -= CalculatePartInertiaYy(hole.Points);
            }

            return inertia;
        }

        internal static AreaMomentOfInertia CalculateInertiaZz(IPerimeter perimeter)
        {
            IPerimeter centredOnElasticCentroid = MoveToElasticCentroid(perimeter);
            AreaMomentOfInertia inertia = CalculatePartInertiaZz(centredOnElasticCentroid.OuterEdge.Points);
            if (centredOnElasticCentroid.VoidEdges == null || centredOnElasticCentroid.VoidEdges.Count == 0)
            {
                return inertia;
            }

            foreach (ILocalPolygon2d hole in centredOnElasticCentroid.VoidEdges)
            {
                inertia -= CalculatePartInertiaZz(hole.Points);
            }

            return inertia;
        }

        private static AreaMomentOfInertia CalculatePartInertiaYy(IList<ILocalPoint2d> p)
        {
            double inertia = 0;
            LengthUnit unit = p.FirstOrDefault().Z.Unit;
            for (int i = 0; i < p.Count - 1; i++)
            {
                inertia += (p[i].Y.As(unit) * p[i + 1].Z.As(unit) - p[i + 1].Y.As(unit) * p[i].Z.As(unit))
                    * (Math.Pow(p[i].Z.As(unit), 2) + p[i].Z.As(unit) * p[i + 1].Z.As(unit) + Math.Pow(p[i + 1].Z.As(unit), 2));
            }

            inertia = Math.Abs(inertia) / 12;
            AreaMomentOfInertia m4 = AreaMomentOfInertia.Zero;
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit)}⁴", out m4);
            return new AreaMomentOfInertia(inertia, m4.Unit);
        }

        private static AreaMomentOfInertia CalculatePartInertiaZz(IList<ILocalPoint2d> p)
        {
            double inertia = 0;
            LengthUnit unit = p.FirstOrDefault().Y.Unit;
            for (int i = 0; i < p.Count - 1; i++)
            {
                inertia += (p[i].Y.As(unit) * p[i + 1].Z.As(unit) - p[i + 1].Y.As(unit) * p[i].Z.As(unit))
                    * (Math.Pow(p[i].Y.As(unit), 2) + p[i].Y.As(unit) * p[i + 1].Y.As(unit) + Math.Pow(p[i + 1].Y.As(unit), 2));
            }

            inertia = Math.Abs(inertia) / 12;
            AreaMomentOfInertia m4 = AreaMomentOfInertia.Zero;
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit)}⁴", out m4);
            return new AreaMomentOfInertia(inertia, m4.Unit);
        }

        internal static IPerimeter MoveToElasticCentroid(IPerimeter perimeter)
        {
            ILocalPoint2d centroid = CalculateCentroid(perimeter);
            ILocalPoint2d translation = new LocalPoint2d()
            {
                Y = centroid.Y * -1,
                Z = centroid.Z * -1
            };

            IList<ILocalPoint2d> outerPoints = new List<ILocalPoint2d>();
            foreach (ILocalPoint2d pt in perimeter.OuterEdge.Points)
            {
                outerPoints.Add(Move(pt, translation));
            }
            ILocalPolygon2d outerEdge = new LocalPolygon2d(outerPoints);

            if (perimeter.VoidEdges == null || perimeter.VoidEdges.Count == 0)
            {
                return new Perimeter(outerEdge);
            }

            IList<ILocalPolygon2d> voidEdges = new List<ILocalPolygon2d>();
            foreach (ILocalPolygon2d voidEdge in perimeter.VoidEdges)
            {
                IList<ILocalPoint2d> voidPoints = new List<ILocalPoint2d>();
                foreach (ILocalPoint2d pt in voidEdge.Points)
                {
                    voidPoints.Add(Move(pt, translation));
                }
                ILocalPolygon2d translatedVoidEdge = new LocalPolygon2d(voidPoints);
                voidEdges.Add(translatedVoidEdge);
            }

            return new Perimeter(outerEdge, voidEdges);
        }

        private static ILocalPoint2d Move(ILocalPoint2d point, ILocalPoint2d translation)
        {
            return new LocalPoint2d()
            {
                Y = point.Y + translation.Y,
                Z = point.Z + translation.Z,
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
