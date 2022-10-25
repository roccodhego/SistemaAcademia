using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAcademia
{
    public partial class F_NovoUsuario : Form
    {
        BancoUser bancoUser; //Cria o objeto da class CRUD BancoUser

        public F_NovoUsuario()
        {
            InitializeComponent();
            bancoUser = new BancoUser(); // Instância o objeto da Class CRUD BancoUser 
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.nome = tb_nome.Text;
            usuario.username = tb_username.Text;
            usuario.senha = tb_senha.Text;
            usuario.status = cb_status.Text;
            usuario.nivel = Convert.ToInt32(Math.Round(n_nivel.Value, 0));

            bancoUser.CriarUsuario(usuario);       //Chama o CRUD BancoUser

        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tb_nome.Clear();
            tb_username.Clear();
            tb_senha.Clear();
            cb_status.Text = "";
            n_nivel.Value = 0;
            tb_nome.Focus();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_nome.Clear();
            tb_username.Clear();
            tb_senha.Clear();
            cb_status.Text = "";
            n_nivel.Value = 0;
            tb_nome.Focus();
        }
    }
}
