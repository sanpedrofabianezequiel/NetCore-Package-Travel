using Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
using System.Collections.Generic;

namespace ServicioRest.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AngularPolicy")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        // GET: api/<ClientController>
        public IRepositoryWrapper _repoWrapper;
        public ClientController(IRepositoryWrapper repoWrapper) => _repoWrapper = repoWrapper;
        [HttpGet]
        public ActionResult<List<Client_Type>> Get_ClientTypes()
        {
            var listClientTypes = _repoWrapper.Client_Type.Get_ClientTypes();
            if (listClientTypes.Count == 0)
                return NotFound();
            return Ok(listClientTypes);
        }
    }
}
