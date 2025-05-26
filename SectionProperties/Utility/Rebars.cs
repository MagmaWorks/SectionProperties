using MagmaWorks.Taxonomy.Sections.Properties.Utility.Parts;

namespace MagmaWorks.Taxonomy.Sections.Properties.Utility
{
    public static class Rebars
    {
        private const double PiFactor = Math.PI / 4;

        public static Area CalculateArea(IEnumerable<ILongitudinalReinforcement> rebars)
        {
            LengthUnit unit = rebars.FirstOrDefault().Rebar.Diameter.Unit;
            double area = 0;
            foreach (ILongitudinalReinforcement reinforcement in rebars)
            {
                area += PiFactor * Math.Pow(reinforcement.Rebar.Diameter.As(unit), 2);
            }

            Area m2 = Area.Zero;
            Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out m2);
            return new Area(area, m2.Unit);
        }

        public static Area CalculateArea(IRebar rebar)
        {
            LengthUnit unit = rebar.Diameter.Unit;
            Area m2 = Area.Zero;
            Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out m2);
            return new Area(PiFactor * Math.Pow(rebar.Diameter.As(unit), 2), m2.Unit);
        }

        public static Area CalculateArea(IConcreteSection section, SectionFace face)
        {
            ILocalPoint2d concreteCentroid = Centroids.CalculateCentroid(section.Profile);
            switch (face)
            {
                case SectionFace.Top:
                    return CalculateArea(section.Rebars.Where(r => r.Position.Z > concreteCentroid.Z));

                case SectionFace.Bottom:
                    return CalculateArea(section.Rebars.Where(r => r.Position.Z < concreteCentroid.Z));

                case SectionFace.Left:
                    return CalculateArea(section.Rebars.Where(r => r.Position.Y > concreteCentroid.Y));

                case SectionFace.Right:
                    return CalculateArea(section.Rebars.Where(r => r.Position.Y > concreteCentroid.Y));

                default:
                    throw new NotImplementedException($"Unknown Face type {face}");
            }
        }

        public static Length CalculateEffectiveDepth(IConcreteSection section, SectionFace face)
        {
            ILocalPoint2d concreteCentroid = Centroids.CalculateCentroid(section.Profile);
            ILocalDomain2d extends = Extends.GetDomain(section.Profile);
            switch (face)
            {
                case SectionFace.Top:
                    {
                        List<IPart> rebars = GetParts(section.Rebars.Where(r => r.Position.Z > concreteCentroid.Z));
                        ILocalPoint2d rebarsCentroid = Centroids.CalculateCentroid(rebars);
                        return rebarsCentroid.Z - extends.Min.Z;
                    }

                case SectionFace.Bottom:
                    {
                        List<IPart> rebars = GetParts(section.Rebars.Where(r => r.Position.Z < concreteCentroid.Z));
                        ILocalPoint2d rebarsCentroid = Centroids.CalculateCentroid(rebars);
                        return extends.Max.Z - rebarsCentroid.Z;
                    }

                case SectionFace.Left:
                    {
                        List<IPart> rebars = GetParts(section.Rebars.Where(r => r.Position.Y > concreteCentroid.Y));
                        ILocalPoint2d rebarsCentroid = Centroids.CalculateCentroid(rebars);
                        return rebarsCentroid.Y - extends.Min.Y;
                    }

                case SectionFace.Right:
                    {
                        List<IPart> rebars = GetParts(section.Rebars.Where(r => r.Position.Y < concreteCentroid.Y));
                        ILocalPoint2d rebarsCentroid = Centroids.CalculateCentroid(rebars);
                        return extends.Max.Y - rebarsCentroid.Y;
                    }

                default:
                    throw new NotImplementedException($"Unknown Face type {face}");
            }
        }

        public static AreaMomentOfInertia CalculateInertiaYy(IConcreteSection section)
        {
            ILocalPoint2d concreteCentroid = Centroids.CalculateCentroid(section.Profile);
            List<IPart> rebars = GetParts(section.Rebars);
            return Inertiae.CalculateInertiaYy(rebars, concreteCentroid);
        }

        public static AreaMomentOfInertia CalculateInertiaZz(IConcreteSection section)
        {
            ILocalPoint2d concreteCentroid = Centroids.CalculateCentroid(section.Profile);
            List<IPart> rebars = GetParts(section.Rebars);
            return Inertiae.CalculateInertiaZz(rebars, concreteCentroid);
        }

        public static Length CalculateRadiusOfGyrationYy(IConcreteSection section)
        {
            Area area = CalculateArea(section.Rebars);
            AreaMomentOfInertia inertia = CalculateInertiaYy(section);
            return RadiusOfGyrations.CalculateRadiusOfGyration(area, inertia);
        }

        public static Length CalculateRadiusOfGyrationZz(IConcreteSection section)
        {
            Area area = CalculateArea(section.Rebars);
            AreaMomentOfInertia inertia = CalculateInertiaZz(section);
            return RadiusOfGyrations.CalculateRadiusOfGyration(area, inertia);
        }

        private static List<IPart> GetParts(IEnumerable<ILongitudinalReinforcement> rebars)
        {
            var parts = new List<IPart>();
            foreach (ILongitudinalReinforcement rebar in rebars)
            {
                IList<IPart> part = EllipseQuarterPart.CreateCircle(rebar.Rebar.Diameter, rebar.Position);
                parts.AddRange(part);
            }

            return parts;
        }
    }
}
