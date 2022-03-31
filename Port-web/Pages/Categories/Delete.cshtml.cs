using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Port_web.Data;
using Port_web.Model;

namespace Port_web.Pages.Categories
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public   void OnGet(int id)
        {
            Category =  _db.Category.Find(id);

            //   Category = _db.Category.First(u=>u.Id==id); //Errors if it doesn't find anything.
            //   Category = _db.Category.FirstOrDefault(u => u.Id == id); //Returns null if not found.
            //   Category = _db.Category.SingleOrDefault(u => u.Id == id);//Returns null if not found.
            //   Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();//Returns multiple if it finds more than one.  We call FirstOrDefault at the end to get only one.

        }
        public async Task<IActionResult> OnPost()
        {
            
            var categoryFromDB = _db.Category.Find(Category.Id);
            if (categoryFromDB != null)
            { 
                _db.Category.Remove(categoryFromDB);
                await _db.SaveChangesAsync();
            }
                return RedirectToPage("/Categories/Index");


        }
    }
}

