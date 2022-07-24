using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUNetwork.Entity
{
    public class FavorityEntitiy
    {
        public string UserId { get; set; }
        public long UserNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string CommentStr { get; set; }

        public DateTime CreateDate { get; set; }
    }
}