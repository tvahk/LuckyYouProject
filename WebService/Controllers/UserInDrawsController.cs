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
using Domain;
using DomainLogic.IdentityModels;

namespace WebApi.Controllers
{
    /// <summary>
    /// Serve raw data of user in draws in XML or JSON
    /// </summary>
    public class UserInDrawsController : ApiController
    {
        private readonly IUOW _uow;
        private UserInDrawService _userInDrawService;

        public UserInDrawsController(IUOW uow)
        {
            _userInDrawService = new UserInDrawService();
            _uow = uow;
        }

        // GET: api/UserInDraws
        /// <summary>
        /// Get the list of user in draws
        /// </summary>
        /// <returns></returns>
        public List<UserInDrawDTO> GetUserInDraws()
        {
            return _userInDrawService.getAllUsersInDraw();
        }

        // GET: api/UserInDraws/5
        /// <summary>
        /// Get a single user in draw
        /// </summary>
        /// <param name="id">User in draw Id</param>
        /// <returns></returns>
        [ResponseType(typeof(UserInDraw))]
        public IHttpActionResult GetUserInDraw(int id)
        {

            UserInDraw userInDraw = _uow.UserInDraws.GetById(id);
            if (userInDraw == null)
            {
                return NotFound();
            }

            return Ok(userInDraw);
        }

        // PUT: api/UserInDraws/5
        /// <summary>
        /// Update a single user in draw
        /// </summary>
        /// <param name="id">User in draw Id</param>
        /// <param name="userInDraw">User in draw Name</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserInDraw(int id, UserInDraw userInDraw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userInDraw.UserInDrawId)
            {
                return BadRequest();
            }
            _uow.UserInDraws.Update(userInDraw);

            try
            {
               _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInDrawExists(id))
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

        // POST: api/UserInDraws
        /// <summary>
        /// Create a single user in draw
        /// </summary>
        /// <param name="userInDraw">User in draw Name</param>
        /// <returns></returns>
        [ResponseType(typeof(UserInDraw))]
        public IHttpActionResult PostUserInDraw(UserInDraw userInDraw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User user = new User();
            user = _uow.Users.GetById(userInDraw.UserId);
            if (user.Score.HasValue)
            {
                user.Score++;
            }
            else
            {
                user.Score = 1;
            }
            _uow.Users.Update(user);
            _uow.UserInDraws.Add(userInDraw);
            _uow.Commit();

            return CreatedAtRoute("DefaultApi", new { id = userInDraw.UserInDrawId }, userInDraw);
        }

        // DELETE: api/UserInDraws/5
        /// <summary>
        /// Delete a single user in draw
        /// </summary>
        /// <param name="id">User in draw Id</param>
        /// <returns></returns>
        [ResponseType(typeof(UserInDraw))]
        public IHttpActionResult DeleteUserInDraw(int id)
        {
            UserInDraw userInDraw = _uow.UserInDraws.GetById(id);
            if (userInDraw == null)
            {
                return NotFound();
            }

            _uow.UserInDraws.Delete(userInDraw);
            _uow.Commit();

            return Ok(userInDraw);
        }

        /// <summary>
        /// Release the unmanaged resources
        /// </summary>
        /// <param name="disposing">Disposing Name</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.UserInDraws.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserInDrawExists(int id)
        {
            return _uow.UserInDraws.All.Any(e => e.UserInDrawId == id);
        }
    }
}