using CroudeDemoMvc.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CroudeDemoMvc.Controllers
{
    public class ImageController : Controller
    {
        private readonly EmpDataContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ImageController(EmpDataContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }
       
        public IActionResult Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                TempData["BodyContent"] = "Please enter a name to search.";
                return View();
            }

            var photos = (from u in _db.Image
                          where u.Name == name
                          select u).FirstOrDefault();

            if (photos == null)
            {
                TempData["BodyContent"] = "No image found for the given name.";

                return View();
            }
            string html = System.IO.File.ReadAllText(Path.Combine(_hostingEnvironment.WebRootPath, "Templates", "Template.html"));
            string fullPath;

            if (photos != null && !string.IsNullOrEmpty(photos.Photo) && System.IO.File.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "Images", photos.Photo)))
            {
                fullPath = "/images/" + photos.Photo;
            }
            else
            {
                fullPath = "/Images/default.jpg" + photos.Photo; // Path to the default image
            }
        
            html = html.Replace("{image}", fullPath);

            TempData["BodyContent"] = html;
           
            return View();
        }
    }
}
