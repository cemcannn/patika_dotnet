using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject
{
    class TeamMember
    {
        private int id;
        private string fullname;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
    }
}
