namespace phoneBookConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        PhoneBookMenu phonebook = new PhoneBookMenu();
       

        while (true)
        {
            Console.WriteLine("----Welcome to the mTel-----");
            Console.WriteLine("\n1. Add Contact");
            Console.WriteLine("2. Search Contact");
            Console.WriteLine("3. Display All Contacts");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("\nEnter name: ");
                    string name = Console.ReadLine();
                    string phoneNumber;
                    while (true)
                    {

                        Console.Write("Enter phone number: ");
                        try
                        {
                            phoneNumber = Console.ReadLine();
                            int.Parse(phoneNumber); // Try to parse input as an integer
                            break; // If parsing succeeds, exit the loop
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nInvalid input. Please enter a valid integer.");
                        }
                    }
                    phonebook.AddContact(new Contact { Name = name, PhoneNumber = phoneNumber });
                    Console.WriteLine("\nContact added successfully.");
                    break;

                case "2":
                    Console.Write("Enter name to search: ");
                    string searchName = Console.ReadLine();
                    Contact foundContact = phonebook.SearchContact(searchName);
                    if (foundContact != null)
                    {
                        Console.WriteLine($"Name: {foundContact.Name}, Phone Number: {foundContact.PhoneNumber}");
                    }
                    else
                    {
                        Console.WriteLine("\nContact not found.");
                    }
                    break;

                case "3":
                    phonebook.DisplayAllContacts();
                    break;

                case "4":
                    Console.Write("Enter name of contact to edit: ");
                    string editName = Console.ReadLine();
                    Contact editContact = phonebook.SearchContact(editName);
                    if (editContact != null)
                    {
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new phone number: ");
                        string newPhoneNumber = Console.ReadLine();
                        phonebook.EditContact(editName, newName, newPhoneNumber);
                        Console.WriteLine("Contact edited successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Contact not found.");
                    }
                    break;

                case "5":
                    Console.Write("Enter name of contact to delete: ");
                    string deleteName = Console.ReadLine();
                    if (phonebook.DeleteContact(deleteName))
                    {
                        Console.WriteLine("Contact deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Contact not found.");
                    }
                    break;

                case "6":
                    Console.WriteLine("Are you sure you want to exit? (Y/N)");
                    string choicee = Console.ReadLine().ToUpper();
                    if (choicee.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\nThank you for using mTel. See you later...");
                        Environment.Exit(0);
                        
                    }
                    else
                    {
                        Main(args);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }
}

