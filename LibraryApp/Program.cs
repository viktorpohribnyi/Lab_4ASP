using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Додаємо служби для контролерів з представленнями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Перевіряємо, чи додаток знаходиться в режимі розробки
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // Обробка помилок у виробничому середовищі
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Налаштовуємо середовище виконання
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Налаштовуємо маршрутизацію
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

// Налаштування маршруту за замовчуванням (необов'язково, але рекомендовано)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Library}/{action=Index}/{id?}");

app.Run();
