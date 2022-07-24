using Microsoft.AspNet.Identity;
using SUNetwork.DbHelper;
using SUNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SUNetwork.Controllers
{
    public class AdminController : Controller
    {
        private SELCUKDBEntities1 db = new SELCUKDBEntities1();

        /////////////////////////////////////////////////    USER     ///////////////////////////////////////////////////////////////////////////       

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var sp = db.SP_GET_ACTIONS(User.Identity.GetUserId());
            foreach (var item in sp)
            {
                ViewBag.MesajSayisi = " " + item.UNREAD_MESSAGE;
                ViewBag.TakipciSayisi = " " + item.FOLLOWERS;
                ViewBag.TakipEttiklerim = " " + item.FOLLOWING;
                ViewBag.TakipIstekleri = " " + item.UNACCEPTED_REQUEST;
                ViewBag.GrupDaveti = " " + item.UNACCEPTED_INVITATION;
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult UserList()
        {
            return View(db.USERS.ToList());
        }

        [Authorize(Roles = "admin")]
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


        [Authorize(Roles = "admin")]
        public ActionResult UserEdit(string id)
        {
           
            if (id == null)
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
            return View(db.USERS.Find(id));

        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(USERS usr, HttpPostedFileBase PHOTO_PATH)
        {
            USERS ITEM = db.USERS.Find(usr.USER_ID);
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




                return RedirectToAction("UserList");
            }
            return View(usr);
        }


        // POST: Users/Create
        [Authorize(Roles = "admin")]
        public ActionResult AddAdmin(string id)
        {
            AspNetUserRoles aspNetUserRoles = new AspNetUserRoles();
            aspNetUserRoles.UserId = id;
            aspNetUserRoles.RoleId="1";
            if (ModelState.IsValid)
            {
                db.AspNetUserRoles.Add(aspNetUserRoles);
                db.SaveChanges();
                return RedirectToAction("UserList", "Admin");
            }

            return View(aspNetUserRoles);
        }

        [Authorize(Roles = "admin")]
       public ActionResult UserDelete(string id)
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

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("UserDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UserDeleteConfirmed(string id)
        {
            USERS uSERS = db.USERS.Find(id);
            db.USERS.Remove(uSERS);

            AspNetUsers asuSERS = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(asuSERS);

            db.SaveChanges();

            return RedirectToAction("UserList","Admin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


////////////////////////////////////////////////   ACTIVITY     ///////////////////////////////////////////////////////////////////////////       

        [Authorize(Roles = "admin")]
        public ActionResult ActivityList()
        {
            return View(db.SP_ACTIVITY_LIST(10));
        }

        [Authorize(Roles = "admin")]
        public ActionResult ActivityDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVITY aCTIVITY = db.ACTIVITY.Find(id);
            if (aCTIVITY == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVITY);
        }


        [Authorize(Roles = "admin")]
        public ActionResult ActivityEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVITY aCTIVITY = db.ACTIVITY.Find(id);
            if (aCTIVITY == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVITY);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActivityEdit([Bind(Include = "ID,USER_ID,ACTIVITY_TYPE,DESCRIPTION,STATUS_CODE,UPDATE_DATE")] ACTIVITY aCTIVITY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTIVITY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCTIVITY);
        }

        [Authorize(Roles = "admin")]
        public ActionResult ActivityDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVITY aCTIVITY = db.ACTIVITY.Find(id);
            if (aCTIVITY == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVITY);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("ActivityDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ActivityDeleteConfirmed(int id)
        {
            ACTIVITY aCTIVITY = db.ACTIVITY.Find(id);
            db.ACTIVITY.Remove(aCTIVITY);
            db.SaveChanges();
            return RedirectToAction("ActivityList","Admin");
        }

////////////////////////////////////////////////////////     GROUP      ///////////////////////////////////////////////////////////////////////////       

        [Authorize(Roles = "admin")]
        public ActionResult GroupList()
        {
            return View(db.USERS_GROUP.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult GroupDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS_GROUP uSERS_GROUP = db.USERS_GROUP.Find(id);
            if (uSERS_GROUP == null)
            {
                return HttpNotFound();
            }
            return View(uSERS_GROUP);
        }

        [Authorize(Roles = "admin")]
        // GET: USERS_GROUP/Edit/5
        public ActionResult GroupEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS_GROUP uSERS_GROUP = db.USERS_GROUP.Find(id);
            if (uSERS_GROUP == null)
            {
                return HttpNotFound();
            }
            return View(uSERS_GROUP);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GroupEdit([Bind(Include = "ID,GROUP_NAME,CREATE_DATE,USER_ID,STATUS_CODE,UPDATE_DATE")] USERS_GROUP uSERS_GROUP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSERS_GROUP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GroupList");
            }
            return View(uSERS_GROUP);
        }

        [Authorize(Roles = "admin")]
        public ActionResult GroupDelete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS_GROUP uSERS_GROUP = db.USERS_GROUP.Find(id);
            if (uSERS_GROUP == null)
            {
                return HttpNotFound();
            }
            return View(uSERS_GROUP);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("GroupDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult GroupDeleteConfirmed(long id)
        {
            USERS_GROUP uSERS_GROUP = db.USERS_GROUP.Find(id);
            db.USERS_GROUP.Remove(uSERS_GROUP);
            db.SaveChanges();
            return RedirectToAction("GroupList");
        }

////////////////////////////////////////////////////////     GROUP ACTIVITY      ///////////////////////////////////////////////////////////////////////////       


        [Authorize(Roles = "admin")]
        public ActionResult GroupActivityList()
        {
            return View(db.GROUP_ACTIVITY.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult GroupActivityDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GROUP_ACTIVITY gROUP_ACTIVITY = db.GROUP_ACTIVITY.Find(id);
            if (gROUP_ACTIVITY == null)
            {
                return HttpNotFound();
            }
            return View(gROUP_ACTIVITY);
        }

        [Authorize(Roles = "admin")]
        public ActionResult GroupActivityCreate()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GroupActivityCreate([Bind(Include = "ID,GROUP_ID,USER_ID,DESCRIPTION,UPDATE_DATE")] GROUP_ACTIVITY gROUP_ACTIVITY)
        {
            if (ModelState.IsValid)
            {
                db.GROUP_ACTIVITY.Add(gROUP_ACTIVITY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gROUP_ACTIVITY);
        }

        //[Authorize(Roles = "admin")]
        //public ActionResult GroupActivityEdit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GROUP_ACTIVITY gROUP_ACTIVITY = db.GROUP_ACTIVITY.Find(id);
        //    if (gROUP_ACTIVITY == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(gROUP_ACTIVITY);
        //}

        //[Authorize(Roles = "admin")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult GroupActivityEdit([Bind(Include = "ID,GROUP_ID,USER_ID,DESCRIPTION,UPDATE_DATE")] GROUP_ACTIVITY gROUP_ACTIVITY)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(gROUP_ACTIVITY).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(gROUP_ACTIVITY);
        //}

        [Authorize(Roles = "admin")]
        public ActionResult GroupActivityDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GROUP_ACTIVITY gROUP_ACTIVITY = db.GROUP_ACTIVITY.Find(id);
            if (gROUP_ACTIVITY == null)
            {
                return HttpNotFound();
            }
            return View(gROUP_ACTIVITY);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("GroupActivityDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult GroupActivityDeleteConfirmed(int id)
        {
            GROUP_ACTIVITY gROUP_ACTIVITY = db.GROUP_ACTIVITY.Find(id);
            db.GROUP_ACTIVITY.Remove(gROUP_ACTIVITY);
            db.SaveChanges();
            return RedirectToAction("GroupActivityList");
        }

////////////////////////////////////////////////////////    PARAMETRE      ///////////////////////////////////////////////////////////////////////////       

        [Authorize(Roles = "admin")]
        public ActionResult ParameterList()
        {
            return View(db.PARAMETER.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult ParameterDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAMETER pARAMETER = db.PARAMETER.Find(id);
            if (pARAMETER == null)
            {
                return HttpNotFound();
            }
            return View(pARAMETER);
        }

        [Authorize(Roles = "admin")]
        public ActionResult ParameterCreate()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterCreate([Bind(Include = "PARAMETER_CODE,CODE,VALUE")] PARAMETER pARAMETER)
        {
            if (ModelState.IsValid)
            {
                db.PARAMETER.Add(pARAMETER);
                db.SaveChanges();
                return RedirectToAction("ParameterList");
            }

            return View(pARAMETER);
        }

        [Authorize(Roles = "admin")]
        public ActionResult ParameterEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAMETER pARAMETER = db.PARAMETER.Find(id);
            if (pARAMETER == null)
            {
                return HttpNotFound();
            }
            return View(pARAMETER);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterEdit([Bind(Include = "PARAMETER_CODE,CODE,VALUE")] PARAMETER pARAMETER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARAMETER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pARAMETER);
        }

        [Authorize(Roles = "admin")]
        public ActionResult ParameterDelete()
        {
            
            PARAMETER pARAMETER = db.PARAMETER.Find();
            if (pARAMETER == null)
            {
                return HttpNotFound();
            }
            return View(pARAMETER);
        }

        // POST: PARAMETERs/Delete/5
        [HttpPost, ActionName("ParameterDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ParameterDeleteConfirmed()
        {
            PARAMETER pARAMETER = db.PARAMETER.Find();
            db.PARAMETER.Remove(pARAMETER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}