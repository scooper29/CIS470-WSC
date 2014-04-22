namespace WSCAutomation.App
{
	partial class EnterEditOrderQualityDialog
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
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			this.txtQualityDescription = new System.Windows.Forms.TextBox();
			this.cbxGrade = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtQualityDescription
			// 
			this.txtQualityDescription.Location = new System.Drawing.Point(85, 56);
			this.txtQualityDescription.Multiline = true;
			this.txtQualityDescription.Name = "txtQualityDescription";
			this.txtQualityDescription.Size = new System.Drawing.Size(187, 165);
			this.txtQualityDescription.TabIndex = 7;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(1, 59);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(60, 13);
			label2.TabIndex = 6;
			label2.Text = "Description";
			// 
			// cbxGrade
			// 
			this.cbxGrade.FormattingEnabled = true;
			this.cbxGrade.Location = new System.Drawing.Point(85, 29);
			this.cbxGrade.Name = "cbxGrade";
			this.cbxGrade.Size = new System.Drawing.Size(100, 21);
			this.cbxGrade.TabIndex = 5;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(1, 32);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(36, 13);
			label1.TabIndex = 4;
			label1.Text = "Grade";
			// 
			// EnterEditOrderQualityDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.txtQualityDescription);
			this.Controls.Add(label2);
			this.Controls.Add(this.cbxGrade);
			this.Controls.Add(label1);
			this.Name = "EnterEditOrderQualityDialog";
			this.Controls.SetChildIndex(this.lblRecordId, 0);
			this.Controls.SetChildIndex(this.txtRecordId, 0);
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnClose, 0);
			this.Controls.SetChildIndex(label1, 0);
			this.Controls.SetChildIndex(this.cbxGrade, 0);
			this.Controls.SetChildIndex(label2, 0);
			this.Controls.SetChildIndex(this.txtQualityDescription, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtQualityDescription;
		private System.Windows.Forms.ComboBox cbxGrade;
	}
}
