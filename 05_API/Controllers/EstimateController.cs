using _03_Models.AddModels;
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
    public class EstimateController : ControllerBase
    {
        private readonly IEstimateService _estimateService;
        private readonly ILoggerService _loggerService;

        public EstimateController(IEstimateService estimateService, ILoggerService loggerService)
        {
            _estimateService = estimateService;
            _loggerService = loggerService;
            InitializeLogger();
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

        private void InitializeLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4netconfig.config"));
        }
    }
}
