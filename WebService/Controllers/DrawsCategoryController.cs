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
    public class DrawCategoryController : ApiController
    {
        private readonly IUOW _uow;
        private BLL.Service.DrawCategoryService _service;

        public DrawCategoryController(IUOW uow)
        {
            _uow = uow;
            _service = new BLL.Service.DrawCategoryService();
        }

        // GET: api/Draws
        /// <summary>
        /// Get the list of draws
        /// </summary>
        /// <returns></returns>
        public List<DrawCategoryDTO> GetDrawCategories()
        {
            return _service.getAllDrawCategories();
        }


        // GET: api/Draws/5
        /// <summary>
        /// Get a single draw
        /// </summary>
        /// <param name="id">Draw Id</param>
        /// <returns></returns>
        [ResponseType(typeof(Draw))]
        public IHttpActionResult GetDrawCategory(int id)
        {
            var draw = _service.getDrawCategoryById(id);
            if (draw == null)
            {
                return NotFound();
            }

            return Ok(draw);
        }

       
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrawCategory(int id, DrawCategory drawCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drawCategory.DrawCategoryId)
            {
                return BadRequest();
            }

            _uow.DrawCategories.Update(drawCategory);

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
        [ResponseType(typeof(DrawCategory))]
        public IHttpActionResult PostDraw(DrawCategory drawCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.DrawCategories.Add(drawCategory);

            _uow.Commit();

            return CreatedAtRoute("DefaultApi", new { id = drawCategory.DrawCategoryId }, drawCategory);
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

            DrawCategory drawCategory = _uow.DrawCategories.GetById(id);
            if (drawCategory == null)
            {
                return NotFound();
            }

            _uow.Draws.Delete(drawCategory);
           _uow.Commit();

            return Ok(drawCategory);
        }

        /// <summary>
        /// Release the unmanaged resources
        /// </summary>
        /// <param name="disposing">Disposing Name</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.DrawCategories.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrawExists(int id)
        {
            return _uow.DrawCategories.All.Any(x => x.DrawCategoryId == id);
        }
    }
}