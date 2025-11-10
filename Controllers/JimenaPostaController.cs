using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace APIporAlumno.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JimenaPostaController : Controller
    {
        public readonly HttpClient _httpClient;

        public JimenaPostaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _httpClient.GetAsync("https://localhost:7163/api/GabrielPosta");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("\"Por aqui paso la posta de Jimena");
                var data = await response.Content.ReadAsStringAsync();
                return Ok(data);
            }

            return StatusCode((int)response.StatusCode, "Error fetching data");
        }
    }
}
