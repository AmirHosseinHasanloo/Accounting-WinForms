using AccountingViewModels;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Bussiness
{
    public class Account
    {
        public static ReportViewModel ReportMonth()
        {
            ReportViewModel report = new ReportViewModel();
            using (DataContext db = new DataContext())
            {
                DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
                DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 31);

                // TypeID = 1 ==> Recive
                var Recives = db.AccountingRepository.Get(a => a.TypeID == 1 && a.CreateDate >= StartDate && a.CreateDate <= EndDate).Select(a => a.Amount).ToList();
                var Pays = db.AccountingRepository.Get(a => a.TypeID == 2 && a.CreateDate >= StartDate && a.CreateDate <= EndDate).Select(a => a.Amount).ToList();

                report.Recive = Recives.Sum();
                report.Pay = Pays.Sum();
                report.Balance = Recives.Sum() - Pays.Sum();
            }
            return report;
        }
    }
}
