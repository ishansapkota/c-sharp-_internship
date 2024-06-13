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
                CustomerID = customerAdd.CustomerID,
                Name = customerAdd.name,
                Email = customerAdd.email,
                Address = customerAdd.address,
                Phone = customerAdd.phone,
                DoB = customerAdd.doB,

            };

            var goods = new Goods()
            {
                GoodsID = customerAdd.GoodsID,
                GoodsName = customerAdd.GoodsName

            };

            var custgoods = new CustomerGoods()
            {
                CustomerID = customerAdd.CustomerID,
                GoodsID = goods.GoodsID,
                Customer = customer,
                Goods = goods

            };

            await applicationDBContext.Customers.AddAsync(customer);
            await applicationDBContext.Goods.AddAsync(goods);
            await applicationDBContext.CustomerGoods.AddAsync(custgoods);

            await applicationDBContext.SaveChangesAsync();
            return RedirectToAction("List", "Customer");
        }


        /*[HttpGet]
        public async Task<IActionResult> List()
        {
            var customer = await applicationDBContext.Customers.ToListAsync();
            return View("CustomerList", customer);
        }*/


        [HttpGet]

        public async Task<IActionResult> List()
        {
            var query = await (from c in applicationDBContext.Customers
                               join g in applicationDBContext.CustomerGoods
                               on c.CustomerID equals g.CustomerID
                               select new CustomerGoodsViewModel
                               {
                                   CustomerID = c.CustomerID,
                                   name = c.Name,
                                   address = c.Address,
                                   phone = c.Phone,
                                   doB = c.DoB,
                                   email = c.Email,
                                   GoodsName = g.Goods.GoodsName
                               }).ToListAsync();

            return View("CustomerList", query);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var customer = await applicationDBContext.CustomerGoods.Include(cg => cg.Customer).Include(cg => cg.Goods).FirstOrDefaultAsync(i => i.CustomerID == id);
            if (customer != null)

            {
                var updateobj = new UpdateCustomerVM()
                {
                    CustomerID = customer.CustomerID,
                    email = customer.Customer.Email,
                    name = customer.Customer.Name,
                    phone = customer.Customer.Phone,
                    address = customer.Customer.Address,
                    doB= customer.Customer.DoB,
                    GoodsName = customer.Goods.GoodsName
                };
                return View(updateobj);
            }
            return RedirectToAction("List");
            
        }



        [HttpPost]
        public async Task<IActionResult> Update(CustomerGoods updatecustomer, int id)
        {
            var customer = await applicationDBContext.CustomerGoods.Include(cg => cg.Customer).Include(cg => cg.Goods).FirstOrDefaultAsync(i => i.CustomerID == id);
            if (customer != null)
            {
                customer.Customer.Name = updatecustomer.Customer.Name;
                customer.Customer.Email = updatecustomer.Customer.Email;
                customer.Customer.Address = updatecustomer.Customer.Address;
                customer.Customer.Phone = updatecustomer.Customer.Phone;
                customer.Customer.DoB = updatecustomer.Customer.DoB;

                customer.Goods.GoodsName = updatecustomer.Goods.GoodsName;

                await applicationDBContext.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customergoods = await applicationDBContext.CustomerGoods.FirstOrDefaultAsync(i => i.CustomerID == id);
            var customer = await applicationDBContext.Customers.FirstOrDefaultAsync(i => i.CustomerID == id);
            if (customergoods != null && customer != null)
            {
                applicationDBContext.CustomerGoods.Remove(customergoods);
                applicationDBContext.Customers.Remove(customer);
                await applicationDBContext.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            var customer = applicationDBContext.CustomerGoods.Include(cg => cg.Customer).Include(cg => cg.Goods).FirstOrDefault(i => i.CustomerID == id);
            return View(customer);
        }


    }
}
