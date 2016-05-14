using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bill
    {
        public int BillId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BillDeadline { get; set; }
        public int DrawId { get; set; }
        public Draw Draw { get; set; }
        public double Total { get; set; }


           //getDuration()


           // int totl
           //  bill.Total
    }
}
