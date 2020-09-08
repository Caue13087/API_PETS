using PET_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PET_API.Interfaces
{
    interface IRaca
    {
        Raca Cadastrar(Raca r);
        List<Raca> LerTodos();
        Raca Alterar(int id, Raca r);
        void Deletar(int id);
        Raca BuscarPorId(int id);
    }
}
