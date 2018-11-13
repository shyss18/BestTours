using Microsoft.AspNet.Identity.EntityFramework;

namespace BT.Dom.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Amount { get; set; }

        public virtual ClientProfile ClientProfile { get; set; }
    }
}
