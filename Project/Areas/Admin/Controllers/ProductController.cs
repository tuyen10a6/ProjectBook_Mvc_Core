using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Data;
using Project.DataAccess.Repository.IRepository;
using Project.Models;
using ProjectBook.DataAccess.Repository.IRepository;


namespace ProjectBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //Product? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        // Action Update Product
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Product.Save();
                TempData["success"] = "Product update successfully";
                var ok = "Index";
                return RedirectToAction(ok);
            }
            return View();
        }
        // Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? categoryFromDb = _unitOfWork.Product.Get(c => c.Id == id);
            //Product? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // Action Update Product
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Delete(obj);
                _unitOfWork.Product.Save();
                TempData["success"] = "Xóa danh mục thành công";
                var ok = "Index";
                return RedirectToAction(ok);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
           
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Product.Save();
                TempData["success"] = "Thêm sản phẩm thành công";
                return RedirectToAction("Index");

            }

            return View();
        }
    }
}
