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
    public class DrawSizeRepository : WebApiRepository<DrawSizeAPI>, IDrawSizeRepository
    {
        public DrawSizeRepository(string baseUrl) : base(baseUrl)
        {
        }
        public DrawSizeAPI FindDrawSizeById(int sizeId)
        {
            var response = WebClient.GetAsync("DrawSize/" + sizeId).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsAsync<DrawSizeAPI>().Result;
                return res;
            }

            return new DrawSizeAPI();
        }

    }
}
