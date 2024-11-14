using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;
using OasysUnits;
using OasysUnits.Units;
using Area = OasysUnits.Area;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public class ConcreteSectionProperties : SectionProperties, IConcreteSectionProperties
    {
        public Area ReinforcemenArea => _reinforcementArea ??= Reinforcement.CalculateArea(_section.Rebars);
        public Area ConcreteArea => base.Area - ReinforcemenArea;
        public Ratio GeometricReinforcementRatio =>
            new Ratio(ReinforcemenArea.SquareMeters / ConcreteArea.SquareMeters, RatioUnit.DecimalFraction);
        public Area ShearReinforcementArea => Reinforcement.CalculateArea(_section.Link) * 2;
        public AreaMomentOfInertia ReinforcementSecondMomentOfAreaYy =>
            _reinforcementSecondMomentOfAreaYy ??= Reinforcement.CalculateInertiaYy(_section);
        public AreaMomentOfInertia ReinforcementSecondMomentOfAreaZz =>
            _reinforcementSecondMomentOfAreaZz ??= Reinforcement.CalculateInertiaZz(_section);
        public Length ReinforcementRadiusOfGyrationYy =>
            _reinforcementRadiusOfGyrationYy ??= Reinforcement.CalculateRadiusOfGyrationYy(_section);
        public Length ReinforcementRadiusOfGyrationZz =>
            _reinforcementRadiusOfGyrationZz ??= Reinforcement.CalculateRadiusOfGyrationZz(_section);

        private Area? _concreteArea;
        private Area? _reinforcementArea;
        private Area? _shearReinforcementArea;
        private AreaMomentOfInertia? _reinforcementSecondMomentOfAreaYy;
        private AreaMomentOfInertia? _reinforcementSecondMomentOfAreaZz;
        private Length? _reinforcementRadiusOfGyrationYy;
        private Length? _reinforcementRadiusOfGyrationZz;
        private IConcreteSection _section;
        private ConcreteSectionProperties() { }

        public ConcreteSectionProperties(IConcreteSection section) : base(section.Profile)
        {
            _section = section;
        }
    }
}
