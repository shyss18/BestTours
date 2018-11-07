using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BT.Dom.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public User User { get; set; }
    }
}
