using MagmaWorks.Taxonomy.Sections.Properties.Utility.Parts;

namespace MagmaWorks.Taxonomy.Sections.Properties.Utility
{
    public static class ProfileParts
    {
        internal static List<IPart> GetParts(IProfile profile)
        {
            var parts = new List<IPart>();
            switch (profile)
            {
                case IDoubleAngle doubleAngle:
                    // right flange
                    parts.Add(new TrapezoidalPart(doubleAngle.Width, doubleAngle.FlangeThickness,
                        new LocalPoint2d(
                            (doubleAngle.BackToBackDistance + doubleAngle.Width) / 2,
                            doubleAngle.FlangeThickness / 2)));
                    // right web
                    parts.Add(new TrapezoidalPart(doubleAngle.WebThickness, doubleAngle.Height - doubleAngle.FlangeThickness,
                        new LocalPoint2d(
                            (doubleAngle.BackToBackDistance + doubleAngle.WebThickness) / 2,
                            (doubleAngle.Height - doubleAngle.FlangeThickness) / 2 + doubleAngle.FlangeThickness)));
                    // left flange
                    parts.Add(new TrapezoidalPart(doubleAngle.Width, doubleAngle.FlangeThickness,
                        new LocalPoint2d(
                            (-doubleAngle.BackToBackDistance - doubleAngle.Width) / 2,
                            doubleAngle.FlangeThickness / 2)));
                    // left web
                    parts.Add(new TrapezoidalPart(doubleAngle.WebThickness, doubleAngle.Height - doubleAngle.FlangeThickness,
                        new LocalPoint2d(
                            (-doubleAngle.BackToBackDistance - doubleAngle.WebThickness) / 2,
                            (doubleAngle.Height - doubleAngle.FlangeThickness) / 2 + doubleAngle.FlangeThickness)));
                    return parts;

                case IAngle angle:
                    // flange
                    parts.Add(new TrapezoidalPart(angle.Width, angle.FlangeThickness,
                        new LocalPoint2d(
                            angle.Width / 2,
                            angle.FlangeThickness / 2)));
                    // web
                    parts.Add(new TrapezoidalPart(angle.WebThickness, angle.Height - angle.FlangeThickness,
                        new LocalPoint2d(
                            angle.WebThickness / 2,
                            (angle.Height - angle.FlangeThickness) / 2 + angle.FlangeThickness)));
                    return parts;

                case IC c:
                    // top lip
                    parts.Add(new TrapezoidalPart(c.FlangeThickness, c.Lip,
                        new LocalPoint2d(
                            c.Width - c.FlangeThickness / 2,
                            c.Height / 2 - c.Lip / 2)));
                    // top flange
                    parts.Add(new TrapezoidalPart(c.Width - c.FlangeThickness, c.FlangeThickness,
                        new LocalPoint2d(
                            (c.Width - c.FlangeThickness) / 2,
                            c.Height / 2 - c.FlangeThickness / 2)));
                    // web
                    parts.Add(new TrapezoidalPart(c.WebThickness, c.Height - 2 * c.FlangeThickness,
                        new LocalPoint2d(c.WebThickness / 2, Length.Zero)));
                    // bottom flange
                    parts.Add(new TrapezoidalPart(c.Width - c.FlangeThickness, c.FlangeThickness,
                        new LocalPoint2d(
                            (c.Width - c.FlangeThickness) / 2,
                            -c.Height / 2 + c.FlangeThickness / 2)));
                    // bottom lip
                    parts.Add(new TrapezoidalPart(c.FlangeThickness, c.Lip,
                        new LocalPoint2d(
                            c.Width - c.FlangeThickness / 2,
                            -c.Height / 2 + c.Lip / 2)));
                    return parts;

                case IDoubleChannel doubleChannel:
                    // right top flange
                    parts.Add(new TrapezoidalPart(doubleChannel.Width, doubleChannel.FlangeThickness,
                        new LocalPoint2d(
                            (doubleChannel.BackToBackDistance + doubleChannel.Width) / 2,
                            doubleChannel.Height / 2 - doubleChannel.FlangeThickness / 2)));
                    // right web
                    parts.Add(new TrapezoidalPart(doubleChannel.WebThickness, doubleChannel.Height - 2 * doubleChannel.FlangeThickness,
                        new LocalPoint2d(doubleChannel.BackToBackDistance + doubleChannel.WebThickness / 2, Length.Zero)));
                    // right bottom flange
                    parts.Add(new TrapezoidalPart(doubleChannel.Width, doubleChannel.FlangeThickness,
                        new LocalPoint2d(
                            (doubleChannel.BackToBackDistance + doubleChannel.Width) / 2,
                            -doubleChannel.Height / 2 + doubleChannel.FlangeThickness / 2)));
                    // left top flange
                    parts.Add(new TrapezoidalPart(doubleChannel.Width, doubleChannel.FlangeThickness,
                        new LocalPoint2d(
                            (-doubleChannel.BackToBackDistance - doubleChannel.Width) / 2,
                            doubleChannel.Height / 2 - doubleChannel.FlangeThickness / 2)));
                    // left web
                    parts.Add(new TrapezoidalPart(doubleChannel.WebThickness, doubleChannel.Height - 2 * doubleChannel.FlangeThickness,
                        new LocalPoint2d(-doubleChannel.BackToBackDistance - doubleChannel.WebThickness / 2, Length.Zero)));
                    // left bottom flange
                    parts.Add(new TrapezoidalPart(doubleChannel.Width, doubleChannel.FlangeThickness,
                        new LocalPoint2d(
                            (-doubleChannel.BackToBackDistance - doubleChannel.Width) / 2,
                            -doubleChannel.Height / 2 + doubleChannel.FlangeThickness / 2)));
                    return parts;

                case IChannel channel:
                    // top flange
                    parts.Add(new TrapezoidalPart(channel.Width, channel.FlangeThickness,
                        new LocalPoint2d(
                            channel.Width / 2,
                            channel.Height / 2 - channel.FlangeThickness / 2)));
                    // web
                    parts.Add(new TrapezoidalPart(channel.WebThickness, channel.Height - 2 * channel.FlangeThickness,
                        new LocalPoint2d(channel.WebThickness / 2, Length.Zero)));
                    // bottom flange
                    parts.Add(new TrapezoidalPart(channel.Width, channel.FlangeThickness,
                        new LocalPoint2d(
                            channel.Width / 2,
                            -channel.Height / 2 + channel.FlangeThickness / 2)));
                    return parts;

                case ICircularHollow circularHollow:
                    // solid
                    parts.AddRange(EllipseQuarterPart.CreateCircle(circularHollow.Diameter));
                    // void
                    parts.AddRange(EllipseQuarterPart.CreateCircle(2 * circularHollow.Thickness - circularHollow.Diameter));
                    return parts;

                case ICircle circle:
                    // solid
                    parts.AddRange(EllipseQuarterPart.CreateCircle(circle.Diameter));
                    return parts;

                case ICruciform cruciform:
                    // flange
                    parts.Add(new TrapezoidalPart(cruciform.Width, cruciform.FlangeThickness,
                        new LocalPoint2d()));
                    // web
                    parts.Add(new TrapezoidalPart(cruciform.WebThickness, cruciform.Height,
                        new LocalPoint2d()));
                    // negative overlap
                    parts.Add(new TrapezoidalPart(-cruciform.WebThickness, cruciform.FlangeThickness,
                        new LocalPoint2d()));
                    return parts;

                case ICustomI customI:
                    // top flange
                    parts.Add(new TrapezoidalPart(customI.TopFlangeWidth, customI.TopFlangeThickness,
                        new LocalPoint2d(Length.Zero, customI.Height / 2 - customI.TopFlangeThickness / 2)));
                    // web
                    Length webHeight = customI.Height - customI.TopFlangeThickness - customI.BottomFlangeThickness;
                    parts.Add(new TrapezoidalPart(customI.WebThickness, webHeight,
                        new LocalPoint2d(Length.Zero, customI.Height / 2 - customI.TopFlangeThickness - webHeight / 2)));
                    // bottom flange
                    parts.Add(new TrapezoidalPart(customI.BottomFlangeWidth, customI.BottomFlangeThickness,
                        new LocalPoint2d(Length.Zero, -customI.Height / 2 + customI.BottomFlangeThickness / 2)));
                    return parts;

                case IEllipseHollow ellipseHollow:
                    // solid
                    parts.AddRange(EllipseQuarterPart.CreateFullEllipse(ellipseHollow.Width, ellipseHollow.Height));
                    // void
                    parts.AddRange(EllipseQuarterPart.CreateFullEllipse(
                        2 * ellipseHollow.Thickness - ellipseHollow.Width,
                        ellipseHollow.Height - 2 * ellipseHollow.Thickness));
                    return parts;

                case IEllipse ellipse:
                    parts.AddRange(EllipseQuarterPart.CreateFullEllipse(ellipse.Width, ellipse.Height));
                    return parts;

                case IIParallelFlange parallelFlange:
                    // top flange
                    parts.Add(new TrapezoidalPart(parallelFlange.Width, parallelFlange.FlangeThickness,
                        new LocalPoint2d(Length.Zero,
                            parallelFlange.Height / 2 - parallelFlange.FlangeThickness / 2)));
                    // web
                    parts.Add(new TrapezoidalPart(parallelFlange.WebThickness,
                        parallelFlange.Height - 2 * parallelFlange.FlangeThickness,
                        new LocalPoint2d()));
                    // bottom flange
                    parts.Add(new TrapezoidalPart(parallelFlange.Width, parallelFlange.FlangeThickness,
                        new LocalPoint2d(Length.Zero,
                            -parallelFlange.Height / 2 + parallelFlange.FlangeThickness / 2)));
                    // top-right fillet
                    // rectangular part
                    parts.Add(new TrapezoidalPart(parallelFlange.FilletRadius, parallelFlange.FilletRadius,
                        new LocalPoint2d(parallelFlange.WebThickness / 2 + parallelFlange.FilletRadius / 2,
                            parallelFlange.Height / 2 - parallelFlange.FlangeThickness - parallelFlange.FilletRadius / 2)));
                    // substract cirulcar part
                    parts.Add(new EllipseQuarterPart(-parallelFlange.FilletRadius, parallelFlange.FilletRadius,
                        new LocalPoint2d(parallelFlange.WebThickness / 2 + parallelFlange.FilletRadius,
                            parallelFlange.Height / 2 - parallelFlange.FlangeThickness - parallelFlange.FilletRadius), true, false));
                    // top-left fillet
                    // rectangular part
                    parts.Add(new TrapezoidalPart(parallelFlange.FilletRadius, parallelFlange.FilletRadius,
                        new LocalPoint2d(-parallelFlange.WebThickness / 2 - parallelFlange.FilletRadius / 2,
                            parallelFlange.Height / 2 - parallelFlange.FlangeThickness - parallelFlange.FilletRadius / 2)));
                    // substract cirulcar part
                    parts.Add(new EllipseQuarterPart(-parallelFlange.FilletRadius, parallelFlange.FilletRadius,
                        new LocalPoint2d(-parallelFlange.WebThickness / 2 - parallelFlange.FilletRadius,
                            parallelFlange.Height / 2 - parallelFlange.FlangeThickness - parallelFlange.FilletRadius), false, false));
                    // bottom-right fillet
                    // rectangular part
                    parts.Add(new TrapezoidalPart(parallelFlange.FilletRadius, parallelFlange.FilletRadius,
                        new LocalPoint2d(parallelFlange.WebThickness / 2 + parallelFlange.FilletRadius / 2,
                            -parallelFlange.Height / 2 + parallelFlange.FlangeThickness + parallelFlange.FilletRadius / 2)));
                    // substract cirulcar part
                    parts.Add(new EllipseQuarterPart(-parallelFlange.FilletRadius, parallelFlange.FilletRadius,
                        new LocalPoint2d(parallelFlange.WebThickness / 2 + parallelFlange.FilletRadius,
                            -parallelFlange.Height / 2 + parallelFlange.FlangeThickness + parallelFlange.FilletRadius), true, true));
                    // bottom-left fillet
                    // rectangular part
                    parts.Add(new TrapezoidalPart(parallelFlange.FilletRadius, parallelFlange.FilletRadius,
                        new LocalPoint2d(-parallelFlange.WebThickness / 2 - parallelFlange.FilletRadius / 2,
                            -parallelFlange.Height / 2 + parallelFlange.FlangeThickness + parallelFlange.FilletRadius / 2)));
                    // substract cirulcar part
                    parts.Add(new EllipseQuarterPart(-parallelFlange.FilletRadius, parallelFlange.FilletRadius,
                        new LocalPoint2d(-parallelFlange.WebThickness / 2 - parallelFlange.FilletRadius,
                            -parallelFlange.Height / 2 + parallelFlange.FlangeThickness + parallelFlange.FilletRadius), false, true));
                    return parts;

                case II i:
                    // top flange
                    parts.Add(new TrapezoidalPart(i.Width, i.FlangeThickness,
                        new LocalPoint2d(Length.Zero,
                            i.Height / 2 - i.FlangeThickness / 2)));
                    // web
                    parts.Add(new TrapezoidalPart(i.WebThickness,
                        i.Height - 2 * i.FlangeThickness,
                        new LocalPoint2d()));
                    // bottom flange
                    parts.Add(new TrapezoidalPart(i.Width, i.FlangeThickness,
                        new LocalPoint2d(Length.Zero,
                            -i.Height / 2 + i.FlangeThickness / 2)));
                    return parts;

                case IRectangularHollow rectangularHollow:
                    // solid
                    parts.Add(new TrapezoidalPart(rectangularHollow.Width, rectangularHollow.Height,
                        new LocalPoint2d()));
                    // void
                    parts.Add(new TrapezoidalPart(2 * rectangularHollow.Thickness - rectangularHollow.Width,
                        rectangularHollow.Height - 2 * rectangularHollow.Thickness,
                        new LocalPoint2d()));
                    return parts;

                case IRoundedRectangularHollow roundedRectangularHollow:
                    parts.AddRange(RoundedRectangleParts(roundedRectangularHollow.Width, roundedRectangularHollow.FlatWidth,
                        roundedRectangularHollow.Height, roundedRectangularHollow.FlatHeight));
                    parts.AddRange(RoundedRectangleParts(
                        roundedRectangularHollow.Width - 2 * roundedRectangularHollow.Thickness,
                        roundedRectangularHollow.FlatWidth - 2 * roundedRectangularHollow.Thickness,
                        roundedRectangularHollow.Height - 2 * roundedRectangularHollow.Thickness,
                        roundedRectangularHollow.FlatHeight - 2 * roundedRectangularHollow.Thickness,
                        true));
                    return parts;

                case IRoundedRectangle roundedRectangle:
                    return RoundedRectangleParts(roundedRectangle.Width, roundedRectangle.FlatWidth,
                        roundedRectangle.Height, roundedRectangle.FlatHeight);

                case IRectangle rectangle:
                    parts.Add(new TrapezoidalPart(rectangle.Width, rectangle.Height,
                        new LocalPoint2d()));
                    return parts;

                case ITee tee:
                    // flange
                    parts.Add(new TrapezoidalPart(tee.Width, tee.FlangeThickness,
                        new LocalPoint2d(Length.Zero, -tee.FlangeThickness / 2)));
                    // web
                    parts.Add(new TrapezoidalPart(tee.WebThickness, tee.Height - tee.FlangeThickness,
                    new LocalPoint2d(Length.Zero,
                            -tee.FlangeThickness - (tee.Height - tee.FlangeThickness) / 2)));
                    return parts;

                case ITrapezoid trapezoid:
                    parts.Add(new TrapezoidalPart(trapezoid.TopWidth, trapezoid.BottomWidth, trapezoid.Height,
                        new LocalPoint2d()));
                    return parts;

                case IZ z:
                    // top lip
                    parts.Add(new TrapezoidalPart(z.Thickness, z.TopLip,
                        new LocalPoint2d(
                            z.TopFlangeWidth - z.Thickness,
                            z.Height / 2 - z.TopLip / 2)));
                    // top flange
                    parts.Add(new TrapezoidalPart(z.TopFlangeWidth - z.Thickness, z.Thickness,
                        new LocalPoint2d(
                            (z.TopFlangeWidth - z.Thickness) / 2 - z.Thickness / 2,
                            z.Height / 2 - z.Thickness / 2)));
                    // web
                    parts.Add(new TrapezoidalPart(z.Thickness, z.Height - 2 * z.Thickness,
                        new LocalPoint2d()));
                    // bottom flange
                    parts.Add(new TrapezoidalPart(z.BottomFlangeWidth - z.Thickness, z.Thickness,
                        new LocalPoint2d(
                            (-z.BottomFlangeWidth + z.Thickness) / 2 + z.Thickness / 2,
                            -z.Height / 2 + z.Thickness / 2)));
                    // bottom lip
                    parts.Add(new TrapezoidalPart(z.Thickness, z.BottomLip,
                        new LocalPoint2d(
                            -z.BottomFlangeWidth + z.Thickness,
                            -z.Height / 2 + z.TopLip / 2)));
                    return parts;

                default:
                    throw new System.Exception($"Unable to get parts for unknown Profile type {profile.GetType()}");
            }
        }

