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
using System.Web.Helpers;
using System.IO;

namespace SUNetwork.Controllers
{
    public class UsersGroupController : Controller
    {
        private SELCUKDBEntities1 db = new SELCUKDBEntities1();
        private Entity.Group gr = new Entity.Group();


        [Authorize]
        // GET: UsersGroup
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
            if (UsersDb.IsUserActivated())
            {
                return RedirectToAction("Activation", "Users");
            }
            string userId = User.Identity.GetUserId();
            return View(db.USERS_GROUP.Where(p=>p.USER_ID== userId).ToList());
        }

        [Authorize]
        // GET: UsersGroup/Details/5
        public ActionResult Details(long? id)
        {
            if (UsersDb.IsUserActivated())
            {
                return RedirectToAction("Activation", "Users");
            }
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

        [Authorize]
        // GET: UsersGroup/Create
        public ActionResult Create()
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
            return View();
        }

        // POST: UsersGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GROUP_NAME")] USERS_GROUP uSERS_GROUP)
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
            uSERS_GROUP.USER_ID = User.Identity.GetUserId();
            uSERS_GROUP.STATUS_CODE = "A";
            uSERS_GROUP.CREATE_DATE = DateTime.Today;
            uSERS_GROUP.UPDATE_DATE = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.USERS_GROUP.Add(uSERS_GROUP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uSERS_GROUP);
        }

        // GET: UsersGroup/Edit/5
        public ActionResult Edit(long? id)
        {
            if (UsersDb.IsUserActivated())
            {
                return RedirectToAction("Activation", "Users");
            }
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

        // POST: UsersGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GROUP_NAME,CREATE_DATE,USER_ID,STATUS_CODE,UPDATE_DATE")] USERS_GROUP uSERS_GROUP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSERS_GROUP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSERS_GROUP);
        }

        // GET: UsersGroup/Delete/5
        public ActionResult Delete(long? id)
        {
            if (UsersDb.IsUserActivated())
            {
                return RedirectToAction("Activation", "Users");
            }
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

        // POST: UsersGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            USERS_GROUP uSERS_GROUP = db.USERS_GROUP.Find(id);
            db.USERS_GROUP.Remove(uSERS_GROUP);
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


        //[Authorize]
        //public ActionResult SearchProfileDetailForGroup(string name, string surname, string departman, long groupId, string allGrpupMemberFlag)
        //{
        //    return View(db.SP_SEARCH_PROFILE_FOR_GROUP(name, surname, departman, groupId, allGrpupMemberFlag));

        //    //return Json(sonuc.ToArray(), JsonRequestBehavior.AllowGet);
        //}

        [Authorize]
        public ActionResult SearchDetailUserProfileForGroup()
        {
            ViewBag.DepartmanList = new SelectList(DbHelper.Helper.GetirParametreListesi("P_DEPARTMAN"), "CODE", "VALUE");
            ViewBag.GroupId = Url.RequestContext.RouteData.Values["id"];
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchDetailUserProfileListForGroup([Bind(Include = "DepartmanCode,GroupID")] Entity.Group grup)
        {
            ViewBag.GroupId = grup.GroupID;
            return View(db.SP_SEARCH_USER_PROFILE_FOR_GROUP(grup.DepartmanCode,User.Identity.GetUserId(),grup.GroupID));
        }

        [Authorize]
        public ActionResult SendInvitation(string id,long groupId) //Kişiye gruba katılması için davet gönder
        {
            Entity.Group g = new Entity.Group();           
            if (g != null)
            {
                USERS_GROUP_MEMBERS item = new USERS_GROUP_MEMBERS();
                item.USER_ID = id;
                item.GROUP_ID = groupId;
                item.STATUS_CODE = "W";
                item.MEMBER_DATE = DateTime.Now;
                item.UPDATE_DATE = DateTime.Now;
                db.USERS_GROUP_MEMBERS.Add(item);
                db.SaveChanges();
            }
            return RedirectToAction("SearchDetailUserProfileForGroup");
        }

        [Authorize]
        public ActionResult MyGroups()
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
            //return View(db.SP_GET_FOLLOWERS(User.Identity.GetUserId(), 1, ""));
            return View(db.SP_GET_GROUPS_AND_MYGROUPS(User.Identity.GetUserId(), 1, ""));
        }


        /// <summary>
        /// Takip Edilenler
        /// </summary
        [Authorize]
        public ActionResult AllGroups()
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
            return View(db.SP_ALL_GROUPS(User.Identity.GetUserId(),2));
        }

        [Authorize]
        public ActionResult AcceptInvitation(string id, long groupId)//Daveti onayla
        {
            db.SP_MEMBER_ACTION(id,groupId,"A");
            return View();
        }


        [Authorize]
        public ActionResult RejectInvitation(string id, long groupId)//Daveti reddet
        {
            db.SP_MEMBER_ACTION(id, groupId, "R");            
            return RedirectToAction("MyGroups");
        }
        [Authorize]
        public ActionResult OutofGroup(string id, long groupId)//Gruptan Çık
        {
            db.SP_MEMBER_ACTION(id, groupId, "C");
            return RedirectToAction("GetMembers");

        }

        [Authorize]
        public ActionResult DeleteInvitation(string id, long groupId)//Daveti iptal et
        {
            db.SP_MEMBER_ACTION(id, groupId, "D");
            return RedirectToAction("GetMembers");

        }        

        [Authorize]
        public ActionResult DeleteMember(string id, long groupId)//Üyeyi sil
        {
            db.SP_MEMBER_ACTION(id, groupId, "K");
            return RedirectToAction("GetMembers");

        }

        [Authorize]
        public ActionResult GetMembers(long id)
        {
            ViewBag.GroupId = id;
            return View(db.SP_GET_MEMBERS(id,"A"));
        }


        [Authorize]
        // GET: Activity
        public ActionResult ActivityGroup(long id)
        {
            ViewBag.GroupId = id;
            return View(db.GROUP_ACTIVITY.ToList());
        }

        [Authorize]
        public ActionResult GonderiOlustur(string gonIcerik,long grupId)
        {
            var gonderi = new GROUP_ACTIVITY();            
            gonderi.GROUP_ID = grupId;
            gonderi.UPDATE_DATE = DateTime.Now;
            gonderi.USER_ID = User.Identity.GetUserId();//kullanıcıyı alır 
            gonderi.DESCRIPTION = "Y" + "|" + gonIcerik.Replace("|", "/");

            if (ModelState.IsValid)
            {
                db.GROUP_ACTIVITY.Add(gonderi);
                db.SaveChanges();

                var list = db.SP_GET_MEMBERS(grupId, "A");
                string mailIcerigi = string.Format("SUNETWORK platformunda üyelerden biri paylaşımda bulundu\\n Görmek için platformu ziyaret edebilirsiniz.");

                foreach (var item in list)
                {
                    Helper.MailGonder("SUNETWORK Grup Paylaşımı Hk.", mailIcerigi, item.EMAIL);
                }

                return Json("Eklendi");
            }

            return Json("Hata Oluştu");
        }

        [Authorize]
        public ActionResult GonderiOlusturPhoto()
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var gonderi = new GROUP_ACTIVITY();
                var resim = System.Web.HttpContext.Current.Request.Files["photo"];
                string gonIcerik = System.Web.HttpContext.Current.Request["gonderi"].ToString();
                long grpupID = Convert.ToInt64(System.Web.HttpContext.Current.Request["groupId"].ToString());


                if (resim != null)
                {
                    string filePath = "~/Content/ResimProfil/" + grpupID + "/Resimler";
                    bool exists = System.IO.Directory.Exists(Server.MapPath(filePath));

                    if (!exists)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath(filePath));
                    }
                    WebImage img = new WebImage(resim.InputStream);
                    FileInfo fotoinfo = new FileInfo(resim.FileName);
                    fotoinfo.MoveTo(fotoinfo.Directory.FullName + "\\" + Guid.NewGuid() + Path.GetExtension(resim.FileName));
                    gonderi.DESCRIPTION = "F" + "|" +gonIcerik + "|" + filePath + "/" + fotoinfo.Name;
                    img.Resize(600, 400);
                    try
                    {
                        img.Save(filePath + "/" + fotoinfo.Name);
                    }
                    catch (Exception ex)
                    {
                        Helper.MailGonder(ex.ToString(), "Resim Eklerken Hata Oluştu", "havva.kirac34@gmail.com");
                        return Json("Resim eklerken bir hata oluştu");
                    }
                }

                gonderi.GROUP_ID = grpupID;
                gonderi.UPDATE_DATE = DateTime.Now;
                gonderi.USER_ID = User.Identity.GetUserId();//kullanıcıyı alır 


                if (ModelState.IsValid)
                {
                    db.GROUP_ACTIVITY.Add(gonderi);
                    db.SaveChanges();
                    return Json("Eklendi");
                }
            }

            return Json("Hata Oluştu");
        }


        [Authorize]
        public ActionResult GonderiList(int kayitSayisi,long groupId)
        {
            List<ModelBase> sonuc = new List<ModelBase>();
            // var list = db.SP_USER_ACTIVITY_LIST(kayitSayisi, User.Identity.GetUserId());
            /// var list = db.SP_GROUP_ACTIVITY_LIST(kayitSayisi, );
            var list1 = db.SP_GET_GROUP_ACTIVITY_LIST(kayitSayisi, groupId);
            foreach (var item in list1)
            {
                ModelBase model = new ModelBase();
                model.UserNameSurname = item.kullaniciAdiSoyadi;
                string[] aa = item.DESCRIPTION.Split('|');
                
                model.Activitytype = aa[0];
                model.Description = aa[1];
                if (aa.Length > 2)
                {                    
                    if (model.Activitytype == "F")
                    {
                        model.SharedPhotoPhath = aa[2].Replace("~", "");
                    }
                }

                model.PhotoPath = string.IsNullOrWhiteSpace(item.PHOTO_PATH) ? "" : item.PHOTO_PATH.Replace("~", "");
                model.UpdateDate = Convert.ToDateTime(item.UPDATE_DATE).ToShortDateString();
                sonuc.Add(model);
            }
            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }


       

    }
}
