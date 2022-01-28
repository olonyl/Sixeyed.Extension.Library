using NUnit.Framework;
using System;

namespace Sixeyed.Extension.Library.Tests.Demo1
{

    public class ExceptionExtensionsTests
    {
        [Test]
        public void DivideBy1()
        {
            Assert.AreEqual(10, Divide(10, 1));
        }

        [Test]
        public void DivideBy0()
        {
            try
            {
                Divide(10, 0);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine(ex.FullMessage());
                Assert.IsInstanceOf(typeof(ApplicationException), ex);
            }
        }

        private double Divide(int amount, int by)
        {
            try
            {
                return amount / by;
            }
            catch (Exception ex)
            {
                var invalidOpEx = new InvalidOperationException("Invalid operation", ex);
                var message = string.Format("Divide failed - amount: {0}, by: {1}", amount, by);
                throw new ApplicationException(message, invalidOpEx);
            }
        }
    }
}
