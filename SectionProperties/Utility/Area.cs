using System.Collections.Generic;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility
{
    public static class Area
    {
        public static OasysUnits.Area CalculateArea(IProfile profile)
        {
            if (profile is IPerimeter perim)
            {
                return Perimeter.CalculateArea(perim);
            }

            List<IPart> parts = ProfileParts.GetParts(profile);
            OasysUnits.Area area = OasysUnits.Area.Zero;
            foreach (IPart part in parts)
            {
                area += part.GetArea();
            }

            return area;
        }
    }
}
