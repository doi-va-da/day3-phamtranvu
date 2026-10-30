using day3_phamtranvu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Xml.Linq;
namespace day3_phamtranvu.Controllers
{
    public class CategoryController : Controller
    {
        //gia lap csdl
        private static List<Category> categories = new List<Category>()
        {
            new Category(){Id = 1, Name = "Category 1"},
            new Category(){Id = 2, Name = "Category 2" },
            new Category(){Id = 3, Name = "Category 3" },
        };
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                int newId = categories.Any() ? categories.Max(c => c.Id) + 1 : 1; 
                categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category) ;
        }

        // GET: CategoryController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //tim category theo id 
            var existingCategory = categories.FirstOrDefault(c => c.Id == id);
            //neu k tim thay category tra ve notfound
            if( existingCategory == null )
            {
                return NotFound();
            }
            return View(existingCategory);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == id);
            if(existingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
