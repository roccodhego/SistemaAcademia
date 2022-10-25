using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SistemaAcademia
{
    public partial class F_GestaoUsuarios : Form
    {
<<<<<<< HEAD
        BancoUser bancoUser;
        public F_GestaoUsuarios()
        {
            InitializeComponent();
            bancoUser = new BancoUser();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void F_GestaoUsuarios_Load(object sender, EventArgs e)
        {
            dgv_usuarios.DataSource = bancoUser.ObterUsuarios();  //Obtendo do CRUD BANCOUSER
            dgv_usuarios.Columns[0].Width = 90;
            dgv_usuarios.Columns[1].Width = 195;
        }

        private void dgv_usuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contLinhas=dgv.SelectedRows.Count;
            if (contLinhas > 0)
=======
        public class Aluno
        {
            public int Id { get; set; }
            public string nome { get; set; }
            public string email { get; set; }
            public int idade { get; set; }

            private void CarregaDados()
>>>>>>> main
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
<<<<<<< HEAD

        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            F_NovoUsuario f_NovoUsuario = new F_NovoUsuario();
            f_NovoUsuario.ShowDialog();
            dgv_usuarios.DataSource = bancoUser.ObterUsuarios(); //Obtendo do CRUD BANCOUSER

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            int linha = dgv_usuarios.SelectedRows[0].Index;
            Usuario u = new Usuario();
            u.id = Convert.ToInt32(tb_id.Text);
            u.nome = tb_nome.Text;
            u.username = tb_username.Text;
            u.senha = tb_senha.Text;
            u.status = cb_status.Text;
            u.nivel = Convert.ToInt32(Math.Round(n_nivel.Value));
            bancoUser.AlterarUsuario(u);  //Obtendo do CRUD BANCOUSER
            //Banco.AtualizarUsuario(u);
            dgv_usuarios[1, linha].Value = tb_nome.Text;
        }

        private void btn_excluir_Click(object sender, EventArgs e)
=======
        }
        public DataTable LeDados1<T>(string query) where T : IDbConnection, new()
>>>>>>> main
        {
            using (var conn = new T())
            {
<<<<<<< HEAD
                bancoUser.DeletarUsuario(tb_id.Text);  //Obtendo do CRUD BANCOUSER
                //Banco.DeletarUsuario(tb_id.Text);
                dgv_usuarios.Rows.Remove(dgv_usuarios.CurrentRow);
                
=======
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection.ConnectionString = _connectionString;
                    cmd.Connection.Open();
                    var table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    return table;
                }
>>>>>>> main
            }
        }
    }
}
