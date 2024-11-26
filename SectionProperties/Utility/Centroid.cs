using System.Collections.Generic;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts;
using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class Centroid
    {
        public static ILocalPoint2d CalculateCentroid(IProfile profile)
        {
            if (profile is IPerimeter perim)
            {
                return PerimeterProfile.CalculateCentroid(perim);
            }

            return CalculateCentroid(ProfileParts.GetParts(profile));
        }

        internal static ILocalPoint2d CalculateCentroid(IList<IPart> parts)
        {
            Volume qz = Volume.Zero;
            Volume qy = Volume.Zero;
            OasysUnits.Area area = OasysUnits.Area.Zero;
            foreach (IPart part in parts)
            {
                OasysUnits.Area partArea = part.GetArea();
                qz += partArea * part.ElasticCentroid.Y;
                qy += partArea * part.ElasticCentroid.Z;
                area += partArea;
            }

            return new LocalPoint2d()
            {
                Y = qz / area,
                Z = qy / area,
            };
        }
    }
}
