using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUNetwork.Entity
{
    public class Group
    {
        public long GroupID { get; set; }
        public string GroupName { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string UserID { get; set; }
        public string StatusCode { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public string DepartmanCode { get; set; }

    }
}