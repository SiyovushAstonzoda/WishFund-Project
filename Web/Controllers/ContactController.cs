using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    //Add
    [HttpGet]
    public IActionResult Contact()
    {
        return View(new AddContactDto());
    }

    [HttpPost]
    public async Task<IActionResult> Contact(AddContactDto contact)
    {
        if (ModelState.IsValid == false)
        {
            return View(contact);
        }

        await _contactService.AddContact(contact);
        return RedirectToAction("Areas", "Admin","Contact","Index");
    }
}


