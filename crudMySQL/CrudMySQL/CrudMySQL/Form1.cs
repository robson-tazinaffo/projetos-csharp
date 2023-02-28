using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CrudMySQL
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string data_source = "datasource=localhost;username=root;password=Ekt]+c@AQv>ej(FE;database=db_agenda";

                // Criar conexão xom o MySQL
                conn = new MySqlConnection(data_source);

                string sql = "INSERT INTO contato (nome, telefone, email) VALUES (@nome, @telefone, @email)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                conn.Open();

                cmd.ExecuteReader();

                MessageBox.Show("Registro inserido com sucesso!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
