using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Port_web.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

string strConnString = builder.Configuration["ConnString"];
// Add services to the container.
//Authentication: Cookie options.



builder.Services.AddRazorPages();
/*----------------------------------JCMARIN--------------------------------------------------
//The application requires the connection string to be a variable inside "user secrets" so that the 
//connection string isn't exposed. To use the secrets uncomment line below.  If using environment variables
//then get it from the builder.Configuration settings above instead.
------------------------------------JCMARIN--------------------------------------------------*/

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
         //builder.Configuration.GetConnectionString("ConnString")
         strConnString
        )); ;
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();builder.Services.AddDbContext<ApplicationDbContext>(options =>
   // options.UseSqlServer(connectionString));
   options.UseSqlServer(strConnString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
