namespace InventoryManagementSystem
{
    partial class PurchaseHistory
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
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Suplier_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supply_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rice_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 402);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 36);
            this.button3.TabIndex = 11;
            this.button3.Text = "Reload";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Customer\'s Name";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 360);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 36);
            this.button2.TabIndex = 9;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 334);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "<- Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Suplier_Name,
            this.Supplier_Company,
            this.Supply_Date,
            this.Quantity,
            this.Rice_Name});
            this.dataGridView1.Location = new System.Drawing.Point(142, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(547, 426);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Suplier_Name
            // 
            this.Suplier_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Suplier_Name.HeaderText = "Customer_Name";
            this.Suplier_Name.Name = "Suplier_Name";
            // 
            // Supplier_Company
            // 
            this.Supplier_Company.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Supplier_Company.HeaderText = "Customer_Info";
            this.Supplier_Company.Name = "Supplier_Company";
            // 
            // Supply_Date
            // 
            this.Supply_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Supply_Date.HeaderText = "Purchase_Date";
            this.Supply_Date.Name = "Supply_Date";
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Rice_Name
            // 
            this.Rice_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rice_Name.HeaderText = "Product_Name";
            this.Rice_Name.Name = "Rice_Name";
            // 
            // PurchaseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PurchaseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchaseHistory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PurchaseHistory_FormClosing);
            this.Load += new System.EventHandler(this.PurchaseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suplier_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supply_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rice_Name;
    }
}