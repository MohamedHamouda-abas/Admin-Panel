using LastRevisonRazor_Temp.Data;
using LastRevisonRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastRevisonRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Category? Category { get; set; }
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Category = _context.categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Category? model = _context.categories.Find(Category.Id);
            if (model == null)
            {
                return NotFound();
            }
            _context.categories.Remove(model);
            _context.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToPage("Index");
        }

    }
}
