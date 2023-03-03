using crudSQLite.classes;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace crudSQLite
{
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "e-mail")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "e-mail";
                txtUsuario.ForeColor = Color.DimGray;
            }

        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Senha")
            {
                txtSenha.Text = "";
                txtSenha.ForeColor = Color.LightGray;
                txtSenha.UseSystemPasswordChar = true;
            }

        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.Text = "Senha";
                txtSenha.ForeColor = Color.DimGray;
                txtSenha.UseSystemPasswordChar = false;
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void PictureBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Caixa de texto vazia!", "Usuário ou Senha não informado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Clear();
                txtSenha.Clear();
            }
            else
            {
                Conexao con = new Conexao();

                try
                {
                    con.conectar();

                    string sql = "SELECT * FROM usuario WHERE email = '" + txtUsuario.Text + "' AND password = '" + txtSenha.Text + "'";

                    SQLiteDataAdapter dados = new SQLiteDataAdapter(sql, con.conn); // Query de consulta
                    DataTable usuario = new DataTable();

                    dados.Fill(usuario); // Passando os dados do Adapter para o DataTable 

                    if (usuario.Rows.Count < 0)
                    {
                        MessageBox.Show("Usuário inválido!", "Registro não encontrado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSenha.Clear();
                        txtUsuario.Focus();
                    }
                    else
                    {
                        //string nome = usuario.Rows[0]["username"].ToString();
                        //MessageBox.Show("Bem Vindo(a) " + nome, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        FormPrincipal formulario = new FormPrincipal();
                        formulario.Show();

                        this.Hide();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void abrirJanela(object obj)
        {
        }


        private void FormLogin_Activated(object sender, EventArgs e)
        {
            txtUsuario.Text = "robsontazinaffo@hotmail.com";
            txtSenha.Text = "123";
        }
    }
}
