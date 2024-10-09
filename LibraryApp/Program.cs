using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ������ ������ ��� ���������� � ���������������
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ����������, �� ������� ����������� � ����� ��������
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // ������� ������� � ����������� ����������
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ����������� ���������� ���������
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ����������� �������������
app.MapControllerRoute(
    name: "library",
    pattern: "Library",
    defaults: new { controller = "Library", action = "Index" });

app.MapControllerRoute(
    name: "books",
    pattern: "Library/Books",
    defaults: new { controller = "Library", action = "Books" });

app.MapControllerRoute(
    name: "profile",
    pattern: "Library/Profile/{id?}",
    defaults: new { controller = "Library", action = "Profile" });

// ������������ �������� �� ������������� (������'������, ��� �������������)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Library}/{action=Index}/{id?}");

app.Run();
