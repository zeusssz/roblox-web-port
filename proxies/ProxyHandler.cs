using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
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
        private readonly ProxyManager _proxyManager;

        public UserInputController()
        {
            _proxyManager = new ProxyManager("proxies/proxies.txt");
        }

        [HttpPost]
        public async Task<IActionResult> SendInput([FromBody] UserInput input)
        {
            var proxy = _proxyManager.GetNextProxy();
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxy),
                UseProxy = true
            };

            if (!string.IsNullOrWhiteSpace(proxy.UserInfo))
            {
                var userInfo = proxy.UserInfo.Split(':');
                httpClientHandler.Credentials = new NetworkCredential(userInfo[0], userInfo[1]);
            }

            var httpClient = new HttpClient(httpClientHandler);
            var jsonData = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var url = "https://aVRK8fWlihkopkQ.roblox.com/api/receiveinput"; // i have no idea how, but this does in fact work

            var response = await httpClient.PostAsync(url, content);

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
