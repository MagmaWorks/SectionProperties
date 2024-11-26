using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;
using MagmaWorks.Taxonomy.Serialization;
using OasysUnits;
using OasysUnits.Units;
using Area = OasysUnits.Area;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public class ConcreteSectionProperties : SectionProperties, IConcreteSectionProperties, ITaxonomySerializable
    {
        public Area TotalReinforcementArea => _reinforcementArea ??= Reinforcement.CalculateArea(_section.Rebars);
        public Area ConcreteArea => base.Area - TotalReinforcementArea;
        public Ratio GeometricReinforcementRatio =>
            new Ratio(TotalReinforcementArea.SquareMeters / ConcreteArea.SquareMeters, RatioUnit.DecimalFraction);
        public Area CrossSectionalShearReinforcementArea => Reinforcement.CalculateArea(_section.Link) * 2;
        public AreaMomentOfInertia ReinforcementSecondMomentOfAreaYy =>
            _reinforcementSecondMomentOfAreaYy ??= Reinforcement.CalculateInertiaYy(_section);
        public AreaMomentOfInertia ReinforcementSecondMomentOfAreaZz =>
            _reinforcementSecondMomentOfAreaZz ??= Reinforcement.CalculateInertiaZz(_section);
        public Length ReinforcementRadiusOfGyrationYy =>
            _reinforcementRadiusOfGyrationYy ??= Reinforcement.CalculateRadiusOfGyrationYy(_section);
        public Length ReinforcementRadiusOfGyrationZz =>
            _reinforcementRadiusOfGyrationZz ??= Reinforcement.CalculateRadiusOfGyrationZz(_section);

        private Area? _reinforcementArea;
        private AreaMomentOfInertia? _reinforcementSecondMomentOfAreaYy;
        private AreaMomentOfInertia? _reinforcementSecondMomentOfAreaZz;
        private Length? _reinforcementRadiusOfGyrationYy;
        private Length? _reinforcementRadiusOfGyrationZz;
        private readonly IConcreteSection _section;
        private ConcreteSectionProperties() { }

        public ConcreteSectionProperties(IConcreteSection section) : base(section.Profile)
        {
            _section = section;
        }

        public Length EffectiveDepth(SectionFace face)
            => Reinforcement.CalculateEffectiveDepth(_section, face);
        public Area ReinforcementArea(SectionFace face) 
            => Reinforcement.CalculateArea(_section, face);
    }
}
