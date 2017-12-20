using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Models;

using Services;
using Domain.Entity;
using WEB.Models;

namespace WEB.Controllers
{

    public class ArtworkController : Controller
    {
        ArtworkService service = null;
         UserServices serviceUser = null;
        CategoryService serviceCategory = null;
        public ArtworkController()
        {
            service = new ArtworkService();
            serviceUser = new UserServices();
            serviceCategory =new CategoryService();
        }


        // GET: Artwork
        public ActionResult Index()
        {
            

            IEnumerable<artwork> ListArtwork = service.GetMany();
            List<ArtworkModels> ListArtworkModels = new List<ArtworkModels>();



            ShowroomdbContext cnx = new ShowroomdbContext();
            foreach (artwork ar in cnx.artworks)
            {
                var am = new ArtworkModels();
                am.id = ar.id;
                am.description = ar.description;
                am.name = ar.name;
                am.photo = ar.phot;


                ListArtworkModels.Add(am);
            }
            return View(ListArtworkModels);
        }

        // GET: Artwork/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artwork = service.GetById(id);
            ArtworkDetailsModel ArtDetModel = new ArtworkDetailsModel();
            if (artwork == null)
            {
                return HttpNotFound();
            }

            ArtDetModel.id = artwork.id;
            ArtDetModel.name = artwork.name;
            ArtDetModel.description = artwork.description;
            ArtDetModel.photo = artwork.phot;
          //  ArtDetModel.Category = serviceCategory.GetCategoryById(id);
        //    ArtDetModel.NameArtist = serviceUser.GetArtistByArtworkId(id);
          
            
            return View(ArtDetModel);
        }

        // GET: Artwork/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artwork/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtworkModels artwork, HttpPostedFileBase upload)
        {
            try
            {
                // TODO: Add insert logic here


                
                if (ModelState.IsValid)
                {
                    ShowroomdbContext ctx = new ShowroomdbContext();
                    artwork a = new artwork();
                    a.description = artwork.description;
                    a.name = artwork.name;
                    if (upload != null && upload.ContentLength > 0)
                    {
                        a.phot = Guid.NewGuid().ToString() + Path.GetFileName(upload.FileName);
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Content/ArtworkImages"), a.phot));
                    }
                    
                   
                    a.artist_id = (int)Session["LogedUserid"];
                    Debug.WriteLine((int)Session["LogedUserid"]);
                    a.category_id = 1;
                    ctx.artworks.Add(a);
                    ctx.SaveChanges();
                   // service.Add(a);
                  //service.Commit();
                    return RedirectToAction("Index");
                }
                return View();


            }
            catch
            {
                return View();
            }
        }

        // GET: Artwork/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            artwork art = service.GetById(id);
            ArtworkModels artM = new ArtworkModels();
            if (art == null)
            {
                return HttpNotFound();
            }
            else
            {
                artM.id = art.id;
                artM.name = art.name;
                artM.description = art.description;
                artM.photo = art.phot;

                return View(artM);
            }
            
        }

        // POST: Artwork/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArtworkModels artM)
        {

            artwork a = service.GetById(id);
            a.id = artM.id;
            a.name = artM.name;
            a.description = artM.description;
            a.phot = artM.photo;
            service.Update(a);
            service.Commit();
           return RedirectToAction("Index");
            
         
         
        }

        // GET: Artwork/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            artwork artwork = service.GetById(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // POST: Artwork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            ShowroomdbContext cnx = new ShowroomdbContext();
            artwork artwork = cnx.artworks.Find(id);
            cnx.artworks.Remove(artwork);
            cnx.SaveChanges();
            return RedirectToAction("Index");



        }

    }
}
