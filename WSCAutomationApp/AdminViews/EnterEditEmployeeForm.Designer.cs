namespace WSCAutomation.App
{
	partial class EnterEditEmployeeForm
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
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label6;
			this.cbxAccessCode = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(193, 29);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(57, 13);
			label4.TabIndex = 23;
			label4.Text = "First Name";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(193, 6);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(58, 13);
			label3.TabIndex = 21;
			label3.Text = "Last Name";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(1, 56);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 13);
			label2.TabIndex = 19;
			label2.Text = "Email";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(1, 29);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(60, 13);
			label1.TabIndex = 17;
			label1.Text = "User Name";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(1, 86);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(53, 13);
			label6.TabIndex = 27;
			label6.Text = "Password";
			// 
			// cbxAccessCode
			// 
			this.cbxAccessCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxAccessCode.FormattingEnabled = true;
			this.cbxAccessCode.Location = new System.Drawing.Point(256, 56);
			this.cbxAccessCode.Name = "cbxAccessCode";
			this.cbxAccessCode.Size = new System.Drawing.Size(121, 21);
			this.cbxAccessCode.TabIndex = 26;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(193, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "Access";
			// 
			// txtFirstName
			// 
			this.txtFirstName.Location = new System.Drawing.Point(256, 29);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(116, 20);
			this.txtFirstName.TabIndex = 24;
			// 
			// txtLastName
			// 
			this.txtLastName.Location = new System.Drawing.Point(256, 3);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(116, 20);
			this.txtLastName.TabIndex = 22;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(85, 56);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(100, 20);
			this.txtEmail.TabIndex = 20;
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(85, 29);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(100, 20);
			this.txtUserName.TabIndex = 18;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(85, 83);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(100, 20);
			this.txtPassword.TabIndex = 28;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// EnterEditEmployeeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(384, 262);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(label6);
			this.Controls.Add(this.cbxAccessCode);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtFirstName);
			this.Controls.Add(label4);
			this.Controls.Add(this.txtLastName);
			this.Controls.Add(label3);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(label2);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(label1);
			this.Name = "EnterEditEmployeeForm";
			this.Text = "EnterEditUser";
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnClose, 0);
			this.Controls.SetChildIndex(this.lblRecordId, 0);
			this.Controls.SetChildIndex(this.txtRecordId, 0);
			this.Controls.SetChildIndex(label1, 0);
			this.Controls.SetChildIndex(this.txtUserName, 0);
			this.Controls.SetChildIndex(label2, 0);
			this.Controls.SetChildIndex(this.txtEmail, 0);
			this.Controls.SetChildIndex(label3, 0);
			this.Controls.SetChildIndex(this.txtLastName, 0);
			this.Controls.SetChildIndex(label4, 0);
			this.Controls.SetChildIndex(this.txtFirstName, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.cbxAccessCode, 0);
			this.Controls.SetChildIndex(label6, 0);
			this.Controls.SetChildIndex(this.txtPassword, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbxAccessCode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFirstName;
		private System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;

	}
}
