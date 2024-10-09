using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using LibraryApp.Models; // Додаємо простір імен моделей

namespace LibraryApp.Controllers
{
    public class LibraryController : Controller
    {
        // Метод для основної сторінки бібліотеки
        public IActionResult Index()
        {
            return View();
        }

        // Метод для відображення списку книг
        public IActionResult Books()
        {
            // Завантажуємо список книг з конфігураційного файлу
            var books = LoadBooksFromConfig();
            return View(books);
        }

        // Метод для відображення профілю користувача за ID
        public IActionResult Profile(int? id)
        {
            var profiles = LoadProfilesFromConfig();
            if (id.HasValue && id >= 0 && id <= 5)
            {
                var profile = profiles.FirstOrDefault(p => p.Id == id.Value);
                if (profile != null)
                {
                    return View(profile);
                }
            }

            // Відображаємо профіль самого користувача (id = 0)
            var defaultProfile = profiles.FirstOrDefault(p => p.Id == 0);
            return View(defaultProfile);
        }

        // Приватний метод для завантаження списку книг з JSON файлу
        private List<Book> LoadBooksFromConfig()
        {
            var jsonString = System.IO.File.ReadAllText("Config/books.json");
            return JsonSerializer.Deserialize<List<Book>>(jsonString);
        }

        // Приватний метод для завантаження профілів користувачів з JSON файлу
        private List<Profile> LoadProfilesFromConfig()
        {
            var jsonString = System.IO.File.ReadAllText("Config/profiles.json");
            return JsonSerializer.Deserialize<List<Profile>>(jsonString);
        }
    }
}
