using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BLL.DTO
{
    public class ProductTypeDTO
    {
        public int ProductTypeId { get; set; }
        [MaxLength(128)]
        public string ProductTypeValue { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
