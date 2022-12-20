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
    public partial class F_Mat_Aluno : Form
    {
        public F_Mat_Aluno()
        {
            InitializeComponent();
        }
        int comprimento;
        int[] materias;
        string aluno_id;
        CRUD_Met acesso = new CRUD_Met();

        public void ShowDialog(string i)
        {
            aluno_id = i;
            ReadMaterias();
            InsertInListbox();
            this.Show();
        }

        public void ReadMaterias()
        {
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
                cmdSeleciona = String.Format("Select \"matérias\"[{0}] from \"Cadastro Geral de Alunos\" Where \"CPF\" = '{1}'", i + 1, aluno_id);
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

        public void InsertInListbox()
        {
            listBoxMaterias.Items.Clear();
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona;
            for(int i = 0; i < comprimento; i++)
            {
                cmdSeleciona = String.Format("Select \"Nome\" from \"Matérias\" Where \"ID\" = {0}", materias[i]);
                NpgsqlCommand pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
                NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
                if (pgsqlReader.HasRows)
                {
                    while (pgsqlReader.Read())
                    {
                        listBoxMaterias.Items.Add(Convert.ToString(pgsqlReader.GetValue(0).ToString()).Trim());
                    }
                    pgsqlReader.Close();
                }
            }
            CRUD_Met.cn.Close();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
