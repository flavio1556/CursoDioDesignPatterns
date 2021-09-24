using CursoDioDesignPatterns.Domain.Veiculo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoDioDesignPatterns.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVeiculoDetran _veiculoDetran;

        public VeiculosController(IVeiculoRepository veiculoRepository, IVeiculoDetran veiculoDetran)
        {
            _veiculoRepository = veiculoRepository;
            this._veiculoDetran = veiculoDetran;
        }
        [HttpGet]
        public IActionResult Get() => Ok(_veiculoRepository.GetAll());
       
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var veiculo = _veiculoRepository.GetById(id);
            if (veiculo == null)
                return NotFound();
            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Veiculo veiculo)
        {
            _veiculoRepository.Add(veiculo);
            return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] Veiculo veiculo)
        {
            _veiculoRepository.Update(id,veiculo);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Put (Guid id)
        {
            _veiculoRepository.Delete(id);
            return NotFound();
        }

        [HttpPut("{id}/vistoria")]
        public IActionResult put (Guid id)
        {
            _veiculoDetran.AgendarVistoriaDetran(id);
            return NoContent();
        }
    }
}
