using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            try
            {
                CategoriesLogic categoryLogic = new CategoriesLogic();
                List<CategoryViewModel> result = categoryLogic.GetAll().Select(c => new CategoryViewModel
                {
                    id = c.CategoryID,
                    categoryName = c.CategoryName,
                    categoryDescription = c.Description
                }).ToList();

                return View(result);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Category", "Index"));
            }
        }

        public ActionResult Create()
        {
            try
            {
                ViewBag.Title = "Crear categoría";

                CategoryViewModel model = new CategoryViewModel();

                return View("Update", model);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Category", "Create"));
            }
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            CategoriesLogic categoryLogic = new CategoriesLogic();

            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Update", model);
                }

                var categoryName = model.categoryName;

                if (categoryLogic.ItemExist(categoryName) != null)
                {
                    ModelState.AddModelError("categoryName", $"La categoría {categoryName} ya existe en el sistema.");

                    return View("Update", model);
                }

                Categories category = new Categories
                {
                    CategoryName = model.categoryName,
                    Description = model.categoryDescription
                };

                categoryLogic.Add(category);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Category", "Create"));
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                CategoriesLogic categoryLogic = new CategoriesLogic();

                categoryLogic.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Category", "Delete"));
            }
        }

        public ActionResult Update(int id)
        {
            try
            {
                ViewBag.Title = "Actualizar categoría";

                CategoriesLogic categoryLogic = new CategoriesLogic();
                CategoryViewModel model = new CategoryViewModel();

                var entity = categoryLogic.GetOne(id);

                model.id = entity.CategoryID;
                model.categoryName = entity.CategoryName;
                model.categoryDescription = entity.Description;

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Category", "Update"));
            }
        }

        [HttpPost]
        public ActionResult Update(CategoryViewModel model)
        {
            CategoriesLogic categoryLogic = new CategoriesLogic();

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var categoryName = model.categoryName;

                if (categoryLogic.ItemExist(categoryName) != null)
                {
                    ModelState.AddModelError("categoryName", $"La categoría {categoryName} ya existe en el sistema.");

                    return View("Update", model);
                }

                Categories category = new Categories
                {
                    CategoryID = model.id,
                    CategoryName = model.categoryName,
                    Description = model.categoryDescription
                };

                categoryLogic.Update(category);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Category", "Update"));
            }
        }
    }
}