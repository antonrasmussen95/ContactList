using ContactList2.Model;

namespace ContactList2.Interfaces;

public interface IContactService
{   // interface med metoder för att skapa kontakt, visa kontakter, visa specific och radera kontakt // 
    public bool CreateContact(Contact contact);
    public IEnumerable<Contact> GetContacts();
    public Contact GetSpecificContact(Func<Contact, bool> expression); 
    public void DeleteContact(string email);
}
