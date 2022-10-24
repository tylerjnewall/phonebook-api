using System;
using AutoMapper;
using MediatR;

namespace PhonebookProject.Features.Phonebook.Contacts.Queries.GetAllContacts
{
    public class GetAllContacts
    {
        //Input
        public class GetAllContactsQuery : IRequest<IEnumerable<GetAllContactsResult>> { }

        //Output
        public class GetAllContactsResult
        {
            public Guid ContactId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Number { get; set; }
        }

        //Handler
        public class Handler : IRequestHandler<GetAllContactsQuery, IEnumerable<GetAllContactsResult>>
        {
            private readonly IContactService _contactService;
            private readonly IMapper _mapper;

            public Handler(IContactService contactService, IMapper mapper)
            {
                _contactService = contactService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetAllContactsResult>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
            {
                var consoles = await _contactService.GetAllContactsAsync();
                var results = _mapper.Map<IEnumerable<GetAllContactsResult>>(consoles);
                return results;
            }
        }
    }
}

