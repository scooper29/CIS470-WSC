namespace WSCAutomation.App
{
    partial class EnterEditInventoryForm
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
            this.txbInventoryID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(93, 186);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 186);
            // 
            // txbInventoryName
            // 
            this.txbInventoryName.Location = new System.Drawing.Point(316, 69);
            this.txbInventoryName.Name = "txbInventoryName";
            this.txbInventoryName.Size = new System.Drawing.Size(100, 20);
            this.txbInventoryName.TabIndex = 11;
            // 
            // txtManufacturerName
            // 
            this.txtManufacturerName.Location = new System.Drawing.Point(120, 123);
            this.txtManufacturerName.Name = "txtManufacturerName";
            this.txtManufacturerName.Size = new System.Drawing.Size(139, 20);
            this.txtManufacturerName.TabIndex = 10;
            // 
            // txbInventoryID
            // 
            this.txbInventoryID.Location = new System.Drawing.Point(120, 69);
            this.txbInventoryID.Name = "txbInventoryID";
            this.txbInventoryID.Size = new System.Drawing.Size(100, 20);
            this.txbInventoryID.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Manufacturer Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Inventory Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Inventory ID:";
            // 
            // EnterEditInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(462, 221);
            this.Controls.Add(this.txbInventoryName);
            this.Controls.Add(this.txtManufacturerName);
            this.Controls.Add(this.txbInventoryID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EnterEditInventoryForm";
            this.Load += new System.EventHandler(this.EnterEditInventoryForm_Load);
            this.Controls.SetChildIndex(this.lblRecordId, 0);
            this.Controls.SetChildIndex(this.txtRecordId, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txbInventoryID, 0);
            this.Controls.SetChildIndex(this.txtManufacturerName, 0);
            this.Controls.SetChildIndex(this.txbInventoryName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbInventoryName;
        private System.Windows.Forms.TextBox txtManufacturerName;
        private System.Windows.Forms.TextBox txbInventoryID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
