using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public interface IConcreteSectionProperties : ISectionProperties
    {
        Area ReinforcemenArea { get; }
        Area ConcreteArea { get; }
        Ratio GeometricReinforcementRatio { get; }
        Area ShearReinforcementArea { get; }
        AreaMomentOfInertia ReinforcementSecondMomentOfAreaYy { get; }
        AreaMomentOfInertia ReinforcementSecondMomentOfAreaZz { get; }
        Length ReinforcementRadiusOfGyrationYy { get; }
        Length ReinforcementRadiusOfGyrationZz { get; }
    }
}
