using System.Data.SqlClient;

namespace Agenda_Telefonica.Models
{
    public class ConectarBancoDeDados
    {
        private static string strconexao = @"Data Source=NOTE-HUGO\sqlexpress;Initial Catalog=Agenda;Integrated Security=True";
        
        public static SqlConnection conectarBanco()
        {
            SqlConnection connection = new SqlConnection(strconexao);
            return connection;
        }
    }
}
