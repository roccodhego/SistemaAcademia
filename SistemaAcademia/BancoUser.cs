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
        private SQLiteDataAdapter da { get; set; }

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
                MessageBox.Show("Usuário adicionado com sucesso!");
                return user;


            }
            finally
            {
                vcon.Close();
            }

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

                DataTable dt = new DataTable();


                var cmd = vcon.CreateCommand();
                cmd.CommandText = "select * FROM tb_usuarios WHERE T_USERNAME = '" + nomedeusuario + "'";
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

        public DataTable ObterUsuarios() // Retornar um DataTable com todos os usuários
        {
            var vcon = Banco.ConexaoBanco();

<<<<<<< HEAD
            try
            {
                SQLiteDataAdapter da = null;
                DataTable dt = new DataTable();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT N_IDUSUARIO as 'ID Usuário', T_NOMEUSUARIO as 'Nome Usuário' FROM tb_usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                return dt;
            }
            finally
            {
                vcon.Close(); // fechando essa conexão
            }
=======
        // UPDATE DE USUÁRIO
        static private DataSet CreateCommandAndUpdate(
        string connectionString,
        string queryString)
        {
            DataSet dataSet = new DataSet();

            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                var adapter = new OleDbDataAdapter();
                adapter.SelectCommand =
                    new OleDbCommand(
                        queryString, connection);
                OleDbCommandBuilder builder =
                    new OleDbCommandBuilder(adapter);

                adapter.Fill(dataSet);

                // Code to modify data in the DataSet here.

                // Without the OleDbCommandBuilder, this line would fail.
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(dataSet);
            }
            return dataSet;
        }
>>>>>>> main



            //Criar os CRUDProfessor, alunos 


        }
    }
}
