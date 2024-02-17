using FoodyTekmerDataAccessLayer.Context;
using FoodyTekmerEntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
    public class CategoryController : Controller
    {
        FoodyContext context = new FoodyContext();
        public IActionResult Index()
        {
            var values = context.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category p)
        {
            context.Categories.Add(p);
            context.SaveChanges();//Kayıt işlemini tamamladık.
            return RedirectToAction("Index"); //Anasayfaya yönlendirme işlemi yapar.
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();//Kayıt işlemini tamamladık.
            return RedirectToAction("Index"); //Anasayfaya yönlendirme işlemi yapar.
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {            
            context.Categories.Update(category);
            context.SaveChanges();//Kayıt işlemini tamamladık.
            return RedirectToAction("Index"); //Anasayfaya yönlendirme işlemi yapar.
        }

    }
}
