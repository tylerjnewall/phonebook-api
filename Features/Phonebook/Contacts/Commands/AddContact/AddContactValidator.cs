using System;
using FluentValidation;
using static PhonebookProject.Features.Phonebook.Contacts.Commands.AddContact.AddContact;

namespace PhonebookProject.Features.Phonebook.Contacts.Commands.AddContact
{
    public class AddContactValidator : AbstractValidator<AddContactCommand>
    {
        public AddContactValidator()
        {
            RuleFor(b => b.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(50);

            RuleFor(b => b.LastName)
                .NotEmpty().WithMessage("Last name is required");

            RuleFor(b => b.Number)
                .NotEmpty().WithMessage("Phone number is required");
        }
    }
}

