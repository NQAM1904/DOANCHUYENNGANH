using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Agency
    {
        public int IDAGENCY { get; set; }
        public string NAMEAGENCY { get; set; }
        public int PHONEAGENCY { get; set; }
        public string ADDRESSAGENCY { get; set; }
        public string EMAILAGENCY { get; set; }
        public string SUMARYAGENCY { get; set; }
        public string DESCRIPTION { get; set; }
        public int IDSOCIAL { get; set; }
        public bool STATUS { get; set; }
    }
}