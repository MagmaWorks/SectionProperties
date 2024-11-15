using System;
using System.Collections.Generic;
using System.Linq;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class Reinforcement
    {
        private const double PiFactor = Math.PI / 4;

        public static OasysUnits.Area CalculateArea(IList<ILongitudinalReinforcement> rebars)
        {
            LengthUnit unit = rebars.FirstOrDefault().Rebar.Diameter.Unit;
            double area = 0;
            foreach (ILongitudinalReinforcement reinforcement in rebars)
            {
                area += PiFactor * Math.Pow(reinforcement.Rebar.Diameter.As(unit), 2);
            }

            OasysUnits.Area m2 = OasysUnits.Area.Zero;
            OasysUnits.Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out m2);
            return new OasysUnits.Area(area, m2.Unit);
        }

        public static OasysUnits.Area CalculateArea(IRebar rebar)
        {
            LengthUnit unit = rebar.Diameter.Unit;
            OasysUnits.Area m2 = OasysUnits.Area.Zero;
            OasysUnits.Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out m2);
            return new OasysUnits.Area(PiFactor * Math.Pow(rebar.Diameter.As(unit), 2), m2.Unit);
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

        public static Length CalculateRadiusOfGyrationYy(IConcreteSection section)
        {
            OasysUnits.Area area = CalculateArea(section.Rebars);
            AreaMomentOfInertia inertia = CalculateInertiaYy(section);
            return RadiusOfGyration.CalculateRadiusOfGyration(area, inertia);
        }

        public static Length CalculateRadiusOfGyrationZz(IConcreteSection section)
        {
            OasysUnits.Area area = CalculateArea(section.Rebars);
            AreaMomentOfInertia inertia = CalculateInertiaZz(section);
            return RadiusOfGyration.CalculateRadiusOfGyration(area, inertia);
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
