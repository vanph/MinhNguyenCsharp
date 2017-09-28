using System;
using System.ComponentModel.DataAnnotations;

namespace MyCountry.DataAccess.Model
{
    public partial class User
    {
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
