using _02_DAL.Interfaces;
using _04_SRV.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryService _breweryService;

        public BreweryController(IBreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        [HttpGet]
        [Route("GetAllBrewery")]
        public IActionResult GetAllBrewery()
        {
            try
            {
                return Ok(_breweryService.GetAllBrewerWithBeerAndSalers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
