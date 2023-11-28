using CategoriesAndProductsApp.Models;
using CategoriesAndProductsApp.Repository;
using CategoriesAndProductsApp.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CategoriesAndProductsApp.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;
        public CategoryController(ICategoryRepository category)
        {
            _category = category;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> categoryListObj = _category.GetAll();

            return View(categoryListObj);
        }

       //Get data
        public IActionResult Create()
        {


            return View();
        }
        //Post data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            bool result = false;
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display order can't be same.");
                return View(obj);
            }
            if (ModelState.IsValid) // server side validate
            {
                result = _category.Add(obj);
            }
            if (result)
            {
                TempData["success"] = "Successfully created.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Failed to create Category";
            return View(obj);
        }


        //Get Edit
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryObjEdit = _category.Get(id);
            

            if (categoryObjEdit == null)
            {
                return NotFound();
            }
            return View(categoryObjEdit);
        }

        //Post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            bool result = false;
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display order can't be same.");
                return View(obj);
            }
            if (ModelState.IsValid) // server side validate
            {
                result = _category.Update(obj);                  
            }
            if (result)
            {
                TempData["success"] = "Successfully updated.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Failed to update Category";
            return View(obj);
        }


        //Get Delete
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryObj = _category.Get(id);


            if (categoryObj == null)
            {
                return NotFound();
            }
            return View(categoryObj);
        }

        //Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id) // we can post complete obj or ID 
        {
            bool result = false;
            
            if (ModelState.IsValid) // server side validate
            {
                result = _category.Delete(id);
            }
            if (result)
            {
                TempData["success"] = "Successfully created.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Failed to deleted Category";
            return View();
        }

    }
}
