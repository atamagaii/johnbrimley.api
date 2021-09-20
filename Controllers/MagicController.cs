using johnbrimley.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace johnbrimley.api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class MagicController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly HttpClient httpClient;

        public MagicController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.httpClient = new HttpClient(){BaseAddress = new Uri(configuration["SendGrid:Url"])};
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.configuration["SendGrid:APIKey"]);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]User user)
        {
            var payload = $"{{\"from\":{{\"email\":\"{this.configuration["SendGrid:From"]}\"}},\"template_id\":\"{this.configuration["SendGrid:TemplateId"]}\",\"personalizations\":[{{\"to\":[{{\"email\":\"{user.Email}\"}}], \"dynamic_template_data\": {{\"first_name\":\"{user.FirstName}\",\"url\":\"http://www.google.com\"}}}}]}}";

            var content = new StringContent(payload,Encoding.UTF8,"application/json");

            var response = await this.httpClient.PostAsync(this.configuration["SendGrid:Endpoint"], content);

            return Ok();
        }
    }
}

