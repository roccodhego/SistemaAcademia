using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAcademia
{
    public partial class F_GestaoUsuarios : Form
    {
        public class Aluno
        {
            public int Id { get; set; }
            public string nome { get; set; }
            public string email { get; set; }
            public int idade { get; set; }

            private void CarregaDados()
            {
                DataTable dt = new DataTable();
                SQLiteConnection conn = null;
                String sql = "select * from Alunos";
                String strConn = @"D:\SistemaAcademia\--banco";
                try
                {
                    conn = new SQLiteConnection(strConn);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, strConn);
                    da.Fill(dt);
                    dgvAlunos.DataSource = dt.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro :" + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
        public DataTable LeDados1<T>(string query) where T : IDbConnection, new()
        {
            using (var conn = new T())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection.ConnectionString = _connectionString;
                    cmd.Connection.Open();
                    var table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    return table;
                }
            }
        }
    }
}
