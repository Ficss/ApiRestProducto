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
    public class ProductsController : ControllerBase
    {
        private readonly BBDDContext _context;
        private IDataRepository<Producto> _repository;
        public ProductsController(BBDDContext context,IDataRepository<Producto> repository)
        {
            _context = context;
            _repository = repository;
            MarcaSeed.InitData(context);
        }

        // GET: api/<controller>  
        [HttpGet]
        public IActionResult Get()
        {

            IEnumerable<Producto> _product = _repository.GetAll();
            return Ok(_product);
        }

        // GET api/<controller>/5  
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Producto _product = _repository.Get(id);

            if (_product == null)
            {
                return NotFound("No se pudo encontrar el registro de la marca.");
            }

            return Ok(_product);
        }

        // POST api/<controller>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Producto producto)
        {
            try
            {
                if (producto == null)
                {
                    return BadRequest("Los datos enviados para producto están vacíos");
                }
                var model = new Producto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre
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
        public IActionResult Put(int id, [FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("");
            }
            Producto productoToUpdate = _repository.Get(id);
            if (productoToUpdate == null)
            {
                return NotFound("Producto seleccionado no fue encontrado");
            }
            _repository.Change(productoToUpdate, producto);
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
