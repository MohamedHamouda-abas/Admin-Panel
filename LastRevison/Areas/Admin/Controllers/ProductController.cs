using LastRevision.DataAccess.Repository.IRepository;
using LastRevision.Models;
using LastRevision.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LastRevison.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();
            IEnumerable<SelectListItem> categories = _unitOfWork.Category.GetAll().ToList().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString(),

            });
            return View(products);
        }
        //To pass the Data To View
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if (ModelState.IsValid)
            {
                ProductViewModel productVM = new()
                {
                    Categorylist = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString(),
                    }),
                    Product = new Product(),
                };
                if (id == null || id == 0)
                {
                    //Create
                    return View(productVM);
                }
                else
                {
                    //Update               
                    productVM.Product = _unitOfWork.Product.Get(p => p.Id == id);
                    return View(productVM);
                }
            }
            return View();
        }

        //To post Data To DataBase
        [HttpPost]
        public IActionResult Upsert(ProductViewModel model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (file != null)
                    {
                        //To give name to the photos
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        //To give path to the photos
                        string filePath= Path.Combine(wwwRootPath,@"Images\Product");

                        //Check if images is empty or null
                        if (!string.IsNullOrEmpty(model.Product.ImageUrl))
                        {
                            //delete the old image
                            var oldImagePath = Path.Combine(wwwRootPath, model.Product.ImageUrl.Trim('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        //To save the photos
                        using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        model.Product.ImageUrl = @"\Images\Product\" + fileName;
                    }

                if (model.Product.Id == null || model.Product.Id == 0)
                {
                    //Craete
                    _unitOfWork.Product.Add(model.Product);
                    TempData["success"] = "The product Created successfully";
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    //Update
                    _unitOfWork.Product.Update(model.Product);
                    TempData["success"] = "The product Updated successfully";
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public IActionResult Delete(int? id)
        {
            Product? product = _unitOfWork.Product.Get(p => p.Id == id);
            if (ModelState.IsValid)
            {
                if (product.Id != null || product.Id != 0)
                {
                    _unitOfWork.Product.Remove(product);
                    TempData["success"] = "The product Deleted successfully";
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }
    }
}
