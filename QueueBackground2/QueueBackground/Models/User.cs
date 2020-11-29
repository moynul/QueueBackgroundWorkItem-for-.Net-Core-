using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QueueBackground.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("User Name ")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "UserName between 1 and 50 characters!")]
        public string UserName { get; set; }

        [StringLength(15, MinimumLength = 1, ErrorMessage = "PhoneNumber between 1 and 50 characters!")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
