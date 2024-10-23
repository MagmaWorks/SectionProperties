using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public class SectionProperties : ISectionProperties
    {
        public ILocalPoint2d Centroid => _centroid ??= Utility.Centroid.CalculateCentroid(_profile);
        public Length Perimeter => _perimeter ??= Utility.PerimeterLength.CalculatePerimeter(_profile);
        public ILocalDomain2d Extends => Utility.Extends.GetDomain(_profile);
        public Area Area => _area ??= Utility.Area.CalculateArea(_profile);
        public SectionModulus ElasticSectionModulusYy => Utility.SectionModulus.CalculateSectionModulusYy(_profile);
        public SectionModulus ElasticSectionModulusZz => Utility.SectionModulus.CalculateSectionModulusZz(_profile);
        public AreaMomentOfInertia MomentOfInertiaYy => Utility.Inertia.CalculateInertiaYy(_profile);
        public AreaMomentOfInertia MomentOfInertiaZz => Utility.Inertia.CalculateInertiaZz(_profile);

        private ILocalPoint2d _centroid;
        private Length? _perimeter;
        private ILocalDomain2d _domain;
        private Area? _area;
        private SectionModulus? _elasticSectionModulusYy;
        private SectionModulus? _elasticSectionModulusZz;
        private AreaMomentOfInertia? _momentOfInertiaYy;
        private AreaMomentOfInertia? _momentOfInertiaZz;
        private IProfile _profile;

        public SectionProperties(ISection section) : this(section.Profile) { }

        public SectionProperties(IProfile profile)
        {
            _profile = profile;
        }
    }
}
