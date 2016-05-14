using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.ApiModel
{
    public class UserAPI
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserAccountName { get; set; }
        //public string UserAccountPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Score { get; set; }
    }
}
