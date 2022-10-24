using System;
using Microsoft.EntityFrameworkCore;
using PhonebookProject.Data;
using PhonebookProject.Domain;

namespace PhonebookProject.Features.Phonebook.Contacts
{
    public class ContactService : IContactService
    {
        private readonly DataContext _dataContext;

        public ContactService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _dataContext.Contacts.OrderBy(x => x.FirstName).ToListAsync();
        }

        public async Task<Contact> GetContactAsync(Guid contactId)
        {
            return await _dataContext.Contacts
                .FirstOrDefaultAsync(x => x.ContactId == contactId);
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            await _dataContext.Contacts.AddAsync(contact);
            await _dataContext.SaveChangesAsync();

            return contact;
        }

        public void DeleteContact(Contact contact)
        {
            _dataContext.Remove(contact);
        }

        public Task SaveAsync()
        {
            return _dataContext.SaveChangesAsync();
        }
    }
}

