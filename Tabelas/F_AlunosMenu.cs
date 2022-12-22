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
    public partial class F_AlunosMenu : Form
    {
        public F_AlunosMenu()
        {
            InitializeComponent();
        }
        int id;
        string CPF;
        CRUD_Met acesso = new CRUD_Met();
        F_Alunos f_alunos = new F_Alunos();
        F_Notas f_notas = new F_Notas();
        F_Historico f_historico = new F_Historico();
        F_Mat_Aluno f_mat_aluno = new F_Mat_Aluno();

        public void atualizarExibicao()
        {
            dataGridView1.DataSource = acesso.GetTodosRegistros(0,null);
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            f_alunos.ShowDialog(0,0,id);
            atualizarExibicao();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            f_alunos.ShowDialog(0,1,id);
            atualizarExibicao();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            f_alunos.ShowDialog(0, 3, id);
            atualizarExibicao();
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            f_alunos.ShowDialog(1,2,id);
        }

        private void buttonMaterias_Click(object sender, EventArgs e)
        {
            f_mat_aluno.ShowDialog(CPF);
        }

        private void buttonNotas_Click(object sender, EventArgs e)
        {
            f_notas.ShowDialog(CPF);
        }

        private void buttonHistorico_Click(object sender, EventArgs e)
        {
            f_historico.ShowDialog(CPF);
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
                CPF = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            }
        }
    }
}
