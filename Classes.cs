using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Projeto_LPA
{
    public class CRUD_Met
    {
        static public string conec = "Server = localhost; Port = 5432; Database = Projeto CRUD; User Id = LPA; Password = Lpa123456 ;";
        static public NpgsqlConnection cn = null;
        public static void Conectar()
        {
            //string conec = "Server = localhost; Port = 5432; Database = Projeto CRUD; User Id = LPA; Password = Lpa123456 ;";
            //NpgsqlConnection cn = new NpgsqlConnection(conec);
            cn.Open();
        }
        public DataTable GetTodosRegistros(int TableID, string SearchItem)
        {
            cn = new NpgsqlConnection(conec);
            DataTable dt = new DataTable();
            string cmdSeleciona = null;

            try
            {
                using (cn)
                {
                    cn.Open();
                    if(TableID == 0)
                    {
                        cmdSeleciona = String.Format("Select * from \"Cadastro Geral de Alunos\" order by \"ID\"");
                    }
                    else if(TableID == 1)
                    {
                        cmdSeleciona = String.Format("Select * from \"Informações dos Cursos\" order by \"ID\"");
                    }
                    else if(TableID == 2)
                    {
                        cmdSeleciona = String.Format("Select \"ID_Aluno\",\"ID_Curso\",\"Ano_Entrada\" from \"Matriculas\" Where \"Mat_Enc\" = false order by \"ID_Aluno\"");
                    }
                    else if(TableID == 3)
                    {
                        cmdSeleciona = String.Format("Select \"ID_Aluno\",\"ID_Curso\",\"Ano_Entrada\",\"Ano_Saida\" from \"Matriculas\" Where \"Mat_Enc\" = true order by \"ID_Aluno\"");
                    }
                    else if(TableID == 4)
                    {
                        cmdSeleciona = String.Format("Select * from \"Matérias\" order by \"Nome\"");
                    }
                    else if(TableID == 5)
                    {
                        cmdSeleciona = String.Format("Select \"Matérias\",\"Prova 1\",\"Prova 2\",\"Média\" from \"Notas\" Where \"ID_Aluno\" = '{0}' and \"Nota Ativa\" = true Order by \"Matérias\"", SearchItem);
                    }
                    else if(TableID == 6)
                    {
                        cmdSeleciona = String.Format("Select \"Matérias\",\"Prova 1\",\"Prova 2\",\"Média\" from \"Notas\" Where \"ID_Aluno\" = '{0}' Order by \"Matérias\"", SearchItem);
                    }
                    else if(TableID == 7)
                    {
                        cmdSeleciona = String.Format("Select \"ID_Aluno\",\"ID_Curso\",\"Ano_Entrada\",\"Ano_Saida\" from \"Matriculas\" order by \"ID_Aluno\"");
                    }
                    

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, cn))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }

            return dt;
        }
        public bool GetRegistroPorId(int TableID, string SearchItem, int id)
        {
            cn = new NpgsqlConnection(conec);
            string cmdSeleciona = null;
            int i = 0;
            string j = string.Empty;
            try
            {
                using (cn)
                {
                    cn.Open();
                    if (TableID == 0)
                    {
                        cmdSeleciona = String.Format("Select \"ID\" from \"Cadastro Geral de Alunos\" Where \"CPF\" = '{0}'", SearchItem);
                    }
                    else if (TableID == 1)
                    {
                        cmdSeleciona = String.Format("Select \"ID\" from \"Informações dos Cursos\" Where \"Nome\" = '{0}'", SearchItem);
                    }
                    else if (TableID == 2)
                    {
                        cmdSeleciona = String.Format("Select \"ID_Aluno\" from \"Matriculas\" Where \"ID_Aluno\" = '{0}'", SearchItem);
                    }
                    else if (TableID == 4)
                    {
                        cmdSeleciona = String.Format("Select \"ID_Curso\" from \"Matérias\" Where \"Nome\" = '{0}' And \"ID_Curso\" = {1}", SearchItem, id);
                    }

                    if(TableID != 5)
                    {
                        NpgsqlCommand pgsqlCommand = new NpgsqlCommand(cmdSeleciona, cn);
                        NpgsqlDataReader pgsqlReader = pgsqlCommand.ExecuteReader();
                        if (pgsqlReader.HasRows)
                        {
                            while (pgsqlReader.Read())
                            {
                                if(TableID != 2)
                                {
                                    i = Convert.ToInt32(pgsqlReader.GetValue(0).ToString());
                                }
                                else if(String.IsNullOrEmpty(Convert.ToString(pgsqlReader.GetValue(0).ToString())))
                                {
                                    j = SearchItem;
                                }
                                else
                                {
                                    j = string.Empty;
                                }
                            }
                            pgsqlReader.Close();
                        }
                        if(TableID != 2)
                        {
                            if ((i == id && id != 0) || (id == 0 && i != 0))
                            {
                                cn.Close();
                                return true;
                            }
                        }
                        else
                        {
                            if((String.Equals(j,SearchItem) && id != 0) || (id == 0 && !String.IsNullOrEmpty(j)))
                            {
                                cn.Close();
                                return true;
                            }
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return false;
        }
        public void InserirRegistros(int TableID, string[] Names, int[] Numbers)
        {
            cn = new NpgsqlConnection(conec);
            string cmdInserir = null;
            try
            {
                using (cn)
                {               
                    cn.Open();
                    if (TableID == 0)
                    {
                        cmdInserir = String.Format("Insert Into \"Cadastro Geral de Alunos\"(\"Nome\",\"CPF\",\"Telefone\",\"Email\",\"Nascimento\",\"NIS\",\"Cor/Raça\",\"Gênero\",\"Estado Civil\",\"Endereço\",\"UF\",\"Nacionalidade\",\"Procedência\",\"Nome do Pai\",\"Nome da Mãe\",\"Grau de Instrução do Pai\",\"Grau de Instrução da Mãe\",\"Tipo Sanguíneo\",\"RG\") values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}',{18})",
                                                   Names[0], Names[1], Names[2], Names[3], Names[4], Names[5], Names[6], Names[7], Names[8], Names[9], Names[10], Names[11], Names[12], Names[13], Names[14], Names[15], Names[16], Names[17], Names[18]);
                    }
                    else if (TableID == 1)
                    {
                        cmdInserir = String.Format("Insert Into \"Informações dos Cursos\"(\"Nome\",\"Duração\") values('{0}',{1})",
                                                   Names[0], Names[1]);
                    }
                    else if (TableID == 2)
                    {
                        cmdInserir = String.Format("Insert Into \"Matriculas\"(\"ID_Aluno\",\"ID_Curso\",\"Ano_Entrada\",\"Mat_Enc\") values('{0}',{1},{2},false)",
                                                   Names[0], Numbers[0], Names[1]);
                    }
                    else if (TableID == 3)
                    {
                        cmdInserir = String.Format("Insert Into \"Matriculas\"(\"ID_Aluno\",\"ID_Curso\",\"Ano_Entrada\",\"Ano_Saida\") values('{0}',{1},{2},{3})",
                                                   Names[0], Numbers[0], Names[1], Names[2]);
                    }
                    else if (TableID == 4)
                    {
                        cmdInserir = String.Format("Insert Into \"Matérias\"(\"Nome\",\"ID_Curso\") values('{0}',{1})",
                                                   Names[0],Numbers[0]);
                    }

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInserir, cn))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
        public void AtualizarRegistro(int TableID, string[] Names, int[] Numbers)
        {
            cn = new NpgsqlConnection(conec);
            string cmdAtualiza = null;
            try
            {
                using (cn)
                {                 
                    cn.Open();
                    if (TableID == 0)
                    {
                        cmdAtualiza = String.Format("Update \"Cadastro Geral de Alunos\" Set \"Nome\" = '{0}', \"CPF\" = '{1}', \"Telefone\" = '{2}', \"Email\" = '{3}',\"Nascimento\" = '{4}',\"NIS\" = '{5}',\"Cor/Raça\" = '{6}',\"Gênero\" = '{7}',\"Estado Civil\" = '{8}',\"Endereço\" = '{9}',\"UF\" = '{10}',\"Nacionalidade\" = '{11}',\"Procedência\" = '{12}',\"Nome do Pai\" = '{13}',\"Nome da Mãe\" = '{14}',\"Grau de Instrução do Pai\" = '{15}',\"Grau de Instrução da Mãe\" = '{16}',\"Tipo Sanguíneo\" = '{17}',\"RG\" = {18} Where \"ID\" = {19}",
                                                    Names[0], Names[1], Names[2], Names[3], Names[4], Names[5], Names[6], Names[7], Names[8], Names[9], Names[10], Names[11], Names[12], Names[13], Names[14], Names[15], Names[16], Names[17], Names[18], Numbers[0]);
                    }
                    else if (TableID == 1)
                    {
                        cmdAtualiza = String.Format("Update \"Informações dos Cursos\" Set \"Nome\" = '{0}', \"Duração\" = {1} Where \"ID\" = {2}",
                                                    Names[0], Names[1], Numbers[0]);
                    }
                    else if (TableID == 2)
                    {
                        cmdAtualiza = String.Format("Update \"Matriculas\" Set \"ID_Aluno\" = '{0}', \"ID_Curso\" = {1}, \"Ano_Entrada\" = {2}, \"Mat_Enc\" = false Where \"ID_Aluno\" = '{3}'",
                                                    Names[0], Numbers[0], Names[1], Names[0]);
                    }
                    else if (TableID == 3)
                    {
                        cmdAtualiza = String.Format("Update \"Matriculas\" Set \"ID_Aluno\" = '{0}', \"ID_Curso\" = {1}, \"Ano_Entrada\" = {2}, \"Ano_Saida\" = {3}, \"Mat_Enc\" = true Where \"ID_Aluno\" = '{4}'",
                                                    Names[0], Numbers[0], Names[1], Names[2], Names[0]);
                    }
                    else if (TableID == 4)
                    {
                        cmdAtualiza = String.Format("Update \"Matérias\" Set \"Nome\" = '{0}', \"ID_Curso\" = {1} Where \"ID\" = {2}",
                                                    Names[0], Numbers[0], Numbers[1]);
                    }
                    else if (TableID == 5)
                    {
                        cmdAtualiza = String.Format("Update \"Notas\" Set \"Prova 1\" = {0}, \"Prova 2\" = {1}, \"Média\" = {2} Where \"ID_Aluno\" = '{3}'",
                                                    Names[0], Names[1], Names[2], Names[3]);
                    }

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdAtualiza, cn))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
        public void DeletarRegistro(int TableID, string name, int id)
        {
            cn = new NpgsqlConnection(conec);
            string cmdDeletar = null;
            try
            {
                using (cn)
                {        
                    cn.Open();
                    if (TableID == 0)
                    {
                        cmdDeletar = String.Format("Delete From \"Cadastro Geral de Alunos\" Where \"CPF\" = '{0}'",
                                                   name);
                    }
                    else if (TableID == 1)
                    {
                        cmdDeletar = String.Format("Delete From \"Informações dos Cursos\" Where \"Nome\" = '{0}'",
                                                   name);
                    }
                    else if (TableID == 2)
                    {
                        cmdDeletar = String.Format("Delete From \"Matriculas Ativas\" Where \"ID_Aluno\" = '{0}'",
                                                   name);
                    }
                    else if (TableID == 3)
                    {
                        cmdDeletar = String.Format("Delete From \"Matriculas Encerradas\" Where \"ID_Aluno\" = '{0}'",
                                                   name);
                    }
                    else if (TableID == 4)
                    {
                        cmdDeletar = String.Format("Delete From \"Matérias\" Where \"ID\" = {0}",
                                                   id);
                    }

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdDeletar, cn))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
        public void limpaTextBox(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.HasChildren)
                {
                    limpaTextBox(c);
                }
            }
        }
        public void repetitionCheck()
        {
            string queryString = "select top 1 column_1, column_2 from master_table";
            using (NpgsqlConnection dbConnection = new NpgsqlConnection(conec))
            {
                NpgsqlCommand dbCommand = new NpgsqlCommand(queryString, dbConnection);
                dbConnection.Open();
                NpgsqlDataReader dbReader = dbCommand.ExecuteReader();
                if (dbReader.HasRows)
                {
                    while (dbReader.Read())
                    {
                        string col1Value = dbReader.GetValue(0).ToString();
                        string col2Value = dbReader.GetValue(1).ToString();
                    }
                }
                dbReader.Close();
                dbConnection.Close();
            }
        }
    }
}