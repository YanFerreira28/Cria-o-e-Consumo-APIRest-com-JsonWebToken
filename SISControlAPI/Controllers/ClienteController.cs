using System.Collections.Generic;
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
    public class ClienteController : ControllerBase
    {
        public UnityOfWork _unity = new UnityOfWork();
        public HttpResponseMessage response = new HttpResponseMessage();


        [HttpGet]
        [ResponseCache(Duration = 120)]
        [Route("Clientes", Name ="LeituraGeralClientes")]
        public async Task<ICollection<Cliente>> LeituraGeral()
        {
            return await _unity.ClienteRepository.LeituraGeral();
        }

        [HttpGet]
        [ResponseCache(Duration = 120)]
        [Route("Cliente", Name = "LeituraCliente")]
        public async Task<Cliente> Leitura(int id)
        {
            return await _unity.ClienteRepository.Leitura(id);
        }

        [HttpPut]
        [Route("Atualizar")]
        public HttpResponseMessage Atualizar(Cliente model)
        {
            if (ModelState.IsValid)
            {
                _unity.ClienteRepository.Atualizar(model: model);
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Headers.Location = new System.Uri(Url.Link("LeituraCliente", new { id = model.id }));
                response.Content = new ObjectContent<Cliente>(model, new JsonMediaTypeFormatter());
                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Content = new StringContent("Conteúdo Inválido!");

                return response;
            }
        }

        [HttpDelete]
        [Route("Deletar")]
        public HttpResponseMessage Deletar(int id)
        {
            if (_unity.ClienteRepository.Leitura(id) != null)
            {
                _unity.ClienteRepository.Deletar(id: id);
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Content = new StringContent("Índice deletado c/sucesso!");
                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Content = new StringContent("Índice não encontrado!");

                return response;
            }
        }

        [HttpPost]
        [Route("Adicionar")]
        public HttpResponseMessage Adicionar(Cliente model)
        {
            if (ModelState.IsValid)
            {
                _unity.ClienteRepository.Adicionar(model:model);
                response.StatusCode = System.Net.HttpStatusCode.Created;
                response.Headers.Location = new System.Uri(Url.Link("LeituraCliente", new { id = model.id }));
                response.Content = new ObjectContent<Cliente>(model, new JsonMediaTypeFormatter());
                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Content = new StringContent("Conteúdo informado ínvalido!");
                return response;
            }
        }
    }
}