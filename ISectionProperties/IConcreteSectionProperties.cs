using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public interface IConcreteSectionProperties
    {
        Length EffectiveDepth { get; }
        Length EffectiveWidth { get; }
        Area CompressionReinforcementArea { get; }
        Area TensionReinforcementArea { get; }
        Area ConcreteArea { get; }
    }
}
