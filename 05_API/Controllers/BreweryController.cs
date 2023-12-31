﻿using _04_SRV.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _05_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryService _breweryService;
        private readonly ILoggerService _loggerService;

        public BreweryController(IBreweryService breweryService, ILoggerService loggerService)
        {
            _breweryService = breweryService;
            _loggerService = loggerService;
        }

        [HttpGet]
        [Route("GetAllBrewery")]
        public IActionResult GetAllBrewery()
        {
            try
            {
                _loggerService.Debug($"Start {nameof(HttpMethod)}");
                return Ok(_breweryService.GetAllBrewerWithBeerAndSalers());
            }
            catch (Exception ex)
            {
                _loggerService.Error($"crash in {nameof(HttpMethod)}, {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
