using Microsoft.AspNet.Identity.EntityFramework;

namespace BT.Dom.Entities
{
    public class User : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
