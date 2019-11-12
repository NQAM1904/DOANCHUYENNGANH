using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserApiController : ApiController
    {
        DOANCHUYENNGANHEntities data = new DOANCHUYENNGANHEntities();
        public IEnumerable<USER> Get()
        {
            return data.USERs.ToList();
        }

        public USER Get(int id)
        {
            var user = data.USERs.Where(x => x.IDUSER == id).FirstOrDefault();
            return user;
        }
    }
}
