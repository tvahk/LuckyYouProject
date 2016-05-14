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
    public class DrawPriorityRepository : WebApiRepository<DrawPriorityAPI>, IDrawPriorityRepository
    {
        public DrawPriorityRepository(string baseUrl) : base(baseUrl)
        {
        }

    }
}
