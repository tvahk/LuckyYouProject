using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;
using DomainLogic.IdentityModels;

namespace BLL.Service
{
    public class UserInDrawService
    {
        private DAL.Interfaces.IUserInDrawRepository _repo;
        //private DAL.Interfaces.IUserRepository _userRepository;
        private Factories.UserInDrawFactory _factory;

        public UserInDrawService()
        {
            //_userRepository = new UserRepository(new LuckyYouDbContext());
            this._repo = new DAL.Repositories.UserInDrawRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.UserInDrawFactory();
        }

        public List<DTO.UserInDrawDTO> getAllUsersInDraw()
        {
            return
               this._repo.GetAllUserInDrawsIncludedUserAndDraws().Select(
                   x => _factory.createBasicDTO(x)).ToList();
        }

        public DTO.UserInDrawDTO getUserInDrawById(int id)
        {
            var query = _repo.GetAllUserInDrawsIncludedUserAndDraws().FirstOrDefault(x => _factory.createBasicDTO(x).UserInDrawId == id);
            return new DTO.UserInDrawDTO()
            {
                UserInDrawId = query.UserInDrawId,
                UserInDrawDate = query.UserInDrawDate,
                FirstLastName = query.User.FirstLastName,
                DrawName = query.Draw.DrawName
            };
        }

        //public User UpdateUserScore(string userId)
        //{
        //    User user = new User();
        //    user = _userRepository.GetById(userId);

        //    if (user.Score.HasValue)
        //    {
        //        user.Score++;
        //    }
        //    else
        //    {
        //        user.Score = 1;
        //    }


        //    return user;
        //}
    }
}

