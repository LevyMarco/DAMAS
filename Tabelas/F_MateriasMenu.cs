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
    public partial class F_MateriasMenu : Form
    {
        public F_MateriasMenu()
        {
            InitializeComponent();
        }
        int id;
        int id_curso;
        string name = null;
        CRUD_Met acesso = new CRUD_Met();
        F_Materias f_materias = new F_Materias();
        F_Mat_Materia f_mat_materia = new F_Mat_Materia();

        public void atualizarExibicao()
        {
            dataGridView1.DataSource = acesso.GetTodosRegistros(4, null);
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            f_materias.ShowDialog(0, id_curso, name);
            atualizarExibicao();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            f_materias.ShowDialog(1, id_curso, name);
            atualizarExibicao();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            f_materias.ShowDialog(2, id_curso, name);
            atualizarExibicao();
        }

        private void buttonInserirAluno_Click(object sender, EventArgs e)
        {
            f_mat_materia.ShowDialog(id,0);
        }

        private void buttonRemoverAluno_Click(object sender, EventArgs e)
        {
            f_mat_materia.ShowDialog(id, 1);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value is DBNull)
            {
                id_curso = 0;
            }
            else
            {
                name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                id_curso = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            }
        }
    }
}
