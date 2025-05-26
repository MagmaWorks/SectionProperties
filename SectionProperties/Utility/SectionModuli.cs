using MagmaWorks.Taxonomy.Sections.Properties.Utility.Parts;

namespace MagmaWorks.Taxonomy.Sections.Properties.Utility
{
    public static class SectionModuli
    {
        public static SectionModulus CalculateSectionModulusYy(IProfile profile)
        {
            if (profile is IPerimeter perim)
            {
                return PerimeterProfiles.CalculateSectionModulusYy(perim);
            }

            return CalculateSectionModulusYy(ProfileParts.GetParts(profile));
        }

        internal static SectionModulus CalculateSectionModulusYy(IList<IPart> parts)
        {
            ILocalPoint2d elasticCentroid = Centroids.CalculateCentroid(parts);
            ILocalDomain2d domain = Extends.GetDomain(parts);
            AreaMomentOfInertia inertia = Inertiae.CalculateInertiaYy(parts);
            return CalculateSectionModulus(domain.Max.Z, domain.Min.Z, elasticCentroid.Z, inertia);
        }

        public static SectionModulus CalculateSectionModulusZz(IProfile profile)
        {
            if (profile is IPerimeter perim)
            {
                return PerimeterProfiles.CalculateSectionModulusZz(perim);
            }

            return CalculateSectionModulusZz(ProfileParts.GetParts(profile));
        }

        internal static SectionModulus CalculateSectionModulusZz(IList<IPart> parts)
        {
            ILocalPoint2d elasticCentroid = Centroids.CalculateCentroid(parts);
            ILocalDomain2d domain = Extends.GetDomain(parts);
            AreaMomentOfInertia inertia = Inertiae.CalculateInertiaZz(parts);
            return CalculateSectionModulus(domain.Max.Y, domain.Min.Y, elasticCentroid.Y, inertia);
        }

        internal static SectionModulus CalculateSectionModulus(Length dPos, Length dNeg, Length centroid, AreaMomentOfInertia inertia)
        {
            Length zpos = Distance(dPos, centroid);
            Length zneg = Distance(dNeg, centroid);
            Length distance = zpos > zneg ? zpos : zneg;
            LengthUnit unit = dPos.Unit;
            SectionModulus.TryParse($"0 {Length.GetAbbreviation(unit)}³", out SectionModulus m3);
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit)}⁴", out AreaMomentOfInertia m4);
            return new SectionModulus(inertia.As(m4.Unit) / distance.As(unit), m3.Unit);
        }

        private static Length Distance(Length d1, Length d2)
        {
            LengthUnit unit = d1.Unit;
            return new Length(Math.Abs(d1.As(unit) - d2.As(unit)), unit);
        }
    }
}
