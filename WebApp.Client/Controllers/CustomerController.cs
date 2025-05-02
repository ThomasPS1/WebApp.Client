using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Client.Dto;

namespace WebApp.Client.Controllers
{
    public class CustomerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5177/api/Customer/GetAllCustomer");
            var response = await client.SendAsync(request);
            List<CustomerResponseDto> customers = new();
            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                customers = JsonConvert.DeserializeObject<List<CustomerResponseDto>>(result);

            }
            return View(customers);
        }
    }
}
