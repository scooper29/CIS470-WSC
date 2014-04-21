namespace WSCAutomation.App
{
    partial class EnterEditOrderForm
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
			System.Windows.Forms.Label label10;
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label11;
			System.Windows.Forms.Label label12;
			System.Windows.Forms.Label label13;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label3;
			this.txtOrderInvalidMemo = new System.Windows.Forms.TextBox();
			this.txtOrderMessage = new System.Windows.Forms.TextBox();
			this.txtCatalogNumber = new System.Windows.Forms.TextBox();
			this.txtInventoryId = new System.Windows.Forms.TextBox();
			this.txtCustomerId = new System.Windows.Forms.TextBox();
			this.cbxOrderType = new System.Windows.Forms.ComboBox();
			this.cbxOrderValidated = new System.Windows.Forms.ComboBox();
			this.cbxOrderPaid = new System.Windows.Forms.ComboBox();
			this.cbxOrderClosed = new System.Windows.Forms.ComboBox();
			this.txtSalesId = new System.Windows.Forms.TextBox();
			this.txtSpecialistId = new System.Windows.Forms.TextBox();
			this.btnSelectCustomer = new System.Windows.Forms.Button();
			this.btnSelectInventory = new System.Windows.Forms.Button();
			this.btnSelectSalesEmployee = new System.Windows.Forms.Button();
			this.btnSelectSpecialistEmployee = new System.Windows.Forms.Button();
			label10 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(93, 211);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(12, 211);
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(220, 132);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(70, 13);
			label10.TabIndex = 65;
			label10.Text = "Invalid Memo";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(220, 6);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(31, 13);
			label9.TabIndex = 57;
			label9.Text = "Type";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(1, 32);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(65, 13);
			label7.TabIndex = 56;
			label7.Text = "Customer ID";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(1, 58);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(65, 13);
			label5.TabIndex = 54;
			label5.Text = "Inventory ID";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(220, 32);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(53, 13);
			label4.TabIndex = 53;
			label4.Text = "Catalog #";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(1, 132);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(50, 13);
			label2.TabIndex = 52;
			label2.Text = "Message";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(220, 84);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(51, 13);
			label11.TabIndex = 73;
			label11.Text = "Validated";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(220, 57);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(28, 13);
			label12.TabIndex = 74;
			label12.Text = "Paid";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(220, 110);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(39, 13);
			label13.TabIndex = 75;
			label13.Text = "Closed";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(1, 84);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(47, 13);
			label1.TabIndex = 81;
			label1.Text = "Sales ID";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(1, 110);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(66, 13);
			label3.TabIndex = 83;
			label3.Text = "Specialist ID";
			// 
			// txtOrderInvalidMemo
			// 
			this.txtOrderInvalidMemo.Location = new System.Drawing.Point(306, 129);
			this.txtOrderInvalidMemo.Multiline = true;
			this.txtOrderInvalidMemo.Name = "txtOrderInvalidMemo";
			this.txtOrderInvalidMemo.Size = new System.Drawing.Size(100, 44);
			this.txtOrderInvalidMemo.TabIndex = 70;
			// 
			// txtOrderMessage
			// 
			this.txtOrderMessage.Location = new System.Drawing.Point(85, 129);
			this.txtOrderMessage.Multiline = true;
			this.txtOrderMessage.Name = "txtOrderMessage";
			this.txtOrderMessage.Size = new System.Drawing.Size(126, 44);
			this.txtOrderMessage.TabIndex = 64;
			// 
			// txtCatalogNumber
			// 
			this.txtCatalogNumber.Location = new System.Drawing.Point(306, 29);
			this.txtCatalogNumber.Name = "txtCatalogNumber";
			this.txtCatalogNumber.Size = new System.Drawing.Size(100, 20);
			this.txtCatalogNumber.TabIndex = 63;
			// 
			// txtInventoryId
			// 
			this.txtInventoryId.Location = new System.Drawing.Point(85, 55);
			this.txtInventoryId.Name = "txtInventoryId";
			this.txtInventoryId.Size = new System.Drawing.Size(100, 20);
			this.txtInventoryId.TabIndex = 61;
			// 
			// txtCustomerId
			// 
			this.txtCustomerId.Location = new System.Drawing.Point(85, 29);
			this.txtCustomerId.Name = "txtCustomerId";
			this.txtCustomerId.Size = new System.Drawing.Size(100, 20);
			this.txtCustomerId.TabIndex = 59;
			// 
			// cbxOrderType
			// 
			this.cbxOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxOrderType.FormattingEnabled = true;
			this.cbxOrderType.Location = new System.Drawing.Point(306, 3);
			this.cbxOrderType.Name = "cbxOrderType";
			this.cbxOrderType.Size = new System.Drawing.Size(100, 21);
			this.cbxOrderType.TabIndex = 76;
			// 
			// cbxOrderValidated
			// 
			this.cbxOrderValidated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxOrderValidated.FormattingEnabled = true;
			this.cbxOrderValidated.Location = new System.Drawing.Point(306, 79);
			this.cbxOrderValidated.Name = "cbxOrderValidated";
			this.cbxOrderValidated.Size = new System.Drawing.Size(100, 21);
			this.cbxOrderValidated.TabIndex = 78;
			// 
			// cbxOrderPaid
			// 
			this.cbxOrderPaid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxOrderPaid.FormattingEnabled = true;
			this.cbxOrderPaid.Location = new System.Drawing.Point(306, 54);
			this.cbxOrderPaid.Name = "cbxOrderPaid";
			this.cbxOrderPaid.Size = new System.Drawing.Size(100, 21);
			this.cbxOrderPaid.TabIndex = 79;
			// 
			// cbxOrderClosed
			// 
			this.cbxOrderClosed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxOrderClosed.FormattingEnabled = true;
			this.cbxOrderClosed.Location = new System.Drawing.Point(306, 102);
			this.cbxOrderClosed.Name = "cbxOrderClosed";
			this.cbxOrderClosed.Size = new System.Drawing.Size(100, 21);
			this.cbxOrderClosed.TabIndex = 80;
			// 
			// txtSalesId
			// 
			this.txtSalesId.Location = new System.Drawing.Point(85, 81);
			this.txtSalesId.Name = "txtSalesId";
			this.txtSalesId.Size = new System.Drawing.Size(100, 20);
			this.txtSalesId.TabIndex = 82;
			// 
			// txtSpecialistId
			// 
			this.txtSpecialistId.Location = new System.Drawing.Point(85, 107);
			this.txtSpecialistId.Name = "txtSpecialistId";
			this.txtSpecialistId.Size = new System.Drawing.Size(100, 20);
			this.txtSpecialistId.TabIndex = 84;
			// 
			// btnSelectCustomer
			// 
			this.btnSelectCustomer.Location = new System.Drawing.Point(186, 27);
			this.btnSelectCustomer.Name = "btnSelectCustomer";
			this.btnSelectCustomer.Size = new System.Drawing.Size(25, 23);
			this.btnSelectCustomer.TabIndex = 85;
			this.btnSelectCustomer.Text = "...";
			this.btnSelectCustomer.UseVisualStyleBackColor = true;
			this.btnSelectCustomer.Click += new System.EventHandler(this.OnSelectCustomer);
			// 
			// btnSelectInventory
			// 
			this.btnSelectInventory.Location = new System.Drawing.Point(186, 52);
			this.btnSelectInventory.Name = "btnSelectInventory";
			this.btnSelectInventory.Size = new System.Drawing.Size(25, 23);
			this.btnSelectInventory.TabIndex = 86;
			this.btnSelectInventory.Text = "...";
			this.btnSelectInventory.UseVisualStyleBackColor = true;
			this.btnSelectInventory.Click += new System.EventHandler(this.OnSelectInventory);
			// 
			// btnSelectSalesEmployee
			// 
			this.btnSelectSalesEmployee.Location = new System.Drawing.Point(186, 79);
			this.btnSelectSalesEmployee.Name = "btnSelectSalesEmployee";
			this.btnSelectSalesEmployee.Size = new System.Drawing.Size(25, 23);
			this.btnSelectSalesEmployee.TabIndex = 87;
			this.btnSelectSalesEmployee.Text = "...";
			this.btnSelectSalesEmployee.UseVisualStyleBackColor = true;
			this.btnSelectSalesEmployee.Click += new System.EventHandler(this.OnSelectSalesEmployee);
			// 
			// btnSelectSpecialistEmployee
			// 
			this.btnSelectSpecialistEmployee.Location = new System.Drawing.Point(186, 105);
			this.btnSelectSpecialistEmployee.Name = "btnSelectSpecialistEmployee";
			this.btnSelectSpecialistEmployee.Size = new System.Drawing.Size(25, 23);
			this.btnSelectSpecialistEmployee.TabIndex = 88;
			this.btnSelectSpecialistEmployee.Text = "...";
			this.btnSelectSpecialistEmployee.UseVisualStyleBackColor = true;
			this.btnSelectSpecialistEmployee.Click += new System.EventHandler(this.OnSelectSpecialistEmployee);
			// 
			// EnterEditOrderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(423, 246);
			this.Controls.Add(this.btnSelectSpecialistEmployee);
			this.Controls.Add(this.btnSelectSalesEmployee);
			this.Controls.Add(this.btnSelectInventory);
			this.Controls.Add(this.btnSelectCustomer);
			this.Controls.Add(this.txtSpecialistId);
			this.Controls.Add(label3);
			this.Controls.Add(this.txtSalesId);
			this.Controls.Add(label1);
			this.Controls.Add(this.cbxOrderClosed);
			this.Controls.Add(this.cbxOrderPaid);
			this.Controls.Add(this.cbxOrderValidated);
			this.Controls.Add(this.cbxOrderType);
			this.Controls.Add(label13);
			this.Controls.Add(label12);
			this.Controls.Add(label11);
			this.Controls.Add(this.txtOrderInvalidMemo);
			this.Controls.Add(label10);
			this.Controls.Add(this.txtOrderMessage);
			this.Controls.Add(this.txtCatalogNumber);
			this.Controls.Add(this.txtInventoryId);
			this.Controls.Add(this.txtCustomerId);
			this.Controls.Add(label9);
			this.Controls.Add(label7);
			this.Controls.Add(label5);
			this.Controls.Add(label4);
			this.Controls.Add(label2);
			this.Name = "EnterEditOrderForm";
			this.Controls.SetChildIndex(label2, 0);
			this.Controls.SetChildIndex(label4, 0);
			this.Controls.SetChildIndex(label5, 0);
			this.Controls.SetChildIndex(label7, 0);
			this.Controls.SetChildIndex(label9, 0);
			this.Controls.SetChildIndex(this.txtCustomerId, 0);
			this.Controls.SetChildIndex(this.txtInventoryId, 0);
			this.Controls.SetChildIndex(this.txtCatalogNumber, 0);
			this.Controls.SetChildIndex(this.txtOrderMessage, 0);
			this.Controls.SetChildIndex(label10, 0);
			this.Controls.SetChildIndex(this.txtOrderInvalidMemo, 0);
			this.Controls.SetChildIndex(label11, 0);
			this.Controls.SetChildIndex(label12, 0);
			this.Controls.SetChildIndex(label13, 0);
			this.Controls.SetChildIndex(this.cbxOrderType, 0);
			this.Controls.SetChildIndex(this.cbxOrderValidated, 0);
			this.Controls.SetChildIndex(this.cbxOrderPaid, 0);
			this.Controls.SetChildIndex(this.cbxOrderClosed, 0);
			this.Controls.SetChildIndex(this.lblRecordId, 0);
			this.Controls.SetChildIndex(this.txtRecordId, 0);
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnClose, 0);
			this.Controls.SetChildIndex(label1, 0);
			this.Controls.SetChildIndex(this.txtSalesId, 0);
			this.Controls.SetChildIndex(label3, 0);
			this.Controls.SetChildIndex(this.txtSpecialistId, 0);
			this.Controls.SetChildIndex(this.btnSelectCustomer, 0);
			this.Controls.SetChildIndex(this.btnSelectInventory, 0);
			this.Controls.SetChildIndex(this.btnSelectSalesEmployee, 0);
			this.Controls.SetChildIndex(this.btnSelectSpecialistEmployee, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox txtOrderInvalidMemo;
        private System.Windows.Forms.TextBox txtOrderMessage;
        private System.Windows.Forms.TextBox txtCatalogNumber;
        private System.Windows.Forms.TextBox txtInventoryId;
		private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.ComboBox cbxOrderType;
        private System.Windows.Forms.ComboBox cbxOrderValidated;
        private System.Windows.Forms.ComboBox cbxOrderPaid;
        private System.Windows.Forms.ComboBox cbxOrderClosed;
		private System.Windows.Forms.TextBox txtSalesId;
		private System.Windows.Forms.TextBox txtSpecialistId;
		private System.Windows.Forms.Button btnSelectCustomer;
		private System.Windows.Forms.Button btnSelectInventory;
		private System.Windows.Forms.Button btnSelectSalesEmployee;
		private System.Windows.Forms.Button btnSelectSpecialistEmployee;
    }
}
