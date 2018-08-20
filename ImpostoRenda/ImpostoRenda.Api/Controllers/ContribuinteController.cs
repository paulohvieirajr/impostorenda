using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpostoRenda.Application.Dto;
using ImpostoRenda.Application.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ImpostoRenda.Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/contribuinte")]
    public class ContribuinteController : Controller
    {
        private readonly IApplicationContribuinte _service;

        /// <summary>
        /// Controller de contribuinte com todos os métodos necessários a operação do contribuinte. 
        /// </summary>
        public ContribuinteController(IApplicationContribuinte service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna os contribuintes cadastrados com seua salários com desconto
        /// </summary>
        /// <returns> Lista de Objetos contendo os conribuintes</returns>
        [HttpGet]        
        [Route("listar")]
        public ServiceResponse<List<ContribuinteDto>> Listar()
        {
            return _service.ListarComDescontos();
        }

        /// <summary>
        /// Insere um novo contribuinte a base de dados.
        /// </summary>
        /// <returns> Booleano confirmando a operação</returns>
        [HttpPost]
        public ServiceResponse<bool> Inserir([FromBody]ContribuinteDto dto)
        {
            return _service.Inserir(dto);
        }
    }
}
