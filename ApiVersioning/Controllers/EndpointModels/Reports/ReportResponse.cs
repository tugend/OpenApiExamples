using System.Collections.Generic;

namespace ApiVersioning.Controllers.EndpointModels.Reports
{
    public class ReportResponse
    {
        public string Report { get; }

        private ReportResponse(string data)
        {
            Report = data;
        }
        
        public static IEnumerable<ReportResponse> From(string data) => 
            new [] { new ReportResponse(data) };
    }
}