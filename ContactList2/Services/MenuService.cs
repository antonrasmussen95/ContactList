using ContactList2.Interfaces;
using ContactList2.Model;

namespace ContactList2.Services;

public class MenuService : IMenuService
{
    private readonly IContactService _contactService = new ContactService();
    public void MainMenu()
    {
        var exit = false;
        // "Loopar" om Main Menu tills användaren väljer att avsluta programmet (0) // 
        do
        {
            Console.Clear();
            Console.WriteLine("1. Lägg till ny kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa specifik kontakt");
            Console.WriteLine("4. Ta bort kontakt");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj 0-4:  "); 
            var option = Console.ReadLine();

            // Det användaren matar in avgör nästa steg // 
            switch (option)
            {
                case "1":
                    AddMenu();
                    break;
                case "2":
                    GetAllMenu();
                    break;
                case "3":
                    GetSpecificMenu();
                    break;
                case "4":
                    DeleteMenu();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    break;
            }
        }
        while (exit == false);  

    }
    public void AddMenu()
    {
        // Användaren följer stegen för att lägga till en kontakt // 
        var contact = new Contact();

        Console.Clear();
        Console.Write("Förnamn: "); 
        contact.FirstName = Console.ReadLine()!.Trim();

        Console.Write("Efternamn: "); 
        contact.LastName = Console.ReadLine()!.Trim();

        Console.Write("E-postadress: ");
        contact.Email = Console.ReadLine()!.ToLower().Trim();

        Console.Write("Telefonnummer: "); 
        contact.PhoneNumber = Console.ReadLine()!.Trim();

        Console.Write("Adress: "); 
        contact.Address = Console.ReadLine()!.Trim();

        _contactService.CreateContact(contact);

        Console.ReadKey();



    }

    public void DeleteMenu()
    {
        // För att ta bort en kontakt ska användaren ange e-post för kontakt som ska tas bort // 
        Console.Clear();
        Console.Write("Ange e-post för den kontakt du vill ta bort: ");
        var email = Console.ReadLine()!.ToLower().Trim();
        var deletContact = _contactService.GetSpecificContact(contact => contact.Email == email);

        if (deletContact != null) 
        {
            _contactService.DeleteContact(deletContact.Email!);
            Console.WriteLine($"{deletContact.Email} har raderas"); 
        }
        else // Finns det ingen kontakt med angiven e-post kommer felmeddelande // 
        {
            Console.WriteLine("Kunde inte hitta kontakt med den e-postadressen");
        }
        Console.ReadKey(); 
    }

    public void GetAllMenu()
    { 
        // Listar alla befintliga kontakter i alfabetisk ordning på förnamn // 
        Console.Clear();
        Console.WriteLine("Kontakter");
        Console.WriteLine("------------------------------"); 

        foreach (var contact in _contactService.GetContacts().OrderBy(contact => contact.FirstName))
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} {contact.Address}"); 

        }
        Console.ReadKey();
    }

    public void GetSpecificMenu()
    {
        // Användaren anger e-post för att visa specifik kontakt //
        Console.Clear();
        Console.Write("Ange e-post för specific kontakt: "); 

        var email = Console.ReadLine()!.ToLower().Trim();
        var contact = _contactService.GetSpecificContact(contact => contact.Email == email);

        if (contact != null)
        {
            Console.Clear();
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} {contact.Address}");
        }
        else // Finns inte kontakt med angiven e-post så kommer ett felmeddelande // 
        {
            Console.WriteLine("Det finns ingen kontakt med den e-postadressen");
        }
        Console.ReadKey();
    }

    
}
