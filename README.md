# MicroService.PhoneBook
This is a simple micro service to showcase code structure and swagger front end for testing.
The project is broken down into:
- Swagger look and feel. Developer option for testing.
- Controller entry point for the code
- a Service layer  ( Future Feature: Validation of posted data)
- a Repository layer that handles the Data insert, update and  deletes
- currently we make use of in memory db for ease of use.
- Future Feature: is to Add a local db option to make use of Migration Scripts
- Future Feature: is to Add test projects for the service as well as the repository layer
- Future Feature: is to Add authentication on the API's
- Add a MVC page that will make use ether via the API or Service/Repository layers.

What to do: 
Clone the project down to your machine.
Set MicroService.Phonebook as your default project
Run the project
You should see a swagger front end with comments - 
 - Insert one or multiple entries
 - Get those entries, they can also be fitered down by name or number
 - Update an entry. Get and verify entry changed
 - Delete an entry. Get and verify entry deleted
 
 
This is just a basic structure to still be build on. However it can still be used for review.

