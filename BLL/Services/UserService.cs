using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Service
{
    public class UserService
    {
        private DAL.Interfaces.IUserRepository _repo;
        private Factories.UserFactory _factory;
        public UserService()
        {
            this._repo = new DAL.Repositories.UserRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.UserFactory();
        }

        public List<DTO.UserDTO> getAllUsers()
        {
            return
                this._repo.All.Select(
                    x => _factory.createBasicDTO(x)).ToList();
        }

        //public UserInDrawDTO RegisterUserIntoDraw(UserDTO user, DrawDTO draw)
        //{
        //    var userId = user.UserId;
        //    var drawId = draw.DrawId;

        //    return new UserInDrawDTO()
        //    {
        //        UserId = userId,
        //        DrawId = drawId
        //    };
        //}
        public DTO.UserDTO getUserById(string id)
        {
            var query = _repo.All.Where(x => _factory.createBasicDTO(x).UserId == id).FirstOrDefault();
            return new DTO.UserDTO()
            {
                UserId = query.Id,
                UserName = query.UserName,
                FirstName = query.FirstName,
                LastName = query.LastName,
                Score = query.Score
                //UserTypeId = query.UserTypeId
            };
        }

        public List<DTO.UserDTO> getUsersByScore()
        {
            return this._repo.GetUsersByScore().Select(x => _factory.createBasicDTO(x)).ToList();
            
        }
    }
}
