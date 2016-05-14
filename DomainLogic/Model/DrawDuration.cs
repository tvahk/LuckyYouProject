using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DrawDuration
    {
        public int DrawDurationId { get; set; }
        [Range(0,9999999999)]
        public int DrawDurationValue { get; set; }
        [Range(0, 9999999999)]
        public int DrawDurationPrice { get; set; }

        public virtual List<Draw> Draws { get; set; }
    }
}
