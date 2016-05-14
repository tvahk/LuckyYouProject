using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DALWebApi.Interfaces;
using Domain;
using DomainLogic.ApiModel;

namespace DALWebApi.Repositories
{
    public class DrawRepository : WebApiRepository<DrawAPI>, IDrawRepository
    {
        public DrawRepository(string baseUrl) : base(baseUrl)
        {
        }
        public ICollection<DrawAPI> AllDrawsByCategory(int categoryId)
        {
            var response = WebClient.GetAsync("drawscategory?drawCategoryId=" + categoryId).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsAsync<List<DrawAPI>>().Result;
                return res;
            }

            return new List<DrawAPI>();
        }
        public DrawAPI DrawByDrawId(int drawId)
        {
            var response = WebClient.GetAsync("" + drawId).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsAsync<DrawAPI>().Result;
                return res;
            }

            return new DrawAPI();
        }

    }
}
