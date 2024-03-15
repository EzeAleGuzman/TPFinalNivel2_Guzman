namespace TPFinalNivel2_Guzman
{
    partial class frmDetallesArticulo
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
            this.labelCodigo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cbbmarca = new System.Windows.Forms.ComboBox();
            this.cbbcategoria = new System.Windows.Forms.ComboBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.ptbImagen = new System.Windows.Forms.PictureBox();
            this.labelUrlImagen = new System.Windows.Forms.Label();
            this.labelPrecio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(93, 92);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(0, 13);
            this.labelCodigo.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(355, 471);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "button1";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cbbmarca
            // 
            this.cbbmarca.FormattingEnabled = true;
            this.cbbmarca.Location = new System.Drawing.Point(189, 261);
            this.cbbmarca.Name = "cbbmarca";
            this.cbbmarca.Size = new System.Drawing.Size(121, 21);
            this.cbbmarca.TabIndex = 2;
            // 
            // cbbcategoria
            // 
            this.cbbcategoria.FormattingEnabled = true;
            this.cbbcategoria.Location = new System.Drawing.Point(189, 318);
            this.cbbcategoria.Name = "cbbcategoria";
            this.cbbcategoria.Size = new System.Drawing.Size(121, 21);
            this.cbbcategoria.TabIndex = 3;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(256, 204);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(0, 13);
            this.labelNombre.TabIndex = 4;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(120, 434);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(0, 13);
            this.labelDescripcion.TabIndex = 5;
            // 
            // ptbImagen
            // 
            this.ptbImagen.Location = new System.Drawing.Point(604, 141);
            this.ptbImagen.Name = "ptbImagen";
            this.ptbImagen.Size = new System.Drawing.Size(237, 306);
            this.ptbImagen.TabIndex = 6;
            this.ptbImagen.TabStop = false;
            // 
            // labelUrlImagen
            // 
            this.labelUrlImagen.AutoSize = true;
            this.labelUrlImagen.Location = new System.Drawing.Point(133, 528);
            this.labelUrlImagen.Name = "labelUrlImagen";
            this.labelUrlImagen.Size = new System.Drawing.Size(0, 13);
            this.labelUrlImagen.TabIndex = 7;
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Location = new System.Drawing.Point(544, 511);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(35, 13);
            this.labelPrecio.TabIndex = 8;
            this.labelPrecio.Text = "label1";
            // 
            // frmDetallesArticulo
            // 
            this.ClientSize = new System.Drawing.Size(1038, 591);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.labelUrlImagen);
            this.Controls.Add(this.ptbImagen);
            this.Controls.Add(this.labelDescripcion);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.cbbcategoria);
            this.Controls.Add(this.cbbmarca);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.labelCodigo);
            this.Name = "frmDetallesArticulo";
            this.Load += new System.EventHandler(this.DetallesArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cbbmarca;
        private System.Windows.Forms.ComboBox cbbcategoria;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.PictureBox ptbImagen;
        private System.Windows.Forms.Label labelUrlImagen;
        private System.Windows.Forms.Label labelPrecio;
    }
}