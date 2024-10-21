﻿using MagmaWorks.Geometry;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts
{
    internal readonly struct TrapezoidalPart : IPart
    {
        public Length b { get; }
        public Length a { get; }
        public Length h { get; }
        public ILocalPoint2d ElasticCentroid { get; }

        public TrapezoidalPart(Length y, Length z, ILocalPoint2d centre)
        {
            b = y;
            a = y;
            h = z;

            var centroid = new LocalPoint2d()
            {
                Y = centre.Y,
                Z = centre.Z,
            };

            if (centre.Y.Value == 0)
            {
                centroid.Y = new Length(0, centre.Z.Unit);
            }

            if (centre.Z.Value == 0)
            {
                centroid.Z = new Length(0, centre.Y.Unit);
            }

            if (centre.Z.Value == 0 && centre.Y.Value == 0)
            {
                centroid.Y = new Length(0, b.Unit);
                centroid.Z = new Length(0, b.Unit);
            }

            ElasticCentroid = centroid;
        }

        public TrapezoidalPart(Length yTop, Length yBottom, Length z, ILocalPoint2d midHeight)
        {
            b = yTop;
            a = yBottom;
            h = z;
            Length e = h / 3 * (a + 2 * b) / (a + b);

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

        public OasysUnits.Area GetArea()
        {
            LengthUnit unit = b.Unit;
            OasysUnits.Area res = OasysUnits.Area.Zero;
            OasysUnits.Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out res);
            return new OasysUnits.Area(0.5 * (a.As(unit) + b.As(unit)) * h.As(unit), res.Unit);
        }
    }
}
