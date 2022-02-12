using ConnectionSqlServer.Controllers;
using ConnectionSqlServer.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConnectionSqlServer
{
    public partial class Conexion : Form
    {
        private ConnectionModel connectionModel;
        private ConexionController conexionController;
        private SqlConnectionStringBuilder builder;

        public Conexion()
        {
            InitializeComponent();
            RbtnWA.Checked = true;
            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;
            connectionModel = new ConnectionModel();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            makeConnection();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            makeConnection();
        }

        private void RbtnWA_CheckedChanged(object sender, EventArgs e)
        {
            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void RbtnA_CheckedChanged(object sender, EventArgs e)
        {
            txtUsuario.Enabled = true;
            txtPassword.Enabled = true;
        }

        private void makeConnection()
        {
            conexionController = new ConexionController();

            if (RbtnWA.Checked)
            {
                builder = conexionController.ConexionSQLWinAuth();
            }

            if (RbtnA.Checked)
            {
                connectionModel.host     = txtHost.Text;
                connectionModel.port     = txtPuerto.Text;
                connectionModel.dbname   = txtDBName.Text;
                connectionModel.usuario  = txtUsuario.Text;
                connectionModel.password = txtPassword.Text;
                
                builder = conexionController.ConexionSQLAuth(connectionModel);
                MessageBox.Show(builder.ToString());
            }

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexion establecida");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
