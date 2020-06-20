using Microsoft.AspNetCore.Mvc;
using SISControlAPI.Seguranca;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace SISControlAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {
        public JwtSecurity _jwt;

        public SegurancaController(JwtSecurity jwt)
        {
            _jwt = jwt;
        }

        public HttpResponseMessage Token(string nome, string senha, string email)
        {
            var token = _jwt.TokenSecurity(nome: nome, senha: senha, email: email);
            var conteudo = new ObjectContent<string>(token, new JsonMediaTypeFormatter());


            if (token == "Acesso Negado!")
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                response.Content = conteudo;
                return response;
            }
            else
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                response.Content = conteudo;
                return response;
            }
                
        }
    }
}