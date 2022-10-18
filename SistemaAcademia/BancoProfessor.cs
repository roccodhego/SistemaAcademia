using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademia
{
    internal class BancoProfessor
    {
        public Professor CriarProfessor(Professor user) // ctrl + r + r alterar o nome em tudo que tem igual
        {
            var vcon = Banco.ConexaoBanco();
            try
            {

                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_professores (T_NOMEPROFESSOR, T_TELEFONE) VALUES (@nome, @telefone)";
                cmd.Parameters.AddWithValue("@nome", user.nome);
                cmd.Parameters.AddWithValue("@username", user.telefone);
                user.id = cmd.ExecuteNonQuery();
                return user;

            }
            finally
            {
                vcon.Close();
            }
            return null;

        }

        public Professor BuscarProfessor(string nomedeprofessor)
        {
            var vcon = Banco.ConexaoBanco();
            try
            {
                SQLiteDataAdapter da;
                DataTable dt = new DataTable();


                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT T_NOMEPROFESSOR FROM tb_professores WHERE T_NOMEPROFESSOR = '" + nomedeprofessor + "'";
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
    }
}
