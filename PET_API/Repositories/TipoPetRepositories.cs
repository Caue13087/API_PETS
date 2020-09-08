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
    public class TipoPetRepository : ITipoPet

    {
         
        PetsContext conexao = new PetsContext();

        
        SqlCommand cmd = new SqlCommand();

       
        public TipoPet Alterar(int id, TipoPet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TipoPet SET " +
                "Descricao = @descricao WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public TipoPet alterar(int id, TipoPet a)
        {
            throw new NotImplementedException();
        }

       
        public TipoPet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoPet WHERE IdTipoPet = @id ";

            
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoPet a = new TipoPet();

            while (dados.Read())
            {
                a.IdTipoPet = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();
            return a;
        }


        public TipoPet Cadastrar(TipoPet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO TipoPet (Descricao)" +
                "VALUES (@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            //comando para injetar todos os dados do banco sql
            cmd.ExecuteNonQuery();

            //DML > ExecuteNonQuery

            conexao.Desconectar();
            return a;
        }


        public TipoPet cadastrar(TipoPet a)
        {
            throw new NotImplementedException();
        }

        //EXCLUIR cmd
        public void Deletar(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoPet WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        //leitura de todos
        public List<TipoPet> LerTodos()
        {
            //abrir conexão
            cmd.Connection = conexao.Conectar();

            //Preparando´para consultar
            cmd.CommandText = "SELECT * FROM TipoPet";

            SqlDataReader dados = cmd.ExecuteReader();

            //Lista para guardar os tipospet
            List<TipoPet> tipoPets = new List<TipoPet>();

            while (dados.Read())
            {
                tipoPets.Add(
                        new TipoPet()
                        {
                            IdTipoPet = Convert.ToInt32(dados.GetValue(0)),
                            Descricao = dados.GetValue(1).ToString()
                        }
                );
            }

            //encerrando conexão 
            conexao.Desconectar();

            return tipoPets;
        }

        TipoPet ITipoPet.BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        List<TipoPet> ITipoPet.LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
