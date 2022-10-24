using System;
using PhonebookProject.Domain;

namespace PhonebookProject.Features.Phonebook.Contacts
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactAsync(Guid contactId);
        Task<Contact> AddContact(Contact contact);
        void DeleteContact(Contact contact);
        Task SaveAsync();
    }
}

