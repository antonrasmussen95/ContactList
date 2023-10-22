using ContactList2.Interfaces;
using ContactList2.Model;
using Newtonsoft.Json;

namespace ContactList2.Services;

public class ContactService : IContactService
{
    private List<Contact> _contacts = new List<Contact>();
    //konstruktor som kör GetContactsFromFile // 
    public ContactService() 
    {
        GetContactsFromFile();
    }

    public List<Contact> GetContactsFromFile()
    {
        var file = FileService.ReadFromFile(); 

        if (!string.IsNullOrEmpty(file))
        {
            //konverterar JSON till C# objekt//
            _contacts = new List<Contact>();
            return _contacts = JsonConvert.DeserializeObject<List<Contact>>(file)!;
        }
        return null!; 
    }
    public bool CreateContact(Contact contact)
    {
        try
        {
            _contacts.Add(contact);

            //konverterar kontakt (C#) till JSON// 
            var json = JsonConvert.SerializeObject(_contacts);
            FileService.SaveToFile(json);
            return true;
        }
        catch { }
        return false;
    }
    // ifall kontakt finns raderas kontakt baserat på string email // 
    public void DeleteContact(string email)
    {
        try
        {
            var contact = _contacts.FirstOrDefault(contact => contact.Email == email);
            if (contact != null)
            {
                _contacts.Remove(contact);

                var json = JsonConvert.SerializeObject(_contacts);
                FileService.SaveToFile(json);
            }
        } 
        catch { }
    }

    // får lista på alla kontakter // 
    public IEnumerable<Contact> GetContacts()
    {
       return _contacts;
    }

    // hämtar kontakt baserat på expression // 
    public Contact GetSpecificContact(Func<Contact, bool> expression)
    {
        try 
        {
            var contact = _contacts.FirstOrDefault(expression, null!); 
            if (contact != null)
            {
                return contact;
            }
        
        }
        catch { }
        return null!;
    }
}
