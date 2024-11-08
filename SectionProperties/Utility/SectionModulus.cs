using System;
using System.Collections.Generic;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class SectionModulus
    {
        public static OasysUnits.SectionModulus CalculateSectionModulusYy(IProfile profile)
        {
            return CalculateSectionModulusYy(ProfileParts.GetParts(profile));
        }

        internal static OasysUnits.SectionModulus CalculateSectionModulusYy(IList<IPart> parts)
        {
            ILocalPoint2d elasticCentroid = Centroid.CalculateCentroid(parts);
            ILocalDomain2d domain = Extends.GetDomain(parts);
            AreaMomentOfInertia inertia = Inertia.CalculateInertiaYy(parts);
            return CalculateSectionModulus(domain.Max.Z, domain.Min.Z, elasticCentroid.Z, inertia);
        }

        public static OasysUnits.SectionModulus CalculateSectionModulusZz(IProfile profile)
        {
            return CalculateSectionModulusZz(ProfileParts.GetParts(profile));
        }

        internal static OasysUnits.SectionModulus CalculateSectionModulusZz(IList<IPart> parts)
        {
            ILocalPoint2d elasticCentroid = Centroid.CalculateCentroid(parts);
            ILocalDomain2d domain = Extends.GetDomain(parts);
            AreaMomentOfInertia inertia = Inertia.CalculateInertiaZz(parts);
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
