using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using Microsoft.VisualBasic.ApplicationServices;

namespace SistemaAcademia
{
    internal class Banco
    {
        private static SQLiteConnection conexao;

        //Funcções Genéricas

        public static SQLiteConnection ConexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source = "+ Globais.caminhoBanco + Globais.nomeBanco);
            conexao.Open();
            return conexao;
        }


        public static DataTable dql(string sql) // Data Query Language (Select) = Consulta
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        public static void dml(string q, string msgOK=null, string msgERRO=null) //Data manipulation Language (Insert, Delete, Update)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();      //Abrindo uma conexão para o metodo
                var cmd = vcon.CreateCommand();
                cmd.CommandText = q;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close(); // fechando essa conexão

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
        }





        public static DataTable ObterTodosUsuarios() // Retornar um DataTable com todos os usuários
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            { 
                var vcon = ConexaoBanco();      //Abrindo uma conexão para o metodo
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close(); // fechando essa conexão
                return dt;  
            }
            catch (Exception ex)
            {
                throw;
            
            }
        }


        // Funções do FORM F_GestaoUsuarios
        public static DataTable ObterUsuariosIdNome() // Retornar um DataTable com todos os usuários
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();      //Abrindo uma conexão para o metodo
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT N_IDUSUARIO as 'ID Usuário', T_NOMEUSUARIO as 'Nome Usuário' FROM tb_usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close(); // fechando essa conexão
                return dt;
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public static DataTable ObterDadosUsuarios(string id) // Retornar um DataTable com todos os usuários
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();      //Abrindo uma conexão para o metodo
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_usuarios WHERE N_IDUSUARIO = "+id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close(); // fechando essa conexão
                return dt;
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public static void AtualizarUsuario(Usuario u) // Retornar um DataTable com todos os usuários
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();      //Abrindo uma conexão para o metodo
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE tb_usuarios SET T_NOMEUSUARIO ='"+u.nome+ "', T_USERNAME='"+u.username+ "', T_SENHAUSUARIO='"+u.senha+ "', T_STATUSUSUARIO='"+u.status+ "', N_NIVELUSUARIO="+u.nivel+" WHERE N_IDUSUARIO="+u.id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close(); // fechando essa conexão
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public static void DeletarUsuario(string id) // Retornar um DataTable com todos os usuários
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();      //Abrindo uma conexão para o metodo
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "DELETE FROM tb_usuarios WHERE N_IDUSUARIO=" + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery(); // não precisa retornar nada
                vcon.Close(); // fechando essa conexão
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        //FIM Funções do FORM F_GestaoUsuarios



        // Funções do FORM F_NovoUsuario

      public static void NovoUsuario(Usuario u)
        {
            BancoUser a = new BancoUser();
            
            if (a.BuscarUsuario() != null)
            {
                MessageBox.Show("Username já existe");
                return;
            }
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_usuarios (T_NOMEUSUARIO, T_USERNAME, T_SENHAUSUARIO, T_STATUSUSUARIO, N_NIVELUSUARIO) VALUES (@nome, @username, @senha, @status, @nivel)";
                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@status", u.status);
                cmd.Parameters.AddWithValue("@nivel", u.nivel);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Novo usuário inserido!");
                vcon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao gravar Novo usuário!");
            }
        }

        //FIM - Funções do FORM F_NovoUsuario

        // Rotinas Gerais

       



    }
}
