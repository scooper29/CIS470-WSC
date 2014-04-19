﻿namespace WSCAutomation.App
{
    partial class SearchInventoryDialog
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
			this.txbInventoryName = new System.Windows.Forms.TextBox();
			this.txtManufacturerName = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(1, 61);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(104, 13);
			label3.TabIndex = 16;
			label3.Text = "Manufacturer Name:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(20, 35);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(85, 13);
			label2.TabIndex = 15;
			label2.Text = "Inventory Name:";
			// 
			// txbInventoryName
			// 
			this.txbInventoryName.Location = new System.Drawing.Point(110, 32);
			this.txbInventoryName.Name = "txbInventoryName";
			this.txbInventoryName.Size = new System.Drawing.Size(100, 20);
			this.txbInventoryName.TabIndex = 19;
			// 
			// txtManufacturerName
			// 
			this.txtManufacturerName.Location = new System.Drawing.Point(110, 58);
			this.txtManufacturerName.Name = "txtManufacturerName";
			this.txtManufacturerName.Size = new System.Drawing.Size(139, 20);
			this.txtManufacturerName.TabIndex = 18;
			// 
			// SearchInventoryDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(284, 300);
			this.Controls.Add(this.txbInventoryName);
			this.Controls.Add(this.txtManufacturerName);
			this.Controls.Add(label3);
			this.Controls.Add(label2);
			this.Name = "SearchInventoryDialog";
			this.Text = "Search Inventory";
			this.Controls.SetChildIndex(this.lblParameterId, 0);
			this.Controls.SetChildIndex(this.txtParameterId, 0);
			this.Controls.SetChildIndex(this.btnSearch, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnSelect, 0);
			this.Controls.SetChildIndex(this.btnEdit, 0);
			this.Controls.SetChildIndex(label2, 0);
			this.Controls.SetChildIndex(label3, 0);
			this.Controls.SetChildIndex(this.txtManufacturerName, 0);
			this.Controls.SetChildIndex(this.txbInventoryName, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbInventoryName;
		private System.Windows.Forms.TextBox txtManufacturerName;
    }
}
