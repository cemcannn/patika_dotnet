using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject
{
    class Card
    {
            private string title;
            private string description;
            private string assignedPerson;
            private Size cardSize;

            public string Title { get => title; set => title = value; }
            public string Description { get => description; set => description = value; }
            public string AssignedPerson { get => assignedPerson; set => assignedPerson = value; }
            public Size CardSize { get => cardSize; set => cardSize = value; }

        public Card(string title, string description, string assignedPerson, Size cardSize)
        {
            this.title = title;
            this.description = description;
            this.assignedPerson = assignedPerson;
            this.cardSize = cardSize;
        }
    }
}
