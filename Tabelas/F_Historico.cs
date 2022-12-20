using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_LPA
{
    public partial class F_Historico : Form
    {
        public F_Historico()
        {
            InitializeComponent();
        }

        CRUD_Met acesso = new CRUD_Met();
        string SearchItem;

        public void ShowDialog(string CPF)
        {
            SearchItem = CPF;
            atualizarExibicao();
            this.ShowDialog();
        }

        public void atualizarExibicao()
        {
            dataGridView1.DataSource = acesso.GetTodosRegistros(6, SearchItem);
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
