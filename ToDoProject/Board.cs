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
        public void Start()
        {
            TeamMember member1 = new TeamMember() { Id = 1, Fullname = "Ahmet Köse"};
            TeamMember member2 = new TeamMember() { Id = 2, Fullname = "Osman Bayar" };
            TeamMember member3 = new TeamMember() { Id = 3, Fullname = "Aslı Kırbaş" };

            team.Add(member1);
            team.Add(member2);
            team.Add(member3);


            while (true)
            {
                Console.WriteLine("************************************");
                Console.WriteLine("Please select you want to do : \n" +
                                  "(1) List Board\n" +
                                  "(2) Add Card to Board\n" +
                                  "(3) Delete Card from Board\n" +
                                  "(4) Move Card");
                
                select = Console.ReadLine();
                if (select.Equals("1"))
                {
                    ListLine();
                }
                else if (select.Equals("2"))
                {
                    AddCard();
                }
                else if (select.Equals("3"))
                {
                    DeleteCard();
                }
                else if (select.Equals("4"))
                {
                    MoveCard();
                }
                else
                {
                    Console.WriteLine("Please select a valid command!");
                }
            }
        }
        public void ListLine()
        {
            Console.WriteLine("TODO Line\n" +
                "************************");
            foreach (var item in toDoLine)
            {
                Console.WriteLine(item);
                Console.WriteLine("Title            : {0}\n" +
                                  "Description      : {1}\n" +
                                  "Assigned Person  : {2}\n" +
                                  "Size             : {3}\n", item.Title, item.Description, item.AssignedPerson.Fullname, item.CardSize);
            }
            Console.WriteLine("IN PROGRESS Line\n" +
                            "************************");
            foreach (var item in inProgressLine)
            {
                Console.WriteLine(item);
                Console.WriteLine("Title            : {0}\n" +
                                  "Description      : {1}\n" +
                                  "Assigned Person  : {2}\n" +
                                  "Size             : {3}\n", item.Title, item.Description, item.AssignedPerson.Fullname, item.CardSize);
            }
            Console.WriteLine("DONE Line\n" +
                "************************");
            foreach (var item in doneLine)
            {
                Console.WriteLine(item);
                Console.WriteLine("Title            : {0}\n" +
                                  "Description      : {1}\n" +
                                  "Assigned Person  : {2}\n" +
                                  "Size             : {3}\n", item.Title, item.Description, item.AssignedPerson.Fullname, item.CardSize);
            }
        }
        public void AddCard()
        {  
            Console.Write("Please input card title                          : ");
            string newTitle = Console.ReadLine().ToLower();
            Console.Write("Please input description                         : ");
            string newDescription = Console.ReadLine().ToLower();
            Console.Write("Please select size -> XS(1),S(2),M(3),L(4),XL(5) : ");
            Size newCardSize = (Size)int.Parse(Console.ReadLine());
            Console.WriteLine("Please input person                              : ");
            TeamMember newAssignedPerson = Assign();
            
            Card card = new Card(newTitle, newDescription, newAssignedPerson, newCardSize);
            toDoLine.Add(card);
        }
        public void DeleteCard()
        {
            Console.Write("First you need to select the card you want to delete.\n" +
                "Please write the card title : ");
            string value = Console.ReadLine().ToLower();
            
            foreach (Card item in toDoLine)
            {
                if (value.Equals(item.Title))
                {
                    toDoLine.Remove(item);
                    break;
                }
            }
            foreach (Card item in inProgressLine)
            {
                if (value.Equals(item.Title))
                {
                    inProgressLine.Remove(item);
                    break;
                }
            }
            foreach (Card item in doneLine)
            {
                if (value.Equals(item))
                {
                    doneLine.Remove(item);
                    break;
                }
            }
            Console.WriteLine("Doesn't match any card! Please select options below : \n" +
                "* Finalize the deletion : (1)" +
                "* To try again          : (2)");
            switch (Console.ReadLine())
            {
                case "1":
                    break;
                case "2":
                    DeleteCard();
                    break;
                default:
                    Console.WriteLine("Please select a valid command!");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        public void MoveCard()
        {
            Console.Write("First you need to select the card you want to delete.\n" +
                          "Please write the card title : ");
            string value = Console.ReadLine().ToLower();
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
                    break;
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
                    break;
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
                    switch (Console.ReadLine()) 
                    {
                        case ("1"):
                            toDoLine.Remove(item);
                            toDoLine.Add(item);
                            break;
                        case ("2"):
                            toDoLine.Remove(item);
                            inProgressLine.Add(item);
                            break;
                        case ("3"):
                            toDoLine.Remove(item);
                            doneLine.Add(item);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice!");
                            break;
                    }
                }
            }
            Console.WriteLine("Doesn't match any card!\n" + 
                "Press any key to continue...");
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
            int value = Convert.ToInt32(Console.ReadLine());
            return team.Where(person => person.Id == value).FirstOrDefault();
        }
        
    }
}
