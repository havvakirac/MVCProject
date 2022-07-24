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
using System.Web.Helpers;
using System.IO;
using SUNetwork.DbHelper;

namespace SUNetwork.Controllers
{
    public class ActivityController : Controller
    {
        private SELCUKDBEntities1 db = new SELCUKDBEntities1();

        [Authorize]
        // GET: Activity
        public ActionResult Index()
        {
            return View(db.ACTIVITY.ToList());
        }

        // GET: Activity/Details/5
        public ActionResult Details(int? id)
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

        // GET: Activity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USER_ID,ACTIVITY_TYPE,DESCRIPTION,STATUS_CODE,UPDATE_DATE")] ACTIVITY aCTIVITY)
        {
            if (ModelState.IsValid)
            {
                db.ACTIVITY.Add(aCTIVITY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCTIVITY);
        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,USER_ID,ACTIVITY_TYPE,DESCRIPTION,STATUS_CODE,UPDATE_DATE")] ACTIVITY aCTIVITY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTIVITY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCTIVITY);
        }

        [Authorize]
        public ActionResult GonderiOlustur(string gonIcerik, string activityType)
        {
            var gonderi = new ACTIVITY();
            gonderi.UPDATE_DATE = DateTime.Now;
            gonderi.USER_ID = User.Identity.GetUserId();//kullanıcıyı alaır 
            gonderi.DESCRIPTION = gonIcerik.Replace('|', '/'); 
            gonderi.ACTIVITY_TYPE = activityType;
            gonderi.STATUS_CODE = "A";

            if (ModelState.IsValid)
            {
                db.ACTIVITY.Add(gonderi);
                db.SaveChanges();                

                var list = db.SP_GET_FOLLOWERS(User.Identity.GetUserId(), 2, "");
                string mailIcerigi = string.Format("SUNETWORK platformunda takip ettiğin kişilerinden biri paylaşımda bulundu. Görmek için platformu ziyaret edebilirsiniz.");

                foreach (var item in list)
                {
                    Helper.MailGonder("SUNETWORK Gönderi Bildirimi", mailIcerigi, item.EMAIL);
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
                var gonderi = new ACTIVITY();
                var resim = System.Web.HttpContext.Current.Request.Files["photo"];
                string gonIcerik = System.Web.HttpContext.Current.Request["gonderi"].ToString();


                if (resim != null)
                {
                    string filePath = "~/Content/ResimProfil/" + User.Identity.GetUserId() + "/Resimler";
                    bool exists = System.IO.Directory.Exists(Server.MapPath(filePath));

                    if (!exists)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath(filePath));
                    }


                    WebImage img = new WebImage(resim.InputStream);
                    FileInfo fotoinfo = new FileInfo(resim.FileName);
                    fotoinfo.MoveTo(fotoinfo.Directory.FullName + "\\" + Guid.NewGuid()+ Path.GetExtension(resim.FileName));
                    gonderi.DESCRIPTION = gonIcerik + "|" + filePath + "/" + fotoinfo.Name;
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

                gonderi.UPDATE_DATE = DateTime.Now;
                gonderi.USER_ID = User.Identity.GetUserId();//kullanıcıyı alaır 
                //gonderi.DESCRIPTION = gonIcerik;
                gonderi.ACTIVITY_TYPE = "F";
                gonderi.STATUS_CODE = "A";

                if (ModelState.IsValid)
                {
                    db.ACTIVITY.Add(gonderi);
                    db.SaveChanges();
                    return Json("Eklendi");
                }
            }

            return Json("Hata Oluştu");
        }

        [Authorize]
        public ActionResult GonderiList(int kayitSayisi)
        {   
            List<ModelBase> sonuc = new List<ModelBase>();
            var list = db.SP_GET_ALL_USER_ACTIVITY(kayitSayisi,User.Identity.GetUserId());
            foreach (var item in list)
            {
                ModelBase model = new ModelBase();
                model.Activitytype = item.ACTIVITY_TYPE.Trim();
                model.Id = item.USER_ID;
                model.UserNameSurname = item.kullaniciAdiSoyadi;
               
                model.PhotoPath = string.IsNullOrWhiteSpace(item.PHOTO_PATH) ? "" : item.PHOTO_PATH.Replace("~", "");
                model.UpdateDate = Convert.ToDateTime(item.UPDATE_DATE).ToShortDateString();
                if (model.Activitytype == "F")
                {
                    string[] aa = item.DESCRIPTION.Split('|');
                    if (aa.Length == 2)
                    {
                        model.Description = aa[0];
                        model.SharedPhotoPhath = aa[1].Replace("~", "");
                    }
                    else
                        model.Description = aa[0];
                }
                else
                {
                    model.Description = item.DESCRIPTION;
                }
                sonuc.Add(model);
            }
            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }

        // GET: Activity/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ACTIVITY aCTIVITY = db.ACTIVITY.Find(id);
            db.ACTIVITY.Remove(aCTIVITY);
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
    }
}
