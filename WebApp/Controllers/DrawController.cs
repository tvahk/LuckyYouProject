using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DALWebApi;
using DALWebApi.Interfaces;
using Domain;
using DomainLogic.ApiModel;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class DrawController : Controller
    {
        //private WebAppEFContext db = new WebAppEFContext();
        private readonly IWebApiUOW _uow;

        public DrawController()
        {
            _uow = new WebApiUow();
        }

        // GET: Draw
        public ActionResult Index(int? categoryId)
        {
            if(categoryId != null) {
                return View(_uow.Draws.AllDrawsByCategory((int)categoryId));
            }
            return View(_uow.Draws.All);

        }

        // GET: Draw/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawAPI draw = _uow.Draws.GetById(id);
            if (draw == null)
            {
                return HttpNotFound();
            }
            return View(draw);
        }

        // GET: Draw/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(_uow.User.All, "UserId", "FirstName");
            ViewBag.ProductId = new SelectList(_uow.Product.All, "ProductId", "ProductValue");
            ViewBag.DrawDurationId = new SelectList(_uow.DrawDuration.All, "DrawDurationId", "DrawDurationValue");
            ViewBag.DrawPriorityId = new SelectList(_uow.DrawPriority.All, "DrawPriorityId", "DrawPriorityValue");
            ViewBag.DrawSizeId = new SelectList(_uow.DrawSize.All, "DrawSizeId", "DrawSizeValue");
            ViewBag.DrawCategoryId = new SelectList(_uow.DrawCategory.All, "DrawCategoryId", "DrawCategoryValue"); 
            return View();
        }

        // POST: Draw/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DrawAPI draw)
        {
            if (ModelState.IsValid)
            {
                draw.DrawStartDate = Convert.ToDateTime("10/04/2016");
                _uow.Draws.Add(draw);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(_uow.User.All, "UserId", "FirstName");
            ViewBag.ProductId = new SelectList(_uow.Product.All, "ProductId", "ProductValue");
            ViewBag.DrawDurationId = new SelectList(_uow.DrawDuration.All, "DrawDurationId", "DrawDurationValue");
            ViewBag.DrawPriorityId = new SelectList(_uow.DrawPriority.All, "DrawPriorityId", "DrawPriorityValue");
            ViewBag.DrawSizeId = new SelectList(_uow.DrawSize.All, "DrawSizeId", "DrawSizeValue");
            ViewBag.DrawCategoryId = new SelectList(_uow.DrawCategory.All, "DrawCategoryId", "DrawCategoryValue");
            return View(draw);
        }

        // GET: Draw/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawAPI draw = _uow.Draws.GetById(id);
            if (draw == null)
            {
                return HttpNotFound();
            }
            return View(draw);
        }

        // POST: Draw/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DrawAPI draw)
        {
            if (ModelState.IsValid)
            {
                _uow.Draws.Update(draw.DrawId, draw);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(draw);
        }

        // GET: Draw/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawAPI draw = _uow.Draws.GetById(id);
            if (draw == null)
            {
                return HttpNotFound();
            }
            return View(draw);
        }

        // POST: Draw/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Draws.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }
    }
}
