using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class RadiusOfGyrations
    {
        public static Length CalculateRadiusOfGyrationYy(IProfile profile)
        {
            if (profile is IPerimeter perim)
            {
                return PerimeterProfiles.CalculateRadiusOfGyrationYy(perim);
            }

            return CalculateRadiusOfGyrationYy(ProfileParts.GetParts(profile));
        }

        internal static Length CalculateRadiusOfGyrationYy(IList<IPart> parts)
        {
            Area area = Areas.CalculateArea(parts);
            AreaMomentOfInertia inertia = Inertiae.CalculateInertiaYy(parts);
            return CalculateRadiusOfGyration(area, inertia);
        }

        public static Length CalculateRadiusOfGyrationZz(IProfile profile)
        {
            if (profile is IPerimeter perim)
            {
                return PerimeterProfiles.CalculateRadiusOfGyrationZz(perim);
            }

            return CalculateRadiusOfGyrationZz(ProfileParts.GetParts(profile));
        }

        internal static Length CalculateRadiusOfGyrationZz(IList<IPart> parts)
        {
            Area area = Areas.CalculateArea(parts);
            AreaMomentOfInertia inertia = Inertiae.CalculateInertiaZz(parts);
            return CalculateRadiusOfGyration(area, inertia);
        }

        internal static Length CalculateRadiusOfGyration(Area area, AreaMomentOfInertia inertia)
        {
            Length.TryParse($"0 {Area.GetAbbreviation(area.Unit).Replace("²", string.Empty)}", out Length unit);
            Area.TryParse($"0 {Length.GetAbbreviation(unit.Unit)}²", out Area m2);
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit.Unit)}⁴", out AreaMomentOfInertia m4);
            return new Length(Math.Sqrt(inertia.As(m4.Unit) / area.As(m2.Unit)), unit.Unit);
        }
    }
}
