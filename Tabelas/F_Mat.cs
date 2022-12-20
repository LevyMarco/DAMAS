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
    public partial class F_Mat : Form
    {
        public F_Mat()
        {
            InitializeComponent();
        }
        int Mode;
        int curso_id;
        string aluno_id;
        bool Repetition;
        CRUD_Met acesso = new CRUD_Met();

        public void ShowDialog(int i, int j, string CPF)
        {
            Mode = i;
            if(Mode == 0)
            {
                ReadAndInsert(CPF,0);
            }
            else if(Mode == 1 || Mode == 2)
            {
                ReadAndInsert(CPF,j);
            }

            InsertInCombobox();
            this.ShowDialog();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            ExtractFromCombobox();
            Enviar(true);
            if (Repetition == false)
            {
                this.Close();
            }
        }

        public void Enviar(bool cad)
        {
            if (Mode == 0 && cad == true)
            {
                string[] Names = { aluno_id, textBoxAnoEntrada.Text };
                int[] Numbers = { curso_id };
                Repetition = acesso.GetRegistroPorId(2, aluno_id, 0);
                if (Repetition)
                {
                    MessageBox.Show("O Aluno inserido já está matriculado");
                }
                else
                {
                    acesso.InserirRegistros(2, Names, Numbers);
                }
            }
            else if (Mode == 1 && cad == true)
            {
                string[] Names = { aluno_id, textBoxAnoEntrada.Text, textBoxAnoSaida.Text };
                int[] Numbers = { curso_id };
                Repetition = acesso.GetRegistroPorId(2, aluno_id, curso_id);
                if (Repetition)
                {
                    MessageBox.Show("O Aluno inserido já está matriculado");
                }
                else
                {
                    acesso.AtualizarRegistro(2, Names, Numbers);
                }
            }
            else if (Mode == 2 && cad == true)
            {
                string[] Names = { aluno_id, textBoxAnoEntrada.Text, textBoxAnoSaida.Text };
                int[] Numbers = { curso_id };
                Repetition = acesso.GetRegistroPorId(2, aluno_id, 0);
                if (Repetition)
                {
                    MessageBox.Show("O Aluno inserido já está matriculado");
                }
                else
                {
                    acesso.AtualizarRegistro(3, Names, Numbers);
                }
            }
        }

        public void ReadAndInsert(string name, int id)
        {
            if (id == 0)
            {
                comboBoxAluno.Text = string.Empty;
                comboBoxCurso.Text = string.Empty;
                textBoxAnoEntrada.Text = string.Empty;
                textBoxAnoSaida.Text = string.Empty;
            }
            else
            {
                CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
                CRUD_Met.cn.Open();
                string cmdSeleciona = String.Format("Select \"ID_Aluno\",\"ID_Curso\",\"Ano_Entrada\",\"Ano_Saida\" from \"Matriculas\" Where \"ID_Aluno\" = '{0}'", name);
                NpgsqlCommand pgsqlCommand;
                pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
                NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
                if (pgsqlReader.HasRows)
                {
                    while (pgsqlReader.Read())
                    {
                        aluno_id = Convert.ToString(pgsqlReader.GetValue(0).ToString());
                        curso_id = Convert.ToInt32(pgsqlReader.GetValue(1).ToString());
                        textBoxAnoEntrada.Text = Convert.ToString(pgsqlReader.GetValue(2).ToString());
                        textBoxAnoSaida.Text = Convert.ToString(pgsqlReader.GetValue(3).ToString());
                    }
                    pgsqlReader.Close();
                }
                cmdSeleciona = String.Format("Select \"Nome\" from \"Cadastro Geral de Alunos\" where \"CPF\" = '{0}'", aluno_id);
                pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
                pgsqlCommand.ExecuteReader();
                if (pgsqlReader.HasRows)
                {
                    while (pgsqlReader.Read())
                    {
                        comboBoxAluno.Text = Convert.ToString(pgsqlReader.GetValue(0).ToString().Trim());
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
            comboBoxAluno.Items.Clear();
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona;
            cmdSeleciona = String.Format("Select \"Nome\" from \"Cadastro Geral de Alunos\"");
            NpgsqlCommand pgsqlCommand;
            pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (pgsqlReader.HasRows)
            {
                while (pgsqlReader.Read())
                {
                    comboBoxAluno.Items.Add(Convert.ToString(pgsqlReader.GetValue(0).ToString()).Trim());
                }
                pgsqlReader.Close();
            }
            cmdSeleciona = String.Format("Select \"Nome\" from \"Informações dos Cursos\"");
            pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            pgsqlCommand.ExecuteReader();
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
            string cmdSeleciona;
            cmdSeleciona = String.Format("Select \"CPF\" from \"Cadastro Geral de Alunos\" Where \"Nome\" = '{0}'", comboBoxAluno.Text);
            NpgsqlCommand pgsqlCommand;
            pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (pgsqlReader.HasRows)
            {
                while (pgsqlReader.Read())
                {
                    aluno_id = Convert.ToString(pgsqlReader.GetValue(0).ToString());
                }
                pgsqlReader.Close();
            }
            cmdSeleciona = String.Format("Select \"ID\" from \"Informações dos Cursos\" Where \"Nome\" = '{0}'", comboBoxCurso.Text);
            pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            pgsqlCommand.ExecuteReader();
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
