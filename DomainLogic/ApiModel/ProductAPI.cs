using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.ApiModel
{
    public class ProductAPI
    {
        public int ProductId { get; set; }
        [MaxLength(128)]
        public string ProductValue { get; set; }
        public string FirstLastName { get; set; }
        public string ProductType { get; set; }
    }
}
