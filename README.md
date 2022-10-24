# Phonebook project - API

For this project, I have used a vertical slice architecture. I have split each feature into seperate folders in order to adhere to clean code standards.

The technology I have used is:

-.NET6\
-Entity Framework Core\
-MySQL\
-MediatR\
-AutoMapper

# Endpoints
-Get all contacts: /api/phonebook/contacts\
-Get contact: /api/phonebook/contact/?contactid=\
-Add contact: /api/phonebook/create-contact\
-Update contact: /api/phonebook/update-contact?contactId=\
-Delete contact: /api/phonebook/delete-contact/?contactid=

# To Run this project:

1. dotnet ef database update
2. dotnet run
