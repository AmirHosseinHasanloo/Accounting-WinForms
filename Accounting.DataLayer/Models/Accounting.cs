using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Accounting
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int TypeID { get; set; }

        [Required]
        public float Amount { get; set; }

        [MaxLength(800)]
        public string Description { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual AccountingTypes Types { get; set; }
        public Accounting()
        {
            
        }
    }
}
