using NUnit.Framework;
using System;
using componentModel = System.ComponentModel;

namespace Sixeyed.Extension.Library.Tests.Demo1
{
    public class EnumExtensionsTests
    {
        [Test]
        public void GetName()
        {
            var intro = Module.Intro;
            Assert.AreEqual("Intro", intro.ToString());
            Assert.AreEqual("Intro", Enum.GetName(typeof(Module), intro));
            Assert.AreEqual("Intro", intro.GetName());
        }

        [Test]
        public void GetDescription()
        {
            Assert.AreEqual("Introducing Extension Methods", Module.Intro.GetDescription());
            Assert.AreEqual("Advanced", Module.Advanced.GetDescription());

            Assert.AreEqual("In Progress", ModuleStatus.InProgress.GetDescription());
            Assert.AreEqual("Done", ModuleStatus.Done.GetDescription());
        }

        public enum Module
        {
            [componentModel.Description("Introducing Extension Methods")]
            Intro,
            Advanced,
            Library
        }

        public enum ModuleStatus
        {
            Todo,
            [componentModel.Description("In Progress")]
            InProgress,
            Done
        }
    }
}
