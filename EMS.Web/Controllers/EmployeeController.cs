using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.DLL;
using EMS.Entity;
using EMS.BLL.Abstract;
using Microsoft.AspNetCore.SignalR;
using EMS.Web.SignalRHubs;
using Microsoft.AspNetCore.Authorization;

namespace EMS.Web.Controllers
{
    /// <summary>
    /// https://www.youtube.com/watch?v=YzOBrVlthMk&list=PLUOequmGnXxOFPJv8H7DNIappcta9brtN
    /// 
    /// https://www.youtube.com/watch?v=egITMrwMOPU&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=65
    /// 
    /// https://gunnarpeipman.com/ef-core-repository-unit-of-work/
    /// 
    /// https://garywoodfine.com/generic-repository-pattern-net-core/
    /// 
    /// https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/cud-stored-procedures
    /// 
    /// https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx
    /// 
    /// https://medium.com/aspnetrun/cqrs-and-event-sourcing-in-event-driven-architecture-of-ordering-microservices-fb67dc44da7a
    /// 
    /// https://itnext.io/why-and-how-i-implemented-cqrs-and-mediator-patterns-in-a-microservice-b07034592b6d
    /// 
    /// https://referbruv.com/blog/posts/implementing-cqrs-using-mediator-in-aspnet-core-explained
    /// 
    /// https://www.youtube.com/watch?v=YzOBrVlthMk
    /// 
    /// https://www.youtube.com/watch?v=2JzQuIvxIqk&t=13s
    /// 
    /// https://www.youtube.com/watch?v=YzOBrVlthMk&list=PLUOequmGnXxOFPJv8H7DNIappcta9brtN
    /// </summary>

    public class EmployeeController : Controller
    {
        private readonly IHubContext<EmployeeHub> employeeHubContext;
        private readonly IEmployeeService employeeService;

        public EmployeeController(IHubContext<EmployeeHub> employeeHubContext, IEmployeeService employeeService)
        {
            this.employeeHubContext = employeeHubContext;
            this.employeeService = employeeService;
        }

        // GET: Employees
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult EmployeeList()
        {
            var employees = employeeService.GetAll();
            return Json(employees);
        }

        // GET: Employees/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeService.GetById(id.Value);
            if (employee == null)
            {
                return View("NotFound", id);
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {


            if (ModelState.IsValid)
            {
                await employeeHubContext.Clients.All.SendAsync("sendToUser", employee);

                employeeService.Add(employee);
                return RedirectToAction(nameof(Index));


            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeService.GetById(id.Value);
            if (employee == null)
            {
                return View("NotFound", id);
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employeeService.Update(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!EmployeeExists(employee.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeService.GetById(id.Value);
            if (employee == null)
            {
                return View("NotFound", id);
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = employeeService.GetById(id);

            if (employee != null)
            {
                employeeService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Employees.Any(e => e.Id == id);
        //}
    }


}
