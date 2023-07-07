using _03_Models.Models;
using _04_SRV.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockBeerWholesalerController : ControllerBase
    {
        private readonly IStockBeerWholesalerService _stockBeerWholesalerService;

        public StockBeerWholesalerController(IStockBeerWholesalerService stockBeerWholesalerService)
        {
            _stockBeerWholesalerService = stockBeerWholesalerService;
        }

        [HttpPost]
        [Route("AddNewBeerToWholesaler")]
        public IActionResult AddNewBeerToWholesaler(StockBeerWholesalerClient stockBeerWholesalerClient)
        {
            try
            {
                return Ok(_stockBeerWholesalerService.AddNewBeerToWholeSaler(stockBeerWholesalerClient));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateStockBeerWholesaler")]
        public IActionResult UpdateStockBeerWholesaler(StockBeerWholesalerClient stockBeerWholesalerClient)
        {
            try
            {
                return Ok(_stockBeerWholesalerService.UpdateStockBeerWholesaler(stockBeerWholesalerClient));
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteBeerFromWholesaler")]
        public IActionResult DeleteBeerFromWholesaler(int beerId, int wholesalerId)
        {
            try
            {
                return Ok(_stockBeerWholesalerService.DeleteStockBeerWholesaler(beerId, wholesalerId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
