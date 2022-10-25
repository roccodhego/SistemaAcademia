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

namespace SistemaAcademia
{
    public partial class F_GestaoProfessores : Form
    {

        BancoProfessor bancoProfessor;
        public F_GestaoProfessores()
        {
            InitializeComponent();
            bancoProfessor = new BancoProfessor();
        }

        private void F_GestaoProfessores_Load(object sender, EventArgs e)
        {
            dgv_professores.DataSource = bancoProfessor.ObterProfessores(); //Obtendo do CRUD BANCOPROFESSOR
            dgv_professores.Columns[0].Width = 110;
            dgv_professores.Columns[1].Width = 220;
            dgv_professores.Columns[2].Width = 120;
        }

        private void dgv_professores_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contLinhas = dgv.SelectedRows.Count;
            if (contLinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                string vquery = @"SELECT * FROM tb_professores WHERE N_IDPROFESSOR = " + vid;
                dt = Banco.dql(vquery);
                tb_idProfessor.Text = dt.Rows[0].Field<Int64>("N_IDPROFESSOR").ToString();
                tb_nomeProfessor.Text = dt.Rows[0].Field<string>("T_NOMEPROFESSOR");
                mtb_telefone.Text = dt.Rows[0].Field<string>("T_TELEFONE");
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_idProfessor.Clear();
            tb_nomeProfessor.Clear();
            mtb_telefone.Clear();
            tb_nomeProfessor.Focus();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            
            Professor c = new Professor();
            c.nome = tb_nomeProfessor.Text;
            c.telefone = mtb_telefone.Text;

            if (tb_idProfessor.Text == "")
            {
                bancoProfessor.CriarProfessor(c);  //Obtendo do CRUD BancoProfessor

            }
            else
            {
                Professor a = new Professor();
                a.id = Convert.ToInt32(tb_idProfessor.Text);
                a.nome = tb_nomeProfessor.Text;
                a.telefone = mtb_telefone.Text;
                bancoProfessor.AlterarProfessor(a);  //Obtendo do CRUD BancoProfessor
            }
            dgv_professores.DataSource = bancoProfessor.ObterProfessores();

        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
   
                bancoProfessor.ExcluirProfessor(tb_idProfessor.Text); //Obtendo do CRUD BANCOPROFESSOR
                dgv_professores.Rows.Remove(dgv_professores.CurrentRow);
            
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
