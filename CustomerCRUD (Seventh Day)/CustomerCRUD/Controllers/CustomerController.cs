using CustomerCRUD.Data;
using CustomerCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerCRUD.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDBContext applicationDBContext;

        public CustomerController(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("AddCustomer");
        }

        [HttpPost]
        async public Task<IActionResult> Add(CustomerAddVM customerAdd)
        {
            var customer = new Customer()
            {
                Name = customerAdd.name,
                Email = customerAdd.email,
                Address = customerAdd.address,
                Phone = customerAdd.phone,
                DoB = customerAdd.doB
            };
            await applicationDBContext.Customers.AddAsync(customer);
            await applicationDBContext.SaveChangesAsync();

            return RedirectToAction("List", "Customer");
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var customer = await applicationDBContext.Customers.ToListAsync();
            return View("CustomerList", customer);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var customer = await applicationDBContext.Customers.FirstOrDefaultAsync(i => i.ID == id);
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCustomerVM updatecustomer ,int id)
        {
            var customer = await applicationDBContext.Customers.FindAsync(id);
            if (customer != null)
            {
                customer.Name = updatecustomer.Name;
                customer.Email= updatecustomer.Email;
                customer.Address = updatecustomer.Address;
                customer.Phone = updatecustomer.Phone;
                customer.DoB = updatecustomer.DoB;

                await applicationDBContext.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await applicationDBContext.Customers.FirstOrDefaultAsync(i => i.ID == id);
            if (customer != null)
            {
                applicationDBContext.Customers.Remove(customer);
                await applicationDBContext.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            var customer = applicationDBContext.Customers.FirstOrDefault(i => i.ID == id);
            return View(customer);
        }
    }
}
