using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class NameCheckerTest
    {
        [TestMethod]
        public void TagNameValid()
        {
            Assert.IsTrue(NameCheckService.IsTagNameValid("tagone"));
        }
    }
}
