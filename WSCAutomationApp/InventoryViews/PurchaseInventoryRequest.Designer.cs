namespace WSCAutomation.App
{
    partial class PurchaseInventoryRequest
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
			this.label5 = new System.Windows.Forms.Label();
			this.txtInventoryId = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerDelieveryDate = new System.Windows.Forms.DateTimePicker();
			this.upDownOrderQty = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.upDownOrderQty)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(191, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 13);
			this.label5.TabIndex = 56;
			this.label5.Text = "Order Quantity";
			// 
			// txtInventoryId
			// 
			this.txtInventoryId.Location = new System.Drawing.Point(85, 29);
			this.txtInventoryId.Name = "txtInventoryId";
			this.txtInventoryId.ReadOnly = true;
			this.txtInventoryId.Size = new System.Drawing.Size(100, 20);
			this.txtInventoryId.TabIndex = 55;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(1, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 13);
			this.label4.TabIndex = 54;
			this.label4.Text = "Inventory ID";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 58;
			this.label1.Text = "Order Date:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(-1, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 13);
			this.label2.TabIndex = 59;
			this.label2.Text = "Delievery Date:";
			// 
			// dateTimePickerOrderDate
			// 
			this.dateTimePickerOrderDate.Location = new System.Drawing.Point(85, 55);
			this.dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
			this.dateTimePickerOrderDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePickerOrderDate.TabIndex = 60;
			// 
			// dateTimePickerDelieveryDate
			// 
			this.dateTimePickerDelieveryDate.Location = new System.Drawing.Point(85, 81);
			this.dateTimePickerDelieveryDate.Name = "dateTimePickerDelieveryDate";
			this.dateTimePickerDelieveryDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePickerDelieveryDate.TabIndex = 61;
			// 
			// upDownOrderQty
			// 
			this.upDownOrderQty.Location = new System.Drawing.Point(272, 29);
			this.upDownOrderQty.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.upDownOrderQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.upDownOrderQty.Name = "upDownOrderQty";
			this.upDownOrderQty.Size = new System.Drawing.Size(42, 20);
			this.upDownOrderQty.TabIndex = 62;
			this.upDownOrderQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// PurchaseInventoryRequest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(317, 262);
			this.Controls.Add(this.upDownOrderQty);
			this.Controls.Add(this.dateTimePickerDelieveryDate);
			this.Controls.Add(this.dateTimePickerOrderDate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtInventoryId);
			this.Controls.Add(this.label4);
			this.Name = "PurchaseInventoryRequest";
			this.Controls.SetChildIndex(this.lblRecordId, 0);
			this.Controls.SetChildIndex(this.txtRecordId, 0);
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnClose, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtInventoryId, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.dateTimePickerOrderDate, 0);
			this.Controls.SetChildIndex(this.dateTimePickerDelieveryDate, 0);
			this.Controls.SetChildIndex(this.upDownOrderQty, 0);
			((System.ComponentModel.ISupportInitialize)(this.upDownOrderQty)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInventoryId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrderDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDelieveryDate;
        private System.Windows.Forms.NumericUpDown upDownOrderQty;
    }
}
