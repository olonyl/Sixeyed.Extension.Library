using Sixeyed.Extension.Library.Domain.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Siexeyed.ExtensionsLibrary.Stub.Api2.Controller
{
    public class CustomerController : ApiController
    {
        public Customer Get(int id)
        {
            Customer customer = null;
            using (var container = new DomainModelContainer())
            {
                container.Configuration.LazyLoadingEnabled = false;
                customer = container.Customers.Find(id);
            }
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        public HttpResponseMessage Post([FromBody] Customer customer)
        {
            using (var container = new DomainModelContainer())
            {
                container.Customers.Add(customer);
                container.Save();
            }
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            response.AddLocationHeader(Request, customer.Id);

            return response;
        }
    }
}
