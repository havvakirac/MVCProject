using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SUNetwork.Models;
using Microsoft.AspNet.Identity;
using SUNetwork.DbHelper;

namespace SUNetwork.Controllers
{
    public class UsersFriendshipController : Controller
    {
        private SELCUKDBEntities1 db = new SELCUKDBEntities1();

        [Authorize]
        // GET: UsersFriendship
        public ActionResult Index()
        {
            return View(db.USERS_FRENDSHIP.ToList());
        }

        [Authorize]
        // GET: UsersFriendship/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS_FRENDSHIP uSERS_FRENDSHIP = db.USERS_FRENDSHIP.Find(id);
            if (uSERS_FRENDSHIP == null)
            {
                return HttpNotFound();
            }
            return View(uSERS_FRENDSHIP);
        }

        [Authorize]
        // GET: UsersFriendship/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: UsersFriendship/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MAIN_USER_ID,USER_ID,START_DATE,STATUS_CODE,UPDATE_DATE")] USERS_FRENDSHIP uSERS_FRENDSHIP)
        {
            if (ModelState.IsValid)
            {
                db.USERS_FRENDSHIP.Add(uSERS_FRENDSHIP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uSERS_FRENDSHIP);
        }

        [Authorize]
        // GET: UsersFriendship/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS_FRENDSHIP uSERS_FRENDSHIP = db.USERS_FRENDSHIP.Find(id);
            if (uSERS_FRENDSHIP == null)
            {
                return HttpNotFound();
            }
            return View(uSERS_FRENDSHIP);
        }

