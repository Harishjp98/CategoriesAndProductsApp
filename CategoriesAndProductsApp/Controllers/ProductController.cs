using CategoriesAndProductsApp.Models;
using CategoriesAndProductsApp.Repository;
using CategoriesAndProductsApp.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CategoriesAndProductsApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _category;
        private readonly IProductRepository _product;
        public ProductController(ICategoryRepository category, IProductRepository product)
        {
            _category = category;
            _product = product;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Products> ProductListObj = _product.GetAll();

            return View(ProductListObj);
        }

        //Get data
        public IActionResult Create()
        {
            IEnumerable<Category> CategoryList = _category.GetAll();
            ViewBag.CategoryList = new SelectList(CategoryList, "ID", "Name");

            return View();
        }
        //Post data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products obj)
        {
            bool result = false;
            if (obj.Title == obj.Description)
            {
                ModelState.AddModelError("Name", "Description  can't be same as Title.");
                return View(obj);
            }

            result = _product.Add(obj);

            if (result)
            {
                TempData["success"] = "Successfully created.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Failed to create Product";
            var CategoryList = _category.GetAll();
            ViewBag.CategoryList = new SelectList(CategoryList, "ID", "Name");
            return View(obj);
        }

        //Get Edit
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productObjEdit = _product.Get(id);


            if (productObjEdit == null)
            {
                return NotFound();
            }
            IEnumerable<Category> CategoryList = _category.GetAll();
            ViewBag.CategoryList = new SelectList(CategoryList, "ID", "Name");
            return View(productObjEdit);
        }

        //Post  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products obj)
        {
            bool result = false;
            if (obj.Title == obj.Description)
            {
                ModelState.AddModelError("Name", "Description  can't be same as Title.");
                return View(obj);
            }


            result = _product.Update(obj);
            if (result)
            {
                TempData["success"] = "Successfully updated.";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Failed to update Category";
            return View(obj);

        }

        //Get Edit
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productObj = _product.Get(id);         

            if (productObj == null)
            {
                return NotFound();
            }
            return View(productObj);
        }

        //Post
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id) // we can post complete obj or ID 
        {
            bool result = false;

            if (id == null)
            {
                return NotFound();
            }

            result =_product.Delete(id);
            if (result)
            {
                TempData["success"] = "Successfully deleted.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Failed to Delete Product";
            return View();
        }
    }

 }

