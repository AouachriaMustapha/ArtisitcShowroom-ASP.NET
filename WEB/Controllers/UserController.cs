using Domain.Entity;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class UserController : Controller
    {

        IUserServices iuser;

        // GET: User
        public ActionResult Profil(int id)
        {

            ViewBag.solde = Session["LogedSolde"];
          //  user u = iuser.Getuserbyid(1);

            return View();
        }












    }
}