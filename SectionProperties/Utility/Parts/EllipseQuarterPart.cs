using System;
using System.Collections.Generic;
using MagmaWorks.Geometry;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.Parts
{
    internal readonly struct EllipseQuarterPart : IPart
    {
        public Length dy { get; }
        public Length dz { get; }
        public ILocalPoint2d ElasticCentroid { get; }

        public EllipseQuarterPart(Length y, Length z, ILocalPoint2d corner, bool mirrorY = false, bool mirrorZ = false)
        {
            dy = y;
            dz = z;
            var centroid = new LocalPoint2d()
            {
                Y = corner.Y + 4.0 * dy / (3.0 * Math.PI) * (mirrorY ? -1 : 1),
                Z = corner.Z + 4.0 * dz / (3.0 * Math.PI) * (mirrorZ ? -1 : 1),
            };

            if (corner.Y.Value == 0)
            {
                centroid.Y = new Length(0, corner.Z.Unit);
            }

            if (corner.Z.Value == 0)
            {
                centroid.Z = new Length(0, corner.Y.Unit);
            }

            if (corner.Z.Value == 0 && corner.Y.Value == 0)
            {
                centroid.Y = new Length(0, dy.Unit);
                centroid.Z = new Length(0, dy.Unit);
            }

            ElasticCentroid = centroid;
        }

        public OasysUnits.Area GetArea()
        {
            LengthUnit unit = dy.Unit;
            OasysUnits.Area res = OasysUnits.Area.Zero;
            OasysUnits.Area.TryParse($"0 {Length.GetAbbreviation(unit)}²", out res);
            return new OasysUnits.Area(0.25 * Math.PI * dy.As(unit) * dz.As(unit), res.Unit);
        }

        public static IList<IPart> CreateFullEllipse(Length y, Length z)
        {
            return new List<IPart>()
            {
                new EllipseQuarterPart(y / 2, z / 2, new LocalPoint2d(), false, false),
                new EllipseQuarterPart(y / 2, z / 2, new LocalPoint2d(), true, false),
                new EllipseQuarterPart(y / 2, z / 2, new LocalPoint2d(), true, true),
                new EllipseQuarterPart(y / 2, z / 2, new LocalPoint2d(), false, true),
            };
        }

        public static IList<IPart> CreateCircle(Length diameter)
        {
            if (diameter.Value < 0) {
                return CreateFullEllipse(diameter, diameter.Abs());
            }

            return CreateFullEllipse(diameter, diameter);
        }
    }
}
