using System.Collections;
using System.Reflection;

namespace SectionPropertiesTests
{
    public class SectionPropertiesTests
    {
        [Theory]
        [ClassData(typeof(SectionGenerator))]
        public void ConstructorTest(ISection section)
        {
            ISectionProperties sectionProperties = new SectionProperties(section);
            Assert.NotNull(sectionProperties);
            TestObjectsPropertiesAreNotNull(sectionProperties);
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

        private void TestObjectsPropertiesAreNotNull(object obj)
        {
            PropertyInfo[] propertyInfo = obj.GetType().GetProperties(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (PropertyInfo property in propertyInfo)
            {
                Assert.NotNull(property.GetValue(obj));
            }
        }
    }
}
