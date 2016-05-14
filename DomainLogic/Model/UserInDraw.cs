using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.IdentityModels;

namespace Domain
{
    public class UserInDraw
    {
        public int UserInDrawId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UserInDrawDate { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public int DrawId { get; set; }
        public Draw Draw { get; set; }
    }
}
