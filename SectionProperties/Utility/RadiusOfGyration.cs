using System;
using System.Collections.Generic;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts;
using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class RadiusOfGyration
    {
        public static Length CalculateRadiusOfGyrationYy(IProfile profile)
        {
            return CalculateRadiusOfGyrationYy(ProfileParts.GetParts(profile));
        }

        internal static Length CalculateRadiusOfGyrationYy(IList<IPart> parts)
        {
            OasysUnits.Area area = Area.CalculateArea(parts);
            AreaMomentOfInertia inertia = Inertia.CalculateInertiaYy(parts);
            return CalculateRadiusOfGyration(area, inertia);
        }

        public static Length CalculateRadiusOfGyrationZz(IProfile profile)
        {
            return CalculateRadiusOfGyrationZz(ProfileParts.GetParts(profile));
        }

        internal static Length CalculateRadiusOfGyrationZz(IList<IPart> parts)
        {
            OasysUnits.Area area = Area.CalculateArea(parts);
            AreaMomentOfInertia inertia = Inertia.CalculateInertiaZz(parts);
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
