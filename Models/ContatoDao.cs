using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Agenda_Telefonica.Models
{
    public static class ContatoDao
    {
        public static Contato PesquisarContato(int? id)
        {
            Contato contato = null;
            using (SqlConnection connection = ConectarBancoDeDados.conectarBanco())
            {
                try
                {
                    string query = "SELECT * FROM Contato WHERE id =" + id;
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader leitor = command.ExecuteReader();

                    while (leitor.Read())
                    {
                        contato.ID = Convert.ToInt32(leitor["ID"].ToString());
                        contato.Nome = leitor["Nome"].ToString();
                        contato.Apelido = leitor["Apelido"].ToString();
                        contato.Telefone_Residencial = leitor["Telefone_residencial"].ToString();
                        contato.Telefone_Celular = leitor["Telefone_celular"].ToString();
                        contato.Telefone_Comercial = leitor["Telefone_comercial"].ToString();
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return contato;
            }
        }

        public static void IncluirContato(Contato contato)
        {
            using (SqlConnection connection =
                        ConectarBancoDeDados.conectarBanco())
            {               
                try
                {
                    string queryString = @"insert into Contato(Nome,Apelido,Tel_residencial,Tel_celular,Tel_comercial) 
                                    values (@nome, @apelido, @tel_res, @tel_cel, @tel_coml)";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@nome", contato.Nome);
                    command.Parameters.AddWithValue("@apelido", contato.Apelido);
                    command.Parameters.AddWithValue("@tel_res", contato.Telefone_Residencial);
                    command.Parameters.AddWithValue("@tel_cel", contato.Telefone_Celular);
                    command.Parameters.AddWithValue("@tel_coml", contato.Telefone_Comercial);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static List<Contato> ListaContatos()
        {
            using (SqlConnection connection = ConectarBancoDeDados.conectarBanco())
            using (SqlCommand command = new SqlCommand("Select * From Contato", connection))
            try
            { 
                connection.Open();
                List<Contato> listaContatos = new List<Contato>();
                using (SqlDataReader sqlDataReader = command.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Contato contato = new Contato();
                        contato.ID = Convert.ToInt32(sqlDataReader["ID"].ToString());
                        contato.Nome = sqlDataReader["Nome"].ToString();
                        contato.Apelido = sqlDataReader["Apelido"].ToString();
                        contato.Telefone_Residencial = sqlDataReader["Tel_residencial"].ToString();
                        contato.Telefone_Celular = sqlDataReader["Tel_celular"].ToString();
                        contato.Telefone_Comercial = sqlDataReader["Tel_comercial"].ToString();
                        listaContatos.Add(contato);
                    }
                }
                return listaContatos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void AtualizarContato(Contato contato)
        {
            using (SqlConnection connection = ConectarBancoDeDados.conectarBanco())
            {
                try
                {
                    string query = "UPDATE Contato SET ID=@id, Nome=@nome, Apelido=@apelido, Telefone_residencial=@telefone_residencial," +
                    "Telefone_celular=@telefone_celular, Telefone_comercial=@telefone_comercial WHERE ID=@id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", contato.ID);
                    command.Parameters.AddWithValue("@nome", contato.Nome);
                    command.Parameters.AddWithValue("@apelido", contato.Apelido);
                    command.Parameters.AddWithValue("@telefone_residencial", contato.Telefone_Residencial);
                    command.Parameters.AddWithValue("@telefone_celular", contato.Telefone_Celular);
                    command.Parameters.AddWithValue("@telefone_comercial", contato.Telefone_Comercial);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void ExcluirContato(int? id)
        {
            using (SqlConnection connection = ConectarBancoDeDados.conectarBanco())
            try
            {
                string query = "DELETE FROM Contato WHERE ID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
