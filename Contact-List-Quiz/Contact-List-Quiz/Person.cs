using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_List_Quiz
{
    public class Person
    {
        public Int32 id { set; get; }
        public string firstName { set; get; }
        public string lastName { set; get; }
        public string email { set; get; }

        public Person (Int32 id, string firstName, string lastName, string email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }
    }
}
