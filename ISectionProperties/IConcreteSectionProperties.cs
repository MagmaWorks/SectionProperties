using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public interface IConcreteSectionProperties : ISectionProperties
    {
        Area TotalAreaOfReinforcement { get; }
        Area ConcreteArea { get; }
        Ratio GeometricReinforcementRatio { get; }
        Area ShearReinforcementArea { get; }
        Length ShearReinforcementSpacing { get; }
        AreaMomentOfInertia ReinforcementSecondMomentOfAreaYy { get; }
        AreaMomentOfInertia ReinforcementSecondMomentOfAreaZz { get; }
        Length ReinforcementRadiusOfGyrationYy { get; }
        Length ReinforcementRadiusOfGyrationZz { get; }
    }
}
