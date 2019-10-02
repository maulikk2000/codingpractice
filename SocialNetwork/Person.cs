using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public class Person
    {
        private int personID;

        public Person(int id)
        {
            this.personID = id;
        }

        public string Info { get; set; }
        public List<int> Friends { get; set; }
    }
}
