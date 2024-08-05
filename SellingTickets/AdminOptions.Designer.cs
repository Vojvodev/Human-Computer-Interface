namespace SellingTickets
{
    partial class AdminOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminOptions));
            btnBrowseUsers = new Button();
            txtBoxBrowseUsers = new TextBox();
            lblBrowseUsers = new Label();
            tabControl1 = new TabControl();
            tabUsers = new TabPage();
            dataGridView1 = new DataGridView();
            tabLogout = new TabPage();
            btnLogOut = new Button();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabLogout.SuspendLayout();
            SuspendLayout();
            // 
            // btnBrowseUsers
            // 
            resources.ApplyResources(btnBrowseUsers, "btnBrowseUsers");
            btnBrowseUsers.Name = "btnBrowseUsers";
            btnBrowseUsers.UseVisualStyleBackColor = true;
            // 
            // txtBoxBrowseUsers
            // 
            resources.ApplyResources(txtBoxBrowseUsers, "txtBoxBrowseUsers");
            txtBoxBrowseUsers.Name = "txtBoxBrowseUsers";
            txtBoxBrowseUsers.TextChanged += txtBoxBrowseUsers_TextChanged;
            // 
            // lblBrowseUsers
            // 
            resources.ApplyResources(lblBrowseUsers, "lblBrowseUsers");
            lblBrowseUsers.Name = "lblBrowseUsers";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabUsers);
            tabControl1.Controls.Add(tabLogout);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // tabUsers
            // 
            tabUsers.Controls.Add(dataGridView1);
            tabUsers.Controls.Add(txtBoxBrowseUsers);
            tabUsers.Controls.Add(lblBrowseUsers);
            tabUsers.Controls.Add(btnBrowseUsers);
            resources.ApplyResources(tabUsers, "tabUsers");
            tabUsers.Name = "tabUsers";
            tabUsers.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tabLogout
            // 
            tabLogout.Controls.Add(btnLogOut);
            tabLogout.Controls.Add(label1);
            resources.ApplyResources(tabLogout, "tabLogout");
            tabLogout.Name = "tabLogout";
            tabLogout.UseVisualStyleBackColor = true;
            // 
            // btnLogOut
            // 
            resources.ApplyResources(btnLogOut, "btnLogOut");
            btnLogOut.Name = "btnLogOut";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // AdminOptions
            // 
            AcceptButton = btnBrowseUsers;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "AdminOptions";
            tabControl1.ResumeLayout(false);
            tabUsers.ResumeLayout(false);
            tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabLogout.ResumeLayout(false);
            tabLogout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnBrowseUsers;
        private TextBox txtBoxBrowseUsers;
        private Label lblBrowseUsers;
        private TabControl tabControl1;
        private TabPage tabUsers;
        private TabPage tabLogout;
        private Button btnLogOut;
        private Label label1;
        private DataGridView dataGridView1;
    }
}