using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteRx.Interface.Domain.Entities
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("phone_number")]

        public string PhoneNumber { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Column("is_active")]

        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        

    }
}
