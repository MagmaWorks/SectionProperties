using MagmaWorks.Geometry;
using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts
{
    internal interface IPart
    {
        public ILocalPoint2d ElasticCentroid { get; }
        public OasysUnits.Area GetArea();
    }
}
