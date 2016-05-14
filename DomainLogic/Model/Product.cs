using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.IdentityModels;

namespace Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        [MaxLength(128)]
        public string ProductValue { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public virtual List<Draw> Draws { get; set; }
    }
}
