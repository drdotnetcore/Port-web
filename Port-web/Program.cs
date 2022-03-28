using Microsoft.EntityFrameworkCore;
using Port_web.Data;

var builder = WebApplication.CreateBuilder(args);
string strConnString = builder.Configuration["ConnString"];
// Add services to the container.
    builder.Services.AddRazorPages();
//The application requires the connection string to be a variable inside "user secrets" so that the 
//connection string isn't exposed.

    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        //builder.Configuration.GetConnectionString("ConnString")
        strConnString
        ));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
