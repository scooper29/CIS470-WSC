namespace WSCAutomation.App.OrdersViews
{
    partial class SearchedOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbOrderID = new System.Windows.Forms.TextBox();
            this.txbEmployeeID = new System.Windows.Forms.TextBox();
            this.txbCustomerID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(4, 151);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(85, 151);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(4, 336);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(85, 336);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Order ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Employee ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Customer ID:";
            // 
            // txbOrderID
            // 
            this.txbOrderID.Location = new System.Drawing.Point(99, 44);
            this.txbOrderID.Name = "txbOrderID";
            this.txbOrderID.Size = new System.Drawing.Size(100, 20);
            this.txbOrderID.TabIndex = 10;
            // 
            // txbEmployeeID
            // 
            this.txbEmployeeID.Location = new System.Drawing.Point(99, 104);
            this.txbEmployeeID.Name = "txbEmployeeID";
            this.txbEmployeeID.Size = new System.Drawing.Size(100, 20);
            this.txbEmployeeID.TabIndex = 11;
            // 
            // txbCustomerID
            // 
            this.txbCustomerID.Location = new System.Drawing.Point(99, 75);
            this.txbCustomerID.Name = "txbCustomerID";
            this.txbCustomerID.Size = new System.Drawing.Size(100, 20);
            this.txbCustomerID.TabIndex = 12;
            // 
            // SearchedOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(472, 371);
            this.Controls.Add(this.txbCustomerID);
            this.Controls.Add(this.txbEmployeeID);
            this.Controls.Add(this.txbOrderID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SearchedOrder";
            this.Controls.SetChildIndex(this.lblParameterId, 0);
            this.Controls.SetChildIndex(this.txtParameterId, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txbOrderID, 0);
            this.Controls.SetChildIndex(this.txbEmployeeID, 0);
            this.Controls.SetChildIndex(this.txbCustomerID, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbOrderID;
        private System.Windows.Forms.TextBox txbEmployeeID;
        private System.Windows.Forms.TextBox txbCustomerID;
    }
}
