using _03_Models.AddModels;
using _04_SRV.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _05_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;
        private readonly ILoggerService _loggerService;



        public BeerController(IBeerService beerService, ILoggerService loggerService)
        {
            _beerService = beerService;
            _loggerService = loggerService;
        }

        [HttpGet]
        [Route("GetAllBeer")]
        public IActionResult GetAllBeer()
        {
            try
            {
                _loggerService.Debug($"Start {nameof(HttpMethod)}");
                return Ok(_beerService.GetAllBeerWithBrewerAndSalers());
            }
            catch (Exception ex)
            {
                _loggerService.Error($"crash in {nameof(HttpMethod)}, {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddNewBeer")]
        public IActionResult Add(AddBeerModel addBeer)
        {
            try
            {
                _loggerService.Debug($"Start {nameof(HttpMethod)}");
                _beerService.AddBeer(addBeer);
                return Ok();
            }
            catch (Exception ex)
            {
                _loggerService.Error($"crash in {nameof(HttpMethod)}, {ex.Message}");
                return BadRequest(ex.Message);
            }

        }
    }
}
