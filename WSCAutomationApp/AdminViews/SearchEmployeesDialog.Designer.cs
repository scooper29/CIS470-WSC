namespace WSCAutomation.App
{
	partial class SearchEmployeesDialog
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			this.txtParameterUserName = new System.Windows.Forms.TextBox();
			this.txtParameterEmail = new System.Windows.Forms.TextBox();
			this.txtParameterLastName = new System.Windows.Forms.TextBox();
			this.txtParameterFirstName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbxParameterAccessCode = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(1, 29);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(60, 13);
			label1.TabIndex = 7;
			label1.Text = "User Name";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(1, 56);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 13);
			label2.TabIndex = 9;
			label2.Text = "Email";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(193, 6);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(58, 13);
			label3.TabIndex = 11;
			label3.Text = "Last Name";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(193, 29);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(57, 13);
			label4.TabIndex = 13;
			label4.Text = "First Name";
			// 
			// txtParameterUserName
			// 
			this.txtParameterUserName.Location = new System.Drawing.Point(85, 29);
			this.txtParameterUserName.Name = "txtParameterUserName";
			this.txtParameterUserName.Size = new System.Drawing.Size(100, 20);
			this.txtParameterUserName.TabIndex = 8;
			// 
			// txtParameterEmail
			// 
			this.txtParameterEmail.Location = new System.Drawing.Point(85, 56);
			this.txtParameterEmail.Name = "txtParameterEmail";
			this.txtParameterEmail.Size = new System.Drawing.Size(100, 20);
			this.txtParameterEmail.TabIndex = 10;
			// 
			// txtParameterLastName
			// 
			this.txtParameterLastName.Location = new System.Drawing.Point(256, 3);
			this.txtParameterLastName.Name = "txtParameterLastName";
			this.txtParameterLastName.Size = new System.Drawing.Size(116, 20);
			this.txtParameterLastName.TabIndex = 12;
			// 
			// txtParameterFirstName
			// 
			this.txtParameterFirstName.Location = new System.Drawing.Point(256, 29);
			this.txtParameterFirstName.Name = "txtParameterFirstName";
			this.txtParameterFirstName.Size = new System.Drawing.Size(116, 20);
			this.txtParameterFirstName.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(193, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Access";
			// 
			// cbxParameterAccessCode
			// 
			this.cbxParameterAccessCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxParameterAccessCode.FormattingEnabled = true;
			this.cbxParameterAccessCode.Location = new System.Drawing.Point(256, 56);
			this.cbxParameterAccessCode.Name = "cbxParameterAccessCode";
			this.cbxParameterAccessCode.Size = new System.Drawing.Size(121, 21);
			this.cbxParameterAccessCode.TabIndex = 16;
			// 
			// SearchEmployeesDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(384, 300);
			this.Controls.Add(this.cbxParameterAccessCode);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtParameterFirstName);
			this.Controls.Add(label4);
			this.Controls.Add(this.txtParameterLastName);
			this.Controls.Add(label3);
			this.Controls.Add(this.txtParameterEmail);
			this.Controls.Add(label2);
			this.Controls.Add(this.txtParameterUserName);
			this.Controls.Add(label1);
			this.Name = "SearchEmployeesDialog";
			this.Text = "Search Users";
			this.Controls.SetChildIndex(label1, 0);
			this.Controls.SetChildIndex(this.txtParameterUserName, 0);
			this.Controls.SetChildIndex(this.lblParameterId, 0);
			this.Controls.SetChildIndex(this.txtParameterId, 0);
			this.Controls.SetChildIndex(this.btnSearch, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnSelect, 0);
			this.Controls.SetChildIndex(this.btnEdit, 0);
			this.Controls.SetChildIndex(label2, 0);
			this.Controls.SetChildIndex(this.txtParameterEmail, 0);
			this.Controls.SetChildIndex(label3, 0);
			this.Controls.SetChildIndex(this.txtParameterLastName, 0);
			this.Controls.SetChildIndex(label4, 0);
			this.Controls.SetChildIndex(this.txtParameterFirstName, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.cbxParameterAccessCode, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtParameterUserName;
		private System.Windows.Forms.TextBox txtParameterEmail;
		private System.Windows.Forms.TextBox txtParameterLastName;
		private System.Windows.Forms.TextBox txtParameterFirstName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbxParameterAccessCode;
	}
}
