using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PET_API.Domains;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPetController : ControllerBase
    {
        TipoPetRepositories repo = new TipoPetRepositories();
        // GET: api/<TipoPetController>
        [HttpGet]
        public List<TipoPet> Get()
        {
            return repo.LerTodos();
        }

        // GET api/<TipoPetController>/5
        [HttpGet("{id}")]
        public TipoPet Get(int id)
        {
            return repo.BuscarPorId(id);
        }


        // POST api/<TipoPetController>
        [HttpPost]
        public TipoPet Post([FromBody] TipoPet a)
        {
            return repo.Cadastrar(a);
        }

        // PUT api/<TipoPetController>/5
        [HttpPut("{id}")]
        public TipoPet Put(int id, [FromBody] TipoPet a)
        {
            return repo.Alterar(id, a);
        }

        // DELETE api/<TipoPetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Deletar(id);
        }
    }

    internal class TipoPetRepositories
    {
        internal TipoPet Alterar(int id, TipoPet a)
        {
            throw new NotImplementedException();
        }

        internal TipoPet BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        internal TipoPet Cadastrar(TipoPet a)
        {
            throw new NotImplementedException();
        }

        internal void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        internal List<TipoPet> LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}

