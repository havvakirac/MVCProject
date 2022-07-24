using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUNetwork.Models
{
    public class ModelBase
    {
        public long UserNo{ get; set; }
        public string Id { get; set; }
        public String UserNameSurname { get; set; }
        public String PhotoPath { get; set; }
        public String UpdateDate { get; set; }
        public String Description { get; set; }
        public String SharedPhotoPhath { get; set; }

        public long GrupId { get; set; }
        public string Activitytype { get; set; }
    }
}