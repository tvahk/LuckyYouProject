using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.ApiModel;

namespace WebApp.ViewModels
{
    public class DrawIndexViewModel
    {
        public ICollection<DrawAPI> Draws { get; set; }
        public List<DrawSizeAPI> DrawsSize { get; set; }

    }
    public class DrawMoreInformationViewModel
    {
        public string DrawFacebookAddress { get; set; }
        public string FirstName { get; set; }
        public string ProductName { get; set; }
        public string DrawName { get; set; }
        public int DrawProductsAmount { get; set; }
        public string DrawCategory { get; set; }
        public string AgeGroup { get; set; }
        public DateTime DrawStartDate { get; set; }

    }
}