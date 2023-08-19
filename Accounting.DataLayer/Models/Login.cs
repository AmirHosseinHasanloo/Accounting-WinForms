using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting
{
    public class Login
    {
        [Key]
        public int LoginID { get; set; }
        [MaxLength(150)]
        [Required]
        public string UserName { get; set; }
        [MaxLength(150)]
        [Required]
        public string Password { get; set; }
    }
}
