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
    public partial class F_MatMenu : Form
    {
        public F_MatMenu()
        {
            InitializeComponent();
        }
        CRUD_Met acesso = new CRUD_Met();
        F_Mat f_mat = new F_Mat();
        int Modo = 0;
        int id;
        int id_curso;
        string name = null;

        public void atualizarExibicao()
        {
            if(Modo == 0)
            {
                dataGridView1.DataSource = acesso.GetTodosRegistros(7, null);
            }
            else if(Modo == 1)
            {
                dataGridView1.DataSource = acesso.GetTodosRegistros(2, null);
            }
            else if(Modo == 2)
            {
                dataGridView1.DataSource = acesso.GetTodosRegistros(3, null);
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            f_mat.ShowDialog(0,id_curso,name);
            atualizarExibicao();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            f_mat.ShowDialog(1,id_curso,name);
            atualizarExibicao();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            f_mat.ShowDialog(2,id_curso,name);
            atualizarExibicao();
        }

        private void buttonMudarModo_Click(object sender, EventArgs e)
        {
            Modo++;
            if(Modo > 2)
            {
                Modo = 0;
            }
            atualizarExibicao();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value is DBNull)
            {
                name = null;
            }
            else
            {
                name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                id_curso = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            }
        }
    }
}
