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
                return Perimeter.CalculateCentroid(perim);
            }

            Volume qz = Volume.Zero;
            Volume qy = Volume.Zero;
            List<IPart> parts = ProfileParts.GetParts(profile);
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
