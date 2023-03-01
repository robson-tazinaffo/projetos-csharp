using crudSQLite.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudSQLite
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Caixa de texto vazia!", "Usuário ou Senha não informado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUser.Clear();
                txtSenha.Clear();
            }
            else
            {
                Conexao con = new Conexao();

                try
                {
                    con.conectar();

                    string sql = "SELECT * FROM usuario WHERE email = '" + txtUser.Text +  "' AND password = '" + txtSenha.Text + "'";

                    SQLiteDataAdapter dados = new SQLiteDataAdapter(sql, con.conn); // Query de consulta
                    DataTable usuario = new DataTable();

                    dados.Fill(usuario); // Passando os dados do Adapter para o DataTable 

                    if (usuario.Rows.Count < 0)
                    {
                        MessageBox.Show("Usuário inválido!", "Registro não encontrado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSenha.Clear();
                        txtUser.Focus();
                    } else
                    {
                        string nome = usuario.Rows[0]["username"].ToString();
                        MessageBox.Show("Bem Vindo(a) " + nome, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
    }
}
