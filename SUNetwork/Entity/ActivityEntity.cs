using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUNetwork.Entity
{
    public class ActivityEntity
    {
        public long UserId { get; set; }
        public long UserNo { get; set; }
        public string StatusCode { get; set; }
        public string CommentStr { get; set; }
        public string ActivityType { get; set; }
        public DateTime CreateDate { get; set; }
    }
}