namespace WSCAutomation.App
{
	partial class SearchRecordsDialogBase
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
			this.lblParameterId = new System.Windows.Forms.Label();
			this.txtParameterId = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.dgvSearchResults = new System.Windows.Forms.DataGridView();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
			this.SuspendLayout();
			// 
			// lblParameterId
			// 
			this.lblParameterId.AutoSize = true;
			this.lblParameterId.Location = new System.Drawing.Point(1, 6);
			this.lblParameterId.Name = "lblParameterId";
			this.lblParameterId.Size = new System.Drawing.Size(18, 13);
			this.lblParameterId.TabIndex = 0;
			this.lblParameterId.Text = "ID";
			// 
			// txtParameterId
			// 
			this.txtParameterId.Location = new System.Drawing.Point(85, 3);
			this.txtParameterId.Name = "txtParameterId";
			this.txtParameterId.Size = new System.Drawing.Size(100, 20);
			this.txtParameterId.TabIndex = 1;
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSearch.Location = new System.Drawing.Point(4, 80);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "&Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.OnSearchClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(85, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// dgvSearchResults
			// 
			this.dgvSearchResults.AllowUserToAddRows = false;
			this.dgvSearchResults.AllowUserToDeleteRows = false;
			this.dgvSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSearchResults.Location = new System.Drawing.Point(4, 109);
			this.dgvSearchResults.MultiSelect = false;
			this.dgvSearchResults.Name = "dgvSearchResults";
			this.dgvSearchResults.ReadOnly = true;
			this.dgvSearchResults.Size = new System.Drawing.Size(278, 150);
			this.dgvSearchResults.TabIndex = 4;
			// 
			// btnSelect
			// 
			this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSelect.Enabled = false;
			this.btnSelect.Location = new System.Drawing.Point(4, 265);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(75, 23);
			this.btnSelect.TabIndex = 5;
			this.btnSelect.Text = "&View";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.OnSelectClick);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEdit.Enabled = false;
			this.btnEdit.Location = new System.Drawing.Point(85, 265);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 6;
			this.btnEdit.Text = "&Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.OnEditClick);
			// 
			// SearchRecordsDialogBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(284, 300);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.dgvSearchResults);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.txtParameterId);
			this.Controls.Add(this.lblParameterId);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SearchRecordsDialogBase";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SearchRecordsDialogBase";
			((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.Label lblParameterId;
		protected System.Windows.Forms.TextBox txtParameterId;
		protected System.Windows.Forms.Button btnSearch;
		protected System.Windows.Forms.Button btnCancel;
		protected System.Windows.Forms.DataGridView dgvSearchResults;
		protected System.Windows.Forms.Button btnSelect;
		protected System.Windows.Forms.Button btnEdit;
	}
}