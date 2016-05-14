using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DrawCategory
    {
        public int DrawCategoryId { get; set; }
        [MaxLength(128)]
        public string DrawCategoryValue { get; set; }
        public virtual List<Draw> Draws { get; set; }
    }
}
