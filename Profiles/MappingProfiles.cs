using System;
using AutoMapper;
using PhonebookProject.Domain;
using PhonebookProject.Features.Phonebook.Contacts.Commands.AddContact;
using PhonebookProject.Features.Phonebook.Contacts.Commands.UpdateContact;
using PhonebookProject.Features.Phonebook.Contacts.Queries.GetAllContacts;
using PhonebookProject.Features.Phonebook.Contacts.Queries.GetContact;

namespace PhonebookProject.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Contact, GetAllContacts.GetAllContactsResult>();
            CreateMap<GetAllContacts.GetAllContactsResult, Contact>().ReverseMap();
            CreateMap<Contact, AddContact.AddContactResult>();
            CreateMap<Contact, GetContact.GetContactResult>();
            CreateMap<Contact, UpdateContact.UpdateContactResult>();
            CreateMap<Contact, UpdateContact.UpdateContactResult>().ReverseMap();
            CreateMap<Contact, UpdateContact.UpdateContactCommand>();
            CreateMap<Contact, UpdateContact.UpdateContactCommand>().ReverseMap();
        }
    }
}

