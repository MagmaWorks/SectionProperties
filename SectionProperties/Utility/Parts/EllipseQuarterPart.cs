namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts
{
    internal readonly struct EllipseQuarterPart : IPart
    {
        public Length a { get; }
        public Length b { get; }
        public ILocalPoint2d ElasticCentroid { get; }
        public ILocalDomain2d Extends { get; }


        private const double Factor = Math.PI / 16 - 4 / (9 * Math.PI);

        public EllipseQuarterPart(Length y, Length z, ILocalPoint2d corner, bool mirrorY = false, bool mirrorZ = false)
        {
            a = y;
            b = z;
            ElasticCentroid = new LocalPoint2d()
            {
                Y = corner.Y + 4.0 * a.Abs() / (3.0 * Math.PI) * (mirrorY ? -1 : 1),
                Z = corner.Z + 4.0 * b.Abs() / (3.0 * Math.PI) * (mirrorZ ? -1 : 1),
            };
            Length maxY = mirrorY
                ? corner.Y
                : corner.Y + a.Abs();
            Length minY = mirrorY
                ? corner.Y - a.Abs()
                : corner.Y;
            Length maxZ = mirrorZ
                ? corner.Z
                : corner.Z + b.Abs();
            Length minZ = mirrorZ
                ? corner.Z - b.Abs()
                : corner.Z;
            Extends = Utility.Extends.CreateDomain(maxY, minY, maxZ, minZ);
        }

        public static IList<IPart> CreateFullEllipse(Length y, Length z, ILocalPoint2d position = null)
        {
            position ??= new LocalPoint2d();
            return new List<IPart>()
            {
                new EllipseQuarterPart(y / 2, z / 2, position, false, false),
                new EllipseQuarterPart(y / 2, z / 2, position, true, false),
                new EllipseQuarterPart(y / 2, z / 2, position, true, true),
                new EllipseQuarterPart(y / 2, z / 2, position, false, true),
            };
        }

        public static IList<IPart> CreateCircle(Length diameter, ILocalPoint2d position = null)
        {
            if (diameter.Value < 0)
            {
                return CreateFullEllipse(diameter, diameter.Abs(), position);
            }

            return CreateFullEllipse(diameter, diameter, position);
        }

        public Area GetArea()
        {
            LengthUnit unit = a.Unit;
            Area res = Area.Zero;
            Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out res);
            return new Area(0.25 * Math.PI * a.As(unit) * b.As(unit), res.Unit);
        }

        public AreaMomentOfInertia GetMomentOfInertiaYy()
        {
            LengthUnit unit = a.Unit;
            AreaMomentOfInertia res = AreaMomentOfInertia.Zero;
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit)}⁴", out res);
            return new AreaMomentOfInertia(Factor * a.As(unit) * Math.Pow(b.As(unit), 3), res.Unit);
        }

        public AreaMomentOfInertia GetMomentOfInertiaZz()
        {
            LengthUnit unit = a.Unit;
            AreaMomentOfInertia res = AreaMomentOfInertia.Zero;
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit)}⁴", out res);
            return new AreaMomentOfInertia(Factor * Math.Pow(a.As(unit), 3) * b.As(unit), res.Unit);
        }

        private void SetExtends(ILocalPoint2d corner, bool mirrorY = false, bool mirrorZ = false)
        {

        }
    }
}
