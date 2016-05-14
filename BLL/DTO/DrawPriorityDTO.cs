using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BLL.DTO
{
    public class DrawPriorityDTO
    {
        public int DrawPriorityId { get; set; }
        public int DrawPriorityValue { get; set; }

        [Range(0, 9999999999)]
        public int DrawPriorityPrice { get; set; }
    }
}
