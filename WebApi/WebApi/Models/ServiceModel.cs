using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ServiceModel
    {
        public int IDSERVICES { get; set; }
        public string NAMESERVICES { get; set; }
        public string SUMARYSERVICES { get; set; }
        public Nullable<int> BEGIN_PRICE { get; set; }
        public Nullable<int> MAX_PRICE { get; set; }
        public int IDAGENCY { get; set; }
    }
}