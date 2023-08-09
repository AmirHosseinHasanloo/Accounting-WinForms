using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AccountingTypes
    {
        [Key]
        public int TypeID { get; set; }
        [Display(Name ="عنوان")]
        public string TypeTitle { get; set; }

        public virtual List<Accounting> Account { get; set; }

        public AccountingTypes()
        {
            
        }
    }
}
