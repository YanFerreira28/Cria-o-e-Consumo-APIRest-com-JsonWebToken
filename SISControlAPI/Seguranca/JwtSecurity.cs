using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SISControlAPI.Infra.UnityOfWork;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SISControlAPI.Seguranca
{
    public class JwtSecurity
    {
        public IConfiguration _config;
        public UnityOfWork _unity;

        public JwtSecurity(IConfiguration config, UnityOfWork unity)
        {
            _config = config;
            _unity = unity;
        }
        public string TokenSecurity(string nome, string senha, string email)
        {
            if (_unity.UsuarioRepository.ValidaUsuario(nome: nome, senha: senha, email: email))
            {
                var Issuer = _config.GetSection("JsonWebToken").GetSection("Issuer").Value;
                var Audience = _config.GetSection("JsonWebToken").GetSection("Audience").Value;
                var Key = _config.GetSection("JsonWebToken").GetSection("Key").Value;
                var Expires = DateTime.Now.AddMinutes(2);

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
                var criptografy = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(issuer: Issuer, audience: Audience, expires: Expires, signingCredentials: criptografy);
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenAccess = tokenHandler.WriteToken(token);
                return tokenAccess;
            }
            else
            {
                return "Acesso Negado!";
            }




        }
    }
}
