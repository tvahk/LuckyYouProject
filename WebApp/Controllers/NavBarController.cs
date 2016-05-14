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

namespace WebApp.Controllers
{
    public class NavBarController : Controller
    {
        //private WebAppEFContext db = new WebAppEFContext();
        private readonly IWebApiUOW _uow;

        public NavBarController()
        {
            _uow = new WebApiUow();
        }

        [ChildActionOnly]
        public ActionResult NavBar()
        {

            var navbar = _uow.DrawCategory.All;
            return PartialView("_NavBar", navbar);
        }

        [ChildActionOnly]
        public ActionResult Rankings()
        {

            var rankings = _uow.User.AllUsersSortedByScore();
            return PartialView("_Rankings", rankings);
        }

    }
}