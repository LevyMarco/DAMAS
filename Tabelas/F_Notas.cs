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
    public partial class F_Notas : Form
    {
        public F_Notas()
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
            dataGridView1.DataSource = acesso.GetTodosRegistros(5, SearchItem);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value is DBNull)
            {
                return;
            }
            else
            {
                if (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[1].Value)!=10)
                {
                    maskedTextBoxNota1.Text = "0" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                }
                else
                {
                    maskedTextBoxNota1.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                }
                if (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value)!=10)
                {
                    maskedTextBoxNota2.Text = "0" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                }
                else
                {
                    maskedTextBoxNota2.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                }
                if (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[3].Value)!=10)
                {
                    maskedTextBoxMedia.Text = "0" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                }
                else
                {
                    maskedTextBoxMedia.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                }
            }
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            string[] Names = { maskedTextBoxNota1.Text, maskedTextBoxNota2.Text, maskedTextBoxMedia.Text, SearchItem };
            acesso.AtualizarRegistro(5, Names, null);
            atualizarExibicao();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
