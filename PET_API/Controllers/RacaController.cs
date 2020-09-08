using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PET_API.Domains;
using PET_API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacaController : ControllerBase
    {
        RacaRepositories rep = new RacaRepositories();
        // GET: api/<RacaController>
        [HttpGet]
        public List<Raca> Get()
        {
            return rep.LerTodos();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return rep.BuscarPorId(id);
        }


        // POST api/<RacaController>
        [HttpPost]
        public Raca Post([FromBody] Raca a)
        {
            return rep.Cadastrar(a);
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public Raca Put(int id, [FromBody] Raca a)
        {
            return rep.Alterar(id, a);
        }


        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rep.Deletar(id);
        }
    }
}

