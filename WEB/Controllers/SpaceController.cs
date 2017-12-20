using Data.Models;
using Domain.Entity;
using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class SpaceController : Controller
    {
        SpaceServices service = new SpaceServices();
        ExposureService es = new ExposureService();

        //public SpaceController()
        //{
        //    service = new SpaceService();
        //}
        // GET: Space
        public ActionResult Index()
        {
            IEnumerable<space> ListSpace = service.GetMany();
            IList<SpaceViewModel> ListSpaceModel = new List<SpaceViewModel>();
            foreach(space s in ListSpace)
            {
                SpaceViewModel svm = new SpaceViewModel();
               // svm.Id = s.id;
                svm.Adress = s.adress;
                svm.Description = s.description;
                
                svm.Prix = (int)s.rentalPrice;
                svm.Urlimage = s.pic;
                ListSpaceModel.Add(svm);
            }
            return View(ListSpaceModel);
        }

        // GET: Space/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            space space = service.GetById(id);
            if(space == null)
            {
                return HttpNotFound();
            }
            return View(space);
        }

        // GET: Space/Create
        public ActionResult Create()

        {
            return View();
        }

        // POST: Space/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpaceViewModel svm, HttpPostedFileBase upload)
        {
            string userid = this.Session["LogedUserid"].ToString();
            try
            {
                // TODO: Add insert logic here


                if (ModelState.IsValid)
                {
                    ShowroomdbContext ctx = new ShowroomdbContext();
                    space s = new space();
                    s.adress = svm.Adress;
                    s.rentalPrice = svm.Prix;
                    s.description = svm.Description;
                    s.owner_id = Int32.Parse(userid);
                    if (upload != null && upload.ContentLength > 0)
                    {
                        

                        s.pic = Guid.NewGuid().ToString() + Path.GetFileName(upload.FileName);
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Content/SpaceImages"), s.pic));

                    }
                    ctx.spaces.Add(s);
                    ctx.SaveChanges();
                    //service.Add(s);
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

        // GET: Space/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            space s = service.GetById(id);
            SpaceViewModel svm = new SpaceViewModel();
            if(s== null)
            {
                return HttpNotFound();
            }
            else
            {
                svm.Id = s.id;
                svm.Prix = (int)s.rentalPrice;
                svm.Adress = s.adress;
                svm.Description = s.description;
                svm.Urlimage = s.pic;
                return View(svm);

            }
            
        }

        // POST: Space/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id,SpaceViewModel svm)
        {
            space s = service.GetById(id);
            s.id = svm.Id;
            s.adress = svm.Adress;
            s.description = svm.Description;
            s.rentalPrice = svm.Prix;
            s.pic = svm.Urlimage;
            service.Update(s);
            service.Commit();
            return RedirectToAction("Index");
        }

        // GET: Space/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            space s = service.GetById(id);
            if(s == null)
            {
                return HttpNotFound();
            }

            return View(s);
        }

        // POST: Space/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, FormCollection collection)
        {
            ShowroomdbContext cnt = new ShowroomdbContext();
            space s = service.GetById(id);
            service.Delete(s);
            service.Commit();
            //cnt.spaces.Remove(s);
            //cnt.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult afficher()
        {


            var x = es.GetMany();
            return View(x);
        }
        public ActionResult chercher(int id)
        {


            var x = service.find(id);
            return View(x);
            
        }





        public ActionResult MapEventByRegion()
        {
            List<MapModel> mp = new List<MapModel>();
            List<String> listAd = service.AllAdress();
            foreach (var item in listAd)
            {
                int c = service.GetCountAddresse(item);
                String code = "";
                String color = "";
                if (item == "Ariana") { code = "Ariana"; color = "#d8854f"; }
                else if (item == "Tunis") { code = "Tunis"; color = "#86a965"; }
                else if (item == "Gafsa") { code = "Gafsa"; color = "#a7a737"; }
                else if (item == "Gabes") { code = "Gabes"; color = "#de4c4f"; }
                else if (item == "Sfax") { code = "Sfax"; color = "#86a965"; }
                else if (item == "Jandouba") { code = "Jandouba"; color = "#d8854f"; }
                else if (item == "Australia") { code = "AU"; color = "#8aabb0"; }
                else if (item == "Austria") { code = "AT"; color = "#d8854f"; }
                else if (item == "Azerbaijan") { code = "AZ"; color = "#d8854f"; }
                else if (item == "Bahrain") { code = "BH"; color = "#eea638"; }
                else if (item == "Bangladesh") { code = "BD"; color = "#eea638"; }
                else if (item == "Belarus") { code = "BY"; color = "#d8854f"; }
                else if (item == "Belgium") { code = "BE"; color = "#d8854f"; }
                else if (item == "Benin") { code = "BJ"; color = "#de4c4f"; }
                else if (item == "Brazil") { code = "BR"; color = "#86a965"; }
                else if (item == "Canada") { code = "CA"; color = "#a7a737"; }
                else if (item == "Cameroon") { code = "ARCM"; color = "#de4c4f"; }
                else if (item == "Chile") { code = "CL"; color = "#Argentina"; }
                else if (item == "China") { code = "CN"; color = "#eea638"; }
                else if (item == "Egypt") { code = "EG"; color = "#de4c4f"; }
                else if (item == "India") { code = "IN"; color = "#eea638"; }
                else if (item == "Italy") { code = "JM"; color = "#a7a737"; }
                else if (item == "Japan") { code = "JP"; color = "#eea638"; }
                else if (item == "United States") { code = "US"; color = "#a7a737"; }
                else if (item == "Tunisia") { code = "TN"; color = "#de4c4f"; }
                else if (item == "Morocco") { code = "MA"; color = "#de4c4f"; }
                else if (item == "France") { code = "FR"; color = "#d8854f"; }
                else if (item == "Spain") { code = "ES"; color = "#d8854f"; }
                else if (item == "Qatar") { code = "QA"; color = "#eea638"; }
                mp.Add(
                    new MapModel
                    {
                        name = item + " " + c,
                        value = c,
                        code = code,
                        color = color
                    }
                );

            }
            ViewBag.List = mp;
            return View();
        }




        public ActionResult Chart()

        {

            //IEnumerable<space> deals = service.GetMany();
            IEnumerable<exposure> Exposure = es.GetMany();
            List<String> dates = new List<String>();
            List<int> CBA = new List<int>();
            foreach (exposure u in Exposure)
            {
                dates.Add(u.startDate);
                Debug.WriteLine("***********" + u.startDate);
                Debug.WriteLine("***********" + es.Getlistidexposure(u.id));
                CBA.Add(es.Getlistidexposure(u.id));
            }
             new Chart(width: 800, height: 400)
            .AddTitle("Number of spaces exposed at certain date ")
            .AddSeries("Default", chartType: "Pie",
             xValue: dates, xField: "date exposure",
             yValues: CBA, yFields: "space").Write("png");
            return null;

        }

















    }
}
