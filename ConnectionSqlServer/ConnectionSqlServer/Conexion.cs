using ConnectionSqlServer.Controllers;
using ConnectionSqlServer.Models;
using System;
using System.Windows.Forms;

namespace ConnectionSqlServer
{
    public partial class Conexion : Form
    {
        private ConnectionModel connectionModel;
        private ConexionController conexionController;

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
                conexionController.ConexionSQLWinAuth();
            }

            if (RbtnA.Checked)
            {
                connectionModel.host     = txtHost.Text;
                connectionModel.port     = txtPuerto.Text;
                connectionModel.dbname   = txtDBName.Text;
                connectionModel.usuario  = txtUsuario.Text;
                connectionModel.password = txtPassword.Text;
                
                conexionController.ConexionSQLAuth(connectionModel);
            }
        }
    }
}
