namespace Ventanas
{
    partial class BusquedaEquipos
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
            this.nudAños = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudAños)).BeginInit();
            this.SuspendLayout();
            // 
            // nudAños
            // 
            this.nudAños.Location = new System.Drawing.Point(95, 29);
            this.nudAños.Name = "nudAños";
            this.nudAños.Size = new System.Drawing.Size(120, 22);
            this.nudAños.TabIndex = 0;
            // 
            // BusquedaEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 498);
            this.Controls.Add(this.nudAños);
            this.Name = "BusquedaEquipos";
            this.Text = "BusquedaEquipos";
            this.Load += new System.EventHandler(this.BusquedaEquipos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAños)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudAños;
    }
}