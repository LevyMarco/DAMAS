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
    public partial class F_Menu : Form
    {
        

        public F_Menu()
        {
            InitializeComponent();
        }

        private void buttonAlunos_Click(object sender, EventArgs e)
        {
            F_AlunosMenu f_AlunosMenu = new F_AlunosMenu();
            f_AlunosMenu.atualizarExibicao();
            this.Hide();
            f_AlunosMenu.ShowDialog();
            this.Show();
        }

        private void buttonCursos_Click(object sender, EventArgs e)
        {
            F_CursosMenu f_CursosMenu = new F_CursosMenu();
            f_CursosMenu.atualizarExibicao();
            this.Hide();
            f_CursosMenu.ShowDialog();
            this.Show();
        }

        private void buttonMat_Ativas_Click(object sender, EventArgs e)
        {
            F_MatMenu f_MatMenu = new F_MatMenu();
            f_MatMenu.atualizarExibicao();
            this.Hide();
            f_MatMenu.ShowDialog();
            this.Show();
        }

        private void buttonMaterias_Click(object sender, EventArgs e)
        {
            F_MateriasMenu f_MateriasMenu = new F_MateriasMenu();
            f_MateriasMenu.atualizarExibicao();
            this.Hide();
            f_MateriasMenu.ShowDialog();
            this.Show();
        }
    }
}
