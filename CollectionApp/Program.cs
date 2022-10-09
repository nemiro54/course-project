using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CollectionApp.Data;
using CollectionApp.LocalizationResources;
using CollectionApp.Models;
using Microsoft.AspNetCore.Localization;
using XLocalizer;
using XLocalizer.Routing;
using XLocalizer.Translate;
using XLocalizer.Translate.MyMemoryTranslate;
using XLocalizer.Xml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<ApplicationDbContext>(ops =>
    ops.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(ops =>
    {
        ops.SignIn.RequireConfirmedEmail = false;
        ops.Password.RequireDigit = false;
        ops.Password.RequireLowercase = false;
        ops.Password.RequireUppercase = false;
        ops.Password.RequireNonAlphanumeric = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Configure request localization
builder.Services.Configure<RequestLocalizationOptions>(ops =>
{
    var cultures = new CultureInfo[]
    {
        new("en"),
        new("pl"),
        new("be")
    };

    ops.SupportedCultures = cultures;
    ops.SupportedUICultures = cultures;
    ops.DefaultRequestCulture = new RequestCulture("en");
    ops.RequestCultureProviders.Insert(0, new RouteSegmentRequestCultureProvider(cultures));
});

// Register XmlResourceProvider
builder.Services.AddSingleton<IXResourceProvider, XmlResourceProvider>();
// Register translation service
builder.Services.AddHttpClient<ITranslator, MyMemoryTranslateService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(ops =>
    {
        ops.Conventions.Insert(0, new RouteTemplateModelConventionRazorPages());
    })
    .AddXLocalizer<LocSource, MyMemoryTranslateService>(ops =>
    {
        ops.ResourcesPath = "LocalizationResources";
        ops.AutoAddKeys = true;
        ops.AutoTranslate = true;
        ops.TranslateFromCulture = "en";
        ops.UseExpressMemoryCache = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default-area",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute(
        name: "culture-route-area",
        pattern: "{culture=en}/{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(name: "culture-route", pattern: "{culture=en}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();