﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Drawing;

namespace SistemaAcademia
{
    internal class Banco
    {
        private static SQLiteConnection conexao;

        private static SQLiteConnection ConexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source = G:\\Curso\\ProjetoIntegrador\\SistemaAcademia\\banco\\banco_academia.db");
            conexao.Open();
            return conexao;
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
                throw ex;
            
            }
        }

        public static DataTable consulta(string sql)
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
                throw ex;

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
                throw ex;

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
                throw ex;

            }
        }


        //FIM Funções do FORM F_GestaoUsuarios



        // Funções do FORM F_NovoUsuario

        public static void NovoUsuario(Usuario u)
        {
            if (existeUsername(u))
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

        public static bool existeUsername(Usuario u)  // VERIFICAR SE O USUÁRIO EXISTE
        {
            bool res;
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            var vcon = ConexaoBanco();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "SELECT T_USERNAME FROM tb_usuarios WHERE T_USERNAME = '" + u.username + "'";
            da = new SQLiteDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            else 
            {
                res = false;
            }
            vcon.Close();
            return res;
        }


    }
}
