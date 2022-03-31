
using Microsoft.EntityFrameworkCore;
using Port_web.Data;
using Microsoft.AspNetCore.Identity;
using Port_web.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

string strConnString = builder.Configuration["ConnString"];


builder.Services.AddRazorPages();
/*----------------------------------JCMARIN--------------------------------------------------
//The application requires the connection string to be a variable inside "user secrets" so that the 
//connection string isn't exposed. To use the secrets uncomment line below.  If using environment variables
//then get it from the builder.Configuration settings above instead.
------------------------------------JCMARIN--------------------------------------------------*/

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(strConnString)); 


builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
//New add------------------------------------------
builder.Services.AddSingleton<IEmailSender, EmailSender>();



//New add------------------------------------------------

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
app.MapControllers();
   
app.Run();
