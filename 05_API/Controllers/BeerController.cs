using _03_Models.AddModels;
using _04_SRV.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        [Route("GetAllBeer")]
        public IActionResult GetAllBeer()
        {
            try
            {
                return Ok(_beerService.GetAllBeerWithBrewerAndSalers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddNewBeer")]
        public IActionResult Add(AddBeerModel addBeer)
        {
            try
            {
                _beerService.AddBeer(addBeer);
                return Ok();
            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
