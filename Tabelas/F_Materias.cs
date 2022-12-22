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
    public partial class F_Materias : Form
    {
        public F_Materias()
        {
            InitializeComponent();
        }
        int id;
        int id_materia;
        int Mode;
        int curso_id;
        string name = null;
        bool Repetition;
        CRUD_Met acesso = new CRUD_Met();

        public void ShowDialog(int i, int j, string name)
        {
            Mode = i;
            id = j;
            this.name = name;
            if (i == 0)
            {
                ReadAndInsert(this.name, 0);
            }
            else
            {
                ReadAndInsert(this.name, id);
            }
            Enviar(false);
            if (i != 2)
            {
                InsertInCombobox();
                this.ShowDialog();
            }
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            ExtractFromCombobox();
            Enviar(true);
            if(Repetition == false)
            {
                this.Close();
            }
        }

        public void Enviar(bool cad)
        {
            if (Mode == 0 && cad == true)
            {
                string[] Names = { textBoxNome.Text };
                int[] Numbers = { curso_id };
                Repetition = acesso.GetRegistroPorId(4, textBoxNome.Text, 0);
                if (Repetition)
                {
                    MessageBox.Show("A Matéria inserida já está cadastrada");
                }
                else
                {
                    acesso.InserirRegistros(4, Names, Numbers);
                }
            }
            else if (Mode == 1 && cad == true)
            {
                string[] Names = { textBoxNome.Text, comboBoxCurso.Text };
                int[] Numbers = { curso_id, id_materia };
                Repetition = acesso.GetRegistroPorId(4, textBoxNome.Text, curso_id);
                if (Repetition)
                {
                    MessageBox.Show("A Matéria inserida já está cadastrada");
                }
                else
                {
                    acesso.AtualizarRegistro(4, Names, Numbers);
                }
            }
            else if (Mode == 2)
            {
                acesso.DeletarRegistro(4, null, id_materia);
            }
        }
        public void ReadAndInsert(string name, int id)
        {
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona = String.Format("Select * from \"Matérias\" where \"Nome\" = '{0}' And \"ID_Curso\" = {1}", name, id);
            NpgsqlCommand pgsqlCommand;
            pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if(id == 0)
            {
                textBoxNome.Text = string.Empty;
                comboBoxCurso.Text = string.Empty;
            }
            else
            {
                if (pgsqlReader.HasRows)
                {
                    while (pgsqlReader.Read())
                    {
                        textBoxNome.Text = Convert.ToString(pgsqlReader.GetValue(0).ToString());
                        curso_id = Convert.ToInt32(pgsqlReader.GetValue(1).ToString());
                        id_materia = Convert.ToInt32(pgsqlReader.GetValue(2).ToString());
                    }
                    pgsqlReader.Close();
                }
                cmdSeleciona = String.Format("Select \"Nome\" from \"Informações dos Cursos\" where \"ID\" = {0}", curso_id);
                pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
                pgsqlCommand.ExecuteReader();
                if (pgsqlReader.HasRows)
                {
                    while (pgsqlReader.Read())
                    {
                        comboBoxCurso.Text = Convert.ToString(pgsqlReader.GetValue(0).ToString().Trim());
                    }
                    pgsqlReader.Close();
                }
            }
            CRUD_Met.cn.Close();
        }

        public void InsertInCombobox()
        {
            comboBoxCurso.Items.Clear();
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona = String.Format("Select \"Nome\" from \"Informações dos Cursos\"");
            NpgsqlCommand pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (pgsqlReader.HasRows)
            {
                while (pgsqlReader.Read())
                {
                    comboBoxCurso.Items.Add(Convert.ToString(pgsqlReader.GetValue(0).ToString()).Trim());
                }
                pgsqlReader.Close();
            }
            CRUD_Met.cn.Close();
        }

        public void ExtractFromCombobox()
        {
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona = String.Format("Select \"ID\" from \"Informações dos Cursos\" Where \"Nome\" = '{0}'", comboBoxCurso.Text);
            NpgsqlCommand pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (pgsqlReader.HasRows)
            {
                while (pgsqlReader.Read())
                {
                    curso_id = Convert.ToInt32(pgsqlReader.GetValue(0).ToString());
                }
                pgsqlReader.Close();
            }
            CRUD_Met.cn.Close();
        }
    }
}
