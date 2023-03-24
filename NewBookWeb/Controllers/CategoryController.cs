using Microsoft.AspNetCore.Mvc;
using NewBookWeb.Data;
using NewBookWeb.Models;

namespace NewBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext local_db;
        public CategoryController(ApplicationDbContext db)
        {
            local_db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = local_db.Categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category Obj) 
        {
            if (ModelState.IsValid)
            {
                if(Obj.Name == Obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("CustomError", "Name and Display cannot be the same");
                    //ModelState.AddModelError("NamE", "Name and Display cannot be the same");
                    return View(Obj);
                }
                else
                {
                    local_db.Categories.Add(Obj);
                    local_db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                return View(Obj);
            }
            
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id < 0)
            {
                return NotFound();
            }

            var CategoryFromDb = local_db.Categories.Find(id);
            //var CategoryFromDbFirst = local_db.Categories.FirstOrDefault(u=>u.Id == id);
            //var CategoryFromDbSingle = local_db.Categories.SingleOrDefault(u=>u.Id== id);

            if(CategoryFromDb == null)
            {
                return NotFound();
            }


            return View(CategoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category Obj)
        {
            if (ModelState.IsValid)
            {
                if (Obj.Name == Obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("CustomError", "Name and Display cannot be the same");
                    //ModelState.AddModelError("NamE", "Name and Display cannot be the same");
                    return View(Obj);
                }
                else
                {
                    local_db.Categories.Update(Obj);
                    local_db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return View(Obj);
            }

        }
    }
}
