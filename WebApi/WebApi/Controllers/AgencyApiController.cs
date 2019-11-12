using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class AgencyApiController : ApiController
    {
        DOANCHUYENNGANHEntities data = new DOANCHUYENNGANHEntities();
        public IEnumerable<AGENCY> Get()
        {
            return data.AGENCies.ToList();
        }
        public AGENCY Get(int id)
        {

            var agency = data.AGENCies.Where(x => x.IDAGENCY == id).FirstOrDefault();
            return agency;
        }

        
    }
}
