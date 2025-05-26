using MagmaWorks.Taxonomy.Sections.Properties.Utility;

namespace MagmaWorks.Taxonomy.Sections.Properties
{
    public class ConcreteSectionProperties : SectionProperties, IConcreteSectionProperties
    {
        public Area TotalReinforcementArea => _reinforcementArea ??= Rebars.CalculateArea(_section.Rebars);
        public Area ConcreteArea => Area - TotalReinforcementArea;
        public Ratio GeometricReinforcementRatio =>
            new Ratio(TotalReinforcementArea.SquareMeters / ConcreteArea.SquareMeters, RatioUnit.DecimalFraction);
        public Area CrossSectionalShearReinforcementArea => Rebars.CalculateArea(_section.Link) * 2;
        public AreaMomentOfInertia ReinforcementSecondMomentOfAreaYy =>
            _reinforcementSecondMomentOfAreaYy ??= Rebars.CalculateInertiaYy(_section);
        public AreaMomentOfInertia ReinforcementSecondMomentOfAreaZz =>
            _reinforcementSecondMomentOfAreaZz ??= Rebars.CalculateInertiaZz(_section);
        public Length ReinforcementRadiusOfGyrationYy =>
            _reinforcementRadiusOfGyrationYy ??= Rebars.CalculateRadiusOfGyrationYy(_section);
        public Length ReinforcementRadiusOfGyrationZz =>
            _reinforcementRadiusOfGyrationZz ??= Rebars.CalculateRadiusOfGyrationZz(_section);

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
            => Rebars.CalculateEffectiveDepth(_section, face);
        public Area ReinforcementArea(SectionFace face)
            => Rebars.CalculateArea(_section, face);
    }
}
