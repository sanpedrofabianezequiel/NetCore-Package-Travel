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
    public class PackageController : ControllerBase
    {
        public IRepositoryWrapper _repoWrapper;
        public PackageController(IRepositoryWrapper repoWrapper) => _repoWrapper = repoWrapper;
        // GET api/<Salesman>
        [HttpGet]
        public IActionResult Get()=> Ok(_repoWrapper.Package.GetAll());
        [HttpGet]
        [Route("api/[controller]Id/{id}")]
        public IActionResult Get_PackageById(long id)
        {
            var package = _repoWrapper.Package.Get_PackageById(id);
            if (package == null)
                return NotFound($"No package with this id: {id} was found.");
            return Ok(package);
        }
        [HttpGet]
        [Route("api/[controller]Description/{Description}")]
        public ActionResult<IEnumerable<Package>> Get_PackageByDescription(string description)
        {
            var packages = _repoWrapper.Package.Get_PackageByDescription(description.ToLower());
            if (packages == null || packages.Count == 0)
                return NotFound($"No package with this description: '{description}' was found.");
            return Ok(packages);
        }
    }
}
