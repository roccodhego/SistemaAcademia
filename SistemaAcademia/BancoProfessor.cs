using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace SistemaAcademia
{
    public class BancoProfessor: IBancoProfessor
    {
        private SQLiteDataAdapter da { get; set; }

        public Professor CriarProfessor(Professor user) // ctrl + r + r alterar o nome em tudo que tem igual
        {
            var vcon = Banco.ConexaoBanco();
            try
            {
                SQLiteDataAdapter da;
                
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_professores ( T_NOMEPROFESSOR, T_TELEFONE) VALUES (@nome, @telefone)";   
                cmd.Parameters.AddWithValue("@nome", user.nome);
                cmd.Parameters.AddWithValue("@telefone", user.telefone);
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                return user;

            }
            finally
            {
                vcon.Close();
            }


        }

        public Professor BuscarProfessor(string nomedeprofessor)
        {
            var vcon = Banco.ConexaoBanco();
            try
            {
                SQLiteDataAdapter da;
                DataTable dt = new DataTable();


                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_professores WHERE T_NOMEPROFESSOR = '" + nomedeprofessor + "'";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    var user = new Professor();

                    user.id = int.Parse(dt.Rows[0].Field<Int64>("N_IDPROFESSOR").ToString());
                    user.nome = dt.Rows[0].Field<string>("T_NOMEPROFESSOR").ToString();
                    user.telefone = dt.Rows[0].Field<string>("T_USERNAME").ToString();
                    return user;
                }
            }
            finally // não importa o que aconteça ele sempre cairá no finally e fechará a conexão
            {
                vcon.Close();
            }
            return null;
        }

        public Professor AlterarProfessor(Professor p)
        {
            var vcon = Banco.ConexaoBanco();

            try
            {
                SQLiteDataAdapter da;
                
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE tb_professores SET T_NOMEPROFESSOR ='" + p.nome + "', T_TELEFONE='" + p.telefone + "' WHERE N_IDPROFESSOR = " + p.id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                vcon.Close();
            }
            return null;
        }

        public Professor ExcluirProfessor(string id)
        {
            var vcon = Banco.ConexaoBanco();

            try
            {
                DialogResult res = MessageBox.Show("Confirma a Exclusão?", "Excluir?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    SQLiteDataAdapter da;
                    DataTable dt = new DataTable();

                    var cmd = vcon.CreateCommand();
                    cmd.CommandText = "DELETE FROM tb_professores WHERE N_IDPROFESSOR = " + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("registro deletado com sucesso...!");
                }
            }
            finally
            {
                vcon.Close();
            }
            return null;
        }

        public DataTable ObterProfessores() // Retornar um DataTable com todos os usuários
        {
            var vcon = Banco.ConexaoBanco();

            try
            {
                SQLiteDataAdapter da = null;
                DataTable dt = new DataTable();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT N_IDPROFESSOR as 'ID Professores', T_NOMEPROFESSOR as 'Nome Professor', T_TELEFONE as 'Telefone' FROM tb_professores";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                return dt;
            }
            finally
            {
                vcon.Close(); // fechando essa conexão
            }

        }

        public void InserirProfessor(string q, string msgOK = null, string msgERRO = null) //Data manipulation Language (Insert, Delete, Update)
        {
            var vcon = Banco.ConexaoBanco();
            
            try
            {
                SQLiteDataAdapter da = null;
                DataTable dt = new DataTable();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = q;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();

                if (msgOK != null)
                {
                    MessageBox.Show(msgOK);
                }
            }
            catch (Exception ex)
            {
                if (msgERRO != null)
                {
                    MessageBox.Show(msgERRO + "\n" + ex.Message);
                }
                throw;
            }
            finally { vcon.Close(); }
        }


    }
}
