using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class Employee
    {
        public Enterprise Enterprise { get; set; }
        public User User { get; set; }

        public Employee()
        {

        }

        public Employee(Enterprise enterprise, User user)
        {
            this.Enterprise = enterprise;
            this.User = user;
        }
    }
}
