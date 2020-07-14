using Antlr.Runtime.Misc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public CustomersController()
        {
            _customers.Add(new Customer { Id = 1, Name = "Fred" });
            _customers.Add(new Customer { Id = 2, Name = "Barney" });
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(_customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == id);

            return View(customer);
        }

        private readonly List<Customer> _customers = new ListStack<Customer>();
    }
}