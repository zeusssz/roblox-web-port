using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RobloxDataApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RobloxDataController : ControllerBase
    {
        private static List<object> gameData = new List<object>(); // Store game data

        [HttpPost]
        public IActionResult PostData([FromBody] object data)
        {
            gameData.Add(data);
            return Ok("Data received");
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(gameData);
        }
    }
}
