namespace WSCAutomation.App
{
    partial class SearchCustomersDialog
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
			System.Windows.Forms.Label label3;
			this.txtCustomerLastName = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvSearchResults
			// 
			this.dgvSearchResults.Size = new System.Drawing.Size(444, 150);
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(1, 32);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(58, 13);
			label3.TabIndex = 9;
			label3.Text = "Last Name";
			// 
			// txtCustomerLastName
			// 
			this.txtCustomerLastName.Location = new System.Drawing.Point(85, 29);
			this.txtCustomerLastName.Name = "txtCustomerLastName";
			this.txtCustomerLastName.Size = new System.Drawing.Size(100, 20);
			this.txtCustomerLastName.TabIndex = 12;
			// 
			// SearchCustomersDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(448, 300);
			this.Controls.Add(this.txtCustomerLastName);
			this.Controls.Add(label3);
			this.Name = "SearchCustomersDialog";
			this.Text = "Search Customers";
			this.Controls.SetChildIndex(this.dgvSearchResults, 0);
			this.Controls.SetChildIndex(this.lblParameterId, 0);
			this.Controls.SetChildIndex(this.txtParameterId, 0);
			this.Controls.SetChildIndex(this.btnSearch, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnSelect, 0);
			this.Controls.SetChildIndex(this.btnEdit, 0);
			this.Controls.SetChildIndex(label3, 0);
			this.Controls.SetChildIndex(this.txtCustomerLastName, 0);
			((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox txtCustomerLastName;
    }
}
