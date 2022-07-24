using SUNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace SUNetwork.DbHelper
{
    public class Helper
    {
        public static SELCUKDBEntities1 db = new SELCUKDBEntities1();



        public static List<PARAMETER> GetirParametreListesi(string parametre)
        {
            return db.PARAMETER.Where(p => p.PARAMETER_CODE == parametre).ToList();
        }


        public static string GetParameterValue(string parametre, string code)
        {
            var aa = db.PARAMETER.FirstOrDefault(p => p.PARAMETER_CODE == parametre && p.CODE == code);
            if (aa == null)
                return code;

            return aa.VALUE;
        }



        public static List<PARAMETER> GetStartYears()
        {
            List<PARAMETER> list = new List<PARAMETER>();
            int startYear = 1975;
            int finishYear = DateTime.Now.Year + 1;

            for (int i = startYear; i < finishYear; i++)
            {
                PARAMETER years = new PARAMETER();
                years.CODE = i.ToString();
                years.VALUE = i.ToString();
                list.Add(years);
            }

            return list;
        }


        public static List<PARAMETER> GetSFinishYears()
        {
            List<PARAMETER> list = new List<PARAMETER>();
            int startYear = 1975;
            int finishYear = DateTime.Now.Year + 7;

            for (int i = startYear; i < finishYear; i++)
            {
                PARAMETER years = new PARAMETER();
                years.CODE = i.ToString();
                years.VALUE = i.ToString();
                list.Add(years);
            }

            return list;
        }



        public static bool MailGonder(string konu, string icerik, string mailAdress)
        {
            MailMessage mail = new MailMessage("selcuknetwork@gmail.com", mailAdress);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("selcuknetwork@gmail.com", "sunetwork1525");
            client.Host = "smtp.gmail.com";
            mail.Subject = konu;
            mail.Body = icerik +
                 "\\n http://sunetwork.azurewebsites.net/";            
            
            bool kontrol = true;
            try
            {
                client.Send(mail);
            }
            catch
            {
                kontrol = false;
                
            }
            return kontrol;
        }
    }
}