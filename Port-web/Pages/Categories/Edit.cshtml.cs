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
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
         //   Category = _db.Category.First(u=>u.Id==id); //Errors if it doesn't find anything.
         //   Category = _db.Category.FirstOrDefault(u => u.Id == id); //Returns null if not found.
         //   Category = _db.Category.SingleOrDefault(u => u.Id == id);//Returns null if not found.
         //   Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();//Returns multiple if it finds more than one.  We call FirstOrDefault at the end to get only one.

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
                _db.Category.Update(Category);
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
