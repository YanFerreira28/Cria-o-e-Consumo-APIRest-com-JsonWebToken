using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SISControlWeb.ViewModel;

namespace SISControlWeb.Controllers
{
    public class ClientesController : Controller
    {
        public IConfiguration _config;

        public ClientesController(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            using(HttpClient client = new HttpClient())
            {
                await AutenticacaoToken(client);

                var cli = client.GetAsync("https://localhost:44869/api/Cliente/Clientes").Result;
                if (cli.IsSuccessStatusCode)
                {
                    var conteudo = await cli.Content.ReadAsStringAsync();
                    var clienteModel = JsonConvert.DeserializeObject<ClienteViewModel>(conteudo);
                    return View(clienteModel);
                }
                else
                {
                    return View();
                }
            }
        }

        private async Task AutenticacaoToken(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var userAccess = JsonConvert.SerializeObject(_config.GetSection("JwtAccess").Value);

            var conteudo = new StringContent(userAccess);

            HttpResponseMessage response = await httpClient.PostAsync("https://localhost:44869/Token", conteudo);

            var token = response.Content.ReadAsStringAsync().Result;


            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}