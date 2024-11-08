using OasysUnits;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties
{
    public class ConcreteSectionProperties : SectionProperties, IConcreteSectionProperties
    {
        public Area TotalAreaOfReinforcement => throw new System.NotImplementedException();
        public Area ConcreteArea => throw new System.NotImplementedException();
        public Ratio GeometricReinforcementRatio => throw new System.NotImplementedException();
        public Area ShearReinforcementArea => throw new System.NotImplementedException();
        public Length ShearReinforcementSpacing => throw new System.NotImplementedException();
        public AreaMomentOfInertia ReinforcementSecondMomentOfAreaYy => throw new System.NotImplementedException();
        public AreaMomentOfInertia ReinforcementSecondMomentOfAreaZz => throw new System.NotImplementedException();
        public Length ReinforcementRadiusOfGyrationYy => throw new System.NotImplementedException();
        public Length ReinforcementRadiusOfGyrationZz => throw new System.NotImplementedException();

        private Area _concreteArea;
        private Area _longitudinalReinforcementArea;
        private Area _shearReinforcementArea;
        private IConcreteSection _section;
        private ConcreteSectionProperties() { }

        public ConcreteSectionProperties(IConcreteSection section) : base(section.Profile)
        {
            _section = section;
        }
    }
}
