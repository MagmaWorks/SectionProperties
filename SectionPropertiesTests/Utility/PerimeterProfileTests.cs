using System.Collections;
using System.Reflection;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;
using SectionModuli = MagmaWorks.Taxonomy.Sections.SectionProperties.Utility.SectionModuli;

namespace SectionPropertiesTests
{
    public class PerimeterProfileTests
    {
        [Theory]
        [ClassData(typeof(SectionGenerator))]
        public void MoveToElasticCentroidTest(ISection section)
        {
            // Assemble
            IPerimeter original = new Perimeter(section.Profile);
            ILocalPoint2d originalCentroid = Centroids.CalculateCentroid(original);

            // Act
            IPerimeter translatedPerimeter = PerimeterProfiles.MoveToElasticCentroid(original);
            ILocalPoint2d newCentroid = Centroids.CalculateCentroid(translatedPerimeter);

            // Assert
            Assert.Equal(0, newCentroid.Y.Value, 12);
            Assert.Equal(0, newCentroid.Z.Value, 12);
        }

        [Theory]
        [ClassData(typeof(SectionGenerator))]
        public void AreaTests(ISection section)
        {
            // skip back to back profiles as they do not convert to a single Perimeter profile
            if (section.Profile is IBackToBack)
            {
                return;
            }

            // Assemble
            Area originalA = Areas.CalculateArea(section.Profile);
            IPerimeter perimeter = new Perimeter(section.Profile);

            // Act
            Area area = Areas.CalculateArea(perimeter);

            // Assert
            Assert.Equal(originalA.SquareCentimeters, area.SquareCentimeters, 0.05 * area.SquareCentimeters);
        }


        [Theory]
        [ClassData(typeof(SectionGenerator))]
        public void RadiusOfGyrationTests(ISection section)
        {
            // skip back to back profiles as they do not convert to a single Perimeter profile
            if (section.Profile is IBackToBack)
            {
                return;
            }

            // Assemble
            Length originalYy = RadiusOfGyrations.CalculateRadiusOfGyrationYy(section.Profile);
            Length originalZz = RadiusOfGyrations.CalculateRadiusOfGyrationZz(section.Profile);
            IPerimeter perimeter = new Perimeter(section.Profile);

            // Act
            Length radiusOfGyrationYy = RadiusOfGyrations.CalculateRadiusOfGyrationYy(perimeter);
            Length radiusOfGyrationZz = RadiusOfGyrations.CalculateRadiusOfGyrationZz(perimeter);

            // Assert
            Assert.Equal(originalYy.Centimeters, radiusOfGyrationYy.Centimeters, 0.05 * radiusOfGyrationYy.Centimeters);
            Assert.Equal(originalZz.Centimeters, radiusOfGyrationZz.Centimeters, 0.05 * radiusOfGyrationZz.Centimeters);
        }

        [Theory]
        [ClassData(typeof(SectionGenerator))]
        public void MomentOfInertiaTests(ISection section)
        {
            // skip back to back profiles as they do not convert to a single Perimeter profile
            if (section.Profile is IBackToBack)
            {
                return;
            }

            // Assemble
            AreaMomentOfInertia originalYy = Inertiae.CalculateInertiaYy(section.Profile);
            AreaMomentOfInertia originalZz = Inertiae.CalculateInertiaZz(section.Profile);
            IPerimeter perimeter = new Perimeter(section.Profile);

            // Act
            AreaMomentOfInertia inertiaYy = Inertiae.CalculateInertiaYy(perimeter);
            AreaMomentOfInertia inertiaZz = Inertiae.CalculateInertiaZz(perimeter);

            // Assert
            Assert.Equal(originalYy.CentimetersToTheFourth, inertiaYy.CentimetersToTheFourth, 0.05 * inertiaYy.CentimetersToTheFourth);
            Assert.Equal(originalZz.CentimetersToTheFourth, inertiaZz.CentimetersToTheFourth, 0.05 * inertiaZz.CentimetersToTheFourth);
        }

        [Theory]
        [ClassData(typeof(SectionGenerator))]
        public void SectionModulusTests(ISection section)
        {
            // skip back to back profiles as they do not convert to a single Perimeter profile
            if (section.Profile is IBackToBack)
            {
                return;
            }

            // Assemble
            SectionModulus originalYy = SectionModuli.CalculateSectionModulusYy(section.Profile);
            SectionModulus originalZz = SectionModuli.CalculateSectionModulusZz(section.Profile);
            IPerimeter perimeter = new Perimeter(section.Profile);

            // Act
            SectionModulus inertiaYy = SectionModuli.CalculateSectionModulusYy(perimeter);
            SectionModulus inertiaZz = SectionModuli.CalculateSectionModulusZz(perimeter);

            // Assert
            Assert.Equal(originalYy.CubicCentimeters, inertiaYy.CubicCentimeters, 0.05 * inertiaYy.CubicCentimeters);
            Assert.Equal(originalZz.CubicCentimeters, inertiaZz.CubicCentimeters, 0.05 * inertiaZz.CubicCentimeters);
        }

        public class SectionGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = GetAllComponents();

            public IEnumerator<object[]> GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private static List<object[]> GetAllComponents()
            {
                Type sectionGeneratorClass = typeof(Sections);
                MethodInfo[] sectionMethods = sectionGeneratorClass.GetMethods()
                    .Where(x => x.IsPublic && x.IsStatic).ToArray();

                var data = new List<object[]>();
                foreach (MethodInfo method in sectionMethods)
                {
                    object sect = method.Invoke(null, null);
                    {
                        data.Add([sect]);
                    }
                }

                return data;
            }
        }
    }
}
