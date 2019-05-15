using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TimeFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            DateTime date = DateTime.Parse(req.Query["Date"]);
            bool succ = int.TryParse(req.Query["TimeZone"], out int timezone);

            if (date == null || !succ)
            {
                return new BadRequestObjectResult("Bad Request");
            }
            return (ActionResult)new OkObjectResult($"{date.AddHours(timezone).ToShortDateString() + ' ' + date.AddHours(timezone).ToShortTimeString()}");
        }
    }
}
