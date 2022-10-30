using System.Diagnostics;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICategoryService _categoryService;
    private readonly IContactService _contactService;

    public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IContactService contactService)
    {
        _logger = logger;
        _categoryService = categoryService;
        _contactService = contactService;
    }

    public async Task<IActionResult> Index()
    {
        var home = new HomeInfoDto();
        ViewBag.Categories = await _categoryService.GetCategories() ;

        return View(home);
    }

    public async Task<IActionResult> About()
    {
        ViewBag.Categories = await _categoryService.GetCategories() ;

        return View();
    }

    public async Task<IActionResult> Contact()
    {
        ViewBag.Contacts = await _contactService.GetContacts();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contact(AddContactDto contact)
    {
        ViewBag.Contacts = await _categoryService.GetCategories();
        return View();
    }

    public async Task<IActionResult> Privacy()
    {
        ViewBag.Categories = await _contactService.GetContacts() ;

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
