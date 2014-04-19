namespace WSCAutomation.App
{
	partial class MainForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLogOutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.inventorySearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryAddNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.customersSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersAddNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersAddNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.adminSearchUsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminAddNewUserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.inventoryMenu,
            this.customersMenu,
            this.ordersMenu,
            this.adminMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(784, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "Main Menu";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileLogOutMenuItem,
            this.fileExitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // fileLogOutMenuItem
            // 
            this.fileLogOutMenuItem.Name = "fileLogOutMenuItem";
            this.fileLogOutMenuItem.Size = new System.Drawing.Size(117, 22);
            this.fileLogOutMenuItem.Text = "Log Out";
            this.fileLogOutMenuItem.Click += new System.EventHandler(this.OnFileLogOutClick);
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.Size = new System.Drawing.Size(117, 22);
            this.fileExitMenuItem.Text = "Exit";
            this.fileExitMenuItem.Click += new System.EventHandler(this.OnFileExitClick);
            // 
            // inventoryMenu
            // 
            this.inventoryMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventorySearchMenuItem,
            this.inventoryAddNewMenuItem});
            this.inventoryMenu.Name = "inventoryMenu";
            this.inventoryMenu.Size = new System.Drawing.Size(69, 20);
            this.inventoryMenu.Text = "Inventory";
            // 
            // inventorySearchMenuItem
            // 
            this.inventorySearchMenuItem.Name = "inventorySearchMenuItem";
            this.inventorySearchMenuItem.Size = new System.Drawing.Size(162, 22);
            this.inventorySearchMenuItem.Text = "Search Inventory";
            this.inventorySearchMenuItem.Click += new System.EventHandler(this.OnInventorySearchClick);
            // 
            // inventoryAddNewMenuItem
            // 
            this.inventoryAddNewMenuItem.Name = "inventoryAddNewMenuItem";
            this.inventoryAddNewMenuItem.Size = new System.Drawing.Size(162, 22);
            this.inventoryAddNewMenuItem.Text = "Add New Item";
            this.inventoryAddNewMenuItem.Click += new System.EventHandler(this.OnInventoryAddClick);
            // 
            // customersMenu
            // 
            this.customersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customersSearchMenuItem,
            this.customersAddNewMenuItem});
            this.customersMenu.Name = "customersMenu";
            this.customersMenu.Size = new System.Drawing.Size(76, 20);
            this.customersMenu.Text = "Customers";
            // 
            // customersSearchMenuItem
            // 
            this.customersSearchMenuItem.Name = "customersSearchMenuItem";
            this.customersSearchMenuItem.Size = new System.Drawing.Size(178, 22);
            this.customersSearchMenuItem.Text = "Search Customers";
            this.customersSearchMenuItem.Click += new System.EventHandler(this.OnCustomersSearchClick);
            // 
            // customersAddNewMenuItem
            // 
            this.customersAddNewMenuItem.Name = "customersAddNewMenuItem";
            this.customersAddNewMenuItem.Size = new System.Drawing.Size(178, 22);
            this.customersAddNewMenuItem.Text = "Add New Customer";
            this.customersAddNewMenuItem.Click += new System.EventHandler(this.OnCustomersAddClick);
            // 
            // ordersMenu
            // 
            this.ordersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordersSearchMenuItem,
            this.ordersAddNewMenuItem});
            this.ordersMenu.Name = "ordersMenu";
            this.ordersMenu.Size = new System.Drawing.Size(54, 20);
            this.ordersMenu.Text = "Orders";
            // 
            // ordersSearchMenuItem
            // 
            this.ordersSearchMenuItem.Name = "ordersSearchMenuItem";
            this.ordersSearchMenuItem.Size = new System.Drawing.Size(168, 22);
            this.ordersSearchMenuItem.Text = "Search Orders";
            this.ordersSearchMenuItem.Click += new System.EventHandler(this.OnOrdersSearchClick);
            // 
            // ordersAddNewMenuItem
            // 
            this.ordersAddNewMenuItem.Name = "ordersAddNewMenuItem";
            this.ordersAddNewMenuItem.Size = new System.Drawing.Size(168, 22);
            this.ordersAddNewMenuItem.Text = "Create New Order";
            this.ordersAddNewMenuItem.Click += new System.EventHandler(this.OnOrdersAddClick);
            // 
            // adminMenu
            // 
            this.adminMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminSearchUsersMenuItem,
            this.adminAddNewUserMenuItem});
            this.adminMenu.Name = "adminMenu";
            this.adminMenu.Size = new System.Drawing.Size(55, 20);
            this.adminMenu.Text = "Admin";
            // 
            // adminSearchUsersMenuItem
            // 
            this.adminSearchUsersMenuItem.Name = "adminSearchUsersMenuItem";
            this.adminSearchUsersMenuItem.Size = new System.Drawing.Size(149, 22);
            this.adminSearchUsersMenuItem.Text = "Search Users";
            this.adminSearchUsersMenuItem.Click += new System.EventHandler(this.OnAdminSearchUsersClick);
            // 
            // adminAddNewUserMenuItem
            // 
            this.adminAddNewUserMenuItem.Name = "adminAddNewUserMenuItem";
            this.adminAddNewUserMenuItem.Size = new System.Drawing.Size(149, 22);
            this.adminAddNewUserMenuItem.Text = "Add New User";
            this.adminAddNewUserMenuItem.Click += new System.EventHandler(this.OnAdminAddUserClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Williams Specialty Company";
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem fileLogOutMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem inventoryMenu;
		private System.Windows.Forms.ToolStripMenuItem inventorySearchMenuItem;
		private System.Windows.Forms.ToolStripMenuItem inventoryAddNewMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customersMenu;
		private System.Windows.Forms.ToolStripMenuItem customersSearchMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customersAddNewMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ordersMenu;
		private System.Windows.Forms.ToolStripMenuItem ordersSearchMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ordersAddNewMenuItem;
		private System.Windows.Forms.ToolStripMenuItem adminMenu;
		private System.Windows.Forms.ToolStripMenuItem adminSearchUsersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem adminAddNewUserMenuItem;
	}
}

