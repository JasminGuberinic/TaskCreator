using Domain;
using NUnit.Framework;
using System;

namespace TaskCreatorTestProject
{
    public class NameTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TagNameValidCheck()
        {
            Assert.IsTrue(NameCheckService.IsTagNameValid("jsksee"));
        }

        [Test]
        public void TagNameInvalidCheckLestThenThreeLeters()
        {
            Assert.IsTrue(NameCheckService.IsTagNameValid("js"));
        }

        [Test]
        public void TagNameInvalidCheckNotAllLowerCase()
        {
            Assert.IsTrue(NameCheckService.IsTagNameValid("jsAV"));
        }

        [Test]
        public void IsUserTaskNameValid()
        {
            var userTaskName = NameCheckService.MakeUserTaskNameValid("jsss");
            Assert.IsTrue(Char.IsUpper(userTaskName[0]));
        }

        [Test]
        public void InvalidUserTaskNameNoChars()
        {
            Assert.Throws<InvalidNameException>(() => NameCheckService.MakeUserTaskNameValid(""));
        }
    }
}