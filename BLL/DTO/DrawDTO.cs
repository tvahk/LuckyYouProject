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
    public class DrawDTO
    {
        public int DrawId { get; set; }

        [Range(0, 100)]
        public int DrawProductsAmount { get; set; }
        [MaxLength(128)]
        public string AgeGroup { get; set; }
         [DataType(DataType.DateTime)]
        public DateTime DrawStartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DrawEndDate { get; set; }

        public string DrawName { get; set; }
        public string DrawFacebookAddress { get; set; }

        public string FirstName { get; set; }
        public string ProductName { get; set; }
        public string DrawCategory { get; set; }
        public int DrawSize { get; set; }
        public int DrawDuration { get; set; }
        public int DrawPriority { get; set; }
    }
}
