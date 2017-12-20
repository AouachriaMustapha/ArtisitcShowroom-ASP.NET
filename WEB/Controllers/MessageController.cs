using Data.Models;
using Domain.Entity;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    public class MessageController : Controller
    {
        
        MessageServices mss = new MessageServices();
        UserServices us = new UserServices();



        [HttpPost]
        public ActionResult Inbox(string s)
        {
            List<message> pvm = new List<message>();
            IEnumerable<message> prod = mss.GetAllMsgbyreciever((int)Session["LogedUserid"]);

            if (!String.IsNullOrEmpty(s))
            {

                IEnumerable<message> y = mss.Recherche(s,(int)Session["LogedUserid"]);
                foreach (var u in y)
                {

                    message G = new message
                    {
                        idMessage = u.idMessage,
                        subject = u.subject,
                        text = u.text,
                        date = u.date

                    };

                    pvm.Add(G);


                }
                return View(pvm);
            }


            return View(prod);
        }


        public ActionResult Inbox()
        {
            List<message> pvm = new List<message>();
            IEnumerable<message> prod = mss.GetAllMsgbyreciever((int)Session["LogedUserid"]);


            foreach (var u in prod)
            {

                message G = new message
                {
                    idMessage = u.idMessage,
                    subject = u.subject,
                    text = u.text,
                    date = u.date,
                    user = us.GetById((int)u.idReceiver)

                };

                pvm.Add(G);


            }
            return View(prod);
        }
        // GET: Message
        public ActionResult ListMessage()
        {
            List<message> pvm = new List<message>();
            IEnumerable<message> prod = mss.GetAlLMsgBysender((int)Session["LogedUserid"]);

            foreach (var u in prod)
            {

                message G = new message
                {
                    idMessage=u.idMessage,
                    subject=u.subject,
                    text = u.text,
                    date=u.date,
                 

                };

                pvm.Add(G);


            }
            return View(pvm);
        }



        public ActionResult Create()
        {

            MessageModels msg = new MessageModels();

            msg.users = us.GetAllOwners().ToSelectListItems();

            return View(msg);

        }

        [HttpPost]
        public ActionResult Create(MessageModels ms)
        {

            user c = us.GetById((int)Session["LogedUserid"]);

            message msg = new message
            {  
                subject=ms.subject,
               date= System.DateTime.Now,
                idSender = (int)Session["LogedUserid"],
                text = ms.text,
                idReceiver= (int)ms.UserId
               
            };

            mss.Add(msg);
            mss.SaveChange();

            return RedirectToAction("ListMessage");

        }



        public ActionResult Delete(int id)
        {
            
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message prod = mss.GetById(id);
            if (prod == null)
            {
                return HttpNotFound();
            }
            return View(prod);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deletemsg(int id)
        {

            
            message prod = mss.GetById(id);

            mss.Delete(prod);
            mss.SaveChange();
            return RedirectToAction("ListMessage");
        }

        public ActionResult repondre(int id)
        {

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message m = mss.GetById(id);
            message msg = new message {
                idMessage=m.idMessage,
                idReceiver=m.idReceiver,
                idSender=m.idSender,
                user=us.GetById((int)m.idSender)


            };
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(msg);
        }

        [HttpPost, ActionName("repondre")]
        [ValidateAntiForgeryToken]
        public ActionResult repondremsg(int id, message a)
        {


            message prod = mss.GetById(id);
            message m = new message {
                date= System.DateTime.Now,
                subject=a.subject,
                text=a.text,
                idReceiver=prod.idSender,
                idSender=prod.idReceiver,
               
    
            };

            mss.Add(m);
            mss.SaveChange();
            return RedirectToAction("ListMessage");
        }


        public ActionResult Details (int id)
        {
            message m = mss.GetById(id);
          
            user a = us.GetById((int)m.idReceiver);

            message msg = new message{
                idMessage=m.idMessage,
                idReceiver=m.idReceiver,
                idSender=m.idSender,
                text=m.text,
                subject=m.subject,
                date=m.date,
                user=a

            };

            return View(msg);
        }

    }
}