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
    public class ProductDTO
    {
        public int ProductId { get; set; }
        [MaxLength(128)]
        public string ProductValue { get; set; }
        public string FirstLastName { get; set; }
        public string ProductType { get; set; }
    }
}
