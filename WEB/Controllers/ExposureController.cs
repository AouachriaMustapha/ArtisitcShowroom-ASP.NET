using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Data.Models;
using WEB.Helpers;

using Services;
using WEB.Models;
using Domain.Entity;

namespace WEB.Controllers
{
    public class ExposureController : Controller
    {
         ExposureService service = null;
         ArtworkService serviceA = null;
         SpaceServices ServiceS = null;
         UserServices ServiceU = null;
         ExpositionArtworkService ServicExpositionArtwork = null;
         ExpositionArtworkService ServiceArt = null;
        public ExposureController()
        {
            service = new ExposureService();
            serviceA = new ArtworkService();
            ServiceS = new SpaceServices();
            ServiceArt=new ExpositionArtworkService(); 
            ServiceU=new UserServices();
            ServicExpositionArtwork =new ExpositionArtworkService();
        }
        #region ExposureGet
        // GET: Exposure
        public ActionResult Index()
        {
            
            IEnumerable<exposure> ListExposure = service.GetMany();
            List<ExposureModel> ListExpositionModel = new List<ExposureModel>();
            //service.Archiver();
            ShowroomdbContext cnx = new ShowroomdbContext();
           
            
            foreach (exposure ex in cnx.exposures)
            {
                ExposureModel em = new ExposureModel();
                em.id = ex.id;
                em.startDate = ex.SDate;
                em.endDate = ex.EDate;
                em.name = ex.name;
                if(!ex.Archiver)
             ListExpositionModel.Add(em);
            }

            return View(ListExpositionModel);
        }
#endregion
        #region DetailGet
        // GET: Exposure/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<artwork> ListArtworkById = serviceA.ArtworkByIdArtwork(id);
            List<ArtworkForExposureModel> ArtById = new List<ArtworkForExposureModel>();

            ShowroomdbContext ctx = new ShowroomdbContext();
            

            //user Artist = ServiceU.GetById(u.fk_artist.Value);
            //ExpositionArtwork ExpositionArtwork = ServicExpositionArtwork.GetOneExpoByIdExpo(id);
            //space space = ServiceS.GetById(ExpositionArtwork.fk_space);
            //exposure exposure = service.GetById(id);
            //int? FkOwner = space.fk_owner;
            //user Owner = ServiceU.GetById(FkOwner.Value);

            if (ListArtworkById == null)
            {
                return HttpNotFound();
            }
         
            foreach (var x in ListArtworkById)
            {
                ArtworkForExposureModel ar = new ArtworkForExposureModel();
                
                user Artist = ServiceU.GetById((int)x.artist_id);
                ExpositionArtwork ExpositionArtwork = ServicExpositionArtwork.GetOneExpoByIdExpo(id);
                space space = ServiceS.GetById(ExpositionArtwork.fk_space);
                exposure exposure = service.GetById(id);
                int? FkOwner = space.owner_id;
                user Owner = ServiceU.GetById(FkOwner.Value);
                ar.id = x.id;
                ar.name = x.name;
                ar.photo = x.phot;
                ar.ArtistName = Artist.firstName+Artist.lastName;
                ar.StartDate = exposure.SDate.Value;
                ar.EndDate = exposure.EDate.Value;
                ar.SpaceName = space.name;
                ar.SpaceAddress = space.adress;
                ar.OwnerName = Owner.firstName + Owner.lastName;
                ar.Priority = ServicExpositionArtwork.GetByIdArtworkAndIdExposure(id, x.id);
                ArtById.Add(ar);

            }
            
            
            return View(ArtById.OrderBy(a =>a.Priority).ToList());
        }
        #endregion
        #region CreateGet
        // GET: Exposure/Create
        public ActionResult Create()
        {
#region Initialisation
            ExposureModel ExpoM = new ExposureModel();
            ShowroomdbContext ctx = new ShowroomdbContext();
            var z= serviceA.GetArtworkByIdArtist((int)@Session["LogedUserid"]);
            ExpoM.ArtworksOfArtist = z;
            foreach (var x in ExpoM.ArtworksOfArtist)
            {
                Debug.WriteLine("aaaaaaaaaaaaa"+x.name);
            }
           // ExpoM.Spaces = ServiceS.GetAllSpaves.ToSelectListItems();
           
            //ViewBag.Spaces = ServiceS.GetMany().Select(x => new SelectListItem {Text = x.name,Value = x.id.ToString()});
            List<space> listSpace = new List<space>();

            #endregion

           

            return View(ExpoM);
        }
#endregion
        #region CreatePost
        // POST: Exposure/Create
        [HttpPost]
      
        public ActionResult Create(ExposureModel exM)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    #region Intialisation
                    ShowroomdbContext ctx = new ShowroomdbContext();
                    exposure Expo = new exposure();
                    List<artwork> la = new List<artwork>();
                   
