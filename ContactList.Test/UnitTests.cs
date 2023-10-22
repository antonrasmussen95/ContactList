
using ContactList2.Model;
using ContactList2.Services;

namespace ContactList.Test;

public class UnitTests
{
    [Fact]
    public void AddContact_ShouldAddContactToList_ReturnTrue()
    {
        ContactService contactService = new ContactService();
        
        //Skapar en kontakt för test för att se om kontakt läggs till i listan //
        Contact contact = new Contact();

        contact.FirstName = "test";
        contact.LastName = "test";
        contact.Email = "test";
        contact.PhoneNumber = "test";
        contact.Address = "test";

        

        bool result = contactService.CreateContact(contact);


        Assert.True(result);
    }
}