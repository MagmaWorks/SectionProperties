using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;
using OasysUnits;
using OasysUnits.Units;
using Area = OasysUnits.Area;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public class ConcreteSectionProperties : SectionProperties, IConcreteSectionProperties
    {
        public Area TotalReinforcementArea => _reinforcementArea ??= Rebar.CalculateArea(_section.Rebars);
        public Area ConcreteArea => base.Area - TotalReinforcementArea;
        public Ratio GeometricReinforcementRatio =>
            new Ratio(TotalReinforcementArea.SquareMeters / ConcreteArea.SquareMeters, RatioUnit.DecimalFraction);
        public Area CrossSectionalShearReinforcementArea => Rebar.CalculateArea(_section.Link) * 2;
        public AreaMomentOfInertia ReinforcementSecondMomentOfAreaYy =>
            _reinforcementSecondMomentOfAreaYy ??= Rebar.CalculateInertiaYy(_section);
        public AreaMomentOfInertia ReinforcementSecondMomentOfAreaZz =>
            _reinforcementSecondMomentOfAreaZz ??= Rebar.CalculateInertiaZz(_section);
        public Length ReinforcementRadiusOfGyrationYy =>
            _reinforcementRadiusOfGyrationYy ??= Rebar.CalculateRadiusOfGyrationYy(_section);
        public Length ReinforcementRadiusOfGyrationZz =>
            _reinforcementRadiusOfGyrationZz ??= Rebar.CalculateRadiusOfGyrationZz(_section);

        private Area? _reinforcementArea;
        private AreaMomentOfInertia? _reinforcementSecondMomentOfAreaYy;
        private AreaMomentOfInertia? _reinforcementSecondMomentOfAreaZz;
        private Length? _reinforcementRadiusOfGyrationYy;
        private Length? _reinforcementRadiusOfGyrationZz;
        private readonly IConcreteSection _section;

        public ConcreteSectionProperties(IConcreteSection section) : base(section.Profile)
        {
            _section = section;
        }

        public Length EffectiveDepth(SectionFace face)
            => Rebar.CalculateEffectiveDepth(_section, face);
        public Area ReinforcementArea(SectionFace face)
            => Rebar.CalculateArea(_section, face);
    }
}