                    List<ArtworkForExposureModel> ArtForExpo = new List<ArtworkForExposureModel>();
                    ExpositionArtwork ar = new ExpositionArtwork();
                    #endregion
#region PopulateExposition
                    Expo.id = exM.id;
                    Expo.SDate = exM.startDate;
                    Expo.EDate = exM.endDate;
                    Expo.name = exM.name;
                    Expo.Archiver = false;
                    service.Add(Expo);
                    service.Commit();
                    #endregion
#region PopulateExposureArtworks

                    var a=exM.Order;

                    Debug.WriteLine(a);

                    int IdEpo = (service.GetIdByName(Expo.name));
                    
                    Debug.WriteLine(IdEpo);
                    DateTime DatePriority = DateTime.Now;
                    Debug.WriteLine(DatePriority);
                    int FkSpace = 1;
                    String[] Priorities = a.Split(',');
                    for (int i = 0; i < Priorities.Length; i++)
                    {
                        Debug.WriteLine("idddddddddds"+Priorities[i]);
                        Debug.WriteLine("priiiiiiot"+(i+1));
                    }
                    
                    for (int i = 0; i < Priorities.Length; i++)
                    {
                        
                        ExpositionArtwork EA = new ExpositionArtwork();
                        EA.exposureId = IdEpo;
                        EA.DateExpoPriority = DatePriority;
                        EA.fk_space = FkSpace;
                        EA.artworkId = Convert.ToInt32(Priorities[i]);
                        EA.Priority = i+1;
                        ServiceArt.Add(EA);
                        ServiceArt.Commit();

                    }




                    #endregion

                    return RedirectToAction("Index");
                }

                return View();

            }
            catch
            {
                return View();
            }
        }
#endregion
        #region EditGet
        // GET: Exposure/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<artwork> ListArtworkById = serviceA.ArtworkByIdArtwork(id);
            List<ArtworkForExposureModel> ArtById = new List<ArtworkForExposureModel>();

            ShowroomdbContext ctx = new ShowroomdbContext();


           

            if (ListArtworkById == null)
            {
                return HttpNotFound();
            }
            
            foreach (var x in ListArtworkById)
            {
                ArtworkForExposureModel ar = new ArtworkForExposureModel();

                user Artist = ServiceU.GetById((int)x.artist_id);
                ExpositionArtwork ExpositionArtwork = ServicExpositionArtwork.GetOneExpoByIdExpo(id);
                space space = ServiceS.GetById(ExpositionArtwork.fk_space);
                exposure exposure = service.GetById(id);
                int? FkOwner = space.owner_id;
                user Owner = ServiceU.GetById(FkOwner.Value);
                ar.id = x.id;
                ar.name = x.name;
                ar.photo = x.phot;
                ar.ArtistName = Artist.firstName + Artist.lastName;
                ar.StartDate = exposure.SDate.Value;
                ar.EndDate = exposure.EDate.Value;
                ar.SpaceName = space.name;
                ar.SpaceAddress = space.adress;
                ar.OwnerName = Owner.firstName + Owner.lastName;
                ar.Priority = ServicExpositionArtwork.GetByIdArtworkAndIdExposure(id, x.id);
                ArtById.Add(ar);

            }


            return View(ArtById.OrderBy(a => a.Priority).ToList());
            
        }
        #endregion
        #region EditPost       
        // POST: Exposure/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ArtworkForExposureModel eA)
        {
            try
            {
                List<ExpositionArtwork> eafc =new List<ExpositionArtwork>();
                eafc = ServicExpositionArtwork.ExpositionArtworksByIdExposition(id);
                String[] Priorities = eA.Order.Split(',');
                for (int i = 0; i < Priorities.Length ; i++)
                {
                    ExpositionArtwork expA = new ExpositionArtwork();
                    expA.exposureId = id;


                    expA.artworkId = Convert.ToInt32(Priorities[i]);
                    expA.Priority = i + 1;
                    ServicExpositionArtwork.Update(expA);
                    ServicExpositionArtwork.Commit();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
#endregion
        #region DeleteGet
        // GET: Exposure/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exposure exposure = service.GetById(id);
            if (exposure== null)
            {
                return HttpNotFound();
            }
            return View(exposure);
        }
        #endregion
        #region Delete
        // POST: Exposure/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ShowroomdbContext ctx = new ShowroomdbContext();
            var x = ctx.exposures.Find(id);
            x.Archiver = true;

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        //public ActionResult Chart()

        //{


        //    var artist = ServiceU.GetMany();
        //    var a = service.Statistic();
        //    //var s = new ArtistExposition();
        //    List<string> artistName = new List<string>();
        //    List <int> countExpo = new List<int>();
        //    foreach (var u in artist)
        //    {

        //        artistName.Add(u.firstName);
        //        countExpo.Add(a.GroupBy(w => w.Artist).Count());
             
        //    }
        //    new Chart(width: 800, height: 400)
        //   .AddTitle("Number of exposition By artist ")
        //   .AddSeries("Default", chartType: "Pie",
        //    xValue: artistName, xField: "arist",
        //    yValues: countExpo, yFields: "expo").Write("png");
        //    return null;

        //}
    }
}
