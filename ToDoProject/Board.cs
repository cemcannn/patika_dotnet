using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject
{
    class Board
    {
        List<Card> toDoLine = new List<Card>();
        List<Card> inProgressLine = new List<Card>();
        List<Card> doneLine = new List<Card>();
        List<TeamMember> team = new List<TeamMember>();

        string select;
        int value;
        public void Start()
        {
            TeamMember member1 = new TeamMember() { Id = 1, Fullname = "Ahmet Köse"};
            TeamMember member2 = new TeamMember() { Id = 2, Fullname = "Osman Bayar" };
            TeamMember member3 = new TeamMember() { Id = 3, Fullname = "Aslı Kırbaş" };

            Console.WriteLine("Please select you want to do : \n" +
                "(1) List Board\n" +
                "(2) Add Card to Board\n" +
                "(3) Delete Card from Board\n" +
                "(4) Move Card");
            while (true)
            {
                select = Console.ReadLine();
                if (select.Equals("1"))
                {
                    Listing();
                }
                else if (select.Equals("2"))
                {
                    Adding();
                }
                else if (select.Equals("3"))
                {
                }
                else if (select.Equals("4"))
                {
                }
                else
                {
                    Console.WriteLine("Please select a valid command!");
                }
            }
        }
        public void Listing()
        {
            Console.WriteLine("TODO Line\n" +
                "************************");
            foreach (var item in toDoLine)
            {
                Console.WriteLine(item);
                Console.WriteLine("Title            : {0}\n" +
                                  "Description      : {1}\n" +
                                  "Assigned Person  : {2}\n" +
                                  "Size             : {3}\n", item.Title, item.Description, item.AssignedPerson, item.CardSize);
            }
            Console.WriteLine("TODO Line\n" +
                            "************************");
            foreach (var item in inProgressLine)
            {
                Console.WriteLine(item);
                Console.WriteLine("Title            : {0}\n" +
                                  "Description      : {1}\n" +
                                  "Assigned Person  : {2}\n" +
                                  "Size             : {3}\n", item.Title, item.Description, item.AssignedPerson, item.CardSize);
            }
            Console.WriteLine("TODO Line\n" +
                "************************");
            foreach (var item in doneLine)
            {
                Console.WriteLine(item);
                Console.WriteLine("Title            : {0}\n" +
                                  "Description      : {1}\n" +
                                  "Assigned Person  : {2}\n" +
                                  "Size             : {3}\n", item.Title, item.Description, item.AssignedPerson, item.CardSize);
            }
        }
        public void Adding()
        {
            
            Console.Write("Please input card title                          : ");
            string newTitle = Console.ReadLine().ToLower();
            Console.Write("Please input description                         : ");
            string newDescription = Console.ReadLine().ToLower();
            Console.Write("Please select size -> XS(1),S(2),M(3),L(4),XL(5) : ");
            Size newCardSize = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please input person                              : ");
            TeamMember newAssignedPerson = Assign();
            

            Card card = new Card(newTitle, newDescription, newAssignedPerson, newCardSize);
            toDoLine.Add(card);
        }
        public void Delete()
        {
            Console.Write("First you need to select the card you want to delete.\n" +
                "Please write the card title : ");
            value = Console.ReadLine().ToLower();
            
            foreach (Card item in toDoLine)
            {
                if (value.Equals(item.Title))
                {
                    toDoLine.Remove(item);
                    goto LoopEnd;
                }
            }
            foreach (Card item in inProgressLine)
            {
                if (value.Equals(item.Title))
                {
                    inProgressLine.Remove(item);
                    goto LoopEnd;
                }
            }
            foreach (Card item in doneLine)
            {
                if (value.Equals(item))
                {
                    doneLine.Remove(item);
                    goto LoopEnd;
                }
            }
            Console.WriteLine("Doesn't match any card! Please select options below : \n" +
                "* Finalize the deletion : (1)" +
                "* To try again          : (2)");
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
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        public void Move()
        {
            Console.Write("First you need to select the card you want to delete.\n" +
                          "Please write the card title : ");
            value = Console.ReadLine().ToLower();
            foreach (Card item in toDoLine)
            {
                if (value.Equals(item.Title))
                {
                    Console.WriteLine("Card information : \n" +
                        "Title : {0}\n" +
                        "Description : {1}\n" +
                        "Assigned person : {2}\n" +
                        "Size : {3}\n" +
                        "Line : TODO Line", item.Title, item.Description, item.AssignedPerson, item.CardSize);
                    goto LoopEnd;
                }
            }
            foreach (Card item in inProgressLine)
            {
                if (value.Equals(item.Title))
                {
                    Console.WriteLine("Card information : \n" +
                        "Title : {0}\n" +
                        "Description : {1}\n" +
                        "Assigned person : {2}\n" +
                        "Size : {3}\n" +
                        "Line : IN PROGRESS Line", item.Title, item.Description, item.AssignedPerson, item.CardSize);
                    goto LoopEnd;
                }
            }
            foreach (Card item in doneLine)
            {
                if (value.Equals(item))
                {
                    Console.WriteLine("Card information : \n" +
                        "Title : {0}\n" +
                        "Description : {1}\n" +
                        "Assigned person : {2}\n" +
                        "Size : {3}\n" +
                        "Line : DONE Line", item.Title, item.Description, item.AssignedPerson, item.CardSize);
                    Console.WriteLine("Please select Line you want to move : \n" +
                        "(1) TODO\n" +
                        "(2) IN PROGRESS\n" +
                        "(3) DONE");
                    select = Console.ReadLine();
                    if (select.Equals("1"))
                    {
                        toDoLine.Remove(item);
                        toDoLine.Add(item);
                        goto LoopEnd;
                    }
                    else if (select.Equals("2"))
                    {
                        toDoLine.Remove(item);
                        inProgressLine.Add(item);
                        goto LoopEnd;
                    }
                    else if (select.Equals("3"))
                    {
                        toDoLine.Remove(item);
                        doneLine.Add(item);
                        goto LoopEnd;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice! Please select one of the options above!");
                    }
                }
            }
            Console.WriteLine("Doesn't match any card!");
        LoopEnd:
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        public TeamMember Assign()
        {
            Console.WriteLine("Team members : \n" +
                "************************************");
            foreach (var person in team)
            {
                Console.WriteLine("Id : {0}\n" +
                    "Full Name : {1}", person.Id, person.Fullname);
            }
            Console.Write("Please select team member with id from above list : ");
            value = Convert.ToInt32(Console.ReadLine());
            foreach (var person in team)
            {
                if (value == person.Id)
                {
                    return person;
                }
            }
            return null;

        }
        
    }
}
