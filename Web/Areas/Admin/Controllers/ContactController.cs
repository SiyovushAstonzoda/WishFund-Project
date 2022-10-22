using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers;

[Area("Admin")]
public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    //Get
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _contactService.GetContacts());
    }

    //Add
    [HttpGet]
    public IActionResult Create()
    {
        return View(new AddContactDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddContactDto contact)
    {
        if (ModelState.IsValid == false)
        {
            return View(contact);
        }

        await _contactService.AddContact(contact);
        return RedirectToAction("Index");
    }

    //Update
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var getContactDto = await _contactService.GetContactById(id);
        return View(getContactDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AddContactDto contact)
    {
        if (ModelState.IsValid == false)
        {
            return View(contact);
        }

        await _contactService.UpdateContact(contact);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _contactService.DeleteContact(id);
        return RedirectToAction("Index");
    }
}


