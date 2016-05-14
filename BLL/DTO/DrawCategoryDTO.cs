using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BLL.DTO
{
    public class DrawCategoryDTO
    {
        public int DrawCategoryId { get; set; }
        [MaxLength(128)]
        public string DrawCategoryValue { get; set; }
    }
}
