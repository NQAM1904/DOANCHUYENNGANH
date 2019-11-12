using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CategoryApiController : ApiController
    {
        DOANCHUYENNGANHEntities data = new DOANCHUYENNGANHEntities();
        public IEnumerable<CATEGORY> Get()
        {
            return data.CATEGORies.ToList();
        }

        public IEnumerable<AGENCY> Get(int id)
        {
            var cate = data.CATEGORies.Where(x => x.IDCATE == id).FirstOrDefault();
            return cate.AGENCies.ToList();
        }


    }
}
