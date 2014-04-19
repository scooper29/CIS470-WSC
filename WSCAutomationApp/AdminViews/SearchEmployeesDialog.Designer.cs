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
			this.txtParameterUserName = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
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
			// txtParameterUserName
			// 
			this.txtParameterUserName.Location = new System.Drawing.Point(85, 29);
			this.txtParameterUserName.Name = "txtParameterUserName";
			this.txtParameterUserName.Size = new System.Drawing.Size(100, 20);
			this.txtParameterUserName.TabIndex = 8;
			// 
			// SearchEmployeesDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(284, 300);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtParameterUserName;
	}
}
