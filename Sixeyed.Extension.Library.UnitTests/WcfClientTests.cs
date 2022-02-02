using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sixeyed.Extension.Library.UnitTests.Stubs.ScfService;
using System;
using System.Diagnostics;

namespace Sixeyed.Extension.Library.UnitTests
{
    [TestClass]
    public class WcfClientTests
    {
        [TestMethod]
        public void Call()
        {
            var response = string.Empty;
            using (var client = new ServiceClient())
            {
                response = client.GetData(10);
            }
            Assert.AreEqual("You entered: 10", response);
        }

        [TestMethod]
        public void CallWithException_InUsingBlock()
        {
            var response = new CompositeType();
            using (var client = new ServiceClient())
            {
                try
                {
                    response = client.GetDataUsingDataContract(null);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.FullMessage());
                }
            }
        }

        [TestMethod]
        public void CallWithException()
        {
            var response = new CompositeType();
            var client = new ServiceClient();

            try
            {
                response = client.GetDataUsingDataContract(null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.FullMessage());
            }
            finally
            {
                ((IDisposable)client).Dispose();
            }
        }

        [TestMethod]
        public void CallWithDisposeSafely()
        {
            var response = new CompositeType();
            var client = new ServiceClient();

            try
            {
                response = client.GetDataUsingDataContract(null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.FullMessage());
            }
            finally
            {
                client.DisposeSafely();
            }
        }
    }
}
