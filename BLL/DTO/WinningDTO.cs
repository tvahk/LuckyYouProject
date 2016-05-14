using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DomainLogic.IdentityModels;

namespace BLL.DTO
{
    public class WinningDTO
    {
        public int WinningId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime WinningDate { get; set; }
        [MaxLength(256)]
        public string WinningComment { get; set; }

        public string FirstLastName { get; set; }
        public string DrawName { get; set; }
    }
}
