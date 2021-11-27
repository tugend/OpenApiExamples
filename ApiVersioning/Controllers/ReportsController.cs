using System;
using System.Collections.Generic;
using ApiVersioning.Controllers.EndpointModels.Forecast.CurrentVersion;
using ApiVersioning.Controllers.EndpointModels.Forecast.Legacy;
using ApiVersioning.Controllers.EndpointModels.Reports;
using ApiVersioning.Domain.Forecast;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ReportsController : ControllerBase
    {
        [ApiVersion("2-reports")]
        [ApiVersion("3-reports")]
        [HttpGet]
        public IEnumerable<ReportResponse> GetReports(ReportRange range)
        {
            return new List<ReportResponse>(ReportResponse.From("Here are some detailed forecast reports!"));
        }
    }
}