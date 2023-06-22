using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectRazor_Temp.Data;
using ProjectRazor_Temp.Models;

namespace ProjectRazor_Temp.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Models.Category> CategoryList { get; set; }
        public IndexModel (ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
