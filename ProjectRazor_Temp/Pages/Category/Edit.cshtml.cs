using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectRazor_Temp.Data;

namespace ProjectRazor_Temp.Pages.Category
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Models.Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id !=null && id !=0)
            {
                Category = _db.Categories.Find(id);


                 }
        }
        public IActionResult OnPost()
        {
           if(ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category Update Successfully";

                return RedirectToPage("Index");
            }
            return Page();

        }
        public IActionResult OnPust()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category Update Successfully";

                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
