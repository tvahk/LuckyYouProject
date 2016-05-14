using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.ApiModel
{
    public class DrawAPI
    {
        public int DrawId { get; set; }

        public string DrawFacebookAddress { get; set; }
        public string FirstName { get; set; }
        public string ProductName { get; set; }
        public string DrawName { get; set; }
        public int DrawProductsAmount { get; set; }
        public string DrawCategory { get; set; }
        public string AgeGroup { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DrawStartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DrawEndDate { get; set; }
        [DataType(DataType.DateTime)]
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int DrawDurationId { get; set; }
        public int DrawSizeId { get; set; }
        public int DrawPriorityId { get; set; }
        public int DrawCategoryId { get; set; }
    }
}
