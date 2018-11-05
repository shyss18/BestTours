using System.Collections.Generic;

namespace BT.Dom.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public decimal Amount { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IList<Tour> Tours { get; set; }

        public Role Role { get; set; }
    }
}
