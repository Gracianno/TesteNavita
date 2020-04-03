using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteNavita.Domain;
using TesteNavita.Repository;
using TesteNavita.WebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNavita.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimonioController: ControllerBase
    {
        private readonly ITesteNaviaRepository _repository;

        public readonly IMapper _mapper;

        public PatrimonioController(ITesteNaviaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var patrimonios = await _repository.GetPatrimoniosAsync();
                var results = _mapper.Map<IEnumerable<PatrimonioDto>>(patrimonios);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }

        }

        [HttpGet("{PatrimonioId}")]
        public async Task<IActionResult> Get(int PatrimonioId)
        {
            try
            {
                var patrimonio = await _repository.GetPatrimoniosAsyncById(PatrimonioId);
                var results = _mapper.Map<PatrimonioDto>(patrimonio);

                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }

        }

        [HttpPost()]
        public async Task<IActionResult> Post(Patrimonio model)
        {
            try
            {
                model.NumeroTombo = Guid.NewGuid().ToString();
                var patrimonio = _mapper.Map<Patrimonio>(model);
                _repository.Add(patrimonio);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/patrimonio/{model.Id}", _mapper.Map<PatrimonioDto>(patrimonio));
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }
            return BadRequest();
        }

        [HttpPut("{PatrimonioId}")]
        public async Task<IActionResult> Put(int PatrimonioId, PatrimonioDto model)
        {
            try
            {
                var patrimonio = await _repository.GetPatrimoniosAsyncById(model.Id);

                if (patrimonio == null) return NotFound();
                if (model.NumeroTombo != patrimonio.NumeroTombo) return BadRequest("Não é permitido a alteração do numero de tombo.");
                _mapper.Map(model, patrimonio);

                _repository.Update(patrimonio);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", _mapper.Map<PatrimonioDto>(patrimonio));
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }
            return BadRequest();
        }

        [HttpDelete("{PatrimonioId}")]
        public async Task<IActionResult> Delete(int PatrimonioId)
        {
            try
            {
                var patrimonio = await _repository.GetPatrimoniosAsyncById(PatrimonioId);

                if (patrimonio == null) return NotFound();

                _repository.Delete(patrimonio);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }
            return BadRequest();
        }

    }
}
