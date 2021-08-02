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
    public class CategoriaController : ControllerBase
    {
        private readonly BBDDContext _context;
        private IDataRepository<Categoria> _repository;
        public CategoriaController(BBDDContext context, IDataRepository<Categoria> repository)
        {
            _context = context;
            _repository = repository;
           CategoriaSeed.InitData(context);
        }

        // GET: api/<controller>  
        [HttpGet]
        public IActionResult Get()
        {

            IEnumerable<Categoria> categorias = _repository.GetAll();
            return Ok(categorias);
        }

        // GET api/<controller>/5  
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Categoria categoria = _repository.Get(id);

            if (categoria == null)
            {
                return NotFound("No se pudo encontrar el registro de la categoria.");
            }

            return Ok(categoria);
        }

        // POST api/<controller>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return BadRequest("Los datos enviados para marca éstán vacíos");
                }
                var model = new Categoria
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre
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
        public IActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest("");
            }
            Categoria categoriaToUpdate = _repository.Get(id);
            if (categoriaToUpdate == null)
            {
                return NotFound("Categoria seleccionada no fue encontrada");
            }
            _repository.Change(categoriaToUpdate, categoria);
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
