﻿using _03_Models.AddModels;
using _04_SRV.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _05_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        private readonly IEstimateService _estimateService;
        private readonly ILoggerService _loggerService;

        public EstimateController(IEstimateService estimateService, ILoggerService loggerService)
        {
            _estimateService = estimateService;
            _loggerService = loggerService;
        }

        [HttpPost]
        [Route("ManageEstimate")]
        public IActionResult ManageEstimate(AddEstimateModel addEstimateModel)
        {
            try
            {
                _loggerService.Debug($"Start {nameof(HttpMethod)}");
                return Ok(_estimateService.ManageEstimate(addEstimateModel));
            }
            catch (Exception ex)
            {
                _loggerService.Error($"crash in {nameof(HttpMethod)}, {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
