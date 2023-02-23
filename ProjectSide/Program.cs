using Microsoft.EntityFrameworkCore;
using ProjectSide.Infrastructure.Database.BoundedContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Context AddDbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProjectSideContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

//Context AddDbContext
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<ProjectSideContext>();
await dbContext.Database.EnsureCreatedAsync();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
	name: "default",
	pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
