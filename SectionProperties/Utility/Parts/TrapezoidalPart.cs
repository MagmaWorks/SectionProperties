﻿namespace MagmaWorks.Taxonomy.Sections.Properties.Utility.Parts
{
    internal readonly struct TrapezoidalPart : IPart
    {
        public Length b { get; }
        public Length a { get; }
        public Length h { get; }
        public ILocalPoint2d ElasticCentroid { get; }
        public ILocalDomain2d Extends => GetExtends();

        public TrapezoidalPart(Length y, Length z, ILocalPoint2d centre)
        {
            b = y;
            a = y;
            h = z;
            ElasticCentroid = new LocalPoint2d()
            {
                Y = centre.Y,
                Z = centre.Z,
            };
        }

        public TrapezoidalPart(Length yTop, Length yBottom, Length z, ILocalPoint2d midHeight)
        {
            b = yTop;
            a = yBottom;
            h = z;
            Length e = h / 3 * (a.Abs() + 2 * b.Abs()) / (a.Abs() + b.Abs());

            var centroid = new LocalPoint2d()
            {
                Y = midHeight.Y,
                Z = e - z / 2,
            };

            if (centroid.Y.Value == 0)
            {
                centroid.Y = new Length(0, midHeight.Z.Unit);
            }

            if (centroid.Z.Value == 0)
            {
                centroid.Z = new Length(0, midHeight.Y.Unit);
            }

            if (centroid.Z.Value == 0 && centroid.Y.Value == 0)
            {
                centroid.Y = new Length(0, b.Unit);
                centroid.Z = new Length(0, b.Unit);
            }

            ElasticCentroid = centroid;
        }

        public Area GetArea()
        {
            LengthUnit unit = b.Unit;
            Area res = Area.Zero;
            Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out res);
            return new Area(0.5 * (a.As(unit) + b.As(unit)) * h.As(unit), res.Unit);
        }

        public AreaMomentOfInertia GetMomentOfInertiaYy()
        {
            LengthUnit unit = a.Unit;
            AreaMomentOfInertia res = AreaMomentOfInertia.Zero;
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit)}⁴", out res);
            return new AreaMomentOfInertia(
                Math.Pow(h.As(unit), 3) *
                (Math.Pow(a.As(unit), 2) + 4 * a.As(unit) * b.As(unit) + Math.Pow(b.As(unit), 2))
                / (36 * (a.As(unit) + b.As(unit))), res.Unit);
        }

        public AreaMomentOfInertia GetMomentOfInertiaZz()
        {
            LengthUnit unit = a.Unit;
            AreaMomentOfInertia res = AreaMomentOfInertia.Zero;
            AreaMomentOfInertia.TryParse($"0 {Length.GetAbbreviation(unit)}⁴", out res);
            return a.As(unit) == b.As(unit)
                ? new AreaMomentOfInertia(h.As(unit) * Math.Pow(a.As(unit), 3) / 12, res.Unit)
                : new AreaMomentOfInertia(
                h.As(unit) * (Math.Pow(a.As(unit), 4) - Math.Pow(b.As(unit), 4))
                / (48 * (a.As(unit) - b.As(unit))), res.Unit);
        }

        private ILocalDomain2d GetExtends()
        {
            Length maxY = a.Abs() > b.Abs()
                ? a.Abs() / 2 + ElasticCentroid.Y
                : b.Abs() / 2 + ElasticCentroid.Y;
            Length minY = a.Abs() > b.Abs()
                ? ElasticCentroid.Y - a.Abs() / 2
                : ElasticCentroid.Y - b.Abs() / 2;
            Length e = h / 3 * (a.Abs() + 2 * b.Abs()) / (a.Abs() + b.Abs());
            Length maxZ = ElasticCentroid.Z + h - e;
            Length minZ = ElasticCentroid.Z - e;
            return Utility.Extends.CreateDomain(maxY, minY, maxZ, minZ);
        }
    }
}
