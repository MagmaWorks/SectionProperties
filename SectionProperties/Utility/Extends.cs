using System.Linq;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class Extends
    {
        public static ILocalDomain2d GetDomain(IProfile profile)
        {
            Length maxY = Length.Zero;
            Length minY = Length.Zero;
            Length maxZ = Length.Zero;
            Length minZ = Length.Zero;
            switch (profile)
            {
                case IDoubleAngle doubleAngle:
                    maxY = doubleAngle.BackToBackDistance / 2 + doubleAngle.Width;
                    minY = maxY * -1;
                    maxZ = doubleAngle.Height;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case IAngle angle:
                    maxY = angle.Width;
                    maxZ = angle.Height;
                    return CreateDomain(maxY, minY, maxZ, minZ);


                case IDoubleChannel doubleChannel:
                    maxY = doubleChannel.BackToBackDistance / 2 + doubleChannel.Width;
                    minY = maxY * -1;
                    maxZ = doubleChannel.Height / 2;
                    minZ = -doubleChannel.Height / 2;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case IChannel channel:
                    maxY = channel.Width;
                    maxZ = channel.Height / 2;
                    minZ = -channel.Height / 2;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case ICircle circle:
                    maxY = circle.Diameter / 2;
                    minY = maxY * -1;
                    maxZ = circle.Diameter / 2;
                    minZ = maxZ * -1;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case ICruciform cruciform:
                    maxY = cruciform.Width / 2;
                    minY = maxY * -1;
                    maxZ = cruciform.Height / 2;
                    minZ = maxZ * -1;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case ICustomI customI:
                    maxY = (customI.TopFlangeWidth > customI.BottomFlangeWidth
                        ? customI.TopFlangeWidth : customI.BottomFlangeWidth) / 2;
                    minY = maxY * -1;
                    maxZ = customI.Height / 2;
                    minZ = maxZ * -1;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case IEllipse ellipse:
                    maxY = ellipse.Width / 2;
                    minY = maxY * -1;
                    maxZ = ellipse.Height / 2;
                    minZ = maxZ * -1;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case II i:
                    maxY = i.Width / 2;
                    minY = maxY * -1;
                    maxZ = i.Height / 2;
                    minZ = maxZ * -1;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case IRectangle rectangle:
                    maxY = rectangle.Width / 2;
                    minY = maxY * -1;
                    maxZ = rectangle.Height / 2;
                    minZ = maxZ * -1;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case ITee tee:
                    maxY = tee.Width / 2;
                    minY = maxY * -1;
                    minZ = -tee.Height;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case ITrapezoid trapezoid:
                    maxY = (trapezoid.TopWidth > trapezoid.BottomWidth
                        ? trapezoid.TopWidth : trapezoid.BottomWidth) / 2;
                    minY = maxY * -1;
                    maxZ = trapezoid.Height / 2;
                    minZ = maxZ * -1;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                case IZ z:
                    maxY = z.TopFlangeWidth - z.Thickness / 2;
                    minY = -z.BottomFlangeWidth + z.Thickness / 2;
                    maxZ = z.Height / 2;
                    minZ = maxZ * -1;
                    return CreateDomain(maxY, minY, maxZ, minZ);

                default:
                    var pts = new Perimeter(profile).OuterEdge.Points;
                    maxY = pts.Select(pt => pt.Y).Max();
                    minY = pts.Select(pt => pt.Y).Min();
                    maxZ = pts.Select(pt => pt.Z).Max();
                    minZ = pts.Select(pt => pt.Z).Min();
                    return CreateDomain(maxY, minY, maxZ, minZ);
            }
        }

        private static LocalDomain2d CreateDomain(Length maxY, Length minY, Length maxZ, Length minZ)
        {
            var max = new LocalPoint2d(maxY, maxZ);
            var min = new LocalPoint2d(minY, minZ);
            return new LocalDomain2d(max, min);
        }
    }
}
