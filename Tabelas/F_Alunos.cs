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
    public partial class F_Alunos : Form
    {
        public F_Alunos()
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
            if(Repetition == false)
            {
                this.Close();
            }
        }

        public void ShowDialog(int i, int j, int h)
        {
            if(i == 0)
            {
                textBoxEmail.Enabled = true;
                textBoxEndereco.Enabled = true;
                textBoxNome.Enabled = true;
                textBoxNomeMae.Enabled = true;
                textBoxNomePai.Enabled = true;
                textBoxRG.Enabled = true;
                maskedTextBoxCPF.Enabled = true;
                maskedTextBoxNascimento.Enabled = true;
                maskedTextBoxTelefone.Enabled = true;
                comboBoxCor.Enabled = true;
                comboBoxECivil.Enabled = true;
                comboBoxGenero.Enabled = true;
                comboBoxGIMae.Enabled = true;
                comboBoxGIPai.Enabled = true;
                comboBoxNacionalidade.Enabled = true;
                comboBoxSangue.Enabled = true;
                comboBoxUF.Enabled = true;
                textBoxNIS.Enabled = true;
                comboBoxProced.Enabled = true;
            }
            else if(i == 1)
            {
                textBoxEmail.Enabled = false;
                textBoxEndereco.Enabled = false;
                textBoxNome.Enabled = false;
                textBoxNomeMae.Enabled = false;
                textBoxNomePai.Enabled = false;
                textBoxRG.Enabled = false;
                maskedTextBoxCPF.Enabled = false;
                maskedTextBoxNascimento.Enabled = false;
                maskedTextBoxTelefone.Enabled = false;
                comboBoxCor.Enabled = false;
                comboBoxECivil.Enabled = false;
                comboBoxGenero.Enabled = false;
                comboBoxGIMae.Enabled = false;
                comboBoxGIPai.Enabled = false;
                comboBoxNacionalidade.Enabled = false;
                comboBoxSangue.Enabled = false;
                comboBoxUF.Enabled = false;
                textBoxNIS.Enabled = false;
                comboBoxProced.Enabled = false;
            }
            Mode = j;
            id = h;
            if(j == 0)
            {
                ReadAndInsert(0);
            }
            else
            {
                ReadAndInsert(id);
            }
            Enviar(false);
            if(j != 3)
            {
                this.ShowDialog();
            }
        }

        public void Enviar(bool cad)
        {
            if(Mode!=2 && string.Equals(buttonEnviar.Text, "Sair"))
            {
                buttonEnviar.Text = "Enviar";
            }
            if(Mode == 0 && cad == true)
            {
                string[] Names = { textBoxNome.Text, maskedTextBoxCPF.Text, maskedTextBoxTelefone.Text, textBoxEmail.Text, maskedTextBoxNascimento.Text, textBoxNIS.Text, comboBoxCor.Text, comboBoxGenero.Text, comboBoxECivil.Text, textBoxEndereco.Text, comboBoxUF.Text, comboBoxNacionalidade.Text, comboBoxProced.Text, textBoxNomePai.Text, textBoxNomeMae.Text, comboBoxGIPai.Text, comboBoxGIMae.Text, comboBoxSangue.Text, textBoxRG.Text };
                Repetition = acesso.GetRegistroPorId(0, maskedTextBoxCPF.Text, 0);
                if (Repetition)
                {
                    MessageBox.Show("O CPF inserido já está cadastrado");
                }
                else
                {
                    acesso.InserirRegistros(0, Names, null);
                }
            }
            else if(Mode == 1 && cad == true)
            {
                string[] Names = { textBoxNome.Text, maskedTextBoxCPF.Text, maskedTextBoxTelefone.Text, textBoxEmail.Text, maskedTextBoxNascimento.Text, textBoxNIS.Text, comboBoxCor.Text, comboBoxGenero.Text, comboBoxECivil.Text, textBoxEndereco.Text, comboBoxUF.Text, comboBoxNacionalidade.Text, comboBoxProced.Text, textBoxNomePai.Text, textBoxNomeMae.Text, comboBoxGIPai.Text, comboBoxGIMae.Text, comboBoxSangue.Text, textBoxRG.Text };
                int [] Numbers = { id };
                Repetition = acesso.GetRegistroPorId(0, maskedTextBoxCPF.Text, id);
                if (Repetition)
                {
                    MessageBox.Show("O CPF inserido já está cadastrado");
                }
                else
                {
                    acesso.AtualizarRegistro(0, Names, Numbers);
                }
            }
            else if(Mode == 2)
            {
                buttonEnviar.Text = "Sair";
            }
            else if(Mode == 3)
            {
                acesso.DeletarRegistro(0, maskedTextBoxCPF.Text, 0);
            }
        }
        public void ReadAndInsert(int id)
        {
            CRUD_Met.cn = new NpgsqlConnection(CRUD_Met.conec);
            CRUD_Met.cn.Open();
            string cmdSeleciona = String.Format("Select * from \"Cadastro Geral de Alunos\" where \"ID\" = {0}", id);
            NpgsqlCommand pgsqlCommand = new NpgsqlCommand(cmdSeleciona, CRUD_Met.cn);
            NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
            if (id == 0)
            {
                textBoxNome.Text = string.Empty;
                maskedTextBoxCPF.Text = string.Empty;
                maskedTextBoxTelefone.Text = string.Empty;
                textBoxEmail.Text = string.Empty;
                maskedTextBoxNascimento.Text = string.Empty;
                textBoxNIS.Text = string.Empty;
                comboBoxCor.Text = string.Empty;
                comboBoxGenero.Text = string.Empty;
                comboBoxECivil.Text = string.Empty;
                textBoxEndereco.Text = string.Empty;
                comboBoxUF.Text = string.Empty;
                comboBoxNacionalidade.Text = string.Empty;
                comboBoxProced.Text = string.Empty;
                textBoxNomePai.Text = string.Empty;
                textBoxNomeMae.Text = string.Empty;
                comboBoxGIPai.Text = string.Empty;
                comboBoxGIMae.Text = string.Empty;
                comboBoxSangue.Text = string.Empty;
                textBoxRG.Text = string.Empty;
            }
            else
            {
                if (pgsqlReader.HasRows)
                {
                    while (pgsqlReader.Read())
                    {
                        textBoxNome.Text = Convert.ToString(pgsqlReader.GetValue(1).ToString());
                        maskedTextBoxCPF.Text = Convert.ToString(pgsqlReader.GetValue(2).ToString());
                        maskedTextBoxTelefone.Text = Convert.ToString(pgsqlReader.GetValue(3).ToString());
                        textBoxEmail.Text = Convert.ToString(pgsqlReader.GetValue(4).ToString());
                        maskedTextBoxNascimento.Text = Convert.ToString(pgsqlReader.GetValue(5).ToString());
                        textBoxNIS.Text = Convert.ToString(pgsqlReader.GetValue(6).ToString());
                        comboBoxCor.Text = Convert.ToString(pgsqlReader.GetValue(7).ToString());
                        comboBoxGenero.Text = Convert.ToString(pgsqlReader.GetValue(8).ToString());
                        comboBoxECivil.Text = Convert.ToString(pgsqlReader.GetValue(9).ToString());
                        textBoxEndereco.Text = Convert.ToString(pgsqlReader.GetValue(10).ToString());
                        comboBoxUF.Text = Convert.ToString(pgsqlReader.GetValue(11).ToString());
                        comboBoxNacionalidade.Text = Convert.ToString(pgsqlReader.GetValue(12).ToString());
                        comboBoxProced.Text = Convert.ToString(pgsqlReader.GetValue(13).ToString());
                        textBoxNomePai.Text = Convert.ToString(pgsqlReader.GetValue(14).ToString());
                        textBoxNomeMae.Text = Convert.ToString(pgsqlReader.GetValue(15).ToString());
                        comboBoxGIPai.Text = Convert.ToString(pgsqlReader.GetValue(16).ToString());
                        comboBoxGIMae.Text = Convert.ToString(pgsqlReader.GetValue(17).ToString());
                        comboBoxSangue.Text = Convert.ToString(pgsqlReader.GetValue(18).ToString());
                        textBoxRG.Text = Convert.ToString(pgsqlReader.GetValue(20).ToString());
                    }
                    pgsqlReader.Close();
                }
            }
            CRUD_Met.cn.Close();
        }
    }
}
