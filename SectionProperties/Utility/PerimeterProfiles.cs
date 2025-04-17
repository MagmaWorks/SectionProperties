namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    internal static class PerimeterProfiles
    {
        internal static Area CalculateArea(IPerimeter perimeter)
        {
            Area area = CalculatePartArea(perimeter.OuterEdge.Points);
            if (perimeter.VoidEdges == null || perimeter.VoidEdges.Count == 0)
            {
                return area;
            }

            foreach (ILocalPolyline2d hole in perimeter.VoidEdges)
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

            Area edgeArea = CalculatePartArea(perimeter.OuterEdge.Points);
            ILocalPoint2d edgeCentroid = CalculatePartCentroid(perimeter.OuterEdge.Points);
            SectionModulus qz = edgeArea * edgeCentroid.Y;
            SectionModulus qy = edgeArea * edgeCentroid.Z;
            foreach (ILocalPolyline2d hole in perimeter.VoidEdges)
            {
                Area holeArea = CalculatePartArea(hole.Points);
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
            Area area = CalculateArea(perimeter);
            AreaMomentOfInertia inertia = CalculateInertiaYy(perimeter);
            return RadiusOfGyrations.CalculateRadiusOfGyration(area, inertia);
        }

        internal static Length CalculateRadiusOfGyrationZz(IPerimeter perimeter)
        {
            Area area = CalculateArea(perimeter);
            AreaMomentOfInertia inertia = CalculateInertiaZz(perimeter);
            return RadiusOfGyrations.CalculateRadiusOfGyration(area, inertia);
        }

        internal static AreaMomentOfInertia CalculateInertiaYy(IPerimeter perimeter)
        {
            IPerimeter centredOnElasticCentroid = MoveToElasticCentroid(perimeter);
            AreaMomentOfInertia inertia = CalculatePartInertiaYy(centredOnElasticCentroid.OuterEdge.Points);
            if (centredOnElasticCentroid.VoidEdges == null || centredOnElasticCentroid.VoidEdges.Count == 0)
            {
                return inertia;
            }

            foreach (ILocalPolyline2d hole in centredOnElasticCentroid.VoidEdges)
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

            foreach (ILocalPolyline2d hole in centredOnElasticCentroid.VoidEdges)
            {
                inertia -= CalculatePartInertiaZz(hole.Points);
            }

            return inertia;
        }

        internal static SectionModulus CalculateSectionModulusYy(IPerimeter perimeter)
        {
            ILocalPoint2d elasticCentroid = Centroids.CalculateCentroid(perimeter);
            ILocalDomain2d domain = Extends.GetDomain(perimeter);
            AreaMomentOfInertia inertia = Inertiae.CalculateInertiaYy(perimeter);
            return SectionModuli.CalculateSectionModulus(domain.Max.Z, domain.Min.Z, elasticCentroid.Z, inertia);
        }

        internal static SectionModulus CalculateSectionModulusZz(IPerimeter perimeter)
        {
            ILocalPoint2d elasticCentroid = Centroids.CalculateCentroid(perimeter);
            ILocalDomain2d domain = Extends.GetDomain(perimeter);
            AreaMomentOfInertia inertia = Inertiae.CalculateInertiaZz(perimeter);
            return SectionModuli.CalculateSectionModulus(domain.Max.Y, domain.Min.Y, elasticCentroid.Y, inertia);
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
            ILocalPolyline2d outerEdge = new LocalPolyline2d(outerPoints);

            if (perimeter.VoidEdges == null || perimeter.VoidEdges.Count == 0)
            {
                return new Perimeter(outerEdge);
            }

            IList<ILocalPolyline2d> voidEdges = new List<ILocalPolyline2d>();
            foreach (ILocalPolyline2d voidEdge in perimeter.VoidEdges)
            {
                IList<ILocalPoint2d> voidPoints = new List<ILocalPoint2d>();
                foreach (ILocalPoint2d pt in voidEdge.Points)
                {
                    voidPoints.Add(Move(pt, translation));
                }
                ILocalPolyline2d translatedVoidEdge = new LocalPolyline2d(voidPoints);
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

        private static Area CalculatePartArea(IList<ILocalPoint2d> pts)
        {
            Area res = Area.Zero;
            Area.TryParse($"0 {Length.GetAbbreviation(pts.FirstOrDefault().Y.Unit)}²", out res);

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
            Area res = Area.Zero;
            Area.TryParse($"0 {Length.GetAbbreviation(pts.FirstOrDefault().Y.Unit)}²", out res);

            for (int i = 0; i < pts.Count - 1; i++)
            {
                res += (pts[i].Y * pts[i + 1].Z - pts[i].Z * pts[i + 1].Y) / 2;
            }

            return res.Value < 0;
        }
    }
}
