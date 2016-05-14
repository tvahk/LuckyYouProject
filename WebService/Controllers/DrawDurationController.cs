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
    public class DrawDurationController : ApiController
    {
        private readonly IUOW _uow;
        private BLL.Service.DrawDurationService _service;

        public DrawDurationController(IUOW uow)
        {
            _uow = uow;
            _service = new BLL.Service.DrawDurationService();
        }

        // GET: api/Draws
        /// <summary>
        /// Get the list of draws
        /// </summary>
        /// <returns></returns>
        public List<DrawDurationDTO> GetDrawDurations()
        {
            return _service.getAllDrawDurations();
        }


        // GET: api/Draws/5
        /// <summary>
        /// Get a single draw
        /// </summary>
        /// <param name="id">Draw Id</param>
        /// <returns></returns>
        [ResponseType(typeof(DrawDuration))]
        public IHttpActionResult GetDrawDuration(int id)
        {
            var draw = _service.getDrawDurationById(id);
            if (draw == null)
            {
                return NotFound();
            }

            return Ok(draw);
        }

       
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrawDuration(int id, DrawDuration drawDuration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drawDuration.DrawDurationId)
            {
                return BadRequest();
            }

            _uow.DrawDurations.Update(drawDuration);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrawDurationExists(id))
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
        [ResponseType(typeof(DrawDuration))]
        public IHttpActionResult PostDraw(DrawDuration drawDuration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.DrawDurations.Add(drawDuration);

            _uow.Commit();

            return CreatedAtRoute("DefaultApi", new { id = drawDuration.DrawDurationId }, drawDuration);
        }

        //// DELETE: api/Draws/5
        ///// <summary>
        ///// Delete a single draw
        ///// </summary>
        ///// <param name="id">Draw Id</param>
        ///// <returns></returns>
        //[ResponseType(typeof(Draw))]
        //public IHttpActionResult DeleteDraw(int id)
        //{

        //    DrawCategory drawCategory = _uow.DrawCategories.GetById(id);
        //    if (drawCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    _uow.Draws.Delete(drawCategory);
        //   _uow.Commit();

        //    return Ok(drawCategory);
        //}

        ///// <summary>
        ///// Release the unmanaged resources
        ///// </summary>
        ///// <param name="disposing">Disposing Name</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _uow.DrawCategories.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool DrawDurationExists(int id)
        {
            return _uow.DrawDurations.All.Any(x => x.DrawDurationId == id);
        }
    }
}