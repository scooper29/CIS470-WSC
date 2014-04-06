namespace WSCAutomation.App.InventoryViews
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
            this.txbInventoryName = new System.Windows.Forms.TextBox();
            this.txtManufacturerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(4, 133);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(85, 133);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(4, 318);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(85, 318);
            // 
            // txbInventoryName
            // 
            this.txbInventoryName.Location = new System.Drawing.Point(172, 53);
            this.txbInventoryName.Name = "txbInventoryName";
            this.txbInventoryName.Size = new System.Drawing.Size(100, 20);
            this.txbInventoryName.TabIndex = 19;
            // 
            // txtManufacturerName
            // 
            this.txtManufacturerName.Location = new System.Drawing.Point(172, 79);
            this.txtManufacturerName.Name = "txtManufacturerName";
            this.txtManufacturerName.Size = new System.Drawing.Size(139, 20);
            this.txtManufacturerName.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Manufacturer Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Inventory Name:";
            // 
            // SearchInventoryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(453, 353);
            this.Controls.Add(this.txbInventoryName);
            this.Controls.Add(this.txtManufacturerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "SearchInventoryDialog";
            this.Controls.SetChildIndex(this.lblParameterId, 0);
            this.Controls.SetChildIndex(this.txtParameterId, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtManufacturerName, 0);
            this.Controls.SetChildIndex(this.txbInventoryName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbInventoryName;
        private System.Windows.Forms.TextBox txtManufacturerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
