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
    public partial class F_Mat_Materia : Form
    {
        public F_Mat_Materia()
        {
            InitializeComponent();
        }
        int materia;
        int comprimento;
        int Mode;
        string aluno_id;
        int[] materias;
        string new_materias;
        CRUD_Met acesso = new CRUD_Met();

        public void ShowDialog(int id, int i)
        {
            Mode = i;
            materia = id;
            if(Mode == 0)
            {
                buttonInserir.Text = "Inserir";
            }
            else
            {
                buttonInserir.Text = "Remover";
            }
            InsertInCombobox();
            this.ShowDialog();
            
        }

        public void ReadMaterias()
        {
            ExtractFromCombobox();
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona;
            cmdSeleciona = String.Format("Select cardinality(matérias) from \"Cadastro Geral de Alunos\" Where \"CPF\" = '{0}'", aluno_id);
            NpgsqlCommand pgsqlCommand;
            pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (pgsqlReader.HasRows)
            {
                while (pgsqlReader.Read())
                {
                    if (String.IsNullOrEmpty(pgsqlReader.GetValue(0).ToString()))
                    {
                        comprimento = 0;
                    }
                    else
                    {
                        comprimento = Convert.ToInt32(pgsqlReader.GetValue(0).ToString());
                    }
                }
                pgsqlReader.Close();
            }
            materias = new int[comprimento];
            for (int i = 0; i < comprimento; i++)
            {
                cmdSeleciona = String.Format("Select \"matérias\"[{0}] from \"Cadastro Geral de Alunos\" Where \"CPF\" = '{1}'", i+1, aluno_id);
                pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
                pgsqlCommand.ExecuteReader();
                if (pgsqlReader.HasRows)
                {
                    while (pgsqlReader.Read())
                    {
                        materias[i] = Convert.ToInt32(pgsqlReader.GetValue(0).ToString());
                    }
                    pgsqlReader.Close();
                }
            }
            CRUD_Met.cn.Close();
        }

        public void InsertMaterias()
        {
            if(comprimento == 0)
            {
                new_materias = String.Format("{{{0}}}",materia);
            }
            else
            {
                if (materias.Contains(Convert.ToInt32(materia)))
                {
                    MessageBox.Show("O Aluno já está matriculado na matéria");
                    return;
                }
                else
                {
                    new_materias = String.Format("{{{0}", materias[0]);
                    for (int i = 1; i < comprimento; i++)
                    {
                        new_materias = new_materias + String.Format(",{0}", materias[i]);
                    }
                    new_materias = new_materias + String.Format(",{0}}}", materia);
                }
            }
            ExtractFromCombobox();
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdAtualiza;
            cmdAtualiza = String.Format("Update \"Cadastro Geral de Alunos\" Set \"matérias\" = '{0}' Where \"CPF\" = '{1}'", new_materias, aluno_id);
            MessageBox.Show(cmdAtualiza);
            NpgsqlCommand pgsqlCommand;
            pgsqlCommand = new NpgsqlCommand(cmdAtualiza, CRUD_Met.cn);
            pgsqlCommand.ExecuteNonQuery();
            CRUD_Met.cn.Close();
            MessageBox.Show("Aluno matriculado com sucesso");
            InserirNota();
        }

        public void RemoveMaterias()
        {
            if (comprimento == 0)
            {
                MessageBox.Show("O Aluno não está matriculado em nenhuma matéria");
                return;
            }
            else
            {
                if (materias.Contains(Convert.ToInt32(materia)))
                {
                    materias = materias.Except(new int[] { materia }).ToArray();
                    string cmdAtualiza;
                    if (materias.Length == 0)
                    {
                        MessageBox.Show("O Aluno não está mais matriculado em nenhuma matéria");
                        ExtractFromCombobox();
                        CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
                        CRUD_Met.cn.Open();
                        cmdAtualiza = String.Format("Update \"Cadastro Geral de Alunos\" Set \"matérias\" = null Where \"CPF\" = '{0}'", aluno_id);
                        
                    }
                    else
                    {
                        new_materias = String.Format("{{{0}", materias[0]);
                        for (int i = 1; i < comprimento - 1; i++)
                        {
                            new_materias = new_materias + String.Format(",{0}", materias[i]);
                        }
                        new_materias = new_materias + "}";
                        MessageBox.Show(new_materias);
                        ExtractFromCombobox();
                        CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
                        CRUD_Met.cn.Open();
                        cmdAtualiza = String.Format("Update \"Cadastro Geral de Alunos\" Set \"matérias\" = '{0}' Where \"CPF\" = '{1}'", new_materias, aluno_id);
                        
                    }
                    MessageBox.Show(cmdAtualiza);
                    NpgsqlCommand pgsqlCommand;
                    pgsqlCommand = new NpgsqlCommand(cmdAtualiza, CRUD_Met.cn);
                    pgsqlCommand.ExecuteNonQuery();
                    CRUD_Met.cn.Close();
                    MessageBox.Show("Aluno desmatriculado com sucesso");
                    RemoverNota();
                }
                else
                {
                    MessageBox.Show("O Aluno não está matriculado nesta matéria");
                    return;
                }
            }
        }

        public void InserirNota()
        {
            string materia_nome = null;
            int curso_id = 0;
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona = String.Format("Select \"Nome\",\"ID_Curso\" from \"Matérias\" Where \"ID\" = {0}", materia);
            NpgsqlCommand pgsqlCommand;
            pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (pgsqlReader.HasRows)
            {
                while (pgsqlReader.Read())
                {
                    materia_nome = Convert.ToString(pgsqlReader.GetValue(0).ToString()).Trim();
                    curso_id = Convert.ToInt32(pgsqlReader.GetValue(1).ToString());
                }
                pgsqlReader.Close();
            }
            string cmdInserir = String.Format("Insert Into \"Notas\"(\"Matérias\",\"ID_Aluno\",\"ID_Curso\",\"Nota Ativa\") values('{0}','{1}',{2},true)",materia_nome, aluno_id, curso_id);
            pgsqlCommand = new NpgsqlCommand(cmdInserir, CRUD_Met.cn);
            pgsqlCommand.ExecuteNonQuery();
            CRUD_Met.cn.Close();
        }

        public void RemoverNota()
        {
            string materia_nome = null;
            int curso_id = 0;
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona = String.Format("Select \"Nome\",\"ID_Curso\" from \"Matérias\" Where \"ID\" = {0}", materia);
            NpgsqlCommand pgsqlCommand;
            pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (pgsqlReader.HasRows)
            {
                while (pgsqlReader.Read())
                {
                    materia_nome = Convert.ToString(pgsqlReader.GetValue(0).ToString()).Trim();
                    curso_id = Convert.ToInt32(pgsqlReader.GetValue(1).ToString());
                }
                pgsqlReader.Close();
            }
            string cmdAtualiza = String.Format("Update \"Notas\" Set \"Nota Ativa\" = false Where \"Matérias\" = '{0}' And \"ID_Aluno\" = '{1}' And \"ID_Curso\" = {2}",materia_nome, aluno_id, curso_id);
            pgsqlCommand = new NpgsqlCommand(cmdAtualiza, CRUD_Met.cn);
            pgsqlCommand.ExecuteNonQuery();
            CRUD_Met.cn.Close();
        }

        public void InsertInCombobox()
        {
            comboBoxAluno.Items.Clear();
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona = String.Format("Select \"Nome\" from \"Cadastro Geral de Alunos\"");
            NpgsqlCommand pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (pgsqlReader.HasRows)
            {
                while (pgsqlReader.Read())
                {
                    comboBoxAluno.Items.Add(Convert.ToString(pgsqlReader.GetValue(0).ToString()).Trim());
                }
                pgsqlReader.Close();
            }
            CRUD_Met.cn.Close();
        }

        public void ExtractFromCombobox()
        {
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona = String.Format("Select \"CPF\" from \"Cadastro Geral de Alunos\" Where \"Nome\" = '{0}'", comboBoxAluno.Text);
            NpgsqlCommand pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (pgsqlReader.HasRows)
            {
                while (pgsqlReader.Read())
                {
                    aluno_id = Convert.ToString(pgsqlReader.GetValue(0).ToString());
                }
                pgsqlReader.Close();
            }
            CRUD_Met.cn.Close();
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            if(Mode == 0)
            {
                ReadMaterias();
                InsertMaterias();
            }
            else
            {
                ReadMaterias();
                RemoveMaterias();
            }
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
