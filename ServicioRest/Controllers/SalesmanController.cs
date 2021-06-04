using Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
using Repository;
using System;
using System.Collections.Generic;

namespace ServicioRest.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AngularPolicy")]
    [ApiController]
    public class SalesmanController : ControllerBase
    {
        public IRepositoryWrapper _repoWrapper;
        public SalesmanController(IRepositoryWrapper repoWrapper) => _repoWrapper = repoWrapper;
        [HttpGet]
        public IActionResult Get() =>  Ok(_repoWrapper.SalesMan.GetAll());
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            if (id < 1)
                return BadRequest("ID must be greater than 0");
            return Ok(_repoWrapper.SalesMan.GetById(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] CreateSalesmanDTO salesman)
        {
            if (salesman.StartDate < DateTime.Now.Date)
                return BadRequest("Start Date should be greater or equal to current date");
            return Ok(_repoWrapper.SalesMan.Add(salesman));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }
            try
            {
                SalesmanDTO salesman = _repoWrapper.SalesMan.GetById(id);
                if (salesman == null)
                {
                    return BadRequest($"Couldn't find {typeof(Salesman)}: {id}");
                }

                _repoWrapper.SalesMan.Delete(id);
                return Ok($"Salesman: {salesman.FullName} deleted!.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("/Confirm")]
        public IActionResult Confirm([FromBody]  CalculateCommissionRequestDTO saleConfirm)
        {
            if (saleConfirm == null)
                return BadRequest("You need to submit a sale with the required information");
            if (ValidateSale(saleConfirm))
            {
                bool result = _repoWrapper.Commission.Save(saleConfirm, _repoWrapper);
                if (result)
                    return Ok();
                else
                    return BadRequest("Sale could not be Saved. Please check associated sales before proceeding.");

            }
            return BadRequest("Sale could not be Saved. Please check associated sales before proceeding.");
        }
        private bool ValidateSale(CalculateCommissionRequestDTO sale)
        {
            if (sale.ClientTypeId > 2 || sale.ClientTypeId < 1)
                return false;
            if (sale.PassengersAmmount <= 0 
                    || sale.PassengersAmmount > 10 
                    || sale.TripDuration <= 0 
                    || sale.TripDuration > 60)
                return false;

            return true;
        }
    }
}
