using MedicalBooking.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportingController : ControllerBase
    {
        private readonly IReportingService _service;

        public ReportingController(IReportingService service)
        {
            _service = service;
        }

        [HttpGet("summary")]
        public IActionResult Summary()
            => Ok(_service.GenerateReport());
    }
}