        private static List<IPart> RoundedRectangleParts(Length width, Length flatWidth, Length height, Length flatHeight, bool negative = false)
        {
            var parts = new List<IPart>();
            // ellipse parts
            Length ellipseQuarterWidth = (width - flatWidth) / 2;
            Length ellipseQuarterHeight = (height - flatHeight) / 2 * (negative ? -1 : 1);
            // top-right
            parts.Add(new EllipseQuarterPart(ellipseQuarterWidth, ellipseQuarterHeight,
                new LocalPoint2d(flatWidth / 2, flatHeight / 2), false, false));
            // top-left
            parts.Add(new EllipseQuarterPart(ellipseQuarterWidth, ellipseQuarterHeight,
                new LocalPoint2d(-flatWidth / 2, flatHeight / 2), true, false));
            // bottom-right
            parts.Add(new EllipseQuarterPart(ellipseQuarterWidth, ellipseQuarterHeight,
                new LocalPoint2d(flatWidth / 2, -flatHeight / 2), false, true));
            // bottom-left
            parts.Add(new EllipseQuarterPart(ellipseQuarterWidth, ellipseQuarterHeight,
                new LocalPoint2d(-flatWidth / 2, -flatHeight / 2), true, true));
            // mid-rectangle
            parts.Add(new TrapezoidalPart(flatWidth, height * (negative ? -1 : 1),
                new LocalPoint2d()));
            // right-rectangle
            parts.Add(new TrapezoidalPart(ellipseQuarterWidth, flatHeight * (negative ? -1 : 1),
                new LocalPoint2d((width - ellipseQuarterWidth) / 2, Length.Zero)));
            // left-rectangle
            parts.Add(new TrapezoidalPart(ellipseQuarterWidth, flatHeight * (negative ? -1 : 1),
                new LocalPoint2d(-(width - ellipseQuarterWidth) / 2, Length.Zero)));
            return parts;
        }
    }
}
