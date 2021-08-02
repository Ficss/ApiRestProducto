using ApiRestProducto.DataAccess;
using ApiRestProducto.Models;
using ApiRestProducto.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private readonly BBDDContext _context;
        private IDataRepository<Subcategoria> _repository;
        public SubcategoriaController(BBDDContext context, IDataRepository<Subcategoria> repository)
        {
            _context = context;
            _repository = repository;
            SubcategoriaSeed.InitData(context);
        }

        // GET: api/<controller>  
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Subcategoria> subcategorias = _repository.GetAll();
            return Ok(subcategorias);
        }

        // GET api/<controller>/5  
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Subcategoria subcategoria = _repository.Get(id);

            if (subcategoria == null)
            {
                return NotFound("No se pudo encontrar el registro de la subcategoria.");
            }

            return Ok(subcategoria);
        }

        // POST api/<controller>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Subcategoria subcategoria)
        {
            try
            {
                if (subcategoria == null)
                {
                    return BadRequest("Los datos enviados para subcategoria están vacíos");
                }
                var model = new Subcategoria
                {
                    Id = subcategoria.Id,
                    Nombre = subcategoria.Nombre
                };

                _repository.Add(model);

                return Ok();
            }
            catch (Exception e)
            {
                return ValidationProblem(e.Message);
            }
        }

        // PUT api/<controller>/5  
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Subcategoria subcategoria)
        {
            if (subcategoria == null)
            {
                return BadRequest("");
            }
            Subcategoria subcategoriaToUpdate = _repository.Get(id);
            if (subcategoriaToUpdate == null)
            {
                return NotFound("Categoria seleccionada no fue encontrada");
            }
            _repository.Change(subcategoriaToUpdate, subcategoria);
            return NoContent();
        }

        // DELETE api/<controller>/5  
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
