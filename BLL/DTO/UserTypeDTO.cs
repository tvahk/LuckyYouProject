using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DomainLogic.IdentityModels;

namespace BLL.DTO
{
    public class UserTypeDTO
    {
        public int UserTypeId { get; set; }
        public string UsertTypeValue { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
