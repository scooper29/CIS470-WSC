namespace WSCAutomation.App
{
	partial class EnterEditRecordFormBase
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
			this.lblRecordId = new System.Windows.Forms.Label();
			this.txtRecordId = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblRecordId
			// 
			this.lblRecordId.AutoSize = true;
			this.lblRecordId.Location = new System.Drawing.Point(1, 6);
			this.lblRecordId.Name = "lblRecordId";
			this.lblRecordId.Size = new System.Drawing.Size(18, 13);
			this.lblRecordId.TabIndex = 0;
			this.lblRecordId.Text = "ID";
			// 
			// txtRecordId
			// 
			this.txtRecordId.Location = new System.Drawing.Point(85, 3);
			this.txtRecordId.Name = "txtRecordId";
			this.txtRecordId.ReadOnly = true;
			this.txtRecordId.Size = new System.Drawing.Size(100, 20);
			this.txtRecordId.TabIndex = 1;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(93, 227);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.OnSaveClick);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(12, 227);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.OnCloseClick);
			// 
			// EnterEditRecordFormBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.txtRecordId);
			this.Controls.Add(this.lblRecordId);
			this.MaximizeBox = false;
			this.Name = "EnterEditRecordFormBase";
			this.ShowInTaskbar = false;
			this.Text = "EnterEditRecordFormBase";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.Label lblRecordId;
		protected System.Windows.Forms.TextBox txtRecordId;
		protected System.Windows.Forms.Button btnSave;
		protected System.Windows.Forms.Button btnClose;

	}
}