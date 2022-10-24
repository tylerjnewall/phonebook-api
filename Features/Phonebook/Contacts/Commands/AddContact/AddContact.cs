using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using PhonebookProject.Domain;

namespace PhonebookProject.Features.Phonebook.Contacts.Commands.AddContact
{
    public class AddContact
    {
        public class AddContactCommand : IRequest<AddContactResult>
        {
            [Required()]            
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string Number { get; set; }
        }

        //Output
        public class AddContactResult
        {
            public Guid Id { get; set; }
            [Required(AllowEmptyStrings = false)]
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Number { get; set; }
        }

        //Handler
        public class Handler : IRequestHandler<AddContactCommand, AddContactResult>
        {
            private readonly IContactService _contactService;
            private readonly IMapper _mapper;

            public Handler(IContactService contactService, IMapper mapper)
            {
                _contactService = contactService;
                _mapper = mapper;
            }

            public async Task<AddContactResult> Handle(AddContactCommand request, CancellationToken cancellationToken)
            {
                var validator = new AddContactValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (validationResult.Errors.Count > 0)
                    throw new Exceptions.ValidationException(validationResult);

                var contact = new Contact()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Number = request.Number
                };

                await _contactService.AddContact(contact);

                await _contactService.SaveAsync();

                var result = _mapper.Map<AddContactResult>(contact);

                return result;
            }
        }
    }
}

