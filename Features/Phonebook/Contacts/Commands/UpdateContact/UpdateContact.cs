using System;
using AutoMapper;
using MediatR;

namespace PhonebookProject.Features.Phonebook.Contacts.Commands.UpdateContact
{
    public class UpdateContact
    {
        public class UpdateContactCommand : IRequest<Unit>
        {
            public Guid ContactId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Number { get; set; }
        }

        public class UpdateContactResult
        {
            public Guid ContactId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Number { get; set; }
        }

        public class Handler : IRequestHandler<UpdateContactCommand>
        {
            private readonly IContactService _contactService;
            private readonly IMapper _mapper;

            public Handler(IContactService contactService, IMapper mapper)
            {
                _contactService = contactService;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
            {
                var contact = await _contactService.GetContactAsync(request.ContactId);


                contact.FirstName = request.FirstName;
                contact.LastName = request.LastName;
                contact.Number = request.Number;

                await _contactService.SaveAsync();

                return Unit.Value;
            }
        }
    }
}

