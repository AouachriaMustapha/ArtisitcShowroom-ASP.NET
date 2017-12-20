using Data.Models;
using Domain.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using Services;
using WEB.Helpers;
using WEB.Models;
using System.Net;
using System;

namespace WEB.Controllers
{
    public class MettingController : Controller
    {
        MettingServices ms = new MettingServices();
        UserServices us = new UserServices();


        public ActionResult listOwnerMetting()
        {

            List<metting> pvm = new List<metting>();
            IEnumerable<metting> prod = ms.GetAlLownerMetting((int)Session["LogedUserid"]);

            foreach (var u in prod)
            {

                metting G = new metting

                { fk_artist = u.fk_artist,
                    mettingDate = u.mettingDate,
                    place = u.place,
                    etat = u.etat,
                    fk_owner=u.fk_owner


                };

                pvm.Add(G);

            }


            return View(pvm);
        }


        public ActionResult OHistorymetting()
        {

            List<metting> pvm = new List<metting>();
            IEnumerable<metting> prod = ms.GetOhistoryMetting((int)Session["LogedUserid"]);

            foreach (var u in prod)
            {

                metting G = new metting

                {
                    fk_artist = u.fk_artist,
                    mettingDate = u.mettingDate,
                    place = u.place,
                    etat = u.etat,
                    fk_owner = u.fk_owner,
                    user=us.GetById(u.fk_artist)


                };

                pvm.Add(G);

            }


            return View(pvm);
        }




        [HttpPost]
        public ActionResult Index(string s)
        {
            List<metting> pvm = new List<metting>();
            IEnumerable<metting> prod = ms.GetAlLMetting((int)Session["LogedUserid"]);
            if (!String.IsNullOrEmpty(s))
            {

                IEnumerable<metting> y = ms.RechercheA(s,(int)Session["LogedUserid"]);
                foreach (var u in y)
                {

                    metting G = new metting
                    {
                        fk_artist=u.fk_artist,
                        fk_owner=u.fk_owner,
                        mettingDate = u.mettingDate,
                        place = u.place,
                        etat = u.etat


                    };

                    pvm.Add(G);

                }
                return View(pvm);
            }


            return View(prod);
        }

        // GET: Metting
        public ActionResult Index()
        {

            List<metting> pvm = new List<metting>();
            IEnumerable<metting> prod = ms.GetAlLMetting((int)Session["LogedUserid"]);

            foreach (var u in prod)
            {

                metting G = new metting
                {
                    fk_owner=u.fk_owner,
                    fk_artist=u.fk_artist,
                    mettingDate = u.mettingDate,
                    place = u.place,
                    etat=u.etat,
                    
                    

                };

                pvm.Add(G);

            }


            return View(pvm);
        }







        [HttpGet]
        public ActionResult ListOwners()
        {
            List<user> pvm = new List<user>();
            IEnumerable<user> prod = us.GetAllOwners();

            foreach (var u in prod)
            {

                user G = new user
                {
                    id = u.id,
                    firstName = u.firstName,
                    lastName = u.lastName,
                    age = u.age,
                    mail = u.mail,
                    city = u.city

                };

                pvm.Add(G);

            }

            return View(pvm);
        }

        
        public ActionResult Meet()
        {

            MettingModels mett = new MettingModels();

            mett.users = us.GetAllOwners().ToSelectListItems();
           
            return View(mett);

        }

        [HttpPost]
        public ActionResult Meet(MettingModels mett)
        {
            user c = us.GetById((int)Session["LogedUserid"]);

            metting met = new metting
            {
                etat = "WAITING",
                mettingDate=mett.mettingDate,
                fk_artist = (int)Session["LogedUserid"],
                place = mett.place,
                fk_owner = (int)mett.UserId
            };
              

            ms.Add(met);
            ms.SaveChange();
            return RedirectToAction("Index");

        }


        public ActionResult Confirm(int id1, int id2, string e, string p)
        {

            if (id1 == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metting prod = ms.Getmetting(id1, id2, e, p);
            user u = us.GetById(id1);
            MettingModels mod = new MettingModels
            {

                fk_artist = prod.fk_artist,
                fk_owner = prod.fk_owner,
                etat = prod.etat,
                mettingDate = prod.mettingDate,
                place = prod.place,
                u = prod.user



            };

            return View(mod);
        }


        [HttpPost, ActionName("Confirm")]
        [ValidateAntiForgeryToken]
        public ActionResult confirme(int id1, int id2, string e, string p, MettingModels m)
        {
            

            user c = us.GetById((int)Session["LogedUserid"]);

            metting prod = ms.Getmetting(id1, id2, e, p);


            user u = us.GetById(id1);
            if (prod != null) {

                prod.etat = "CONFIRMED";
               
                ms.Update(prod);
                ms.SaveChange();

                return RedirectToAction("listOwnerMetting");
            }
            return RedirectToAction("ListOwners");
        }




        public ActionResult Delete(int id1, int id2, string e, string p)
        {

            if (id1 == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          metting  prod = ms.Getmetting( id1,  id2,  e,  p);
            user u = us.GetById(id1);
            MettingModels mod = new MettingModels {

                fk_artist = prod.fk_artist,
                fk_owner = prod.fk_owner,
                etat = prod.etat,
                mettingDate = prod.mettingDate,
                place = prod.place,
                u=prod.user



            };
            
            return View(mod);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deletemsg(int id1, int id2, string e, string p)
        {


            metting prod = ms.Getmetting( id1,  id2,  e,  p);

            ms.Delete(prod);
            ms.SaveChange();
            return RedirectToAction("Index");
        }



      
    }
}
