
using Microsoft.EntityFrameworkCore;
using Port_web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

string strConnString = builder.Configuration["ConnString"];


builder.Services.AddRazorPages();
/*----------------------------------JCMARIN--------------------------------------------------
//The application requires the connection string to be a variable inside "user secrets" so that the 
//connection string isn't exposed. To use the secrets uncomment line below.  If using environment variables
//then get it from the builder.Configuration settings above instead.
------------------------------------JCMARIN--------------------------------------------------*/

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(strConnString)); 


//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
//New add------------------------------------------


builder.Services.AddControllers(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});


//New add------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute
    (
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"
    );
   
app.Run();
