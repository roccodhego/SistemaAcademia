namespace SistemaAcademia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            F_Login f_Login = new F_Login(this);
            f_Login.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void logonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Login f_Login=new F_Login(this);
            f_Login.ShowDialog();
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lb_acesso.Text = "0";
            lb_nomeUsuario.Text = "---";
            pb_ledLogado.Image = Properties.Resources.led_vermelho;
            Globais.nivel = 0;
            Globais.logado = false;
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel >= 2)
                {
                    //PROCEDIMENTOS

                }
                else 
                {
                    MessageBox.Show("Acesso n�o permitido");
                }
            }
            else
            {
                MessageBox.Show("� necess�rio ter um usu�rio logado");
            }
        }

        private void novoUsu�riosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel >= 1)
                {
                    //PROCEDIMENTOS

                }
                else
                {
                    MessageBox.Show("Acesso n�o permitido");
                }
            }
            else
            {
                MessageBox.Show("� necess�rio ter um usu�rio logado");
            }
        }

        private void gest�oDeUsu�riosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel >= 1)
                {
                    //PROCEDIMENTOS

                }
                else
                {
                    MessageBox.Show("Acesso n�o permitido");
                }
            }
            else
            {
                MessageBox.Show("� necess�rio ter um usu�rio logado");
            }
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                //PROCEDIMENTOS
            }
            else
            {
                MessageBox.Show("� necess�rio ter um usu�rio logado");
            }
        }
    }
}