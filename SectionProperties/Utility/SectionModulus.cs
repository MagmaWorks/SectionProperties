using System;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class SectionModulus
    {
        public static OasysUnits.SectionModulus CalculateSectionModulusYy(IProfile profile)
        {
            ILocalPoint2d elasticCentroid = Centroid.CalculateCentroid(profile);
            ILocalDomain2d domain = Extends.GetDomain(profile);
            AreaMomentOfInertia inertia = Inertia.CalculateInertiaYy(profile);
            return CalculateSectionModulus(domain.Max.Z, domain.Min.Z, elasticCentroid.Z, inertia);
        }

        public static OasysUnits.SectionModulus CalculateSectionModulusZz(IProfile profile)
        {
            ILocalPoint2d elasticCentroid = Centroid.CalculateCentroid(profile);
            ILocalDomain2d domain = Extends.GetDomain(profile);
            AreaMomentOfInertia inertia = Inertia.CalculateInertiaZz(profile);
            return CalculateSectionModulus(domain.Max.Y, domain.Min.Y, elasticCentroid.Y, inertia);
        }

        private static OasysUnits.SectionModulus CalculateSectionModulus(Length dPos, Length dNeg, Length centroid, AreaMomentOfInertia inertia)
        {
            Length zpos = Distance(dPos, centroid);
            Length zneg = Distance(dNeg, centroid);
            Length distance = zpos > zneg ? zpos : zneg;
            LengthUnit unit = dPos.Unit;
            OasysUnits.SectionModulus.TryParse($"0 {Length.GetAbbreviation(unit)}³", out OasysUnits.SectionModulus m3);
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit)}⁴", out AreaMomentOfInertia m4);
            return new OasysUnits.SectionModulus(inertia.As(m4.Unit) / distance.As(unit), m3.Unit);
        }

        private static Length Distance(Length d1, Length d2)
        {
            LengthUnit unit = d1.Unit;
            return new Length(Math.Abs(d1.As(unit) - d2.As(unit)), unit);
        }
    }
}
