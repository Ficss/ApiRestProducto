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
    public class MarcaController : ControllerBase
    {
        private readonly BBDDContext _context;
        private IDataRepository<Marca> _repository;
        public MarcaController(BBDDContext context, IDataRepository<Marca> repository)
        {
            _context = context;
            _repository = repository;
            MarcaSeed.InitData(context);
        }

        // GET: api/<controller>  
        [HttpGet]
        public IActionResult Get()
        {

            IEnumerable<Marca> marca = _repository.GetAll();
            return Ok(marca);
        }

        // GET api/<controller>/5  
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Marca marca = _repository.Get(id);

            if (marca == null)
            {
                return NotFound("No se pudo encontrar el registro de la marca.");
            }

            return Ok(marca);
        }

        // POST api/<controller>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Marca marca)
        {
            try
            {
                if (marca == null)
                {
                    return BadRequest("Los datos enviados para marca están vacíos");
                }
                var model = new Marca
                {
                    Id = marca.Id,
                    Nombre = marca.Nombre
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
        public IActionResult Put(int id,[FromBody] Marca marca)
        {
            if (marca == null)
            {
                return BadRequest("");
            }
            Marca marcaToUpdate = _repository.Get(id);
            if (marcaToUpdate == null)
            {
                return NotFound("Marca seleccionada no fue encontrada");
            }
            _repository.Change(marcaToUpdate, marca);
            return NoContent();

            //var model = new Marca
            //{

            //    Nombre = marca.Nombre
            //};

            //_repository.Change(model);
        }

        //[HttpPatch]
        //public void Patch([FromBody] Marca request)
        //{

        //    var model = new Marca
        //    {
        //        Nombre = request.Nombre
        //    };

        //    _repository.Change(model);
        //}

        // DELETE api/<controller>/5  
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete(int id)
        {

            //Marca customer = _repository.Get(id);
            //if (customer == null)
            //{
            //    return BadRequest("La marca a eliminar no fue encontrada");
            //}
            _repository.Delete(id);
            //return NoContent();
        }
    }
}
