using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SUNetwork.Models;
using SUNetwork.DbHelper;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using System.IO;

namespace SUNetwork.Controllers
{
    public class UsersController : Controller
    {
        private SELCUKDBEntities1 db = new SELCUKDBEntities1();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.USERS.ToList());
        }

        [Authorize]
        // GET: Users/Details/5
        public ActionResult Details()
        {
            if (UsersDb.IsUserActivated())
            {
                return RedirectToAction("Activation", "Users");
            }
            string id = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return HttpNotFound();
            }
            uSERS.USER_TYPE = Helper.GetParameterValue("P_USER_TYPE", uSERS.USER_TYPE);
            uSERS.DEPARTMAN_CODE = Helper.GetParameterValue("P_DEPARTMAN", uSERS.DEPARTMAN_CODE);
            uSERS.JOB = Helper.GetParameterValue("P_JOB", uSERS.JOB);


            var sp = db.SP_GET_ACTIONS(User.Identity.GetUserId());
            foreach (var item in sp)
            {
                ViewBag.MesajSayisi = " " + item.UNREAD_MESSAGE;
                ViewBag.TakipciSayisi = " " + item.FOLLOWERS;
                ViewBag.TakipEttiklerim = " " + item.FOLLOWING;
                ViewBag.TakipIstekleri = " " + item.UNACCEPTED_REQUEST;
                ViewBag.GrupDaveti = " " + item.UNACCEPTED_INVITATION;
            }
            return View(uSERS);
        }


        [Authorize]
        public ActionResult UserDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return HttpNotFound();
            }

            uSERS.USER_TYPE = Helper.GetParameterValue("P_USER_TYPE", uSERS.USER_TYPE);
            uSERS.DEPARTMAN_CODE = Helper.GetParameterValue("P_DEPARTMAN", uSERS.DEPARTMAN_CODE);
            uSERS.JOB = Helper.GetParameterValue("P_JOB", uSERS.JOB);
            return View(uSERS);
        }

        [Authorize]
        //GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

   


        // POST: Users/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NAME,SURNAME,USER_TYPE,START_DATE,FINISH_DATE,PHOTO_PATH,GENDER,DEPARTMAN_CODE,JOB")] USERS usr, HttpPostedFileBase photo)
        {

            usr.USER_ID = User.Identity.GetUserId();
            usr.UPDATE_DATE = DateTime.Now;

            if (ModelState.IsValid)
            {
                //if (photo == null)
                //{
                //    WebImage img = new WebImage(photo.InputStream);
                //    FileInfo fotoinfo = new FileInfo(photo.FileName);
                //    string newfoto = fotoinfo.Name;
                //    usr.PHOTO_PATH = "~/Content/ResimProfil/" + fotoinfo.Name;
                //    img.Resize(800, 350);
                //    img.Save("~/Content/ResimProfil/" + newfoto);
                //}


                db.USERS.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(usr);
        }

        [Authorize]
        public ActionResult Edit()
        {
            string userID = User.Identity.GetUserId();
            if (userID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            ViewBag.GenderList = new SelectList(DbHelper.Helper.GetirParametreListesi("P_GENDER"), "CODE", "VALUE");
            ViewBag.JobList = new SelectList(DbHelper.Helper.GetirParametreListesi("P_JOB"), "CODE", "VALUE");
            ViewBag.UserTypeList = new SelectList(DbHelper.Helper.GetirParametreListesi("P_USER_TYPE"), "CODE", "VALUE");
            ViewBag.DepartmanList = new SelectList(DbHelper.Helper.GetirParametreListesi("P_DEPARTMAN"), "CODE", "VALUE");
            ViewBag.StartList = new SelectList(DbHelper.Helper.GetStartYears(), "CODE", "VALUE");
            ViewBag.FinishList = new SelectList(DbHelper.Helper.GetSFinishYears(), "CODE", "VALUE");
            ViewBag.IsPrivateList = new SelectList(DbHelper.Helper.GetirParametreListesi("P_YES_NO"), "CODE", "VALUE");

            return View(db.USERS.Find(userID));
        }

        [Authorize]
        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(USERS usr, HttpPostedFileBase PHOTO_PATH)
        {
            USERS ITEM = db.USERS.Find(User.Identity.GetUserId());
            ITEM.NAME = usr.NAME;
            ITEM.SURNAME = usr.SURNAME;
            ITEM.USER_TYPE = usr.USER_TYPE;
            ITEM.START_DATE = usr.START_DATE;
            ITEM.FINISH_DATE = usr.FINISH_DATE;
            ITEM.GENDER = usr.GENDER;
            ITEM.DEPARTMAN_CODE = usr.DEPARTMAN_CODE;
            ITEM.JOB = usr.JOB;
            ITEM.IS_PRIVATE = usr.IS_PRIVATE;
            ITEM.UPDATE_DATE = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (PHOTO_PATH != null)
                {
                    string filePath = "~/Content/ResimProfil/" + User.Identity.GetUserId();
                    bool exists = System.IO.Directory.Exists(Server.MapPath(filePath));

                    if (!exists)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath(filePath));
                    }                    

                    WebImage img = new WebImage(PHOTO_PATH.InputStream);
                    FileInfo fotoinfo = new FileInfo(PHOTO_PATH.FileName);
                    ITEM.PHOTO_PATH = filePath + "/" + fotoinfo.Name;
                    img.Resize(800, 350);
                    img.Save(filePath + "/" + fotoinfo.Name);
                }
              

                db.Entry(ITEM).State = EntityState.Modified;
                db.SaveChanges();

               

                return RedirectToAction("Details");
            }
            return View(usr);
        }


        [Authorize]
        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return HttpNotFound();
            }
            return View(uSERS);
        }

        [Authorize]
        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            USERS uSERS = db.USERS.Find(id);
            db.USERS.Remove(uSERS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Activation()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Activation([Bind(Include = "CODE")] ACTIVATION aCTIVATION)
        {
            if (ModelState.IsValid)
            {
                bool isActivited = false;
                string userId = User.Identity.GetUserId();
                var activation = db.ACTIVATION.FirstOrDefault(p => p.CODE == aCTIVATION.CODE && p.USER_ID == userId);

                try
                {
                    if(activation !=null)                   
                    {
                        isActivited = UsersDb.ActivationUser(User.Identity.GetUserId());
                    }
                    if (isActivited)
                    {
                        return RedirectToAction("Edit", "Users");
                    }
                }
                catch (Exception)
                {
                }

                return View();
            }

            return View();
        }


        public ActionResult ActivationAccount(int code)
        {
            bool isActivited = false;
            var activation = db.ACTIVATION.Select(p => p.CODE == code && p.USER_ID == User.Identity.GetUserId());
            foreach (var item in activation)
            {
                isActivited = UsersDb.ActivationUser(User.Identity.GetUserId());

                break;
            }
            if (isActivited)
            {
                return RedirectToAction("Edit", "Users");
            }
            return View();
        }


        public ActionResult AdminPaneli()
        {
            return View();
        }


    }
}
