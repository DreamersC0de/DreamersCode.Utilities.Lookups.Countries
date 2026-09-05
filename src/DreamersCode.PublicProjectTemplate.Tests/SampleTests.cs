using DreamersCode.PublicProjectTemplate;

namespace DreamersCode.PublicProjectTemplate.Tests
{
    [TestClass]
    public sealed class SampleTests
    {
        [TestMethod]
        public void SampleTest()
        {
            var result = SampleClass.Add(1, 2);
            Assert.AreEqual(3, result);
        }
    }
}
