using IBlogs.Data;
using IBlogs.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IBlogs.Repository;
using IBlogs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IBlogDbContext>(options =>            //od 9-10 linije koda je vezana za injection dbconnectionstringa iz appsettings.json
options.UseSqlServer(builder.Configuration.GetConnectionString("IBlogDbConnectionString")));

builder.Services.AddDefaultIdentity<Profile>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IBlogDbContext>();

builder.Services.AddScoped<ILikesRepository, LikesRepository>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<ICreatorsRepository, CreatorsRepository>();


builder.Services.AddSignalR();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapRazorPages();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chat");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
