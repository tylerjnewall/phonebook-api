using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhonebookProject.Features.Phonebook.Contacts.Commands.AddContact;
using PhonebookProject.Features.Phonebook.Contacts.Commands.DeleteContact;
using PhonebookProject.Features.Phonebook.Contacts.Commands.UpdateContact;
using PhonebookProject.Features.Phonebook.Contacts.Queries.GetAllContacts;
using PhonebookProject.Features.Phonebook.Contacts.Queries.GetContact;
using static PhonebookProject.Features.Phonebook.Contacts.Commands.UpdateContact.UpdateContact;

namespace PhonebookProject.Controllers
{
    [Route("api/[controller]")]
    public class PhonebookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhonebookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("contacts")]
        public async Task<ActionResult<List<GetAllContacts.GetAllContactsQuery>>> GetAllContacts()
        {
            var dtos = await _mediator.Send(new GetAllContacts.GetAllContactsQuery());
            return Ok(dtos);
        }

        [HttpGet("contact")]
        public async Task<ActionResult<GetContact.GetContactQuery>> GetContact(Guid contactId)
        {
            var dtos = await _mediator.Send(new GetContact.GetContactQuery() { ContactId = contactId });
            return Ok(dtos);
        }

        [HttpPost("create-contact")]
        public async Task<ActionResult<int>> CreateContact([FromBody] AddContact.AddContactCommand createContactCommand)
        {
            var id = await _mediator.Send(createContactCommand);
            return Ok(id);
        }

        [HttpPut("update-contact")]
        public async Task<ActionResult> UpdateGameForConsole(Guid contactId, [FromBody] UpdateContact.UpdateContactCommand command)
        {
            command.ContactId = contactId;

            var result = await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("delete-contact")]
        public async Task<ActionResult> RemoveGameFromConsole(Guid contactId, DeleteContact.DeleteContactCommand command)
        {
            command.ContactId = contactId;

            var result = await _mediator.Send(command);

            return Ok();
        }
    }
}

