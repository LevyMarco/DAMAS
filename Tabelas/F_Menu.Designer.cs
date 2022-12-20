
namespace Projeto_LPA
{
    partial class F_Menu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Menu));
            this.buttonMat_Ativas = new System.Windows.Forms.Button();
            this.buttonCursos = new System.Windows.Forms.Button();
            this.buttonAlunos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonMaterias = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMat_Ativas
            // 
            this.buttonMat_Ativas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonMat_Ativas.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.buttonMat_Ativas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(244)))));
            this.buttonMat_Ativas.Location = new System.Drawing.Point(12, 342);
            this.buttonMat_Ativas.Name = "buttonMat_Ativas";
            this.buttonMat_Ativas.Size = new System.Drawing.Size(251, 75);
            this.buttonMat_Ativas.TabIndex = 3;
            this.buttonMat_Ativas.Text = "Mátriculas";
            this.buttonMat_Ativas.UseVisualStyleBackColor = false;
            this.buttonMat_Ativas.Click += new System.EventHandler(this.buttonMat_Ativas_Click);
            // 
            // buttonCursos
            // 
            this.buttonCursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonCursos.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.buttonCursos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(244)))));
            this.buttonCursos.Location = new System.Drawing.Point(12, 261);
            this.buttonCursos.Name = "buttonCursos";
            this.buttonCursos.Size = new System.Drawing.Size(251, 75);
            this.buttonCursos.TabIndex = 1;
            this.buttonCursos.Text = "Cursos";
            this.buttonCursos.UseVisualStyleBackColor = false;
            this.buttonCursos.Click += new System.EventHandler(this.buttonCursos_Click);
            // 
            // buttonAlunos
            // 
            this.buttonAlunos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonAlunos.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlunos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(244)))));
            this.buttonAlunos.Location = new System.Drawing.Point(12, 180);
            this.buttonAlunos.Name = "buttonAlunos";
            this.buttonAlunos.Size = new System.Drawing.Size(251, 75);
            this.buttonAlunos.TabIndex = 0;
            this.buttonAlunos.Text = "Alunos";
            this.buttonAlunos.UseVisualStyleBackColor = false;
            this.buttonAlunos.Click += new System.EventHandler(this.buttonAlunos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(355, -41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 900);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // buttonMaterias
            // 
            this.buttonMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonMaterias.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.buttonMaterias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(244)))));
            this.buttonMaterias.Location = new System.Drawing.Point(12, 423);
            this.buttonMaterias.Name = "buttonMaterias";
            this.buttonMaterias.Size = new System.Drawing.Size(251, 75);
            this.buttonMaterias.TabIndex = 6;
            this.buttonMaterias.Text = "Matérias";
            this.buttonMaterias.UseVisualStyleBackColor = false;
            this.buttonMaterias.Click += new System.EventHandler(this.buttonMaterias_Click);
            // 
            // F_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.buttonMaterias);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonMat_Ativas);
            this.Controls.Add(this.buttonAlunos);
            this.Controls.Add(this.buttonCursos);
            this.Name = "F_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCursos;
        private System.Windows.Forms.Button buttonAlunos;
        private System.Windows.Forms.Button buttonMat_Ativas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonMaterias;
    }
}

