namespace WSCAutomation.App
{
	partial class SearchOrdersDialog
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
			this.txtParameterCustomerId = new System.Windows.Forms.TextBox();
			this.txtParameterSpecialistId = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(1, 33);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(65, 13);
			label1.TabIndex = 7;
			label1.Text = "Customer ID";
			// 
			// txtParameterCustomerId
			// 
			this.txtParameterCustomerId.Location = new System.Drawing.Point(85, 30);
			this.txtParameterCustomerId.Name = "txtParameterCustomerId";
			this.txtParameterCustomerId.Size = new System.Drawing.Size(100, 20);
			this.txtParameterCustomerId.TabIndex = 8;
			// 
			// txtParameterSpecialistId
			// 
			this.txtParameterSpecialistId.Location = new System.Drawing.Point(85, 56);
			this.txtParameterSpecialistId.Name = "txtParameterSpecialistId";
			this.txtParameterSpecialistId.Size = new System.Drawing.Size(100, 20);
			this.txtParameterSpecialistId.TabIndex = 10;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(1, 59);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(66, 13);
			label2.TabIndex = 9;
			label2.Text = "Specialist ID";
			// 
			// SearchOrdersDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(284, 300);
			this.Controls.Add(this.txtParameterSpecialistId);
			this.Controls.Add(label2);
			this.Controls.Add(this.txtParameterCustomerId);
			this.Controls.Add(label1);
			this.Name = "SearchOrdersDialog";
			this.Controls.SetChildIndex(this.lblParameterId, 0);
			this.Controls.SetChildIndex(this.txtParameterId, 0);
			this.Controls.SetChildIndex(this.btnSearch, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnSelect, 0);
			this.Controls.SetChildIndex(this.btnEdit, 0);
			this.Controls.SetChildIndex(label1, 0);
			this.Controls.SetChildIndex(this.txtParameterCustomerId, 0);
			this.Controls.SetChildIndex(label2, 0);
			this.Controls.SetChildIndex(this.txtParameterSpecialistId, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtParameterCustomerId;
		private System.Windows.Forms.TextBox txtParameterSpecialistId;

	}
}
