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
    public partial class F_Login : Form
    {
        BancoUser bancoUser;
        Form1 form1;

        public F_Login(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            bancoUser = new BancoUser();
        }

        private void btn_logar_Click(object sender, EventArgs e) //Ação do Botão de Logar
        {
            string username = tb_username.Text; // Campo de digitar o nome
            string senha = tb_senha.Text;       // Campo de digitar a senha

            if (username == "" || senha == "")
            {
                MessageBox.Show("Usuário e ou senha inválidos");
                tb_username.Focus();
                return;
            }
            var user = bancoUser.BuscarUsuario(username);
            if ( user  == null && user.senha.Equals(senha) is false){
                MessageBox.Show("Usuário não encontrado");
                return;
            }

                form1.lb_acesso.Text = user.status;
                form1.lb_nomeUsuario.Text = user.username;
                form1.pb_ledLogado.Image = Properties.Resources.led_verde;
                Globais.nivel = user.nivel;
                Globais.logado = true;
                this.Close();
            
          
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_logar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)){
                this.btn_logar_Click(sender, e);
            }
        }

        private void F_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Keys.Enter))
            {
                this.btn_logar_Click(sender, e);
            }
        }
    }
}
