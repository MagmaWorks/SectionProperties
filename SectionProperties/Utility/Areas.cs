using MagmaWorks.Taxonomy.Sections.Properties.Utility.Parts;

namespace MagmaWorks.Taxonomy.Sections.Properties.Utility
{
    public static class Areas
    {
        public static Area CalculateArea(IProfile profile)
        {
            if (profile is IPerimeter perim)
            {
                return PerimeterProfiles.CalculateArea(perim);
            }

            return CalculateArea(ProfileParts.GetParts(profile));
        }

        internal static Area CalculateArea(IList<IPart> parts)
        {
            Area area = Area.Zero;
            foreach (IPart part in parts)
            {
                area += part.GetArea();
            }

            return area;
        }
    }
}
