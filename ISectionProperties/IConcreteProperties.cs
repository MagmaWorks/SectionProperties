using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public interface IConcreteProperties : ISectionProperties
    {
        Length EffectiveDepthY { get; }
        Length EffectiveDepthZ { get; }
        Area CompressionReinforcementAreaY { get; }
        Area CompressionReinforcementAreaZ { get; }
        Area TensionReinforcementAreaY { get; }
        Area TensionReinforcementAreaZ { get; }
        Area ShearReinforcementArea { get; }
    }
}
