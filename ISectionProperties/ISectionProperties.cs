using MagmaWorks.Geometry;
using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public interface ISectionProperties
    {
        ILocalDomain2d Extends { get; }
        ILocalPoint2d Centroid { get; }
        Length Perimeter { get; }
        Area Area { get; }
        SectionModulus ElasticSectionModulusYy { get; }
        SectionModulus ElasticSectionModulusZz { get; }
        AreaMomentOfInertia MomentOfInertiaYy { get; }
        AreaMomentOfInertia MomentOfInertiaZz { get; }
    }
}
