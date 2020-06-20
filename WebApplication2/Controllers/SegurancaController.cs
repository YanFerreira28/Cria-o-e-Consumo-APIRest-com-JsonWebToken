using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {
        public IConfiguration _config;
        public SegurancaController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        public string GerarToken()
        {
            var Issuer = _config.GetSection("JsonWebToken").GetSection("Issuer").Value;
            var Audience = _config.GetSection("JsonWebToken").GetSection("Audience").Value;
            var Key = _config.GetSection("JsonWebToken").GetSection("Key").Value;
            var Expires = DateTime.Now.AddMinutes(5);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Claims = new[]
            {
                new Claim(ClaimTypes.Name, "teste")
            };

            var jsonToken = new JwtSecurityToken(issuer: Issuer, audience: Audience, claims: Claims , expires: Expires, signingCredentials: credentials);
            var jsonHandler = new JwtSecurityTokenHandler();
            var jsonAcess = jsonHandler.WriteToken(jsonToken);

            return jsonAcess;

        }
    }
}