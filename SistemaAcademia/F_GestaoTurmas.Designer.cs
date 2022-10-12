namespace SistemaAcademia
{
    partial class F_GestaoTurmas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_turmas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_imprimirTurma = new System.Windows.Forms.Button();
            this.btn_novaTurma = new System.Windows.Forms.Button();
            this.btn_salvarEdicoes = new System.Windows.Forms.Button();
            this.btn_excluirTurma = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_professor = new System.Windows.Forms.ComboBox();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.cb_horario = new System.Windows.Forms.ComboBox();
            this.n_maxAlunos = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_dscTurma = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turmas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_maxAlunos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_turmas
            // 
            this.dgv_turmas.AllowUserToAddRows = false;
            this.dgv_turmas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_turmas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_turmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_turmas.EnableHeadersVisualStyles = false;
            this.dgv_turmas.Location = new System.Drawing.Point(10, 11);
            this.dgv_turmas.MultiSelect = false;
            this.dgv_turmas.Name = "dgv_turmas";
            this.dgv_turmas.ReadOnly = true;
            this.dgv_turmas.RowHeadersVisible = false;
            this.dgv_turmas.RowTemplate.Height = 25;
            this.dgv_turmas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_turmas.Size = new System.Drawing.Size(379, 402);
            this.dgv_turmas.TabIndex = 16;
            this.dgv_turmas.SelectionChanged += new System.EventHandler(this.dgv_turmas_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_imprimirTurma);
            this.panel1.Controls.Add(this.btn_novaTurma);
            this.panel1.Controls.Add(this.btn_salvarEdicoes);
            this.panel1.Controls.Add(this.btn_excluirTurma);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 30);
            this.panel1.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(490, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Fechar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_imprimirTurma
            // 
            this.btn_imprimirTurma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_imprimirTurma.Location = new System.Drawing.Point(367, 3);
            this.btn_imprimirTurma.Name = "btn_imprimirTurma";
            this.btn_imprimirTurma.Size = new System.Drawing.Size(106, 23);
            this.btn_imprimirTurma.TabIndex = 8;
            this.btn_imprimirTurma.Text = "imprimir Turma";
            this.btn_imprimirTurma.UseVisualStyleBackColor = true;
            // 
            // btn_novaTurma
            // 
            this.btn_novaTurma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_novaTurma.Location = new System.Drawing.Point(10, 3);
            this.btn_novaTurma.Name = "btn_novaTurma";
            this.btn_novaTurma.Size = new System.Drawing.Size(103, 23);
            this.btn_novaTurma.TabIndex = 5;
            this.btn_novaTurma.Text = "Novo Turma";
            this.btn_novaTurma.UseVisualStyleBackColor = true;
            // 
            // btn_salvarEdicoes
            // 
            this.btn_salvarEdicoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salvarEdicoes.Location = new System.Drawing.Point(129, 3);
            this.btn_salvarEdicoes.Name = "btn_salvarEdicoes";
            this.btn_salvarEdicoes.Size = new System.Drawing.Size(102, 23);
            this.btn_salvarEdicoes.TabIndex = 6;
            this.btn_salvarEdicoes.Text = "Salvar Edições";
            this.btn_salvarEdicoes.UseVisualStyleBackColor = true;
            // 
            // btn_excluirTurma
            // 
            this.btn_excluirTurma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_excluirTurma.Location = new System.Drawing.Point(243, 3);
            this.btn_excluirTurma.Name = "btn_excluirTurma";
            this.btn_excluirTurma.Size = new System.Drawing.Size(111, 23);
            this.btn_excluirTurma.TabIndex = 7;
            this.btn_excluirTurma.Text = "Excluir Turma";
            this.btn_excluirTurma.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Professor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Máximo de Alunos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Horário";
            // 
            // cb_professor
            // 
            this.cb_professor.FormattingEnabled = true;
            this.cb_professor.Location = new System.Drawing.Point(396, 89);
            this.cb_professor.Name = "cb_professor";
            this.cb_professor.Size = new System.Drawing.Size(256, 23);
            this.cb_professor.TabIndex = 2;
            // 
            // cb_status
            // 
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Location = new System.Drawing.Point(531, 145);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(121, 23);
            this.cb_status.TabIndex = 4;
            // 
            // cb_horario
            // 
            this.cb_horario.FormattingEnabled = true;
            this.cb_horario.Location = new System.Drawing.Point(396, 206);
            this.cb_horario.Name = "cb_horario";
            this.cb_horario.Size = new System.Drawing.Size(256, 23);
            this.cb_horario.TabIndex = 5;
            // 
            // n_maxAlunos
            // 
            this.n_maxAlunos.Location = new System.Drawing.Point(396, 145);
            this.n_maxAlunos.Name = "n_maxAlunos";
            this.n_maxAlunos.Size = new System.Drawing.Size(120, 23);
            this.n_maxAlunos.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaAcademia.Properties.Resources.clientes;
            this.pictureBox1.Location = new System.Drawing.Point(437, 244);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Nome Turma";
            // 
            // tb_dscTurma
            // 
            this.tb_dscTurma.Location = new System.Drawing.Point(395, 33);
            this.tb_dscTurma.Name = "tb_dscTurma";
            this.tb_dscTurma.Size = new System.Drawing.Size(257, 23);
            this.tb_dscTurma.TabIndex = 1;
            // 
            // F_GestaoTurmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 450);
            this.Controls.Add(this.tb_dscTurma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.n_maxAlunos);
            this.Controls.Add(this.cb_horario);
            this.Controls.Add(this.cb_status);
            this.Controls.Add(this.cb_professor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_turmas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_GestaoTurmas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestao de Turmas";
            this.Load += new System.EventHandler(this.F_GestaoTurmas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turmas)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.n_maxAlunos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgv_turmas;
        private Panel panel1;
        private Button btn_imprimirTurma;
        private Button btn_novaTurma;
        private Button btn_salvarEdicoes;
        private Button btn_excluirTurma;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private ComboBox cb_professor;
        private ComboBox cb_status;
        private ComboBox cb_horario;
        private NumericUpDown n_maxAlunos;
        private PictureBox pictureBox1;
        private Label label5;
        private TextBox tb_dscTurma;
    }
}