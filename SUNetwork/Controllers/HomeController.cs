using Microsoft.AspNet.Identity;
using SUNetwork.Constant;
using SUNetwork.DbHelper;
using SUNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SUNetwork.Controllers
{
    public class HomeController : Controller
    {
        private SELCUKDBEntities1 db = new SELCUKDBEntities1();


        [Authorize]
        public ActionResult Index()
        {
            if (UsersDb.IsUserActivated())
            {
                return RedirectToAction("Activation", "Users");
            }

            var sp = db.SP_GET_ACTIONS(User.Identity.GetUserId());
            foreach (var item in sp)
            {
                ViewBag.MesajSayisi =" " + item.UNREAD_MESSAGE;
                ViewBag.TakipciSayisi = " " + item.FOLLOWERS;
                ViewBag.TakipEttiklerim =" "+ item.FOLLOWING;
                ViewBag.TakipIstekleri =" "+ item.UNACCEPTED_REQUEST;
               ViewBag.GrupDaveti = " " + item.UNACCEPTED_INVITATION;
            }
            
           return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



      

   }
}
