using Microsoft.AspNetCore.Mvc;
using trialMvcProject.Data;
using trialMvcProject.Models;
namespace trialMvcProject.Controllers
{

    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Index()
        {

            return View(_context.Registrations.ToList());
        }
        [HttpPost]
        public IActionResult Signup(Registration obj)
        {

            _context.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            
            var x = _context.Registrations.Find(id);
            _context.Registrations.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("index");                                                                                            
        }
        
        
        public IActionResult Edit(int id)
        {
            var x = _context.Registrations.Find(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult Edit(Registration obj)
        {

            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}