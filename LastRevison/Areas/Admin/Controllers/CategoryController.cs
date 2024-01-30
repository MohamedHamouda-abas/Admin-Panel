using LastRevision.DataAccess.Data;
using LastRevision.DataAccess.Repository.IRepository;
using LastRevision.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LastRevison.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> category = _unitOfWork.Category.GetAll().ToList();
            return View(category);
        }
        #region Each One depend itself
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Category model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Categories.Add(model);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //public IActionResult Update(int? id)
        //{
        //    if (id == 0 || id == null)
        //    {
        //        NotFound();
        //    }
        //    var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        //    return View(category);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(Category model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Categories.Update(model);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //} 
        #endregion
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if (ModelState.IsValid)
            {
                if (id == 0 || id == null)
                {
                    //Create
                    return View(new Category());
                }
                else
                {
                    //Update
                    var category = _unitOfWork.Category.Get(c => c.Id == id);
                    return View(category);
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Upsert(Category model)
        {

            if (model.Name == model.DisPlayOrder.ToString())
            {
                ModelState.AddModelError("name", "the name is exact match the displayOrder please change it");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                if (model.Id == 0 || model.Id == null)
                {

                    //Create
                    _unitOfWork.Category.Add(model);
                    _unitOfWork.Save();
                    TempData["success"] = "Category Created successfully";

                }
                else
                {
                    //Update
                    _unitOfWork.Category.Update(model);
                    _unitOfWork.Save();
                    TempData["success"] = "Category Updated successfully";
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? Id)
        {
            Category? obj = _unitOfWork.Category.Get(c => c.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
