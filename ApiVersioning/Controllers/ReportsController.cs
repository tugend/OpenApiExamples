using System.Collections.Generic;
using ApiVersioning.Controllers.EndpointModels.Reports;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/reports")]
    [ApiExplorerSettings(GroupName = "Reports")]
    public class ReportsController : ControllerBase
    {
        [ApiVersion("2")]
        [ApiVersion("3")]
        [HttpGet]
        public IEnumerable<ReportResponse> GetReports()
        {
            return new List<ReportResponse>(ReportResponse.From("Here are some detailed forecast reports!"));
        }
    }
}