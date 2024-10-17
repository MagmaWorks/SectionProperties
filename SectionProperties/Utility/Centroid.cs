using System.Collections.Generic;
using System.Linq;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class Centroid
    {
        public static ILocalPoint2d CalculateCentroid(IProfile profile)
        {
            switch (profile)
            {
                case IAngle angle:
                    {
                        OasysUnits.Area flange = angle.FlangeThickness * angle.Width;
                        var flangeCentroid = new LocalPoint2d(angle.Width / 2, angle.FlangeThickness / 2);
                        OasysUnits.Area web = angle.WebThickness * (angle.Height - angle.FlangeThickness);
                        var webCentroid = new LocalPoint2d(angle.WebThickness / 2,
                            (angle.Height - angle.FlangeThickness) / 2 + angle.FlangeThickness);
                        Volume qz = flange * flangeCentroid.Y + web * webCentroid.Y;
                        Volume qy = flange * flangeCentroid.Z + web * webCentroid.Z;
                        Length y = qz / (flange + web);
                        Length z = qy / (flange + web);
                        return new LocalPoint2d(y, z);
                    }

                case IC c:
                    {
                        OasysUnits.Area lip = c.FlangeThickness * c.Lip;
                        OasysUnits.Area flange = c.FlangeThickness * (c.Width - c.FlangeThickness);
                        OasysUnits.Area web = c.WebThickness * (c.Height - 2 * c.FlangeThickness);
                        Volume qz = 2 * (lip * (c.Width - c.FlangeThickness / 2)
                            + flange * (c.Width - c.FlangeThickness) / 2)
                            + web * c.WebThickness / 2;
                        OasysUnits.Area area = 2 * (lip + flange) + web;
                        Length y = qz / area;
                        return new LocalPoint2d(y, Length.Zero);
                    }

                case IChannel channel:
                    {
                        OasysUnits.Area flange = channel.FlangeThickness * channel.Width;
                        OasysUnits.Area web = channel.WebThickness * (channel.Height - 2 * channel.FlangeThickness);
                        Volume qz = 2 * flange * channel.Width / 2 + web * channel.WebThickness / 2;
                        Length y = qz / (2 * flange + web);
                        return new LocalPoint2d(y, Length.Zero);
                    }

                case ICustomI customI:
                    {
                        OasysUnits.Area topFlange = customI.TopFlangeThickness * customI.TopFlangeWidth;
                        OasysUnits.Area bottomFlange = customI.BottomFlangeThickness * customI.BottomFlangeWidth;
                        OasysUnits.Area web = customI.WebThickness *
                            (customI.Height - customI.TopFlangeThickness - customI.BottomFlangeThickness);
                        Volume qy = topFlange * (customI.Height / 2 - customI.TopFlangeThickness / 2)
                            + bottomFlange * (customI.Height/ 2 - customI.BottomFlangeThickness / 2);
                        Length z = qy / (topFlange + web + bottomFlange);
                        return new LocalPoint2d(Length.Zero, z);
                    }

                case ICircularHollow circularHollow:
                case ICircle circle:
                case ICruciform cruciform:
                case IEllipseHollow ellipseHollow:
                case IEllipse ellipse:
                case IIParallelFlange parallelFlange:
                case II i:
                case IRectangularHollow rectangularHollow:
                case IRoundedRectangularHollow roundedRectangularHollow:
                case IRoundedRectangle roundedRectangle:
                case IRectangle rectangle:
                    return new LocalPoint2d();

                case ITee tee:
                    {
                        OasysUnits.Area flange = tee.FlangeThickness * tee.Width;
                        OasysUnits.Area web = tee.WebThickness * (tee.Height - tee.FlangeThickness);
                        Volume qy = flange * tee.FlangeThickness / 2
                            + web * ((tee.Height - tee.FlangeThickness) / 2 + tee.FlangeThickness);
                        Length z = qy / (flange + web);
                        return new LocalPoint2d(Length.Zero, -z);
                    }

                case ITrapezoid trapezoid:
                    {
                        Length a = trapezoid.BottomWidth;
                        Length b = trapezoid.TopWidth;
                        Length e = trapezoid.Height / 3 * (a + 2 * b) / (a + b);
                        Length z = e - trapezoid.Height / 2;
                        return new LocalPoint2d(Length.Zero, z);
                    }

                case IZ z:
                    {
                        OasysUnits.Area topLip = z.Thickness * z.TopLip;
                        var topLipCntrd = new LocalPoint2d(
                            z.TopFlangeWidth - 1.5 * z.Thickness, z.Height / 2 - z.TopLip / 2);
                        OasysUnits.Area topFlange = (z.TopFlangeWidth - z.Thickness) * z.Thickness;
                        var topFlangeCntrd = new LocalPoint2d(
                            (z.TopFlangeWidth - z.Thickness) / 2 - z.Thickness / 2, z.Height / 2 - z.Thickness / 2);
                        OasysUnits.Area web = z.Thickness * (z.Height - 2 * z.Thickness);
                        OasysUnits.Area bottomLip = z.Thickness * z.BottomLip;
                        var bottomLipCntrd = new LocalPoint2d(
                            -z.BottomFlangeWidth + 1.5 * z.Thickness, -z.Height / 2 + z.TopLip / 2);
                        OasysUnits.Area bottomFlange = (z.BottomFlangeWidth - z.Thickness) * z.Thickness;
                        var bottomFlangeCntrd = new LocalPoint2d(
                            (-z.BottomFlangeWidth + z.Thickness) / 2 + z.Thickness / 2, -z.Height / 2 + z.Thickness / 2);
                        Volume qz = topLip * topLipCntrd.Y
                            + topFlange * topFlangeCntrd.Y
                            + bottomFlange * bottomFlangeCntrd.Y
                            + bottomLip * bottomLipCntrd.Y;
                        Volume qy = topLip * topLipCntrd.Z
                            + topFlange * topFlangeCntrd.Z
                            + bottomFlange * bottomFlangeCntrd.Z
                            + bottomLip * bottomLipCntrd.Z;
                        OasysUnits.Area area = topLip + topFlange + web + bottomFlange + bottomLip;
                        Length py = qz / area;
                        Length pz = qy / area;
                        return new LocalPoint2d(py, pz);
                    }

                default:
                    {
                        IPerimeter perimeter = new Perimeter(profile);
                        if (perimeter.VoidEdges == null || perimeter.VoidEdges.Count == 0)
                        {
                            return CalculatePartCentroid(perimeter.OuterEdge.Points);
                        }

                        OasysUnits.Area edgeArea = Area.CalculatePartArea(perimeter.OuterEdge.Points);
                        ILocalPoint2d edgeCentroid = CalculatePartCentroid(perimeter.OuterEdge.Points);
                        Volume qz = edgeArea * edgeCentroid.Y;
                        Volume qy = edgeArea * edgeCentroid.Z;
                        foreach (ILocalPolygon2d hole in perimeter.VoidEdges)
                        {
                            OasysUnits.Area holeArea = Area.CalculatePartArea(hole.Points);
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
            }
        }

        private static ILocalPoint2d CalculateRectangleCentroid(
            ILocalPoint2d pt1, ILocalPoint2d pt2, ILocalPoint2d pt3, ILocalPoint2d pt4)
        {
            Length y = pt1.Y + pt2.Y + pt3.Y + pt4.Y / 4;
            Length z = pt1.Z + pt2.Z + pt3.Z + pt4.Z / 4;
            return new LocalPoint2d(y, z);
        }

        private static ILocalPoint2d CalculatePartCentroid(IList<ILocalPoint2d> pts)
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
            double area = Area.CalculatePartArea(pts).Value;
            y /= (6 * area);
            z /= (6 * area);

            // If the values are negative, the polygon is
            // oriented clockwise so reverse the signs.
            if (Area.IsClockwise(pts))
            {
                y = -y;
                z = -z;
            }

            return new LocalPoint2d(y, z);
        }
    }
}
