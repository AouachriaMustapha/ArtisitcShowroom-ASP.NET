using Data.Models;
using Domain.Entity;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    
    public class LoginController : Controller
    {
        RentSpaceservices rs = new RentSpaceservices();
        SpaceServices sp = new SpaceServices();
        MettingServices ms = new MettingServices();
        UserServices us = new UserServices();
        // GET: Login
        public ActionResult authentification(user u)
        {
               
                var user = us.Get(model => model.login.Equals(u.login) && model.password.Equals(u.password));
                if (user != null )
                {
                if (user.type.Equals("artist")) {

                    Session.Add("LoggedUser", user.login);
                    Session["LogedUserLogin"] = user.login;
                    Session["LogedUserid"] = user.id;
                    Session["Logedusermail"] = user.mail;
                    return RedirectToAction("profil");

                }if (user.type.Equals("owner"))
                {
                    Session.Add("LoggedUser", user.login);
                    Session["LogedUserLogin"] = user.login;
                    Session["LogedUserid"] = user.id;

                    return RedirectToAction("profilowner");


                }
                }
                else
                {
                    ViewBag.Message = "Failed Login or Password";
                }
            
            return View();
        }


        


        public ActionResult profil()
        {
            List<metting> pvm = new List<metting>();
            IEnumerable<metting> prod = ms.GetCofirmedmetting((int)Session["LogedUserid"]);

            foreach (var u in prod)
            {

                metting G = new metting

                {
                    fk_owner=u.fk_owner,
                    mettingDate = u.mettingDate,
                    place = u.place,
                    etat = u.etat,
                    user = us.GetById(u.fk_owner),
                    user1=us.GetById((int)Session["LogedUserid"])
                    

                };

                pvm.Add(G);

            }

            return View(pvm);

        }

        public ActionResult profilowner()
        {
            user u = us.GetById((int)Session["LogedUserid"]);


            return View(u);

        }






        public ActionResult detail(int id)
        {
            List<space> pvm = new List<space>();
            IEnumerable<space> prod = sp.GetMany(x=>x.owner_id==id);
            
            foreach (var u in prod)
            {

                space G = new space

                {
                    id = u.id,
                    name = u.name,
                    description = u.description,
                    adress = u.adress,
                    loulepar = u.loulepar,
                    rentalPrice = u.rentalPrice,
                    pic = u.pic,
                    owner_id=u.owner_id,

                    user = us.GetById(id)
                    

                };

                pvm.Add(G);

            }

            return View(pvm);
        }



        public ActionResult louer(int id)
        {
           
            space prod = sp.GetById(id);
            space a = new space
            {
                id = prod.id,
                name = prod.name,
                description = prod.description,
                adress = prod.description,
                rentalPrice = prod.rentalPrice,
                pic = prod.pic,
                user=us.GetById((int)prod.owner_id)

            };
           
            return View(prod);
        }

        [HttpPost, ActionName("louer")]
        [ValidateAntiForgeryToken]
        public ActionResult confirmlouer(int id ,space s)
        {

            space prod = sp.GetById(id);

            if (prod != null)
            {
                rentspace r = new rentspace {

                    fk_artist= (int)Session["LogedUserid"],
                    fk_space=prod.id,
                    rentDate=(DateTime)s.rentdate,
                    price=prod.rentalPrice
                };
                prod.disponibility = false;

                rs.Add(r);
                rs.Commit();

                sp.Update(prod);
                sp.Commit();
                return RedirectToAction("Index", "Paypal", new { ids = id });


            }

            return View();
        }





        public ActionResult Desponibility(int id)
        {
            int a =(int) sp.GetById(id).owner_id;
            user uss = us.GetById(a);
            List<rentspace> pvm = new List<rentspace>();
            IEnumerable<rentspace> prod =rs.SpaceDisponibility(id);
            foreach (var u in prod)
            {
                rentspace r = new rentspace {

                    fk_artist = u.fk_artist,
                    fk_space = u.fk_space,
                    rentDate = u.rentDate,
                    price=u.price,
                    user=us.GetById(u.fk_artist),
                    user1=uss,
                    space=sp.GetById(id)
     
                };
                pvm.Add(r);

            }

            
                return View(pvm);

        }







        public ActionResult Logout()
        {
            Session["LogedUserLogin"] = null;



            return RedirectToAction("authentification");

        }

    }

    
}