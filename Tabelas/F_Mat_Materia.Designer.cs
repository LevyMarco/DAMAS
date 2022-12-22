
namespace Projeto_LPA
{
    partial class F_Mat_Materia
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
            this.comboBoxAluno = new System.Windows.Forms.ComboBox();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.buttonSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAluno
            // 
            this.comboBoxAluno.FormattingEnabled = true;
            this.comboBoxAluno.Location = new System.Drawing.Point(182, 152);
            this.comboBoxAluno.Name = "comboBoxAluno";
            this.comboBoxAluno.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAluno.TabIndex = 0;
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(134, 221);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(75, 23);
            this.buttonInserir.TabIndex = 1;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // buttonSair
            // 
            this.buttonSair.Location = new System.Drawing.Point(256, 221);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(75, 23);
            this.buttonSair.TabIndex = 2;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = true;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Aluno:";
            // 
            // F_Mat_Materia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.comboBoxAluno);
            this.Name = "F_Mat_Materia";
            this.Text = "Materias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAluno;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.Label label1;
    }
}