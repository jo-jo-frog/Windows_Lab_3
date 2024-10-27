namespace Windows_Lab_3
{
    partial class BrandTable
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
            this.DataGridBrand = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridBrand
            // 
            this.DataGridBrand.AllowUserToAddRows = false;
            this.DataGridBrand.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridBrand.Location = new System.Drawing.Point(12, 12);
            this.DataGridBrand.Name = "DataGridBrand";
            this.DataGridBrand.RowHeadersWidth = 51;
            this.DataGridBrand.RowTemplate.Height = 24;
            this.DataGridBrand.Size = new System.Drawing.Size(776, 349);
            this.DataGridBrand.TabIndex = 0;
            // 
            // BrandTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataGridBrand);
            this.Name = "BrandTable";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BrandTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBrand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridBrand;
    }
}