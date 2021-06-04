
namespace Poligoni
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ForeColorButton = new System.Windows.Forms.Button();
            this.backColorButton = new System.Windows.Forms.Button();
            this.RubberButton = new System.Windows.Forms.Button();
            this.circleBtn = new System.Windows.Forms.Button();
            this.PolygonButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.penButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.ForeColorButton);
            this.panel1.Controls.Add(this.backColorButton);
            this.panel1.Controls.Add(this.RubberButton);
            this.panel1.Controls.Add(this.circleBtn);
            this.panel1.Controls.Add(this.PolygonButton);
            this.panel1.Controls.Add(this.lineButton);
            this.panel1.Controls.Add(this.penButton);
            this.panel1.Controls.Add(this.selectButton);
            this.panel1.Location = new System.Drawing.Point(13, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 415);
            this.panel1.TabIndex = 0;
            // 
            // ForeColorButton
            // 
            this.ForeColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ForeColorButton.BackColor = System.Drawing.Color.Black;
            this.ForeColorButton.Location = new System.Drawing.Point(4, 340);
            this.ForeColorButton.Name = "ForeColorButton";
            this.ForeColorButton.Size = new System.Drawing.Size(33, 33);
            this.ForeColorButton.TabIndex = 7;
            this.ForeColorButton.UseVisualStyleBackColor = false;
            this.ForeColorButton.Click += new System.EventHandler(this.ForeColorButton_Click);
            // 
            // backColorButton
            // 
            this.backColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backColorButton.BackColor = System.Drawing.Color.White;
            this.backColorButton.Location = new System.Drawing.Point(4, 379);
            this.backColorButton.Name = "backColorButton";
            this.backColorButton.Size = new System.Drawing.Size(33, 33);
            this.backColorButton.TabIndex = 6;
            this.backColorButton.UseVisualStyleBackColor = false;
            this.backColorButton.Click += new System.EventHandler(this.backColorButton_Click);
            // 
            // RubberButton
            // 
            this.RubberButton.Image = ((System.Drawing.Image)(resources.GetObject("RubberButton.Image")));
            this.RubberButton.Location = new System.Drawing.Point(4, 200);
            this.RubberButton.Name = "RubberButton";
            this.RubberButton.Size = new System.Drawing.Size(33, 33);
            this.RubberButton.TabIndex = 5;
            this.RubberButton.UseVisualStyleBackColor = true;
            this.RubberButton.Click += new System.EventHandler(this.RubberButton_Click);
            // 
            // circleBtn
            // 
            this.circleBtn.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn.Image")));
            this.circleBtn.Location = new System.Drawing.Point(4, 161);
            this.circleBtn.Name = "circleBtn";
            this.circleBtn.Size = new System.Drawing.Size(33, 33);
            this.circleBtn.TabIndex = 4;
            this.circleBtn.UseVisualStyleBackColor = true;
            this.circleBtn.Click += new System.EventHandler(this.circleBtn_Click);
            // 
            // PolygonButton
            // 
            this.PolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("PolygonButton.Image")));
            this.PolygonButton.Location = new System.Drawing.Point(4, 122);
            this.PolygonButton.Name = "PolygonButton";
            this.PolygonButton.Size = new System.Drawing.Size(33, 33);
            this.PolygonButton.TabIndex = 3;
            this.PolygonButton.UseVisualStyleBackColor = true;
            this.PolygonButton.Click += new System.EventHandler(this.PolygonButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.Location = new System.Drawing.Point(4, 83);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(33, 33);
            this.lineButton.TabIndex = 2;
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // penButton
            // 
            this.penButton.Image = ((System.Drawing.Image)(resources.GetObject("penButton.Image")));
            this.penButton.Location = new System.Drawing.Point(4, 44);
            this.penButton.Name = "penButton";
            this.penButton.Size = new System.Drawing.Size(33, 33);
            this.penButton.TabIndex = 1;
            this.penButton.UseVisualStyleBackColor = true;
            this.penButton.Click += new System.EventHandler(this.penButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.Location = new System.Drawing.Point(4, 5);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(33, 33);
            this.selectButton.TabIndex = 0;
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(60, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(728, 415);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanel_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Disegno - Andrea Bonari Classe 3AI";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button RubberButton;
        private System.Windows.Forms.Button circleBtn;
        private System.Windows.Forms.Button PolygonButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button penButton;
        private System.Windows.Forms.Button ForeColorButton;
        private System.Windows.Forms.Button backColorButton;
    }
}

