using Common.Library;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Master
{
    [Table("Users")]
    public class Users: Entity
    {
        [Required]
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
