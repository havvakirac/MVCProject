using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUNetwork.Models
{
    public class ModelGroup
    {
        public long GroupId { get; set; }
        public string UserId{ get; set; }
        public String UserNameSurname { get; set; }
        public String PhotoPath { get; set; }
        public String UpdateDate { get; set; }
        public String Description { get; set; }
    }
}