using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Projeto_LPA
{
    public partial class F_Cursos : Form
    {
        public F_Cursos()
        {
            InitializeComponent();
        }
        int id;
        int Mode;
        bool Repetition;
        CRUD_Met acesso = new CRUD_Met();

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            Enviar(true);
            if (Repetition == false)
            {
                this.Close();
            }
        }

        public void ShowDialog(int i, int j)
        {
            Mode = i;
            id = j;
            if (i == 0)
            {
                ReadAndInsert(0);
            }
            else
            {
                ReadAndInsert(id);
            }
            Enviar(false);
            if (i != 2)
            {
                this.ShowDialog();
            }
        }

        public void Enviar(bool cad)
        {
            if (Mode == 0 && cad == true)
            {
                string[] Names = { textBoxCurso.Text, comboBoxDuracao.Text };
                Repetition = acesso.GetRegistroPorId(1, textBoxCurso.Text, 0);
                if (Repetition)
                {
                    MessageBox.Show("O Curso inserido já está cadastrado");
                }
                else
                {
                    acesso.InserirRegistros(1, Names, null);
                }
            }
            else if (Mode == 1 && cad == true)
            {
                string[] Names = { textBoxCurso.Text, comboBoxDuracao.Text };
                int[] Numbers = { id };
                Repetition = acesso.GetRegistroPorId(1, textBoxCurso.Text, id);
                if (Repetition)
                {
                    MessageBox.Show("O Curso inserido já está cadastrado");
                }
                else
                {
                    acesso.AtualizarRegistro(1, Names, Numbers);
                }
            }
            else if (Mode == 2)
            {
                acesso.DeletarRegistro(1, textBoxCurso.Text, id);
            }
        }

        public void ReadAndInsert(int id)
        {
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona = String.Format("Select * from \"Informações dos Cursos\" where \"ID\" = {0}", id);
            NpgsqlCommand pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (id == 0)
            {
                textBoxCurso.Text = string.Empty;
                comboBoxDuracao.Text = null;
            }
            else
            {
                if (pgsqlReader.HasRows)
                {
                    while (pgsqlReader.Read())
                    {
                        textBoxCurso.Text = Convert.ToString(pgsqlReader.GetValue(1).ToString());
                        comboBoxDuracao.Text = Convert.ToString(pgsqlReader.GetValue(2).ToString());
                    }
                    pgsqlReader.Close();
                }
            }
            CRUD_Met.cn.Close();
        }
    }
}
