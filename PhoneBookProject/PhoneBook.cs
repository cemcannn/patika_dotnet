using System;
using System.Collections.Generic;

namespace PhoneBookProject
{
    public class PhoneBook
    {
        List<Contact> phoneBook = new List<Contact>();
        string select, value;

        public void Start()
        {
            Contact contact1 = new Contact() { FirstName = "osman", LastName = "bayar", PhoneNumber = "5551234545" };
            Contact contact2 = new Contact() { FirstName = "abuzer", LastName = "kadayıf", PhoneNumber = "5453335468" };
            Contact contact3 = new Contact() { FirstName = "ali", LastName = "veli", PhoneNumber = "5453335545" };
            Contact contact4 = new Contact() { FirstName = "ahmet", LastName = "bayır", PhoneNumber = "5453335475" };
            Contact contact5 = new Contact() { FirstName = "hüseyin", LastName = "doruk", PhoneNumber = "5453335486" };

            phoneBook.Add(contact1);
            phoneBook.Add(contact2);
            phoneBook.Add(contact3);
            phoneBook.Add(contact4);
            phoneBook.Add(contact5);

            while (true)
            {
                Console.WriteLine("\nPlease input a command : \n" +
                                  "**********************************************\n" +
                                  "(1) Add a new contact\n" +
                                  "(2) Delete an existing number\n" +
                                  "(3) Update an existing number\n" +
                                  "(4) Listing a phonebook\n" +
                                  "(5) Searching a phonebook\n");

                select = Console.ReadLine();

                if (select.Equals("1"))
                {
                    Adding();
                }
                else if (select.Equals("2"))
                {
                    Delete();
                }
                else if (select.Equals("3"))
                {
                    Update();
                }
                else if (select.Equals("4"))
                {
                    Listing();
                }
                else if (select.Equals("5"))
                {
                    Search();
                }
            }
        }

        public void Adding()
        {
            Contact contact = new Contact();

            Console.Write("Please input first name : ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Please input last name : ");
            contact.LastName = Console.ReadLine();
            Console.Write("Please input phone number : ");
            contact.PhoneNumber = Console.ReadLine();

            phoneBook.Add(contact);

            Console.WriteLine("\nContact succesfully added.");
        }

        public void Delete()
        {
            Console.Write("Please input first name or last name you want to delete: ");
            value = Console.ReadLine().ToLower();

            foreach (Contact person in phoneBook)
            {
                if (person.FirstName.Equals(value) || person.LastName.Equals(value))
                {
                    Console.WriteLine("The person who name is {0} {1}", person.FirstName, person.LastName + " will be deleted from the phone book.");
                    phoneBook.Remove(person);
                    Console.WriteLine("Contact succesfully deleted.");
                    goto LoopEnd;
                }
            }
            Console.WriteLine("Contact doesn't exist! Please select : \n" +
              "* Finalize the deletion : (1)\n" +
              "* To try again : (2)");
            while (true)
            {
                select = Console.ReadLine();
                if (select.Equals("1"))
                {
                    goto LoopEnd;
                }
                else if (select.Equals("2"))
                {
                    Delete();
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Please select one of the options above!");
                }
            }
            LoopEnd:
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        public void Update()
        {
            Console.Write("Please input first name or last name you want to delete: ");
            value = Console.ReadLine().ToLower();

            foreach (Contact item in phoneBook)
            {
                if (item.FirstName.Equals(value) || item.LastName.Equals(value))
                {
                    Console.WriteLine("The person who name is {0} {1}", item.FirstName, item.LastName + " will be updated from the phone book.");
                    Console.Write("Please input new first name : ");
                    item.FirstName = Console.ReadLine();
                    Console.Write("Please input new last name : ");
                    item.LastName = Console.ReadLine();
                    Console.Write("Please input new phone number : ");
                    item.PhoneNumber = Console.ReadLine();

                    Console.WriteLine("Contact succesfully updated.");

                    goto LoopEnd;
                }
            }
            Console.Write("Contact doesn't exist! Please select : \n" +
          "* Finalize the update : (1)\n" +
          "* To try again : (2)");
            while (true)
            {
                select = Console.ReadLine();
                if (select.Equals("1"))
                {
                    break;
                }
                else if (select.Equals("2"))
                {
                    Update();
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Please select one of the options above!");
                }
            }
        LoopEnd:
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();

        }

        public void Listing()
        {
            Console.WriteLine("Phone Book");
            Console.WriteLine("**********************************************");

            foreach (Contact person in phoneBook)
            {
                Console.WriteLine("\nFirst Name : {0} \nLast Name : {1} \nPhone Number : {2}", person.FirstName, person.LastName, person.PhoneNumber);

            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        public void Search()
        {

            Console.WriteLine("Please select the type you want to search : \n" +
                          "To search by first name or last name : (1)\n" +
                          "To search by phone number : (2)");

            while (true)
            {
                select = Console.ReadLine();
                if (select.Equals("1"))
                {
                    Console.Write("Please input first name or last name : ");
                    value = Console.ReadLine().ToLower();

                    foreach (Contact person in phoneBook)
                    {
                        if (person.FirstName.Equals(value) || person.LastName.Equals(value))
                        {
                            Console.WriteLine("\nSearching Results : " + "\n **********************************************" + "\nFirst Name : {0} \nLast Name : {1} \nPhone Number : {2}", person.FirstName, person.LastName, person.PhoneNumber);
                            goto LoopEnd;
                        }
                    }
                    Console.WriteLine("Contact doesn't exist!");
                    goto LoopEnd;
                }

                else if (select.Equals("2"))
                {
                    Console.Write("Please input phone number : ");
                    value = Console.ReadLine();

                    foreach (Contact person in phoneBook)
                    {
                        if (person.PhoneNumber.Equals(value))
                        {
                            Console.WriteLine("Searching Results : " + "\n **********************************************" + "\nFirst Name : {0} \nLast Name : {1} \nPhone Number : {2}", person.FirstName, person.LastName, person.PhoneNumber);
                            goto LoopEnd;
                        }
                    }
                    Console.WriteLine("Contact doesn't exist!");
                    goto LoopEnd;
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Please select one of the options above!");
                }
            }
        LoopEnd:
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

    }
}

