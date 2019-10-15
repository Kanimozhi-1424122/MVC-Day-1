using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Day_1;
using MVC_Day_1.Models;
using System.Data.Entity;

namespace MVC_Day_1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext dbContext = null;
        public CustomerController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                dbContext.Dispose();
            }
        }
        public ActionResult Index()
        {
            List<customer> customer = dbContext.Customers.Include(k=>k.MemberShipType).ToList();
            return View(customer);
        }
        public ActionResult Details(int id)
        {
            var customer = dbContext.Customers.Include(k => k.MemberShipType).ToList().SingleOrDefault(a => a.Id == id);
            return View(customer);

        }
        public List<customer> GetCustomer()
        {
            List<customer> movies = new List<customer>
            {
                new customer{Id=1,CustomerName="Kani",DateofBirth=Convert.ToDateTime("24/09/1997"),Gender="Female"},
                new customer{Id=2,CustomerName="Kalpana",DateofBirth=Convert.ToDateTime("20/08/1997"),Gender="Female"}
            };
            return movies;
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var Customer = new customer();
            ViewBag.Gender = GetGender();
            ViewBag.MemberShipTypeId = GetMemberShip();
            return View(Customer);
        }
        [HttpPost]
        public ActionResult Create(customer customerFromView)
        {
            if(!ModelState.IsValid)
            {               
                ViewBag.Gender = GetGender();
                ViewBag.MemberShipTypeId = GetMemberShip();
                return View(customerFromView);
            }
            dbContext.Customers.Add(customerFromView);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Customer");
        }
        [Authorize]
        [HttpGet]
        public ActionResult EditCustomer(int Id)
        {
            var Customer = dbContext.Customers.SingleOrDefault(c => c.Id == Id);
            if (Customer != null)
            {
                ViewBag.Gender = GetGender();
                ViewBag.MemberShipTypeId = GetMemberShip();
                return View(Customer);
            }
            return HttpNotFound("Customer ID Not Exists");
        }
        [HttpPost]
        public ActionResult EditCustomer(customer CustomerFromView)
        {
            if(ModelState.IsValid)
            {
                var CustomerInDB = dbContext.Customers.FirstOrDefault(c => c.Id == CustomerFromView.Id);
                CustomerInDB.CustomerName = CustomerFromView.CustomerName;
                CustomerInDB.City = CustomerFromView.City;
                CustomerInDB.DateofBirth = CustomerFromView.DateofBirth;
                CustomerInDB.Gender = CustomerFromView.Gender;
                CustomerInDB.MemberShipType = CustomerFromView.MemberShipType;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Gender = GetGender();
                ViewBag.MemberShipTypeId = GetMemberShip();
                return View(CustomerFromView);
            }
        }
        [Authorize]
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var Customer = dbContext.Customers.SingleOrDefault(c => c.Id == Id);
            
                ViewBag.Gender = GetGender();
                ViewBag.MemberShipTypeId = GetMemberShip();
             dbContext.Customers.Remove(Customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");



        }
        
        [NonAction]
        public List<SelectListItem> GetGender()
        {
            List<SelectListItem> gender = new List<SelectListItem>
            {
                new SelectListItem{Text="Select a gender",Value="0",Disabled=true,Selected=true},
                new SelectListItem{Text="Male",Value="Male"},
                new SelectListItem{Text="Female",Value="Female"},
                new SelectListItem{Text="Others",Value="Others"}
            };
            return gender;
        }
        [NonAction]
        public List<SelectListItem> GetMemberShip()
        {
            var memberShip = (from m in dbContext.memberShipTypes.AsEnumerable()
                              select new SelectListItem
                              {
                                  Text = m.Type,
                                  Value = m.Id.ToString()
                            }).ToList();
            memberShip.Insert(0, new SelectListItem { Text = "--select--", Value = "select", Disabled = true, Selected = true });
            return memberShip;
        }
        
    }
}