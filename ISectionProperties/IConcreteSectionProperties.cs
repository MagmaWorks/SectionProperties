namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public interface IConcreteSectionProperties : ISectionProperties
    {
        Area TotalReinforcementArea { get; }
        Area ConcreteArea { get; }
        Ratio GeometricReinforcementRatio { get; }
        Area CrossSectionalShearReinforcementArea { get; }
        AreaMomentOfInertia ReinforcementSecondMomentOfAreaYy { get; }
        AreaMomentOfInertia ReinforcementSecondMomentOfAreaZz { get; }
        Length ReinforcementRadiusOfGyrationYy { get; }
        Length ReinforcementRadiusOfGyrationZz { get; }
        Length EffectiveDepth(SectionFace face);
        Area ReinforcementArea(SectionFace face);
    }
}
