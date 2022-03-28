using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Port_web.Data;
using Port_web.Model;

namespace Port_web.Pages.Products
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public Product Product { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (Product.Name == Product.Id.ToString())
            {
                ModelState.AddModelError("Product.Name", "The Id cannot match the Name.");
            }
            if (Product.Name.Length <= 3)
            {
                ModelState.AddModelError("Product.Name", "The Name has to be longer than 3 characters");
            }
            if (ModelState.IsValid)
            {
                await _db.Product.AddAsync(Product);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Products/Index");
            }
            else
            {
                return Page();
            }

        }
    }
}
