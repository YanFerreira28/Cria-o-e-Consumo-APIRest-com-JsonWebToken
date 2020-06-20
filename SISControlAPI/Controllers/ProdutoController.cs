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
    public class ProdutoController : ControllerBase
    {
        public UnityOfWork _unity = new UnityOfWork();
        public HttpResponseMessage response = new HttpResponseMessage();

        [HttpGet]
        [ResponseCache(Duration = 120)]
        [Route("Clientes", Name = "LeituraGeralProduto")]
        public async Task<ICollection<Produto>> LeituraGeral()
        {
            return await _unity.ProdutoRepository.LeituraGeral();
        }

        [HttpGet]
        [ResponseCache(Duration = 120)]
        [Route("Cliente", Name = "LeituraProduto")]
        public async Task<Produto> Leitura(int id)
        {
            return await _unity.ProdutoRepository.Leitura(id);
        }

        [HttpPut]
        [Route("Atualizar")]
        public HttpResponseMessage Atualizar(Produto model)
        {
            if (ModelState.IsValid)
            {
                _unity.ProdutoRepository.Atualizar(model: model);
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Headers.Location = new System.Uri(Url.Link("LeituraProduto", new { id = model.id }));
                response.Content = new ObjectContent<Produto>(model, new JsonMediaTypeFormatter());
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
            if (_unity.ProdutoRepository.Leitura(id) != null)
            {
                _unity.ProdutoRepository.Deletar(id: id);
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
        public HttpResponseMessage Adicionar(Produto model)
        {
            if (ModelState.IsValid)
            {
                _unity.ProdutoRepository.Adicionar(model: model);
                response.StatusCode = System.Net.HttpStatusCode.Created;
                response.Headers.Location = new System.Uri(Url.Link("LeituraProduto", new { id = model.id }));
                response.Content = new ObjectContent<Produto>(model, new JsonMediaTypeFormatter());
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