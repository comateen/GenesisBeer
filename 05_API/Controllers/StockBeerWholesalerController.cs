using _03_Models.Models;
using _04_SRV.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _05_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockBeerWholesalerController : ControllerBase
    {
        private readonly IStockBeerWholesalerService _stockBeerWholesalerService;
        private readonly ILoggerService _loggerService;

        public StockBeerWholesalerController(IStockBeerWholesalerService stockBeerWholesalerService, ILoggerService loggerService)
        {
            _stockBeerWholesalerService = stockBeerWholesalerService;
            _loggerService = loggerService;
        }

        [HttpPost]
        [Route("AddNewBeerToWholesaler")]
        public IActionResult AddNewBeerToWholesaler(StockBeerWholesalerClient stockBeerWholesalerClient)
        {
            try
            {
                _loggerService.Debug($"Start {nameof(HttpMethod)}");
                return Ok(_stockBeerWholesalerService.AddNewBeerToWholeSaler(stockBeerWholesalerClient));
            }
            catch (Exception ex)
            {
                _loggerService.Error($"crash in {nameof(HttpMethod)}, {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateStockBeerWholesaler")]
        public IActionResult UpdateStockBeerWholesaler(StockBeerWholesalerClient stockBeerWholesalerClient)
        {
            try
            {
                _loggerService.Debug($"Start {nameof(HttpMethod)}");
                return Ok(_stockBeerWholesalerService.UpdateStockBeerWholesaler(stockBeerWholesalerClient));
            }
            catch (Exception ex)
            {
                _loggerService.Error($"crash in {nameof(HttpMethod)}, {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteBeerFromWholesaler")]
        public IActionResult DeleteBeerFromWholesaler(int beerId, int wholesalerId)
        {
            try
            {
                _loggerService.Debug($"Start {nameof(HttpMethod)}");
                return Ok(_stockBeerWholesalerService.DeleteStockBeerWholesaler(beerId, wholesalerId));
            }
            catch (Exception ex)
            {
                _loggerService.Error($"crash in {nameof(HttpMethod)}, {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

    }
}
