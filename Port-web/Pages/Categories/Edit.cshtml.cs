using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Port_web.Data;
using Port_web.Model;

namespace Port_web.Pages.Categories
{
   
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost() 
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display Order cannot match the Name.");
            }
            if (Category.Name.Length <= 3)
            {
                ModelState.AddModelError("Category.Name", "The Name has to be longer than 3 characters");
            }
            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Categories/Index");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
