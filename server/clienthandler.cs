using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace RobloxWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobloxController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private const string RobloxApiKey = Environment.GetEnvironmentVariable("API-KEY");

        public RobloxController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("user/{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://apis.roblox.com/users/v1/users?usernames={username}");
            request.Headers.Add("x-api-key", RobloxApiKey);

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
