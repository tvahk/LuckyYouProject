using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.Service;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;
using DomainLogic.IdentityModels;

namespace WebApi.Controllers
{
    /// <summary>
    /// Serve raw data of users in XML or JSON
    /// </summary>
    public class UsersController : ApiController
    {
        private readonly IUOW _uow;
        private BLL.Service.UserService _service;

        public UsersController(IUOW uow)
        {
            _uow = uow;
            _service = new BLL.Service.UserService();
        }

        // GET: api/Users
        /// <summary>
        /// Get the list of users
        /// </summary>
        /// <returns></returns>
        public List<UserDTO> GetUsers()
        {
            return _service.getAllUsers();
        }

        // GET: api/UsersByScore
        /// <summary>
        /// Get the list of users sorted by their score
        /// </summary>
        /// <returns></returns>
        [Route("api/users/usersbyscore")]
        public List<UserDTO> GetUsersByScore()
        {
            return _service.getUsersByScore();
        }

        // GET: api/Users/5
        /// <summary>
        /// Get a single user
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string id)
        {
            var user = _service.getUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        /// <summary>
        /// Update a single user
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="user">User Name</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(string id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            _uow.Users.Update(user);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users/RegisterUserToDraw
        /// <summary>
        /// Register user into draw
        /// </summary>
        [Route("api/users/registerusertodraw")]
        [ResponseType(typeof(UserInDraw))]
        public IHttpActionResult RegisterUserToDraw(UserInDraw userInDraw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            userInDraw.UserInDrawDate = DateTime.Now;
            userInDraw.Draw = _uow.Draws.GetById(userInDraw.UserInDrawId);
            userInDraw.User = _uow.Users.GetById(userInDraw.UserId);
            _uow.UserInDraws.Add(userInDraw);
            _uow.Commit();

            return Ok();
        }
        // POST: api/Users
        /// <summary>
        /// Create a single user
        /// </summary>
        /// <param name="user">User Name</param>
        /// <returns></returns>
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.Users.Add(user);
            _uow.Commit();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        /// <summary>
        /// Delete a single user
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {

            User user = _uow.Users.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _uow.Users.Delete(user);
            _uow.Commit();

            return Ok(user);
        }


        private bool UserExists(string id)
        {
            return _uow.Users.All.Any(e => e.Id == id);
        }
    }
}