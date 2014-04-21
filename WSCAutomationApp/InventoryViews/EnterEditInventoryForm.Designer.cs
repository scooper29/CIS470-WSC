namespace WSCAutomation.App
{
    partial class EnterEditInventoryForm
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
			this.txtInventoryName = new System.Windows.Forms.TextBox();
			this.txtManufacturerName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.btnSubmitRequestDetails = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(93, 186);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(12, 186);
			// 
			// txtInventoryName
			// 
			this.txtInventoryName.Location = new System.Drawing.Point(85, 29);
			this.txtInventoryName.Name = "txtInventoryName";
			this.txtInventoryName.Size = new System.Drawing.Size(139, 20);
			this.txtInventoryName.TabIndex = 11;
			// 
			// txtManufacturerName
			// 
			this.txtManufacturerName.Location = new System.Drawing.Point(85, 55);
			this.txtManufacturerName.Name = "txtManufacturerName";
			this.txtManufacturerName.Size = new System.Drawing.Size(139, 20);
			this.txtManufacturerName.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Manufacturer";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Name";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(1, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Quantity";
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.Location = new System.Drawing.Point(85, 81);
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(42, 20);
			this.numericUpDownQuantity.TabIndex = 13;
			// 
			// btnSubmitRequestDetails
			// 
			this.btnSubmitRequestDetails.Location = new System.Drawing.Point(85, 108);
			this.btnSubmitRequestDetails.Name = "btnSubmitRequestDetails";
			this.btnSubmitRequestDetails.Size = new System.Drawing.Size(139, 23);
			this.btnSubmitRequestDetails.TabIndex = 14;
			this.btnSubmitRequestDetails.Text = "Log Purchase Request";
			this.btnSubmitRequestDetails.UseVisualStyleBackColor = true;
			this.btnSubmitRequestDetails.Click += new System.EventHandler(this.OnSubmitRequestDetails);
			// 
			// EnterEditInventoryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(237, 221);
			this.Controls.Add(this.btnSubmitRequestDetails);
			this.Controls.Add(this.numericUpDownQuantity);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtInventoryName);
			this.Controls.Add(this.txtManufacturerName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Name = "EnterEditInventoryForm";
			this.Controls.SetChildIndex(this.lblRecordId, 0);
			this.Controls.SetChildIndex(this.txtRecordId, 0);
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnClose, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtManufacturerName, 0);
			this.Controls.SetChildIndex(this.txtInventoryName, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.numericUpDownQuantity, 0);
			this.Controls.SetChildIndex(this.btnSubmitRequestDetails, 0);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInventoryName;
		private System.Windows.Forms.TextBox txtManufacturerName;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
		private System.Windows.Forms.Button btnSubmitRequestDetails;
    }
}
