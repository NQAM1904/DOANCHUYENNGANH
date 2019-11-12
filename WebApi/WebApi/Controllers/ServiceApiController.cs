using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ServiceApiController : ApiController
    {
        DOANCHUYENNGANHEntities data = new DOANCHUYENNGANHEntities();
        public IEnumerable<SERVICE> Get()
        {
            return data.SERVICES.ToList();
        }
        public SERVICE Get(int id)
        {
            var services = data.SERVICES.Where(x => x.IDSERVICES == id).FirstOrDefault();
            return services;
        }
    }
}
