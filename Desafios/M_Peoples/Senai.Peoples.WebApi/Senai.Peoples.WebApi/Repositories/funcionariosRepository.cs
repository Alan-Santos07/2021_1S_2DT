using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class funcionariosRepository : IfuncionariosRepository
    {
        private string stringConexao = "Data Source=DESKTOP-NQMUPH6\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=senai@132";
        public void Atualizar(funcionarios mudanca)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdBody = "UPDATE funcionarios SET nome = @nome WHERE idFuncionarios = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {

                    cmd.Parameters.AddWithValue("@ID", mudanca.idFuncionarios);
                    cmd.Parameters.AddWithValue("@nome", mudanca.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            } 
        }

        public void AtualizarIdCorpo(funcionarios func)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdBody = "UPDATE funcionarios SET nome = @nome WHERE idFuncionarios = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@ID", func.idFuncionarios);
                    cmd.Parameters.AddWithValue("@Nome", func.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, funcionarios func)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdUrl = "UPDATE funcionarios SET nome = @nome WHERE idFuncionarios = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", func.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public funcionarios BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idFuncionarios, nome FROM funcionarios WHERE idFuncionarios = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        funcionarios buscaFuncionarios = new funcionarios
                        {
                            idFuncionarios = Convert.ToInt32(rdr["idFuncionarios"]),

                            nome = rdr["nome"].ToString()
                        };

                        return buscaFuncionarios;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(funcionarios novoFuncionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string queryInsert = "INSERT INTO funcionarios(nome) VALUES (@nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nome", novoFuncionario.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM funcionarios WHERE idFuncionarioo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<funcionarios> Listar()
        {
            List<funcionarios> listarFuncionarios = new List<funcionarios>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idFuncionarios, nome FROM funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        funcionarios mudanca = new funcionarios()
                        {
                            idFuncionarios = Convert.ToInt32(rdr[0]),

                            nome = rdr[1].ToString()
                        };

                        listarFuncionarios.Add(mudanca);
                    }
                }
            }

            return listarFuncionarios;
        }
    }
}
