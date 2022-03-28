using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Port_web.Data;
using Port_web.Model;

namespace Port_web.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Product> Product { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            //Set the passed dbContext to our private context variable.
            _db = db;
        }
        public void OnGet()
        {
            //Retrieve the Categories from the database.
            Product = _db.Product;
        }
    }
}
