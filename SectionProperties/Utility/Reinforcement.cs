using System;
using System.Collections.Generic;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class Reinforcement
    {
        public static OasysUnits.Area CalculateArea(IList<ILongitudinalReinforcement> rebars)
        {
            return Area.CalculateArea(GetParts(rebars));
        }

        public static OasysUnits.Area CalculateArea(IRebar rebar)
        {
            LengthUnit unit = rebar.Diameter.Unit;
            OasysUnits.Area m2 = OasysUnits.Area.Zero;
            OasysUnits.Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out m2);
            return new OasysUnits.Area(Math.PI / 4 * Math.Pow(rebar.Diameter.As(unit), 2), m2.Unit);
        }

        public static AreaMomentOfInertia CalculateInertiaYy(IConcreteSection section)
        {
            ILocalPoint2d concreteCentroid = Centroid.CalculateCentroid(section.Profile);
            List<IPart> rebars = GetParts(section.Rebars);
            return Inertia.CalculateInertiaYy(rebars, concreteCentroid);
        }

        public static AreaMomentOfInertia CalculateInertiaZz(IConcreteSection section)
        {
            ILocalPoint2d concreteCentroid = Centroid.CalculateCentroid(section.Profile);
            List<IPart> rebars = GetParts(section.Rebars);
            return Inertia.CalculateInertiaZz(rebars, concreteCentroid);
        }

        private static List<IPart> GetParts(IList<ILongitudinalReinforcement> rebars)
        {
            var parts = new List<IPart>();
            foreach (ILongitudinalReinforcement rebar in rebars)
            {
                IList<IPart> part = EllipseQuarterPart.CreateCircle(rebar.Rebar.Diameter, rebar.Position);
                parts.AddRange(part);
            }

            return parts;
        }
    }
}
