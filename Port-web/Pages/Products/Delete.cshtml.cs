using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Port_web.Data;
using Port_web.Model;

namespace Port_web.Pages.Products
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Product Product { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public  void OnGet(int id)
        {
            Product = _db.Product.Find(id);

        }
        public async Task<IActionResult> OnPost()
        {

            var productFromDB = _db.Product.Find(Product.Id);
            if (productFromDB != null)
            {
                _db.Product.Remove(productFromDB);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("/Products/Index");


        }
    }
}
