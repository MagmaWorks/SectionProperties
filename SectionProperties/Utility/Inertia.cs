using System;
using System.Collections.Generic;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class Inertia
    {
        public static AreaMomentOfInertia CalculateInertiaYy(IProfile profile)
        {
            List<IPart> parts = ProfileParts.GetParts(profile);
            ILocalPoint2d elasticCentroid = Centroid.CalculateCentroid(profile);
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
            List<IPart> parts = ProfileParts.GetParts(profile);
            ILocalPoint2d elasticCentroid = Centroid.CalculateCentroid(profile);
            AreaMomentOfInertia inertia = AreaMomentOfInertia.Zero;
            foreach (IPart part in parts)
            {
                inertia += PartAreaContribution(part.GetArea(), part.ElasticCentroid.Y - elasticCentroid.Y);
                inertia += part.GetMomentOfInertiaZz();
            }

            return inertia;
        }

        private static AreaMomentOfInertia PartAreaContribution(OasysUnits.Area area, Length d)
        {
            LengthUnit unit = d.Unit;
            OasysUnits.Area m2 = OasysUnits.Area.Zero;
            OasysUnits.Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out m2);
            AreaMomentOfInertia m4 = AreaMomentOfInertia.Zero;
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit)}⁴", out m4);
            return new AreaMomentOfInertia(area.As(m2.Unit) * Math.Pow(d.As(unit), 2), m4.Unit);
        }
    }
}
