using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using BLL.DTO;
using BLL.Factories;
using BLL.Service;
using DAL;
using DAL.Interfaces;
using Domain;

namespace WebApi.Controllers
{
    /// <summary>
    /// Serve raw data of draws in XML or JSON
    /// </summary>
    public class DrawsController : ApiController
    {
        private readonly IUOW _uow;
        private BLL.Service.DrawService _service;

        public DrawsController(IUOW uow)
        {
            _uow = uow;
            _service = new BLL.Service.DrawService();
        }

        // GET: api/Draws
        /// <summary>
        /// Get the list of draws
        /// </summary>
        /// <returns></returns>
        public List<DrawDTO> GetDraws()
        {
            return _service.getAllDraws();
        }

        // GET: api/DrawsByDuration
        /// <summary>
        /// Get the list of draws by duration
        /// </summary>
        /// <returns></returns>
        [Route("api/draws/drawsbyduration")]
        public List<DrawDTO> GetDrawsByDuration(int drawDurationId)
        {
            return _service.getDrawsByDurationId(drawDurationId);
        }
        [Route("api/draws/drawscategory")]
        public List<DrawDTO> GetDrawsByCategory(int drawCategoryId)
        {
            return _service.getAllDrawsByCategoryId(drawCategoryId);
        }
        [Route("api/draws/drawsbypriority")]
        public List<DrawDTO> GetDrawsByPriority(int drawPriorityId)
        {
            return _service.getAllDrawsByPriorityId(drawPriorityId);
        }
        // GET: api/Draws/5
        /// <summary>
        /// Get a single draw
        /// </summary>
        /// <param name="id">Draw Id</param>
        /// <returns></returns>
        [ResponseType(typeof(Draw))]
        public IHttpActionResult GetDraw(int id)
        {
            var draw = _service.getDrawById(id);
            if (draw == null)
            {
                return NotFound();
            }

            return Ok(draw);
        }

        // PUT: api/Draws/5
        /// <summary>
        /// Update a single draw
        /// </summary>
        /// <param name="id">Draw Id</param>
        /// <param name="draw">Draw Name</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDraw(int id, Draw draw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != draw.DrawId)
            {
                return BadRequest();
            }

            _uow.Draws.Update(draw);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrawExists(id))
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

        // POST: api/Draws
        /// <summary>
        /// Create a single draw
        /// </summary>
        /// <param name="draw">Draw Name</param>
        /// <returns></returns>
        //[Authorize(Roles= "Client, Admin")]
        [ResponseType(typeof(Draw))]
        public IHttpActionResult PostDraw(Draw draw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.Draws.Add(draw);

            Bill bill = new Bill();
            bill.DrawId = draw.DrawId;

            bill.Total = _service.GenerateBillFromDraws(draw.DrawDurationId, draw.DrawSizeId, draw.DrawPriorityId);
           
            _uow.Bills.Add(bill);

            _uow.Commit();

            return CreatedAtRoute("DefaultApi", new { id = draw.DrawId }, draw);
        }

        // DELETE: api/Draws/5
        /// <summary>
        /// Delete a single draw
        /// </summary>
        /// <param name="id">Draw Id</param>
        /// <returns></returns>
        [ResponseType(typeof(Draw))]
        public IHttpActionResult DeleteDraw(int id)
        {

            Draw draw = _uow.Draws.GetById(id);
            if (draw == null)
            {
                return NotFound();
            }

            _uow.Draws.Delete(draw);
           _uow.Commit();

            return Ok(draw);
        }

        /// <summary>
        /// Release the unmanaged resources
        /// </summary>
        /// <param name="disposing">Disposing Name</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Draws.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrawExists(int id)
        {
            return _uow.Draws.All.Any(x => x.DrawId == id);
        }
    }
}