namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts
{
    internal interface IPart
    {
        public ILocalPoint2d ElasticCentroid { get; }
        public ILocalDomain2d Extends { get; }
        public Area GetArea();
        public AreaMomentOfInertia GetMomentOfInertiaYy();
        public AreaMomentOfInertia GetMomentOfInertiaZz();
    }
}
