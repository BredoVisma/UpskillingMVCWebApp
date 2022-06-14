using UpskillingMVCWebApp.Data.Data;
using UpskillingMVCWebApp.Data.Interfaces;
using UpskillingMVCWebApp.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/{0}.cshtml");
    });

builder.Services.AddDbContext<ScrumDbContext>();

builder.Services.AddSingleton<IIssueData, IssueDataDb>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

CreateDbIfNotExists(builder);

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


static void CreateDbIfNotExists(WebApplicationBuilder builder)
{
    using (ServiceProvider? services = builder.Services.BuildServiceProvider())
    {
        try
        {
            //var issueContext = services.GetRequiredService<IssueContext>();
            //DbInitializer.Initialize(issueContext);

            var dbContext = services.GetRequiredService<ScrumDbContext>();
            DbInitializer.Initialize(dbContext);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}