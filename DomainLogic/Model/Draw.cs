using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.IdentityModels;

namespace Domain
{
   public class Draw
    {
       public int DrawId { get; set; }

       [Range(0,100)]
       public int DrawProductsAmount { get; set; }
       [MaxLength(128)]
       public string AgeGroup { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DrawStartDate { get; set; }
        public string DrawName { get; set; }

        public string DrawFaceBookAddress { get; set; }

        public virtual List<Bill> Bills { get; set; }
       public virtual List<Winning> Winnings { get; set; }
       public virtual List<UserInDraw> UserInDraws { get; set; }
       public string UserId { get; set; }
       public User User { get; set; }
       public int ProductId { get; set; }
       public Product Product { get; set; }
       public int DrawCategoryId { get; set; }
       public DrawCategory DrawCategory { get; set; }
        public int DrawSizeId { get; set; }
        public DrawSize DrawSize { get; set; }
        public int DrawDurationId { get; set; }
        public DrawDuration DrawDuration { get; set; }
        public int DrawPriorityId { get; set; }
        public DrawPriority DrawPriority { get; set; }
    }
}