        [Authorize]
        // POST: UsersFriendship/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MAIN_USER_ID,USER_ID,START_DATE,STATUS_CODE,UPDATE_DATE")] USERS_FRENDSHIP uSERS_FRENDSHIP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSERS_FRENDSHIP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSERS_FRENDSHIP);
        }

        [Authorize]
        // GET: UsersFriendship/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS_FRENDSHIP uSERS_FRENDSHIP = db.USERS_FRENDSHIP.Find(id);
            if (uSERS_FRENDSHIP == null)
            {
                return HttpNotFound();
            }
            return View(uSERS_FRENDSHIP);
        }

        [Authorize]
        // POST: UsersFriendship/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            USERS_FRENDSHIP uSERS_FRENDSHIP = db.USERS_FRENDSHIP.Find(id);
            db.USERS_FRENDSHIP.Remove(uSERS_FRENDSHIP);
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


        [Authorize]
        public ActionResult SearchProfile(string name)
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
            return View(db.SP_SEARCH_USER_PROFILE(name, User.Identity.GetUserId()));
        }


        [Authorize]
        public ActionResult SearchDetailUserProfile()
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
            if (UsersDb.IsUserActivated())
            {
                return RedirectToAction("Activation", "Users");
            }
            ViewBag.JobList = new SelectList(DbHelper.Helper.GetirParametreListesi("P_JOB"), "CODE", "VALUE");
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchDetailUserProfileList([Bind(Include = "NAME,JOB")] USERS uSERS)
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
            ViewBag.JobList = new SelectList(DbHelper.Helper.GetirParametreListesi("P_JOB"), "CODE", "VALUE");
            return View(db.SP_SEARCH_DETAIL_USER_PROFILE(uSERS.NAME, uSERS.JOB, User.Identity.GetUserId()));
        }

        [Authorize]
        public ActionResult SendRequest(string id)
        {
            USERS u = db.USERS.Find(id);

            if (u != null)
            {
                USERS_FRENDSHIP item = new USERS_FRENDSHIP();
                item.USER_ID = id;
                item.MAIN_USER_ID = User.Identity.GetUserId();
                item.START_DATE = DateTime.Now;
                item.STATUS_CODE = u.IS_PRIVATE == "E" ? "W" : "A";
                item.UPDATE_DATE = DateTime.Now;
                db.USERS_FRENDSHIP.Add(item);
                db.SaveChanges();
            }

            return View();
        }

        /// <summary>
        /// Takipçiler
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Following()
        {
            if (UsersDb.IsUserActivated())
            {
                return RedirectToAction("Activation", "Users");
            }

            var sp = db.SP_GET_ACTIONS(User.Identity.GetUserId());
            foreach (var item in sp)
            {
                ViewBag.MesajSayisi = " " + item.UNREAD_MESSAGE;
                ViewBag.TakipciSayisi = " " + item.FOLLOWERS;
                ViewBag.TakipEttiklerim = " " + item.FOLLOWING;
                ViewBag.TakipIstekleri = " " + item.UNACCEPTED_REQUEST;
                ViewBag.GrupDaveti = " " + item.UNACCEPTED_INVITATION;
            }
            return View(db.SP_GET_FOLLOWERS(User.Identity.GetUserId(), 1, ""));
        }


        /// <summary>
        /// Takip Edilenler
        /// </summary
        [Authorize]
        public ActionResult Followers()
        {
            if (UsersDb.IsUserActivated())
            {
                return RedirectToAction("Activation", "Users");
            }

            var sp = db.SP_GET_ACTIONS(User.Identity.GetUserId());
            foreach (var item in sp)
            {
                ViewBag.MesajSayisi = " " + item.UNREAD_MESSAGE;
                ViewBag.TakipciSayisi = " " + item.FOLLOWERS;
                ViewBag.TakipEttiklerim = " " + item.FOLLOWING;
                ViewBag.TakipIstekleri = " " + item.UNACCEPTED_REQUEST;
                ViewBag.GrupDaveti = " " + item.UNACCEPTED_INVITATION;
            }
            return View(db.SP_GET_FOLLOWERS(User.Identity.GetUserId(), 2, ""));
        }

        [Authorize]
        public ActionResult AcceptFriendRequest(string id)
        {
            db.SP_FRIENDSHIP_ACTION(id, User.Identity.GetUserId(), "A");
            return RedirectToAction("Following", "UsersFriendship");
        }


        [Authorize]
        public ActionResult Reject(string id)
        {
            db.SP_FRIENDSHIP_ACTION(id, User.Identity.GetUserId(), "R");
            return RedirectToAction("Following", "UsersFriendship");

        }

        [Authorize]
        public ActionResult UnFollow(string id)
        {

            db.SP_FRIENDSHIP_ACTION(id, User.Identity.GetUserId(), "P");
            return RedirectToAction("Following", "UsersFriendship");

        }


        [Authorize]
        public ActionResult EngelKaldir(string id)
        {

            db.SP_FRIENDSHIP_ACTION(id, User.Identity.GetUserId(), "K");
            return RedirectToAction("Following", "UsersFriendship");

        }

        [Authorize]
        public ActionResult BlockFriend(string id)
        {
            db.SP_FRIENDSHIP_ACTION(id, User.Identity.GetUserId(), "B");

            USERS_FRENDSHIP item = new USERS_FRENDSHIP();
            item.USER_ID = id;
            item.MAIN_USER_ID = User.Identity.GetUserId();
            item.START_DATE = DateTime.Now;
            item.STATUS_CODE = "B";
            item.UPDATE_DATE = DateTime.Now;
            db.USERS_FRENDSHIP.Add(item);
            db.SaveChanges();

            return RedirectToAction("Following", "UsersFriendship");
        }

        [Authorize]
        public ActionResult DetailFriend(string id)
        {
            return View();
        }

        [Authorize]
        public ActionResult SendMessage(string id)
        {
            ViewBag.UserId = id;

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


        [Authorize]
        public ActionResult MesajOlustur(string gonIcerik, string receiverUserId)
        {
            var m = new MESSAGES();

            m.READ_DATE = DateTime.Now;
            m.RECEIVER_USER_ID = receiverUserId;
            m.SENDER_USER_ID = User.Identity.GetUserId();
            m.UPDATE_DATE = DateTime.Now;
            m.MESSAGE = gonIcerik;
            m.RECEIVE_DATE = DateTime.Now;
            m.READ_FLAG = "H";
            m.SEND_DATE = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.MESSAGES.Add(m);
                db.SaveChanges();
                return Json("Eklendi");
            }

            return Json("Hata Oluştu");
        }

        [Authorize]
        public ActionResult MesajList(int kayitSayisi, string userId2)
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
            List<ModelMessage> sonuc = new List<ModelMessage>();
            
            var list = db.SP_USERS_MESSAGE_LIST(kayitSayisi,User.Identity.GetUserId(),userId2);

            foreach (var item in list)
            {
                ModelMessage model = new ModelMessage();

                model.Message = item.MESSAGE;
                model.Id = item.ID.ToString();
                model.ReceiveUserId = item.USER_ID;
                model.UserName = item.NAME;
                model.UserSurname = item.SURNAME;
                model.NameSurname = item.NAME_SURNAME;
                model.SenderUserId = item.USER_ID;
                model.SendDate = item.SEND_DATE.ToLongDateString();
                model.ReadDate = item.READ_DATE.ToLongDateString();
                model.ReadFlag = item.READ_FLAG;
                model.PhotoPath = item.PHOTO_PATH.Replace("~", "");
                model.UpdateDate = item.UPDATE_DATE.ToLongDateString();
                model.SendReceiverFlag = item.SEND_RECEIVER_FLAG;
                sonuc.Add(model);
            }
            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult MessagePage()
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
            if (UsersDb.IsUserActivated())
            {
                return RedirectToAction("Activation", "Users");
            }
            List<ModelMessage> sonuc = new List<ModelMessage>();

            var list = db.SP_MESSAGE_ALL(User.Identity.GetUserId());

            foreach (var item in list)
            {
                ModelMessage model = new ModelMessage();

                model.Message = item.MESSAGE;
                model.Id = item.ID.ToString();
                model.UserId = item.USER_ID;
                model.UserName = item.NAME;
                model.UserSurname = item.SURNAME;
                model.NameSurname = item.NAME_SURNAME;               
                model.SendDate = item.SEND_DATE.ToLongDateString();
                model.ReadDate = item.READ_DATE.ToLongDateString();
                model.ReadFlag = item.READ_FLAG;
                model.PhotoPath = item.PHOTO_PATH;
                model.UpdateDate = item.UPDATE_DATE.ToLongDateString();
                model.SendReceiverFlag = item.SEND_RECEIVER_FLAG;
                sonuc.Add(model);
            }

            return View(sonuc);
        }

      

    }
}

