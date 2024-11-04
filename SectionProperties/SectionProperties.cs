using MagmaWorks.Taxonomy.Profiles;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public class SectionProperties : ISectionProperties
    {
        public IGeometricalProperties GeometricalProperties
            => _geometricalProperties ??= new GeometricalProperties(_profile);

        private IGeometricalProperties _geometricalProperties;
        private IProfile _profile;

        private SectionProperties() { }
        public SectionProperties(ISection section) : this(section.Profile) { }

        public SectionProperties(IProfile profile)
        {
            _profile = profile;
        }
    }
}
