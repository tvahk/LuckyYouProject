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
    public class UserRepository : WebApiRepository<UserAPI>, IUserRepository
    {
        public UserRepository(string baseUrl) : base(baseUrl)
        {
        }
        public ICollection<UserAPI> AllUsersSortedByScore()
        {
            var response = WebClient.GetAsync("usersbyscore/").Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsAsync<List<UserAPI>>().Result;
                return res;
            }

            return new List<UserAPI>();
        }
    }
}
