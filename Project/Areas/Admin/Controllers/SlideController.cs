using Microsoft.AspNetCore.Mvc;
using Project.Models;
using ProjectBook.DataAccess.Repository.IRepository;

namespace ProjectBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SlideController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SlideController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region APICALL
        [HttpGet]
        public IActionResult GetAll()
        {

            List<SildeHome> objSlide = _unitOfWork.Slide.GetAll().ToList();
            return Json(new { data = objSlide });

        }
        #endregion
    }
}
