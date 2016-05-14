using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserAccountName { get; set; }
        //public string UserAccountPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Score { get; set; }
        //public int UserTypeId { get; set; }
    }
}
