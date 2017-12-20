using Data.Infrastructure;
using Data.Models;
using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services 
{
    public class ExposureService : Service<exposure>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        SpaceServices sp = new SpaceServices();
        public ExposureService() : base(ut)
        {

        }


        public int Getlistidexposure(int id)
        {
            List<space> listsp = new List<space>();
            ShowroomdbContext cnx = new ShowroomdbContext();
            var List = new List<details>();
           //var list = ut.getRepository<details>().GetMany(a => a.exposure_id == id);
          foreach(var x in cnx.details)
            {
                if(x.exposure_id == id)
                List.Add(x);
            }
            
            foreach (details x in List)
            {


             if (!listsp.Contains(sp.GetById(x.fk_space)))
                {
                   listsp.Add(sp.GetById(x.fk_space));

                }
            }

            return listsp.Count;
        }




        public int GetIdByName(string name)
        {

            return ut.getRepository<exposure>().Get(a => a.name == name).id;
        }





        public void Archiver()
        {
            ShowroomdbContext cnx = new ShowroomdbContext();
            var a = ut.getRepository<exposure>().GetMany().ToList();
            foreach (var x in a)
            {


                if (x.EDate == DateTime.Now)
                {
                    x.Archiver = true;
                }
                else
                {
                    x.Archiver = false;
                }

                ut.getRepository<exposure>().Update(x);
                ut.Commit();
            }


        }


        public void Timer()
        {
            var DailyTime = "22:37:00";
            var timeParts = DailyTime.Split(new char[1] { ':' });

            while (true)
            {

                var dateNow = DateTime.Now;
                var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
                    int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));
                TimeSpan ts;
                if (date > dateNow)
                    ts = date - dateNow;
                else
                {
                    date = date.AddDays(1);
                    ts = date - dateNow;
                }

                //waits certan time and run the code
                Task.Delay(ts).Wait();

                Archiver();
            }
        }

        public class Stat
        {
            public user Artist { get; set; }
            public exposure Exposure { get; set; }
        }










    }
}
