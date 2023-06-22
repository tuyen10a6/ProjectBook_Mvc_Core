using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectRazor_Temp.Data;
using ProjectRazor_Temp.Models;

namespace ProjectRazor_Temp.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public  Models.Category Category { get; set; }
        public CreateModel (ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        { 
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category Create Successfully";
            return RedirectToPage("Index");

            }
    }
}
