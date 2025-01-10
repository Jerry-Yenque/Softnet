using System.Diagnostics;
using Management.Data;
using Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Management.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    //_logger = logger;
        //}
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Contact.ToListAsync());
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> JsonContacts()
        {
            var contacts = await _context.Contact.ToListAsync();
            return Json(contacts); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            Console.WriteLine(ModelState.IsValid);
            Console.WriteLine($"Name: {contact.Name}, Email: {contact.Email}, Phone: {contact.Phone}, Company: {contact.Company}, DataConsent: {contact.DataConsent}, InfoConsent: {contact.InfoConsent}");

            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirigir al índice después de guardar
            }
            return View("Index", contact); // Si no es válido, volver al formulario con datos actuales
        }

    }

}
