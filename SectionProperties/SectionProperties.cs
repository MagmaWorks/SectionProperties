using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public class SectionProperties : ISectionProperties
    {
        public ILocalPoint2d Centroid
            => _centroid ??= Utility.Centroids.CalculateCentroid(_profile);
        public Length Perimeter
            => _perimeter ??= Utility.PerimeterLengths.CalculatePerimeter(_profile);
        public ILocalDomain2d Extends => _domain ??= Utility.Extends.GetDomain(_profile);
        public Area Area => _area ??= Utility.Areas.CalculateArea(_profile);
        public SectionModulus ElasticSectionModulusYy
            => _elasticSectionModulusYy ??= Utility.SectionModuli.CalculateSectionModulusYy(_profile);
        public SectionModulus ElasticSectionModulusZz
            => _elasticSectionModulusZz ??= Utility.SectionModuli.CalculateSectionModulusZz(_profile);
        public AreaMomentOfInertia MomentOfInertiaYy
            => _momentOfInertiaYy ??= Utility.Inertiae.CalculateInertiaYy(_profile);
        public AreaMomentOfInertia MomentOfInertiaZz
            => _momentOfInertiaZz ??= Utility.Inertiae.CalculateInertiaZz(_profile);
        public Length RadiusOfGyrationYy
            => _radiusOfGyrationYy ??= Utility.RadiusOfGyrations.CalculateRadiusOfGyrationYy(_profile);
        public Length RadiusOfGyrationZz
            => _radiusOfGyrationZz ??= Utility.RadiusOfGyrations.CalculateRadiusOfGyrationZz(_profile);

        private ILocalPoint2d _centroid;
        private Length? _perimeter;
        private ILocalDomain2d _domain;
        private Area? _area;
        private SectionModulus? _elasticSectionModulusYy;
        private SectionModulus? _elasticSectionModulusZz;
        private AreaMomentOfInertia? _momentOfInertiaYy;
        private AreaMomentOfInertia? _momentOfInertiaZz;
        private Length? _radiusOfGyrationYy;
        private Length? _radiusOfGyrationZz;
        private IProfile _profile;

        public SectionProperties(ISection section) : this(section.Profile) { }

        public SectionProperties(IProfile profile)
        {
            _profile = profile;
        }
    }
}
