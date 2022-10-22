using Domain.Dtos;
namespace Infrastructure.Services;

public interface IContactService
{
    Task<AddContactDto> AddContact(AddContactDto contactDto);
    Task<bool> DeleteContact(int id);
    Task<List<GetContactDto>> GetContacts();
    Task<AddContactDto> GetContactById(int id);
    Task<AddContactDto> UpdateContact(AddContactDto contactDto);
}