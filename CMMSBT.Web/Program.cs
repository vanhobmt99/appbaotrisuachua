using CMMSBT.Dao;
using CMMSBT.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddSession();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CmmsbtContext>();
builder.Services.AddHttpClient();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddScoped<IKhuVucService, KhuVucService>();
builder.Services.AddScoped<INhanVienService, NhanVienService>();
builder.Services.AddScoped<ICrmFunctionService, CrmFunctionService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IDonViService, DonViService>();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Auth/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(60);

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
