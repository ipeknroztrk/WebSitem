using Microsoft.EntityFrameworkCore;
using MyPortfolioUdemy.DAL.Context;  // DOĞRU
using Npgsql;


var builder = WebApplication.CreateBuilder(args);

// DATABASE_URL varsa onu kullan, yoksa local bağlantıyı kullan
builder.Services.AddDbContext<MyPortfolioContext>(options =>
{
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

    if (!string.IsNullOrWhiteSpace(databaseUrl))
    {
        options.UseNpgsql(ConvertDatabaseUrlToNpgsql(databaseUrl));
    }
    else
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
});

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}"
);

app.Run();


// ---- DATABASE_URL → Npgsql Converter ----
static string ConvertDatabaseUrlToNpgsql(string databaseUrl)
{
    // DATABASE_URL format:
    // postgresql://user:password@host:port/dbname

    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':');

    var builder = new NpgsqlConnectionStringBuilder
    {
        Host = uri.Host,
        Port = uri.Port,
        Username = userInfo[0],
        Password = userInfo.Length > 1 ? userInfo[1] : "",
        Database = uri.AbsolutePath.Trim('/'),
        SslMode = SslMode.Require,
        TrustServerCertificate = true
    };

    return builder.ToString();
}
