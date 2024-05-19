using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RobloxInputApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInputController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public UserInputController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> SendInput([FromBody] UserInput input)
        {
            var jsonData = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Replace with your Roblox game server URL
            var url = "https://your-roblox-server-url/api/receiveinput";

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return Ok("Input sent successfully");
            }
            return StatusCode((int)response.StatusCode, "Failed to send input");
        }
    }

    public class UserInput
    {
        public string PlayerName { get; set; }
        public string Command { get; set; }
    }
}
