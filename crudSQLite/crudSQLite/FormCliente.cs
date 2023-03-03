using crudSQLite.classes;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace crudSQLite
{
    public partial class FormCliente : Form
    {
        Conexao con = new Conexao();

        public FormCliente()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Caixa de texto vazia!", "Usuário ou Senha não informado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Clear();
                txtEmail.Clear();
            }
            else
            {
                Conexao con = new Conexao();

                try
                {
                    con.conectar();

                    //string sql = "INSERT INTO cliente (nome, telefone, email) VALUES (@nome, @telefone, @email)";

                    //SQLiteCommand cmd = new SQLiteCommand(sql, con.conn);
                    //cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    //cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                    //cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    //con.conn.Open();

                    //cmd.ExecuteReader();

                    //MessageBox.Show("Registro inserido com sucesso!");

                    int sequencial = 4;

                    string sql = "INSERT INTO cliente(id, nome, telefone, email) VALUES " +
                        "(" +
                        +sequencial + "," +
                        //                        " , '" + txtNome.Text + "' , '" 
                        //                        + txtTelefone.Text + "' , '" 
                        //                        + txtEmail.Text  
                        //                        + "')";
                        "'" + txtNome.Text + "'" + "," +
                        "'" + txtTelefone.Text + "'" + "," +
                        "'" + txtEmail.Text + "'" +
                        ")";


                    MessageBox.Show(sql);

                    SQLiteDataAdapter dados = new SQLiteDataAdapter(sql, con.conn); // Query de consulta
                    DataTable cliente = new DataTable();

                    dados.Fill(cliente); // Passando os dados do Adapter para o DataTable 

                    if (cliente.Rows.Count < 0)
                    {
                        MessageBox.Show("Cliente inválido!", "Registro não encontrado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEmail.Clear();
                        txtTelefone.Clear();
                        txtNome.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Registro inserido com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            // **********************************************************
            //try
            //{
            //    con.conectar();


            //    string sql = "insert into cliente (nome, telefone, email) values (@nome, @telefone, @email)";

            //    sqlitecommand cmd = new sqlitecommand(sql, conn);
            //    cmd.parameters.addwithvalue("@nome", txtnome.text);
            //    cmd.parameters.addwithvalue("@telefone", txttelefone.text);
            //    cmd.parameters.addwithvalue("@email", txtemail.text);

            //    sqlitedataadapter dados = new sqlitedataadapter(sql, con.conn); // query de consulta
            //    datatable usuario = new datatable();

            //    dados.fill(usuario); // passando os dados do adapter para o datatable 

            //    cmd.executereader();

            //    messagebox.show("registro inserido com sucesso!");

            //}
            //catch (exception ex)
            //{
            //    messagebox.show(ex.message);
            //}
            //finally
            //{
            //    conn.close();
            //}

        }
    }
}
