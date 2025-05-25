namespace ProductsShop
{
    partial class MainForm
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
            this.buttonFileRead = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFileRead
            // 
            this.buttonFileRead.Location = new System.Drawing.Point(12, 338);
            this.buttonFileRead.Name = "buttonFileRead";
            this.buttonFileRead.Size = new System.Drawing.Size(142, 77);
            this.buttonFileRead.TabIndex = 1;
            this.buttonFileRead.Text = "Прочитать файл";
            this.buttonFileRead.UseVisualStyleBackColor = true;
            this.buttonFileRead.Click += new System.EventHandler(this.buttonFileRead_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(169, 338);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(142, 77);
            this.buttonTest.TabIndex = 2;
            this.buttonTest.Text = "test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new System.Drawing.Size(473, 320);
            this.dataGridViewProducts.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonFileRead);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonFileRead;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
    }
}

