using System;
using AutoMapper;
using MediatR;

namespace PhonebookProject.Features.Phonebook.Contacts.Queries.GetContact
{
    public class GetContact
    {
        //Input
        public class GetContactQuery : IRequest<GetContactResult>
        {
            public Guid ContactId { get; set; }
        }

        //Output
        public class GetContactResult
        {
            public Guid ContactId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Number { get; set; }
        }

        //Handler
        public class Handler : IRequestHandler<GetContactQuery, GetContactResult>
        {
            private readonly IContactService _contactService;
            private readonly IMapper _mapper;

            public Handler(IContactService contactService, IMapper mapper)
            {
                _contactService = contactService;
                _mapper = mapper;
            }

            public async Task<GetContactResult> Handle(GetContactQuery request, CancellationToken cancellationToken)
            {
                var contact = await _contactService.GetContactAsync(request.ContactId);
                var result = _mapper.Map<GetContactResult>(contact);
                return result;
            }
        }
    }
}

