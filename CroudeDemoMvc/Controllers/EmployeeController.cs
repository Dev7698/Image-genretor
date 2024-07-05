using CroudeDemoMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CroudeDemoMvc.Controllers
{
    public class EmployeeController : Controller
    {


        private readonly EmpDataContext _db;
        public EmployeeController(EmpDataContext db)
        {
            _db = db;

        }
        public ActionResult Index()
        {
            return View(_db.Employee.ToList());
        }
        public ActionResult Manage(int id = 0)
        {
            var emp = _db.Employee.Find(id);

            return View(emp);
        }
        public ActionResult Save(Employee employee)
        {
            if (employee.Id > 0)
            {
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                _db.Employee.Add(employee);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Employee employee = _db.Employee.Where(s => s.Id == id).FirstOrDefault();
            _db.Employee.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }

}

