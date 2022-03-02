using System;
using System.Data;
using Npgsql;

namespace API_meu_login.Dao
{
    public class DaoUser
    {

        static string serverName = "localhost";                                         
        static string port = "5432";                                                            
        static string userName = "postgres";                                               
        static string password = "root";                                             
        static string databaseName = "meu-login";       
        
        NpgsqlConnection pgsqlConnection = null;
        
        string connString = null;

        public DaoUser() {
            connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                            serverName, port, userName, password, databaseName);
        }

        public DataTable GetUserByEmail(string email)
        {

            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    pgsqlConnection.Open();
                 
                    string cmdSeleciona = String.Format("select * from usuario where email = '{0}'", email);

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }

            return dt;
        }

        public Boolean InsertUser(string nome, string email, int idade)
        {

            try
            {
                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(connString))
                {               
                    pgsqlConnection.Open();

                    string cmdInserir = String.Format("Insert Into funcionarios(nome,email,idade) values('{0}','{1}',{2})", nome, email, idade);

                    //pega a string com o comando sql, no caso 'cmdInserir', e a conexao aberta em 'pgsqlConnection.open'
                    //com isso instancia o objeto 'pgsql' passando os atributos e assim executa os comandos no banco
                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInserir, pgsqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                return false;
                throw ex;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }

    }
}
