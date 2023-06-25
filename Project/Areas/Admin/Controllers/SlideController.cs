using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Project.Models.ViewModels;
using ProjectBook.DataAccess.Repository.IRepository;


namespace ProjectBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SlideController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SlideController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

       
        #region APICALL
        [HttpGet]
        public IActionResult GetAll()
        {

            List<SildeHome> objSlide = _unitOfWork.Slide.GetAll().ToList();
            return Json(new { data = objSlide });

        }
        public IActionResult Index()
        {
            List<SildeHome> slideHome = _unitOfWork.Slide.GetAll().ToList();
            return View(slideHome);
        }
        public IActionResult Create(int? id)
        {
            SildeVM slideVM = new()
            {
               
                sildeHome = new SildeHome()

            };
            if (id == null || id == 0)
            {
                // create
                return View(slideVM);
            }
            else
            {
                // update
                slideVM.sildeHome = _unitOfWork.Slide.Get(u => u.Id == id);
                return View(slideVM);
            }


        }
        [HttpPost]
        public IActionResult Create(SildeVM slideVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwrootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwrootPath, @"images\slides");
                    if (!string.IsNullOrEmpty(slideVM.sildeHome.LinkImage))
                    {
                        var oldImagePath = Path.Combine(wwwrootPath, slideVM.sildeHome.LinkImage.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    slideVM.sildeHome.LinkImage = @"\images\slides\" + fileName;
                }
                // Check ID 
                if (slideVM.sildeHome.Id == 0)
                {
                    // Kiểm tra số lượng Slide nếu vượt quá số lượng cho phép thì vào điều kiện else
                   var ok =  _unitOfWork.Slide.GetAll().Count();
                    if(ok <4)
                    {
                        _unitOfWork.Slide.Add(slideVM.sildeHome);
                        TempData["success"] = "Thêm hình ảnh Slide thành công";
                    }else
                    {
                        TempData["error"] = "Số lượng Slide tối đa chỉ là 4";
                    }
                  

                }
                else
                {
                    _unitOfWork.Slide.Update(slideVM.sildeHome);
                    TempData["success"] = "Sửa hình ảnh Slide thành công";
                }
                _unitOfWork.Product.Save();

                return RedirectToAction("Index");

            }
            else
            {
                return View(slideVM);
            }

        }
       
        #endregion
        // Delele Slide
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var slideToBeDeleted = _unitOfWork.Slide.Get(u => u.Id == id);
            if (slideToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath =
                           Path.Combine(_webHostEnvironment.WebRootPath,
                           slideToBeDeleted.LinkImage.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Slide.Delete(slideToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Xóa slide thành công" });
        }


    }
}
