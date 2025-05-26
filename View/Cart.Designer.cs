namespace ProductsShop.View
{
    partial class Cart
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
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.labelCart = new System.Windows.Forms.Label();
            this.labelMoney = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(12, 44);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.Size = new System.Drawing.Size(496, 261);
            this.dataGridViewCart.TabIndex = 4;
            this.dataGridViewCart.SelectionChanged += new System.EventHandler(this.dataGridViewCart_SelectionChanged);
            // 
            // labelCart
            // 
            this.labelCart.AutoSize = true;
            this.labelCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelCart.ForeColor = System.Drawing.Color.Gray;
            this.labelCart.Location = new System.Drawing.Point(12, 9);
            this.labelCart.Name = "labelCart";
            this.labelCart.Size = new System.Drawing.Size(106, 24);
            this.labelCart.TabIndex = 5;
            this.labelCart.Text = "Корзина: 0";
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelMoney.ForeColor = System.Drawing.Color.Black;
            this.labelMoney.Location = new System.Drawing.Point(12, 319);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(135, 24);
            this.labelMoney.TabIndex = 6;
            this.labelMoney.Text = "Баланс: 0 руб.";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(407, 319);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(101, 93);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Удалить из корзины";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 450);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelMoney);
            this.Controls.Add(this.labelCart);
            this.Controls.Add(this.dataGridViewCart);
            this.Name = "Cart";
            this.Text = "Cart";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.Label labelCart;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Button buttonDelete;
    }
}