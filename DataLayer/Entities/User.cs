
using DataLayer.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        
        [NotMapped]
        public Role role { get; set; }
    }
}
