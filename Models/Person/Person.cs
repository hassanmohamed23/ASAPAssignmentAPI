using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Person
    {
        public int ID { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string  Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Address> Address { get; set; }

    }
}
