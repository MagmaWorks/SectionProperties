using System.Collections;
using System.Reflection;
using MagmaWorks.Geometry;
using MagmaWorks.Taxonomy.Profiles;
using MagmaWorks.Taxonomy.Sections;
using MagmaWorks.Taxonomy.Sections.SectionProperties.Utility;
using OasysUnits;
using SectionPropertiesTests.TestUtility;

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
            ILocalPoint2d originalCentroid = Centroid.CalculateCentroid(original);

            // Act
            IPerimeter translatedPerimeter = PerimeterProfile.MoveToElasticCentroid(original);
            ILocalPoint2d newCentroid = Centroid.CalculateCentroid(translatedPerimeter);

            // Assert
            Assert.Equal(0, newCentroid.Y.Value, 12);
            Assert.Equal(0, newCentroid.Z.Value, 12);
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
            AreaMomentOfInertia originalYy = Inertia.CalculateInertiaYy(section.Profile);
            AreaMomentOfInertia originalZz = Inertia.CalculateInertiaZz(section.Profile);
            IPerimeter perimeter = new Perimeter(section.Profile);

            // Act
            AreaMomentOfInertia inertiaYy = Inertia.CalculateInertiaYy(perimeter);
            AreaMomentOfInertia inertiaZz = Inertia.CalculateInertiaZz(perimeter);

            // Assert
            Assert.Equal(originalYy.CentimetersToTheFourth, inertiaYy.CentimetersToTheFourth, 0.05 * inertiaYy.CentimetersToTheFourth);
            Assert.Equal(originalZz.CentimetersToTheFourth, inertiaZz.CentimetersToTheFourth, 0.05 * inertiaZz.CentimetersToTheFourth);
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
