
namespace Projeto_LPA
{
    partial class F_Notas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maskedTextBoxNota1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBoxNota2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMedia = new System.Windows.Forms.MaskedTextBox();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.buttonSair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 259);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // maskedTextBoxNota1
            // 
            this.maskedTextBoxNota1.BackColor = System.Drawing.SystemColors.Window;
            this.maskedTextBoxNota1.Location = new System.Drawing.Point(226, 93);
            this.maskedTextBoxNota1.Mask = "90,00";
            this.maskedTextBoxNota1.Name = "maskedTextBoxNota1";
            this.maskedTextBoxNota1.Size = new System.Drawing.Size(37, 20);
            this.maskedTextBoxNota1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nota 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nota 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Média:";
            // 
            // maskedTextBoxNota2
            // 
            this.maskedTextBoxNota2.BackColor = System.Drawing.SystemColors.Window;
            this.maskedTextBoxNota2.Location = new System.Drawing.Point(226, 119);
            this.maskedTextBoxNota2.Mask = "90,00";
            this.maskedTextBoxNota2.Name = "maskedTextBoxNota2";
            this.maskedTextBoxNota2.Size = new System.Drawing.Size(37, 20);
            this.maskedTextBoxNota2.TabIndex = 5;
            // 
            // maskedTextBoxMedia
            // 
            this.maskedTextBoxMedia.BackColor = System.Drawing.SystemColors.Window;
            this.maskedTextBoxMedia.Location = new System.Drawing.Point(226, 145);
            this.maskedTextBoxMedia.Mask = "90,00";
            this.maskedTextBoxMedia.Name = "maskedTextBoxMedia";
            this.maskedTextBoxMedia.Size = new System.Drawing.Size(37, 20);
            this.maskedTextBoxMedia.TabIndex = 6;
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(76, 415);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(75, 23);
            this.buttonEnviar.TabIndex = 7;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // buttonSair
            // 
            this.buttonSair.Location = new System.Drawing.Point(321, 415);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(75, 23);
            this.buttonSair.TabIndex = 8;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = true;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // F_Notas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 450);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.maskedTextBoxMedia);
            this.Controls.Add(this.maskedTextBoxNota2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBoxNota1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "F_Notas";
            this.Text = "Notas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNota1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNota2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMedia;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.Button buttonSair;
    }
}