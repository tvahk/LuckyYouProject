using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BLL.DTO
{
    public class DrawDurationDTO
    {
        public int DrawDurationId { get; set; }
        [Range(0, 9999999999)]
        public double DrawDurationValue { get; set; }
        [Range(0, 9999999999)]
        public int DrawDurationPrice { get; set; }
    }
}
