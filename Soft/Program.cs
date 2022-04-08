using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Soft.Data;
using TeamUP.Domain.Party;
using TeamUP.Infra;
using TeamUP.Infra.Initializers;
using TeamUP.Infra.Party;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<TeamUPDb>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddTransient <IStudentsRepo , StudentsRepo>();
builder.Services.AddTransient <ITeamWorksRepo, TeamWorksRepo>();
builder.Services.AddTransient<IUniversitiesRepo, UniversitiesRepo>();
builder.Services.AddTransient<ILocationsRepo, LocationsRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<TeamUPDb>();
    db?.Database?.EnsureCreated();
    TeamUpDbInitializer.Init(db);
}

    app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
