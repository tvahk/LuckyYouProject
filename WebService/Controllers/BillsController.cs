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

namespace WebApi.Controllers
{
    /// <summary>
    /// Serve raw data of bills in XML or JSON
    /// </summary>
    public class BillsController : ApiController
    {
        private LuckyYouDbContext db = new LuckyYouDbContext();
        private DAL.Interfaces.IBillRepository _repo;
        private BLL.Service.BillService _service;

        public BillsController()
        {
            _repo = new BillRepository(db);
            _service = new BillService();
        }

        // GET: api/Bills
        /// <summary>
        /// Get the list of bills
        /// </summary>
        /// <returns></returns>
        public List<BillDTO> GetBills()
        {
            return _service.getAllBills();
        }

        // GET: api/Bills/5
        /// <summary>
        /// Get a single bill
        /// </summary>
        /// <param name="id">Bill Id</param>
        /// <returns></returns>
        [ResponseType(typeof(Bill))]
        public IHttpActionResult GetBill(int id)
        {
            var bill = _service.getBillById(id);

            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }

        // PUT: api/Bills/5
        /// <summary>
        /// Update a single bill
        /// </summary>
        /// <param name="id">Bill id</param>
        /// <param name="bill">Bill Name</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBill(int id, Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bill.BillId)
            {
                return BadRequest();
            }

            db.Entry(bill).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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

        // POST: api/Bills
        /// <summary>
        /// Create a new single bill
        /// </summary>
        /// <param name="bill">Bill Name</param>
        /// <returns></returns>
        [ResponseType(typeof(Bill))]
        public IHttpActionResult PostBill(Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bills.Add(bill);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bill.BillId }, bill);
        }

        // DELETE: api/Bills/5
        /// <summary>
        /// Delete a single bill
        /// </summary>
        /// <param name="id">Bill Id</param>
        /// <returns></returns>
        [ResponseType(typeof(Bill))]
        public IHttpActionResult DeleteBill(int id)
        {
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return NotFound();
            }

            db.Bills.Remove(bill);
            db.SaveChanges();

            return Ok(bill);
        }

        /// <summary>
        /// Release the unmanaged resources
        /// </summary>
        /// <param name="disposing">Disposing Name</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BillExists(int id)
        {
            return db.Bills.Count(e => e.BillId == id) > 0;
        }
    }
}