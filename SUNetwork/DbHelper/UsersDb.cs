using SUNetwork.Entity;
using SUNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SUNetwork.DbHelper
{
    public class UsersDb: Helper
    {
        static public USERS AddUser(UsersEntity ent)
        {
            USERS item = new USERS()
            {
                DEPARTMAN_CODE = ent.DepartmanCode,
                EMAIL = ent.Email,
                FINISH_DATE = ent.FinishDate,
                GENDER = ent.Gender,
                JOB = ent.Job,
                NAME = ent.Name,
                SURNAME = ent.Surname,
                IS_PRIVATE = ent.IsProvate,
                PHOTO_PATH = ent.PhotoPath,
                START_DATE = ent.StartDate,
                STATUS_CODE = ent.StatusCode,
                UPDATE_DATE = DateTime.Now,
                USER_ID = ent.UserId,
                USER_TYPE = ent.UserType
            };
            return AddUser(item);
        }

        static public USERS AddUser(USERS item)
        {            
            db.USERS.Add(item);
            db.SaveChanges();

            return item;
        }

        static public bool AddUserActivation(ACTIVATION item)
        {
            db.ACTIVATION.Add(item);
            db.SaveChanges();

            if(item.ID> 0)
            {
                return true;
            }

            return false;
        }

        public static bool ActivationUser(string userId)
        {
            USERS ITEM = db.USERS.Find(userId);
            ITEM.STATUS_CODE = "A";
            ITEM.UPDATE_DATE = DateTime.Now;
            db.Entry(ITEM).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }


        public static USERS GetUsersWithEmail(String email)
        {
            try
            {
                return db.USERS.FirstOrDefault(p => p.EMAIL == email);                
            }
            catch (Exception)
            {
            }

            return new USERS();
        }


        public static USERS GetUsersWithUserNo(string userId)
        {
            try
            {
                return db.USERS.FirstOrDefault(p => p.USER_ID == userId);
            }
            catch (Exception)
            {
            }

            return new USERS();
        }

        public static bool IsUserActivated()
        {
            bool isValid = true;
            try
            {
                isValid = Constants.Constants.USER_INFOS.USERS.STATUS_CODE == "W";
            }
            catch
            {
            }
            return isValid;
        }
    }
}