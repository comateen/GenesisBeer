using _02_DAL.Interfaces;
using _04_SRV.Interfaces;
using log4net.Config;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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

        private void InitializeLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4netconfig.config"));
        }
    }
}
