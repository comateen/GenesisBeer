using _03_Models.AddModels;
using _04_SRV.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        private readonly IEstimateService _estimateService;

        public EstimateController(IEstimateService estimateService)
        {
            _estimateService = estimateService;
        }

        [HttpPost]
        [Route("ManageEstimate")]
        public IActionResult ManageEstimate(AddEstimateModel addEstimateModel)
        {
            try
            {
                return Ok(_estimateService.ManageEstimate(addEstimateModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
