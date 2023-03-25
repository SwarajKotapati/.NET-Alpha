using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using NewBookWeb.Data;
using NewBookWeb.Models;

namespace NewBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext local_db;
        private readonly INotyfService local_toast;

        public CategoryController(ApplicationDbContext db, INotyfService notyf)
        {
            local_db = db;
            local_toast = notyf;
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
                    local_toast.Warning("Oops...!");
                    return View(Obj);
                }
                else
                {
                    local_db.Categories.Add(Obj);
                    local_db.SaveChanges();
                    local_toast.Success("Category created");
                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                local_toast.Warning("Oops...!");
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
                    local_toast.Warning("Oops...!");
                    return View(Obj);
                }
                else
                {
                    local_db.Categories.Update(Obj);
                    local_db.SaveChanges();
                    local_toast.Information("Category Updated");
                    return RedirectToAction("Index");
                }

            }
            else
            {
                local_toast.Warning("Oops...!");
                return View(Obj);
            }

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }

            var CategoryFromDb = local_db.Categories.Find(id);
            //var CategoryFromDbFirst = local_db.Categories.FirstOrDefault(u=>u.Id == id);
            //var CategoryFromDbSingle = local_db.Categories.SingleOrDefault(u=>u.Id== id);

            if (CategoryFromDb == null)
            {
                return NotFound();
            }


            return View(CategoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category Obj)
        {
            if (Obj == null)
            {
                return NotFound();
            }
            
               
            else
            { 
                local_db.Categories.Remove(Obj);
                local_db.SaveChanges();
                local_toast.Error("Category Deleted");
                return RedirectToAction("Index");
            }

        }
    }
}
