using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUNetwork.Models
{
    public class ModelMessage
    {
        public string Id { get; set; }
        public String Message { get; set; }
        public String NameSurname { get; set; }
        public String UserName { get; set; }
        public String UserSurname { get; set; }
        public String ReceiveUserId { get; set; }      
        public String SenderUserId { get; set; }
        public String UserId { get; set; }

        public String PhotoPath { get; set; }
        public string UpdateDate { get; set; }
        public string ReadDate { get; set; }
        public String ReadFlag { get; set; }
        public string SendDate { get; set; }
        public string SendReceiverFlag { get; set; }

    }
}