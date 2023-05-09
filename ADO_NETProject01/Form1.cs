using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; // add
using System.Data.SqlClient; // add

namespace ADO_NETProject01
{
    public partial class FormDados : Form
    {
        public FormDados()
        {
            InitializeComponent();
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.
                ConnectionStrings["CS_ADO_NET"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into FORNECEDORES(nome, cnpj)" +
                " values(@nome, @cnpj)";
            command.Parameters.AddWithValue("@nome", textBoxNome.Text);
            command.Parameters.AddWithValue("@cnpj", textBoxCnpj.Text);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
            MessageBox.Show("Fornecedor registrado com sucesso");
        }
    }
}
