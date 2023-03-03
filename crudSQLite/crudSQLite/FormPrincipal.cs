using System;
using System.Windows.Forms;

namespace crudSQLite
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente formulario = new FormCliente();
            formulario.Show();
        }

        private void FormPrincipal_Deactivate(object sender, EventArgs e)
        {
            //Application.Exit();
        }
    }
}
