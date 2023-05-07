using System;
using System.Data.SqlClient;

namespace ConnectionSqlServer.Controllers
{
    public class BackupController
    {
        private SqlConnection connection;

        public string Backup(string ruta, SqlConnectionStringBuilder getConnection)
        {
            connection = new SqlConnection(getConnection.ConnectionString);
            string cmfarma = connection.Database.ToString();
            try
            {
                string cmd = "BACKUP DATABASE [" + cmfarma + "] TO DISK ='" + ruta + "\\" + "cmfarma" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak' WITH CHECKSUM;";
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    if (connection.State != System.Data.ConnectionState.Open) connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return "Backup realizado";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ex.ToString();
            }
            return "No se pudo realizar";
        }

        public string Restore(string ruta, string dbName, SqlConnectionStringBuilder getConnection)
        {
            connection = new SqlConnection(getConnection.ConnectionString);
            string cmfarma = dbName;

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();

            try
            {
                /*string sqlStmt2 = string.Format("ALTER DATABASE [" + cmfarma + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, connection);
                bu2.ExecuteNonQuery();*/

                string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + cmfarma + "] FROM DISK='" + ruta + "' WITH REPLACE;";
                SqlCommand bu3 = new SqlCommand(sqlStmt3, connection);
                bu3.ExecuteNonQuery();

                /*string sqlStmt4 = string.Format("ALTER DATABASE [" + cmfarma + "] SET MULTI_USER");
                SqlCommand bu4 = new SqlCommand(sqlStmt4, connection);
                bu4.ExecuteNonQuery();*/
                
                connection.Close();
                
                return "Restauración de la base de datos realizada con éxito";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "No se pudo restaurar la base de datos";
        }
    }
}
