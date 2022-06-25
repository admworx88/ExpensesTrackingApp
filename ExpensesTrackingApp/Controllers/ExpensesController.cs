using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpensesTrackingApp.Models;

namespace ExpensesTrackingApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpensesContext _context;

        public ExpensesController(ExpensesContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index(string searchData, string sortOrder)
        {

            ViewData["GetExpenseData"] = searchData;

            ViewBag.CustomerSortParam = String.IsNullOrEmpty(sortOrder) ? "customer_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.AmountSortParam = sortOrder == "Amount" ? "amount_desc" : "Amount";
            ViewBag.ProjectSortParam = sortOrder == "Project" ? "project_desc" : "Project";

            List<ViewData> vList = new List<ViewData>();
            ViewData vData;
            var query = await _context.Customers
                .Join(_context.Projects,
                cust => cust.Id,
                proj => proj.CustomerId,
                (cust, proj) => new { Customers = cust, Projects = proj })
                .Join(_context.Expenses,
                proj => proj.Projects.Id,
                exp => exp.ProjectId,
                (projCs, exp) => new { projCs.Projects, projCs.Customers, Expenses = exp })
                .Select(c => new
                {
                    c.Expenses.Id,
                    c.Expenses.ProjectId,
                    Date = c.Expenses.ExpenseDate.ToString("MM/dd/yyyy"),
                    Customer = c.Customers.Name,
                    c.Projects.Name,
                    Project = c.Projects.Name,
                    c.Expenses.Amount
                }).ToListAsync();

            if (string.IsNullOrEmpty(sortOrder))
            {
                vList.Clear();
                if (string.IsNullOrEmpty(searchData))
                {
                    foreach (var e in query)
                    {
                        vData = new ViewData();
                        vData.Id = e.Id;
                        vData.ProjectId = e.ProjectId;
                        vData.ExpenseDate = e.Date;
                        vData.Customer = e.Customer;
                        vData.Name = e.Name;
                        vData.Project = e.Project;
                        vData.Amount = e.Amount;
                        vList.Add(vData);
                    }
                    return View(vList);
                }
                else
                {
                    foreach (var e in (from x in query select x).Where(x => x.Customer.Contains(searchData) || x.Project.Contains(searchData)))
                    {
                        vData = new ViewData();
                        vData.Id = e.Id;
                        vData.ProjectId = e.ProjectId;
                        vData.ExpenseDate = e.Date;
                        vData.Customer = e.Customer;
                        vData.Name = e.Name;
                        vData.Project = e.Project;
                        vData.Amount = e.Amount;
                        vList.Add(vData);
                    }
                    return View(vList);
                }
                
            }

            switch (sortOrder)
            {
                case "customer_desc":
                    vList.Clear();
                    foreach (var e in (from x in query select x).OrderByDescending(x => x.Customer))
                    {
                        vData = new ViewData();
                        vData.Id = e.Id;
                        vData.ProjectId = e.ProjectId;
                        vData.ExpenseDate = e.Date;
                        vData.Customer = e.Customer;
                        vData.Name = e.Name;
                        vData.Project = e.Project;
                        vData.Amount = e.Amount;
                        vList.Add(vData);
                    }
                    return View(vList);
                    break;
                case "Date":
                    vList.Clear();
                    foreach (var e in (from x in query select x).OrderBy(x => x.Project))
                    {
                        vData = new ViewData();
                        vData.Id = e.Id;
                        vData.ProjectId = e.ProjectId;
                        vData.ExpenseDate = e.Date;
                        vData.Customer = e.Customer;
                        vData.Name = e.Name;
                        vData.Project = e.Project;
                        vData.Amount = e.Amount;
                        vList.Add(vData);
                    }
                    break;
                case "date_desc":
                    vList.Clear();
                    foreach (var e in (from x in query select x).OrderByDescending(x => x.Project))
                    {
                        vData = new ViewData();
                        vData.Id = e.Id;
                        vData.ProjectId = e.ProjectId;
                        vData.ExpenseDate = e.Date;
                        vData.Customer = e.Customer;
                        vData.Name = e.Name;
                        vData.Project = e.Project;
                        vData.Amount = e.Amount;
                        vList.Add(vData);
                    }
                    break;
                case "Project":
                    vList.Clear();
                    foreach (var e in (from x in query select x).OrderBy(x => x.Project))
                    {
                        vData = new ViewData();
                        vData.Id = e.Id;
                        vData.ProjectId = e.ProjectId;
                        vData.ExpenseDate = e.Date;
                        vData.Customer = e.Customer;
                        vData.Name = e.Name;
                        vData.Project = e.Project;
                        vData.Amount = e.Amount;
                        vList.Add(vData);
                    }
                    break;
                case "project_desc":
                    vList.Clear();
                    foreach (var e in (from x in query select x).OrderByDescending(x => x.Project))
                    {
                        vData = new ViewData();
                        vData.Id = e.Id;
                        vData.ProjectId = e.ProjectId;
                        vData.ExpenseDate = e.Date;
                        vData.Customer = e.Customer;
                        vData.Name = e.Name;
                        vData.Project = e.Project;
                        vData.Amount = e.Amount;
                        vList.Add(vData);
                    }
                    break;
                case "Amount":
                    vList.Clear();
                    foreach (var e in (from x in query select x).OrderBy(x => x.Amount))
                    {
                        vData = new ViewData();
                        vData.Id = e.Id;
                        vData.ProjectId = e.ProjectId;
                        vData.ExpenseDate = e.Date;
                        vData.Customer = e.Customer;
                        vData.Name = e.Name;
                        vData.Project = e.Project;
                        vData.Amount = e.Amount;
                        vList.Add(vData);
                    }
                    break;
                case "amount_desc":
                    vList.Clear();
                    foreach (var e in (from x in query select x).OrderByDescending(x => x.Amount))
                    {
                        vData = new ViewData();
                        vData.Id = e.Id;
                        vData.ProjectId = e.ProjectId;
                        vData.ExpenseDate = e.Date;
                        vData.Customer = e.Customer;
                        vData.Name = e.Name;
                        vData.Project = e.Project;
                        vData.Amount = e.Amount;
                        vList.Add(vData);
                    }
                    break;
                default:
                    vList.Clear();
                    foreach (var e in (from x in query select x).OrderBy(x => x.Customer))
                    {
                        vData = new ViewData();
                        vData.Id = e.Id;
                        vData.ProjectId = e.ProjectId;
                        vData.ExpenseDate = e.Date;
                        vData.Customer = e.Customer;
                        vData.Name = e.Name;
                        vData.Project = e.Project;
                        vData.Amount = e.Amount;
                        vList.Add(vData);
                    }
                    break;
            }
           
            return View(vList);
        }
        


        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }

        // GET: Expenses/Create
        public IActionResult AddEdit(int id=0)
        {
            if (id == 0)
            {
                ViewBag.Mode = "Add";
                TempData["ButtonValue"] = "Save and Add";
                return View(new Expenses());
            }
            else {
                ViewBag.Mode = "Edit";
                TempData["ButtonValue"] = "Apply";
                return View(_context.Expenses.Find(id)); 
            }        
        }

        [HttpGet]
        public JsonResult GetCustomers(int Id)
        {
            List<Customers> cL;
            if (Id == 0) 
            {
                cL = new List<Customers>();
                cL = (from c in _context.Customers select c).ToList();
                cL.Insert(0, new Customers { Id = 0, Name = "Select a Customer" });
            }
            else cL = PopulateCustomerData(Id);

            return Json(cL);
        }
        public List<Customers> PopulateCustomerData(int ID)
        {
            List<Customers> cL = new List<Customers>();
            Customers cust;
            cL = (from c in _context.Customers select c).Where(s => s.Id.Equals(ID)).ToList();
            foreach(var e in (from c in _context.Customers select c).Where(s => s.Id != ID))
            {
                cust = new Customers();
                cust.Id = e.Id;
                cust.Name = e.Name;
                cL.Add(cust);
            }
            return cL;
        }

        [HttpPost]
        public JsonResult GetProjects(int Id)
        {
            List<Projects> cP;
            if (Id == 0)
            {
                cP = new List<Projects>();
                cP = (from c in _context.Projects select c).ToList();
                cP.Insert(0, new Projects { Id = 0, Name = "Select a Project" });
            }
            else
            {
                cP = PopulateProjectData(Id);
            }
            return Json(cP);
        }
        public List<Projects> PopulateProjectData(int CustID)
        {
            List<Projects> cP = new List<Projects>();
            cP = (from c in _context.Projects select c).Where(s => s.CustomerId.Equals(CustID)).ToList();
            return cP;
        }

        // POST: Expenses/AddEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit([Bind("Id,ProjectId,Name,ExpenseDate,Amount,Description")] Expenses expenses, string button)
        {

            if (ModelState.IsValid)
            {
                if (expenses.Id == 0) _context.Add(expenses);
                else _context.Update(expenses);
                await _context.SaveChangesAsync();

                if (!button.Equals("One")) return RedirectToAction(nameof(AddEdit));
                else return RedirectToAction(nameof(Index));
            }
            return View(expenses);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var eID = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(eID);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenses = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expenses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpensesExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
