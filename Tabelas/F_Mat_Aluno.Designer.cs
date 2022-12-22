
namespace Projeto_LPA
{
    partial class F_Mat_Aluno
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
            this.listBoxMaterias = new System.Windows.Forms.ListBox();
            this.buttonSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxMaterias
            // 
            this.listBoxMaterias.FormattingEnabled = true;
            this.listBoxMaterias.Location = new System.Drawing.Point(183, 129);
            this.listBoxMaterias.Name = "listBoxMaterias";
            this.listBoxMaterias.Size = new System.Drawing.Size(120, 147);
            this.listBoxMaterias.TabIndex = 0;
            // 
            // buttonSair
            // 
            this.buttonSair.Location = new System.Drawing.Point(204, 371);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(75, 23);
            this.buttonSair.TabIndex = 1;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = true;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // F_Mat_Aluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 450);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.listBoxMaterias);
            this.Name = "F_Mat_Aluno";
            this.Text = "Materias";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMaterias;
        private System.Windows.Forms.Button buttonSair;
    }
}