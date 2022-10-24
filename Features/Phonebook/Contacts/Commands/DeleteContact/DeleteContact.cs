using System;
using MediatR;

namespace PhonebookProject.Features.Phonebook.Contacts.Commands.DeleteContact
{
    public class DeleteContact
    {
        public class DeleteContactCommand : IRequest<Unit>
        {
            public Guid ContactId { get; set; }
        }

        public class Handler : IRequestHandler<DeleteContactCommand, Unit>
        {
            private readonly IContactService _contactService;

            public Handler(IContactService contactService)
            {
                _contactService = contactService;
            }

            public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
            {
                var contact = await _contactService.GetContactAsync(request.ContactId);

                if (contact == null)
                    throw new Exception("Ex");


                _contactService.DeleteContact(contact);

                await _contactService.SaveAsync();

                return Unit.Value;
            }
        }
    }
}

