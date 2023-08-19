using AccountingViewModels;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Accounting;

namespace Accounting.Bussiness
{
    public class Account
    {
        public static ReportViewModel ReportDay()
        {
            ReportViewModel report = new ReportViewModel();
            using (DataContext db = new DataContext())
            {
                DateTime dtStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime dtEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
                // TypeID = 1 ==> Recive
                // TypeID = 2 ==> Pay
                var Recives = db.AccountingRepository.Get(a => a.TypeID == 1 && a.CreateDate >= dtStart && a.CreateDate <= dtEnd).Select(a => a.Amount).ToList();
                var Pays = db.AccountingRepository.Get(a => a.TypeID == 2 && a.CreateDate >= dtStart && a.CreateDate <= dtEnd).Select(a => a.Amount).ToList();

                report.Recive = Recives.Sum();
                report.Pay = Pays.Sum();
                report.Balance = Recives.Sum() - Pays.Sum();
            }
            return report;
        }
        public static ReportViewModel ReportMonth()
        {
            ReportViewModel report = new ReportViewModel();
            using (DataContext db = new DataContext())
            {
                DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
                DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 31);

                // TypeID = 1 ==> Recive
                // TypeID = 2 ==> Pay
                var Recives = db.AccountingRepository.Get(a => a.TypeID == 1 && a.CreateDate >= StartDate && a.CreateDate <= EndDate).Select(a => a.Amount).ToList();
                var Pays = db.AccountingRepository.Get(a => a.TypeID == 2 && a.CreateDate >= StartDate && a.CreateDate <= EndDate).Select(a => a.Amount).ToList();

                report.Recive = Recives.Sum();
                report.Pay = Pays.Sum();
                report.Balance = Recives.Sum() - Pays.Sum();
            }
            return report;
        }
        public static ReportViewModel ReportYear()
        {
            ReportViewModel report = new ReportViewModel();
            using (DataContext db = new DataContext())
            {
                DateTime StartDate = new DateTime(DateTime.Now.Year,01,01);
                DateTime EndDate = new DateTime(DateTime.Now.Year,12,30);

                // TypeID = 1 ==> Recive
                // TypeID = 2 ==> Pay
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
