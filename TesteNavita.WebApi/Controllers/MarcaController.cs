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
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace TesteNavita.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController: ControllerBase
    {
        private readonly ITesteNaviaRepository _repository;

        public readonly IMapper _mapper;

        public MarcaController(ITesteNaviaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var marcas = await _repository.GetMarcasAsync();
                var results = _mapper.Map<IEnumerable<MarcaDto>>(marcas);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }

        }

        [HttpGet("{MarcaId}")]
        public async Task<IActionResult> Get(int MarcaId)
        {
            try
            {
                var marca = await _repository.GetMarcasAsyncById(MarcaId);
                var results = _mapper.Map<MarcaDto>(marca);

                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }

        }

        [HttpGet("{MarcaId}/patrimonios")]
        public async Task<IActionResult> GetPrimoniosByMarca(int MarcaId)
        {
            try
            {
                var marca = await _repository.GetPatrimoniosAsyncByMarca(MarcaId);

                return Ok(marca);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno: " + ex);
            }

        }

        [HttpPost()]
        public async Task<IActionResult> Post(Marca model)
        {
            try
            {
                var marca = _mapper.Map<Marca>(model);
                _repository.Add(marca);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/marca/{model.Id}", _mapper.Map<MarcaDto>(marca));
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
                {
                    return StatusCode(StatusCodes.Status409Conflict, "Não é possivel cadastrar marcas com nomes já cadastradas anteriormente");
                }
                          
            }
            catch (Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }
            return BadRequest();
        }

        [HttpPut("{MarcaId}")]
        public async Task<IActionResult> Put(int MarcaId, MarcaDto model)
        {
            try
            {
                var marca = await _repository.GetMarcasAsyncById(model.Id);

                if (marca == null) return NotFound();

                _mapper.Map(model, marca);

                _repository.Update(marca);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/marca/{model.Id}", _mapper.Map<MarcaDto>(marca));
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
                {
                    return StatusCode(StatusCodes.Status409Conflict, "Não é possivel cadastrar marcas com nomes já cadastradas anteriormente");
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }
            return BadRequest();
        }

        [HttpDelete("{MarcaId}")]
        public async Task<IActionResult> Delete(int MarcaId)
        {
            try
            {
                var marca = await _repository.GetMarcasAsyncById(MarcaId);

                if (marca == null) return NotFound();

                _repository.Delete(marca);

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
