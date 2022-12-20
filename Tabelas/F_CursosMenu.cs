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
    public partial class F_CursosMenu : Form
    {
        public F_CursosMenu()
        {
            InitializeComponent();
        }
        int id;
        CRUD_Met acesso = new CRUD_Met();
        F_Cursos f_cursos = new F_Cursos();

        public void atualizarExibicao()
        {
            dataGridView1.DataSource = acesso.GetTodosRegistros(1, null);
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            f_cursos.ShowDialog(0, id);
            atualizarExibicao();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            f_cursos.ShowDialog(1, id);
            atualizarExibicao();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            f_cursos.ShowDialog(2, id);
            atualizarExibicao();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value is DBNull)
            {
                id = 0;
            }
            else
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            }
        }
    }
}
