using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt=Banco.ObterDadosUsuarios(vid);
                tb_id.Text = dt.Rows[0].Field<Int64>("N_IDUSUARIO").ToString();
                tb_nome.Text = dt.Rows[0].Field<string>("T_NOMEUSUARIO").ToString();
                tb_username.Text = dt.Rows[0].Field<string>("T_USERNAME").ToString();
                tb_senha.Text = dt.Rows[0].Field<string>("T_SENHAUSUARIO").ToString();
                cb_status.Text = dt.Rows[0].Field<string>("T_STATUSUSUARIO").ToString();
                n_nivel.Value = dt.Rows[0].Field<Int64>("N_NIVELUSUARIO");

            }

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
        {
            DialogResult res = MessageBox.Show("Confirma a exclusão?", "Excluir", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                bancoUser.DeletarUsuario(tb_id.Text);  //Obtendo do CRUD BANCOUSER
                //Banco.DeletarUsuario(tb_id.Text);
                dgv_usuarios.Rows.Remove(dgv_usuarios.CurrentRow);
                
            }
        }
    }
}
