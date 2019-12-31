using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    public class BonusController : ControllerBase
    {

        [Route("api/bonus/getbonusdates")]
        [HttpGet]
        public async Task<IActionResult> GetBonusDates()
        {
            Thread.Sleep(5000);

            var result = new List<DateTime>();
            result.Add(DateTime.Today);
            result.Add(DateTime.Today.AddDays(-1));
            
            var t = Task.Run(() => result);
            await t;

            return Ok(t);

        }

    }
}