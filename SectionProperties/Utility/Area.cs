using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class Area
    {
        public static OasysUnits.Area CalculateArea(IProfile profile)
        {
            switch (profile)
            {
                case IAngle angle:
                    {
                        OasysUnits.Area flange = angle.FlangeThickness * angle.Width;
                        OasysUnits.Area web = angle.WebThickness * (angle.Height - angle.FlangeThickness);
                        return flange + web;
                    }


                case IC c:
                    {
                        OasysUnits.Area lip = c.FlangeThickness * c.Lip;
                        OasysUnits.Area flange = c.FlangeThickness * (c.Width - c.FlangeThickness);
                        OasysUnits.Area web = c.WebThickness * (c.Height - 2 * c.FlangeThickness);
                        return 2 * (lip + flange) + web;
                    }

                case IChannel channel:
                    {
                        OasysUnits.Area flange = channel.FlangeThickness * channel.Width;
                        OasysUnits.Area web = channel.WebThickness * (channel.Height - 2 * channel.FlangeThickness);
                        return (2 * flange + web);
                    }

                case ICircularHollow circularHollow:
                    return 0.25 * Math.PI * (circularHollow.Diameter * circularHollow.Diameter -
                        (circularHollow.Diameter - circularHollow.Thickness) *
                        (circularHollow.Diameter - circularHollow.Thickness));

                case ICircle circle:
                    return 0.25 * Math.PI * circle.Diameter * circle.Diameter;

                case ICruciform cruciform:
                    return cruciform.FlangeThickness * cruciform.Width +
                        (cruciform.Height - cruciform.FlangeThickness) * cruciform.WebThickness;

                case IEllipseHollow ellipseHollow:
                    return 0.25 * Math.PI * ellipseHollow.Width * ellipseHollow.Height
                        - Math.PI * (ellipseHollow.Width / 2 - ellipseHollow.Thickness)
                        * (ellipseHollow.Height / 2 - ellipseHollow.Thickness);

                case IEllipse ellipse:
                    return 0.25 * Math.PI * ellipse.Width * ellipse.Height;

                case IIParallelFlange parallelFlange:
                    {
                        OasysUnits.Area flanges = parallelFlange.FlangeThickness * parallelFlange.Width;
                        OasysUnits.Area web = parallelFlange.WebThickness *
                            (parallelFlange.Height - 2 * parallelFlange.FlangeThickness);
                        OasysUnits.Area fillets = parallelFlange.FilletRadius * parallelFlange.FilletRadius * 4
                            - 0.25 * Math.PI * parallelFlange.FilletRadius * parallelFlange.FilletRadius;
                        return 2 * flanges + web + fillets;
                    }

                case II i:
                    {
                        OasysUnits.Area flanges = i.FlangeThickness * i.Width;
                        OasysUnits.Area web = i.WebThickness *
                            (i.Height - 2 * i.FlangeThickness);
                        return 2 * flanges + web;
                    }

                case IRectangularHollow rectangularHollow:
                    return rectangularHollow.Width * rectangularHollow.Height
                        - (rectangularHollow.Width - 2 * rectangularHollow.Thickness)
                        * (rectangularHollow.Height - 2 * rectangularHollow.Thickness);

                case IRoundedRectangularHollow roundedRectangularHollow:
                    {
                        OasysUnits.Area ellipse = 0.25 * Math.PI * (roundedRectangularHollow.Width - roundedRectangularHollow.FlatWidth)
                            * (roundedRectangularHollow.Height - roundedRectangularHollow.FlatHeight);
                        OasysUnits.Area rectangle = roundedRectangularHollow.FlatWidth * roundedRectangularHollow.FlatHeight;
                        OasysUnits.Area ellipseVoid = Math.PI *
                            ((roundedRectangularHollow.Width - roundedRectangularHollow.FlatWidth) / 2 - roundedRectangularHollow.Thickness)
                            * ((roundedRectangularHollow.Height - roundedRectangularHollow.FlatHeight) / 2 - roundedRectangularHollow.Thickness);
                        OasysUnits.Area rectangleVoid = (roundedRectangularHollow.FlatWidth - 2 * roundedRectangularHollow.Thickness)
                            * (roundedRectangularHollow.FlatHeight - 2 * roundedRectangularHollow.Thickness);
                        return ellipse + rectangle - ellipseVoid - rectangleVoid;
                    }

                case IRoundedRectangle roundedRectangle:
                    {
                        OasysUnits.Area ellipse = 0.25 * Math.PI * (roundedRectangle.Width - roundedRectangle.FlatWidth)
                            * (roundedRectangle.Height - roundedRectangle.FlatHeight);
                        OasysUnits.Area rectangle = roundedRectangle.FlatWidth * roundedRectangle.FlatHeight;
                        return ellipse + rectangle;
                    }

                case IRectangle rectangle:
                    return rectangle.Width * rectangle.Height;

                case ITee tee:
                    {
                        OasysUnits.Area flange = tee.FlangeThickness * tee.Width;
                        OasysUnits.Area web = tee.WebThickness * (tee.Height - tee.FlangeThickness);
                        return flange + web;
                    }

                case ITrapezoid trapezoid:
                    return 0.5 * (trapezoid.BottomWidth + trapezoid.TopWidth) * trapezoid.Height;

                case IZ z:
                    {
                        OasysUnits.Area topLip = z.Thickness * z.TopLip;
                        OasysUnits.Area topFlange = (z.TopFlangeWidth - z.Thickness) * z.Thickness;
                        OasysUnits.Area web = z.Thickness * (z.Height - 2 * z.Thickness);
                        OasysUnits.Area bottomLip = z.Thickness * z.BottomLip;
                        OasysUnits.Area bottomFlange = (z.BottomFlangeWidth - z.Thickness) * z.Thickness;
                        return topLip + topFlange + web + bottomFlange + bottomLip;
                    }

                default:
                    {
                        IPerimeter perimeter = new Perimeter(profile);
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
            }
        }

        internal static OasysUnits.Area CalculatePartArea(IList<ILocalPoint2d> pts)
        {
            OasysUnits.Area res = OasysUnits.Area.Zero;
            OasysUnits.Area.TryParse($"0 {Length.GetAbbreviation(pts.FirstOrDefault().Y.Unit)}²", out res);

            for (int i = 0; i < pts.Count - 1; i++)
            {
                res += (pts[i].Y * pts[i + 1].Z - pts[i].Z * pts[i + 1].Y) / 2;
            }

            return res.Abs();
        }

        internal static bool IsClockwise(IList<ILocalPoint2d> pts)
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
