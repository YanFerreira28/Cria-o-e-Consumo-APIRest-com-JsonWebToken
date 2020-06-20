using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using AspNetCore.CacheOutput;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SISControlAPI.Domain.Entities;
using SISControlAPI.Infra.UnityOfWork;

namespace SISControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        public UnityOfWork _unity = new UnityOfWork();
        public HttpResponseMessage response = new HttpResponseMessage();

        [HttpGet]
        [ResponseCache(Duration = 120)]
        [Route("LeituraUsuario")]
        public async Task<Usuario> Leitura(int id)
        {
            return await _unity.UsuarioRepository.Leitura(id);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public HttpResponseMessage CadastrarUsuario(Usuario model)
        {
            if (ModelState.IsValid)
            {
                _unity.UsuarioRepository.Adicionar(model);
                response.StatusCode = System.Net.HttpStatusCode.Created;
                response.Headers.Location = new System.Uri(Url.Link("LeituraUsuario", new { id = model.id }));
                response.Content = new ObjectContent<Usuario>(model, new JsonMediaTypeFormatter());

                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Content = new StringContent("Dados informados ínvalidos!");
                return response;
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public HttpResponseMessage AtualizarUsuario(Usuario model)
        {
            if (ModelState.IsValid)
            {
                _unity.UsuarioRepository.Atualizar(model);
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Headers.Location = new System.Uri(Url.Link("LeituraUsuario", new { id = model.id }));
                response.Content = new ObjectContent<Usuario>(model, new JsonMediaTypeFormatter());

                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Content = new StringContent("Dados informados ínvalidos!");
                return response;
            }
        }
    }
}