using ConnectionSqlServer.Controllers;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConnectionSqlServer
{
    public partial class Dashboard : Form
    {
        private BackupController backupController;
        private SqlConnectionStringBuilder builder;

        public Dashboard(SqlConnectionStringBuilder getConnection)
        {
            InitializeComponent();
            builder = getConnection;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = dlg.SelectedPath;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            backupController = new BackupController();
            string result = backupController.Backup(txtRuta.Text, builder);
            MessageBox.Show(result);
        }

        private void btnBuscarBack_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL Server Databases backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtRutaRestore.Text = dlg.FileName;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            backupController = new BackupController();
            string result = backupController.Restore(txtRutaRestore.Text, txtDbNameRestore.Text, builder);
            MessageBox.Show(result);
        }
    }
}
