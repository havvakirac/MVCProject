using SUNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUNetwork.Entity
{
    public class UsersEntity
    {
        public string UserId { get; set; }
        public long UserNo { get; set; }
        public string IsProvate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string StatusCode { get; set; }
        public string UserType { get; set; }
        public short StartDate { get; set; }
        public short FinishDate { get; set; }
        public string PhotoPath { get; set; }
        public string Gender { get; set; }
        public string DepartmanCode { get; set; }
        public string Job { get; set; }
        public DateTime UpdateDate { get; set; }
        public USERS USERS { get; set; }
    }
}