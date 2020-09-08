using API_Pets.Context;
using PET_API.Domains;
using PET_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PET_API.Repository
{
    public class RacaRepositories : IRaca

    {
        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();

        public Raca Alterar(int id, Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca SET Descricao= @descricao, IdTipoPet = @idtipopet WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipopet", r.IdTipoPet);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return r;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            object p = cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca a = new Raca();

            while (dados.Read())
            {
                a.IdRaca = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
                a.IdTipoPet = Convert.ToInt32(dados.GetValue(2));
            }

            conexao.Desconectar();

            return a;
        }

        public Raca Cadastrar(Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO Raca (Descricao,IdTipoPet)" + "Values" + "(@descricao, @idtipopet)";

            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipopet", r.IdTipoPet);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return r;
        }

        public void Deletar(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

                public List<Raca> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> racas = new List<Raca>();

            while (dados.Read())
            {
                racas.Add(
                        new Raca()
                        {
                            IdRaca = Convert.ToInt32(dados.GetValue(0)),
                            Descricao = dados.GetValue(1).ToString(),
                            IdTipoPet = Convert.ToInt32(dados.GetValue(2))
                        }
                );
            }

            conexao.Desconectar();

            return racas;
        }
    }
}
