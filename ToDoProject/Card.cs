using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject
{
    class Card
    {
            private string _title;
            private string _description;
            private TeamMember _assignedPerson;
            private Size _cardSize;

            public string Title { get => _title; set => _title = value; }
            public string Description { get => _description; set => _description = value; }
            public TeamMember AssignedPerson { get => _assignedPerson; set => _assignedPerson = value; }
            public Size CardSize { get => _cardSize; set => _cardSize = value; }

        public Card(string title, string description, TeamMember assignedPerson, Size cardSize)
        {
            this._title = title;
            this._description = description;
            this._assignedPerson = assignedPerson;
            this._cardSize = cardSize;
        }
    }
}
