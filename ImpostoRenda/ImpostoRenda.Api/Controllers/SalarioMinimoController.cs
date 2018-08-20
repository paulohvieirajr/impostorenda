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
    [Route("api/salariominimo")]
    public class SalarioMinimoController : Controller
    {
        private readonly IApplicationSalarioMinimo _service;

        /// <summary>
        /// Controller de salario minimo com os métodos necessários para operar a entidade 
        /// </summary>
        public SalarioMinimoController(IApplicationSalarioMinimo service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna o salário mínimo cadastrado na base de dados.
        /// </summary>
        /// <returns> Lista de Objetos contendo os conribuintes</returns>
        [HttpGet]
        public ServiceResponse<SalarioMinimoDto> Obter()
        {
            return _service.Obter();
        }

        /// <summary>
        /// Atualiza o valor do salário mínimo na base de dados.
        /// </summary>
        /// <returns> Retorna um booleano confirmando a operação</returns>
        [HttpPost]
        public ServiceResponse<Boolean> Salvar([FromBody]SalarioMinimoDto dto)
        {
            return _service.Salvar(dto);
        }
    }
}
