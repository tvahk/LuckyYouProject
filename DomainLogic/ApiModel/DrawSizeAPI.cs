using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.ApiModel
{
    public class DrawSizeAPI
    {
        public int DrawSizeId { get; set; }
        public int DrawSizeValue { get; set; }
        [Range(0, 9999999)]
        public int DrawSizePrice { get; set; }
    }
}
