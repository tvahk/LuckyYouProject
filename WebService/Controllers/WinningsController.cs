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
using System.Web.Http.Results;
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
    /// Serve raw data of winnings in XML or JSON
    /// </summary>
    public class WinningsController : ApiController
    {
        private readonly IUOW _uow;
        private WinningService _winningService;

        public WinningsController(IUOW uow)
        {
            _uow = uow;
            _winningService = new WinningService();
        }

        // GET: api/Winnings
        /// <summary>
        /// Get the list of winnings
        /// </summary>
        /// <returns></returns>
        public List<WinningDTO> GetWinnings()
        {
            return _winningService.getAllWinnings();
        }

        // GET: api/Winnings/5
        /// <summary>
        /// Get a single winning
        /// </summary>
        /// <param name="id">Winning Id</param>
        /// <returns></returns>
        [ResponseType(typeof(Winning))]
        public IHttpActionResult GetWinning(int id)
        {
            var winning = _winningService.getWinningById(id);
        
            if (winning == null)
            {
                return NotFound();
            }

            return Ok(winning);
        }

        //How many wins have specific user
        // GET: api/Winning/CountWinnnings/
        [HttpGet]
        [Route("api/winning/countwinnings")]
        [ResponseType(typeof(int))]
        public IHttpActionResult CountUserWinnings(string userId)
        {
            return Ok(_winningService.CountUserWinnings(userId));
        }

        // PUT: api/Winnings/5
        /// <summary>
        /// Update a single winning
        /// </summary>
        /// <param name="id">Winning Id</param>
        /// <param name="winning">Winning Name</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWinning(int id, Winning winning)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != winning.WinningId)
            {
                return BadRequest();
            }

            _uow.Winnings.Update(winning);
            

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinningExists(id))
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

        // POST: api/Winnings
        /// <summary>
        /// Create a single winning
        /// </summary>
        /// <param name="winning">Winning Name</param>
        /// <returns></returns>
        [ResponseType(typeof(Winning))]
        public IHttpActionResult PostWinning(Winning winning)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User();
            user = _uow.Users.GetById(winning.UserId);
            if (user.Score.HasValue)
            {
                user.Score = user.Score + 5;
            }
            else
            {
                user.Score = 5;
            }
            _uow.Users.Update(user);
            _uow.Winnings.Add(winning);
           _uow.Commit();

            return CreatedAtRoute("DefaultApi", new { id = winning.WinningId }, winning);
        }

        // DELETE: api/Winnings/5
        /// <summary>
        /// Delete a single winning
        /// </summary>
        /// <param name="id">Winning Id</param>
        /// <returns></returns>
        [ResponseType(typeof(Winning))]
        public IHttpActionResult DeleteWinning(int id)
        {
            Winning winning = _uow.Winnings.GetById(id);
            if (winning == null)
            {
                return NotFound();
            }
            _uow.Winnings.Delete(winning);
            _uow.Commit();

            return Ok(winning);
        }

        /// <summary>
        /// Release the unmanaged resources
        /// </summary>
        /// <param name="disposing">Disposing Name</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               _uow.Winnings.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WinningExists(int id)
        {
            return _uow.Winnings.All.Any(x => x.WinningId == id);
        }
    }
}