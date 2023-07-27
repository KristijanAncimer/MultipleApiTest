using Amazon.Runtime;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using TenantApi.Models;

namespace TenantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : ControllerBase
    {
        public TenantController()
        {

        }

        [HttpGet]
        [Route("[controller]/Index")]
        public async Task<TenantTestResponse> Get()
        {
            var result = new TenantTestResponse
            {
                ApiName = "Tenant Api",
            };

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://adminapi");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var response = await client.GetAsync("Admin");

                response.EnsureSuccessStatusCode();

                var responseText = await response.Content.ReadAsStringAsync();

                result.OtherApiResponse = responseText;
            }

            return result;
        }




        public class TenantTestResponse
        {
            public string ApiName { get; set; }
            public string OtherApiResponse { get; set; }
        }
    }
}