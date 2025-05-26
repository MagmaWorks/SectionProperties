using MagmaWorks.Taxonomy.Sections.Properties.Utility.Parts;

namespace MagmaWorks.Taxonomy.Sections.Properties.Utility
{
    public static class Inertiae
    {
        public static AreaMomentOfInertia CalculateInertiaYy(IProfile profile)
        {
            if (profile is IPerimeter perim)
            {
                return PerimeterProfiles.CalculateInertiaYy(perim);
            }

            return CalculateInertiaYy(ProfileParts.GetParts(profile));
        }

        internal static AreaMomentOfInertia CalculateInertiaYy(IList<IPart> parts, ILocalPoint2d elasticCentroid = null)
        {
            elasticCentroid ??= Centroids.CalculateCentroid(parts);
            AreaMomentOfInertia inertia = AreaMomentOfInertia.Zero;
            foreach (IPart part in parts)
            {
                inertia += PartAreaContribution(part.GetArea(), part.ElasticCentroid.Z - elasticCentroid.Z);
                inertia += part.GetMomentOfInertiaYy();
            }

            return inertia;
        }

        public static AreaMomentOfInertia CalculateInertiaZz(IProfile profile)
        {
            if (profile is IPerimeter perim)
            {
                return PerimeterProfiles.CalculateInertiaZz(perim);
            }

            return CalculateInertiaZz(ProfileParts.GetParts(profile));
        }

        internal static AreaMomentOfInertia CalculateInertiaZz(IList<IPart> parts, ILocalPoint2d elasticCentroid = null)
        {
            elasticCentroid ??= Centroids.CalculateCentroid(parts);
            AreaMomentOfInertia inertia = AreaMomentOfInertia.Zero;
            foreach (IPart part in parts)
            {
                inertia += PartAreaContribution(part.GetArea(), part.ElasticCentroid.Y - elasticCentroid.Y);
                inertia += part.GetMomentOfInertiaZz();
            }

            return inertia;
        }

        private static AreaMomentOfInertia PartAreaContribution(Area area, Length d)
        {
            LengthUnit unit = d.Unit;
            Area m2 = Area.Zero;
            Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out m2);
            AreaMomentOfInertia m4 = AreaMomentOfInertia.Zero;
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit)}⁴", out m4);
            return new AreaMomentOfInertia(area.As(m2.Unit) * Math.Pow(d.As(unit), 2), m4.Unit);
        }
    }
}
