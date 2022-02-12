using ConnectionSqlServer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionSqlServer.Controllers
{
    public class ConexionController
    {
        private SqlConnectionStringBuilder builder;
        private ConnectionModel connectionModel;

        public SqlConnectionStringBuilder ConexionSQLAuth(ConnectionModel getConnectionModel)
        {
            connectionModel = getConnectionModel;
            builder = new SqlConnectionStringBuilder()
            {
                DataSource = connectionModel.host,
                InitialCatalog = connectionModel.dbname,
                UserID = connectionModel.usuario,
                Password = connectionModel.password
            };
            builder.ApplicationName = "ConexionSQLServer";
            Console.WriteLine(builder.ToString());
            return builder;
        }

        public SqlConnectionStringBuilder ConexionSQLWinAuth()
        {
            builder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "master",
                IntegratedSecurity = true
            };
            builder.ApplicationName = "ConexionSQLServer";
            Console.WriteLine(builder.ToString());
            return builder;
        }
    }
}
