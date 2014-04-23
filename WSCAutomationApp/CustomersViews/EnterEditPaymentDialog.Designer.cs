namespace WSCAutomation.App
{
	partial class EnterEditPaymentDialog
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
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			this.txtCardNumber = new System.Windows.Forms.TextBox();
			this.cbxType = new System.Windows.Forms.ComboBox();
			this.dateTimePickerExpiration = new System.Windows.Forms.DateTimePicker();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(1, 58);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(31, 13);
			label3.TabIndex = 8;
			label3.Text = "Type";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(1, 88);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(53, 13);
			label2.TabIndex = 7;
			label2.Text = "Expiration";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(1, 32);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(69, 13);
			label1.TabIndex = 6;
			label1.Text = "Card Number";
			// 
			// txtCardNumber
			// 
			this.txtCardNumber.Location = new System.Drawing.Point(85, 29);
			this.txtCardNumber.Name = "txtCardNumber";
			this.txtCardNumber.Size = new System.Drawing.Size(121, 20);
			this.txtCardNumber.TabIndex = 11;
			// 
			// cbxType
			// 
			this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxType.FormattingEnabled = true;
			this.cbxType.Location = new System.Drawing.Point(85, 55);
			this.cbxType.Name = "cbxType";
			this.cbxType.Size = new System.Drawing.Size(121, 21);
			this.cbxType.TabIndex = 10;
			// 
			// dateTimePickerExpiration
			// 
			this.dateTimePickerExpiration.Location = new System.Drawing.Point(85, 82);
			this.dateTimePickerExpiration.Name = "dateTimePickerExpiration";
			this.dateTimePickerExpiration.Size = new System.Drawing.Size(187, 20);
			this.dateTimePickerExpiration.TabIndex = 9;
			// 
			// EnterEditPaymentDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.txtCardNumber);
			this.Controls.Add(this.cbxType);
			this.Controls.Add(this.dateTimePickerExpiration);
			this.Controls.Add(label3);
			this.Controls.Add(label2);
			this.Controls.Add(label1);
			this.Name = "EnterEditPaymentDialog";
			this.Controls.SetChildIndex(this.lblRecordId, 0);
			this.Controls.SetChildIndex(this.txtRecordId, 0);
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnClose, 0);
			this.Controls.SetChildIndex(label1, 0);
			this.Controls.SetChildIndex(label2, 0);
			this.Controls.SetChildIndex(label3, 0);
			this.Controls.SetChildIndex(this.dateTimePickerExpiration, 0);
			this.Controls.SetChildIndex(this.cbxType, 0);
			this.Controls.SetChildIndex(this.txtCardNumber, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtCardNumber;
		private System.Windows.Forms.ComboBox cbxType;
		private System.Windows.Forms.DateTimePicker dateTimePickerExpiration;
	}
}
