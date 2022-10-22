using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;

public class ContactService : IContactService
{
    private readonly DataContext _context;
    public ContactService(DataContext context)
    {
        _context = context;
    }

    public async Task<AddContactDto> AddContact(AddContactDto contactDto)
    {
        var contact = new Contact()
        {
            Name = contactDto.Name,
            Subject = contactDto.Subject,
            Email = contactDto.Email,
            Phone = contactDto.Phone,
            Message = contactDto.Message

        };

        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();

        contactDto.Id = contact.Id;

        var contactCreated = await GetContactById(contact.Id);
        return contactCreated;
    }

    public async Task<bool> DeleteContact(int id)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);

        if (contact == null)
        {
            return false;
        }

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<GetContactDto>> GetContacts()
    {
        var contacts = await _context.Contacts
            .Select(c => new GetContactDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Subject = c.Subject,
                    Email = c.Email,
                    Phone = c.Phone,
                    Message = c.Message
                }
            ).ToListAsync();
        return contacts;
    }

    public async Task<AddContactDto> GetContactById(int id)
    {
        var contact = await _context.Contacts
            .Select(c => new AddContactDto()
            {
                Id = c.Id,
                Name = c.Name,
                Subject = c.Subject,
                Email = c.Email,
                Phone = c.Phone,
                Message = c.Message
            })
            .FirstOrDefaultAsync(c => c.Id == id);

        return contact;
    }

    public async Task<AddContactDto> UpdateContact(AddContactDto contactDto)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == contactDto.Id);

        if (contact == null)
        {
            return null;
        }

        contact.Name = contactDto.Name;
        contact.Subject = contactDto.Subject;
        contact.Email = contactDto.Email;
        contact.Phone = contactDto.Phone;
        contact.Message = contactDto.Message;

        await _context.SaveChangesAsync();

        var contactUpdated = await GetContactById(contact.Id);
        return contactUpdated;
    }
}
