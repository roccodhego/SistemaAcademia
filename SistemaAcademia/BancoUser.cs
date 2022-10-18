using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;

namespace SistemaAcademia
{
    internal class BancoUser : IBancoUser
    {

        public Usuario CriarUsuario(Usuario user) // ctrl + r + r alterar o nome em tudo que tem igual
        {
            var vcon = Banco.ConexaoBanco();
            if (BuscarUsuario(user.username) != null)
            {
                throw new Exception("Username já existe");

            }
            try
            {

                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_usuarios (T_NOMEUSUARIO, T_USERNAME, T_SENHAUSUARIO, T_STATUSUSUARIO, N_NIVELUSUARIO) VALUES (@nome, @username, @senha, @status, @nivel)";
                cmd.Parameters.AddWithValue("@nome", user.nome);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@senha", user.senha);
                cmd.Parameters.AddWithValue("@status", user.status);
                cmd.Parameters.AddWithValue("@nivel", user.nivel);
                user.id = cmd.ExecuteNonQuery();
                return user;


            }
            finally
            {
                vcon.Close();
            }
            return null;

        }

        /// <summary>
        /// VERIFICAR SE O USUÁRIO EXISTE
        /// </summary>
        /// <param name="nomedeusuario"></param>
        /// <returns></returns>
        public Usuario BuscarUsuario(string nomedeusuario)
        {
            var vcon = Banco.ConexaoBanco();
            try
            {
                SQLiteDataAdapter da;
                DataTable dt = new DataTable();


                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT T_USERNAME FROM tb_usuarios WHERE T_USERNAME = '" + nomedeusuario + "'";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    var user = new Usuario();

                    user.id = int.Parse(dt.Rows[0].Field<Int64>("N_IDUSUARIO").ToString());
                    user.nome = dt.Rows[0].Field<string>("T_NOMEUSUARIO").ToString();
                    user.username = dt.Rows[0].Field<string>("T_USERNAME").ToString();
                    user.status = dt.Rows[0].Field<string>("T_STATUSUSUARIO").ToString();
                    user.nivel = int.Parse(dt.Rows[0].Field<Int64>("N_NIVELUSUARIO").ToString());
                    return user;
                }
            }
            finally // não importa o que aconteça ele sempre cairá no finally e fechará a conexão
            {
                vcon.Close();
            }
            return null;

        }

        public Usuario AlterarUsuario(Usuario u)
        {
            var vcon = Banco.ConexaoBanco();

            try
            {
                SQLiteDataAdapter da = null;
                DataTable dt = new DataTable();

                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE tb_usuarios SET T_NOMEUSUARIO ='" + u.nome + "', T_USERNAME='" + u.username + "', T_SENHAUSUARIO='" + u.senha + "', T_STATUSUSUARIO='" + u.status + "', N_NIVELUSUARIO=" + u.nivel + " WHERE N_IDUSUARIO=" + u.id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();

            }
            finally 
            {
                vcon.Close();
            }
            return null;

        }

        public Usuario DeletarUsuario(string id)
        {
            var vcon = Banco.ConexaoBanco();

            try
            {
                SQLiteDataAdapter da = null;
                DataTable dt = new DataTable();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "DELETE FROM tb_usuarios WHERE N_IDUSUARIO=" + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery(); // não precisa retornar nada

            }
            finally
            {
                vcon.Close();
            }
            return null;
        }

        // PRECISA CRIAR AINDA
        //
        // DELETE DE USUARIO

        // UPDATE DE USUÁRIO

        //Criar os CRUDProfessor, alunos 


    }
}
