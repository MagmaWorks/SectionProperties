using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class Centroids
    {
        public static ILocalPoint2d CalculateCentroid(IProfile profile)
        {
            if (profile is IPerimeter perim)
            {
                return PerimeterProfiles.CalculateCentroid(perim);
            }

            return CalculateCentroid(ProfileParts.GetParts(profile));
        }

        internal static ILocalPoint2d CalculateCentroid(IList<IPart> parts)
        {
            SectionModulus qz = SectionModulus.Zero;
            SectionModulus qy = SectionModulus.Zero;
            Area area = Area.Zero;
            foreach (IPart part in parts)
            {
                Area partArea = part.GetArea();
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
