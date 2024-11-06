using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public interface IConcreteProperties : ISectionProperties
    {
        Area ConcreteArea { get; }
        Area LongitudinalReinforcementArea { get; }
        Area ShearReinforcementArea { get; }
        IConcreteSectionProperties TensionNegativeYProperties { get; }
        IConcreteSectionProperties TensionPositiveYProperties { get; }
        IConcreteSectionProperties TensionNegativeZProperties { get; }
        IConcreteSectionProperties TensionPositiveZProperties { get; }
    }
}
