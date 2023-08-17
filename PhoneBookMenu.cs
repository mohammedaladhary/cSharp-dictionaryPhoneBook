using System;
namespace phoneBookConsoleApp
{
	public class PhoneBookMenu
	{
        private List<Contact> contacts = new List<Contact>();
        private const string FilePath = "/Users/mohammedaladhary/Projects/phoneBookConsoleApp/mTelPhoneBook.txt";

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            SaveContacts();
        }

        private void SaveContacts()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (Contact contact in contacts)
                {
                    writer.WriteLine("\n------- mTelPhoneBook -------");
                    if (contact.PhoneNumber != null)
                    {
                        writer.WriteLine($"Name : {contact.Name}, Phone no. : {contact.PhoneNumber}");
                    }
                }
            }
        }

        public PhoneBookMenu()
		{
            LoadContacts();
        }
  
        private void LoadContacts()
        {
            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        contacts.Add(new Contact { Name = parts[0], PhoneNumber = parts[1] });
                    }
                }
            }
        }

        public Contact SearchContact(string name)
        {
            return contacts.Find(contact => contact.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void DisplayAllContacts()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}");
            }
        }

        public bool EditContact(string name, string newName, string newPhoneNumber)
        {
            Contact contact = SearchContact(name);
            if (contact != null)
            {
                contact.Name = newName;
                contact.PhoneNumber = newPhoneNumber;
                SaveContacts();
                return true;
            }
            return false;
        }

        public bool DeleteContact(string name)
        {
            Contact contact = SearchContact(name);
            if (contact != null)
            {
                contacts.Remove(contact);
                SaveContacts();
                return true;
            }
            return false;
        }
    }
}

