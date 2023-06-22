using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectRazor_Temp.Data;

namespace ProjectRazor_Temp.Pages.Category
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Models.Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);


            }
        }
        public IActionResult OnPost()
        {
            Models.Category? obj = _db.Categories.Find(Category.Id);
           if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Delete Successfully";

            return RedirectToPage("Index");

        }
    }
}
