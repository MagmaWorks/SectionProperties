using System;
using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class RadiusOfGyration
    {
        public static Length CalculateRadiusOfGyrationYy(IProfile profile)
        {
            OasysUnits.Area area = Area.CalculateArea(profile);
            AreaMomentOfInertia inertia = Inertia.CalculateInertiaYy(profile);
            return CalculateRadiusOfGyration(area, inertia);
        }

        public static Length CalculateRadiusOfGyrationZz(IProfile profile)
        {
            OasysUnits.Area area = Area.CalculateArea(profile);
            AreaMomentOfInertia inertia = Inertia.CalculateInertiaZz(profile);
            return CalculateRadiusOfGyration(area, inertia);
        }

        private static Length CalculateRadiusOfGyration(OasysUnits.Area area, AreaMomentOfInertia inertia)
        {
            Length.TryParse($"0 {OasysUnits.Area.GetAbbreviation(area.Unit).Replace("²", string.Empty)}", out Length unit);
            OasysUnits.Area.TryParse($"0 {Length.GetAbbreviation(unit.Unit)}²", out OasysUnits.Area m2);
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit.Unit)}⁴", out AreaMomentOfInertia m4);
            return new Length(Math.Sqrt(inertia.As(m4.Unit) / area.As(m2.Unit)), unit.Unit);
        }
    }
}
