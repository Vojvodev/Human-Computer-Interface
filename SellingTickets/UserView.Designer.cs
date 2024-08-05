namespace SellingTickets
{
    partial class UserView
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserView));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            txtBoxBrowseEvents = new TextBox();
            dataGridView1 = new DataGridView();
            btnBrowseEvents = new Button();
            lblBrowseEvents = new Label();
            tabPage2 = new TabPage();
            dataGridView2 = new DataGridView();
            btnBrowsePerformers = new Button();
            txtBoxBrowsePerformers = new TextBox();
            lblBrowsePerformers = new Label();
            tabCategories = new TabPage();
            dataGridView3 = new DataGridView();
            btnBrowseCategories = new Button();
            txtBoxBrowseCategories = new TextBox();
            lblBrowseCategories = new Label();
            tabLogout = new TabPage();
            btnLogOut = new Button();
            label1 = new Label();
            eventsBindingSource = new BindingSource(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            tabLogout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)eventsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabCategories);
            tabControl1.Controls.Add(tabLogout);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(760, 491);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtBoxBrowseEvents);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(btnBrowseEvents);
            tabPage1.Controls.Add(lblBrowseEvents);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(752, 463);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Events";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBoxBrowseEvents
            // 
            txtBoxBrowseEvents.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxBrowseEvents.Location = new Point(178, 91);
            txtBoxBrowseEvents.Name = "txtBoxBrowseEvents";
            txtBoxBrowseEvents.Size = new Size(380, 23);
            txtBoxBrowseEvents.TabIndex = 10;
            txtBoxBrowseEvents.TextChanged += txtBoxBrowseEvents_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(3, 211);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(746, 250);
            dataGridView1.TabIndex = 5;
            // 
            // btnBrowseEvents
            // 
            btnBrowseEvents.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseEvents.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnBrowseEvents.Image = (Image)resources.GetObject("btnBrowseEvents.Image");
            btnBrowseEvents.Location = new Point(558, 90);
            btnBrowseEvents.Name = "btnBrowseEvents";
            btnBrowseEvents.Size = new Size(30, 25);
            btnBrowseEvents.TabIndex = 3;
            btnBrowseEvents.UseVisualStyleBackColor = true;
            // 
            // lblBrowseEvents
            // 
            lblBrowseEvents.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBrowseEvents.AutoSize = true;
            lblBrowseEvents.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblBrowseEvents.Location = new Point(155, 26);
            lblBrowseEvents.Name = "lblBrowseEvents";
            lblBrowseEvents.Size = new Size(437, 40);
            lblBrowseEvents.TabIndex = 0;
            lblBrowseEvents.Text = "Browse Through Events";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Controls.Add(btnBrowsePerformers);
            tabPage2.Controls.Add(txtBoxBrowsePerformers);
            tabPage2.Controls.Add(lblBrowsePerformers);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(752, 463);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Performers";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Bottom;
            dataGridView2.Location = new Point(3, 211);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(746, 250);
            dataGridView2.TabIndex = 7;
            // 
            // btnBrowsePerformers
            // 
            btnBrowsePerformers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowsePerformers.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnBrowsePerformers.Image = (Image)resources.GetObject("btnBrowsePerformers.Image");
            btnBrowsePerformers.Location = new Point(558, 90);
            btnBrowsePerformers.Name = "btnBrowsePerformers";
            btnBrowsePerformers.Size = new Size(30, 25);
            btnBrowsePerformers.TabIndex = 6;
            btnBrowsePerformers.UseVisualStyleBackColor = true;
            // 
            // txtBoxBrowsePerformers
            // 
            txtBoxBrowsePerformers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxBrowsePerformers.Location = new Point(178, 91);
            txtBoxBrowsePerformers.Name = "txtBoxBrowsePerformers";
            txtBoxBrowsePerformers.Size = new Size(380, 23);
            txtBoxBrowsePerformers.TabIndex = 4;
            txtBoxBrowsePerformers.TextChanged += txtBoxBrowsePerformers_TextChanged;
            // 
            // lblBrowsePerformers
            // 
            lblBrowsePerformers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBrowsePerformers.AutoSize = true;
            lblBrowsePerformers.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblBrowsePerformers.Location = new Point(155, 26);
            lblBrowsePerformers.Name = "lblBrowsePerformers";
            lblBrowsePerformers.Size = new Size(529, 40);
            lblBrowsePerformers.TabIndex = 3;
            lblBrowsePerformers.Text = "Browse Through Performers";
            // 
            // tabCategories
            // 
            tabCategories.Controls.Add(dataGridView3);
            tabCategories.Controls.Add(btnBrowseCategories);
            tabCategories.Controls.Add(txtBoxBrowseCategories);
            tabCategories.Controls.Add(lblBrowseCategories);
            tabCategories.Location = new Point(4, 24);
            tabCategories.Name = "tabCategories";
            tabCategories.Padding = new Padding(3);
            tabCategories.Size = new Size(752, 463);
            tabCategories.TabIndex = 2;
            tabCategories.Text = "Categories";
            tabCategories.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Dock = DockStyle.Bottom;
            dataGridView3.Location = new Point(3, 210);
            dataGridView3.MultiSelect = false;
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(746, 250);
            dataGridView3.TabIndex = 10;
            // 
            // btnBrowseCategories
            // 
            btnBrowseCategories.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseCategories.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnBrowseCategories.Image = (Image)resources.GetObject("btnBrowseCategories.Image");
            btnBrowseCategories.Location = new Point(558, 90);
            btnBrowseCategories.Name = "btnBrowseCategories";
            btnBrowseCategories.Size = new Size(30, 25);
            btnBrowseCategories.TabIndex = 9;
            btnBrowseCategories.UseVisualStyleBackColor = true;
            // 
            // txtBoxBrowseCategories
            // 
            txtBoxBrowseCategories.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxBrowseCategories.Location = new Point(178, 91);
            txtBoxBrowseCategories.Name = "txtBoxBrowseCategories";
            txtBoxBrowseCategories.Size = new Size(380, 23);
            txtBoxBrowseCategories.TabIndex = 8;
            txtBoxBrowseCategories.TextChanged += txtBoxBrowseCategories_TextChanged;
            // 
            // lblBrowseCategories
            // 
            lblBrowseCategories.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBrowseCategories.AutoSize = true;
            lblBrowseCategories.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblBrowseCategories.Location = new Point(155, 26);
            lblBrowseCategories.Name = "lblBrowseCategories";
            lblBrowseCategories.Size = new Size(513, 40);
            lblBrowseCategories.TabIndex = 7;
            lblBrowseCategories.Text = "Browse Through Categories";
            // 
            // tabLogout
            // 
            tabLogout.BorderStyle = BorderStyle.FixedSingle;
            tabLogout.Controls.Add(btnLogOut);
            tabLogout.Controls.Add(label1);
            tabLogout.Location = new Point(4, 24);
            tabLogout.Name = "tabLogout";
            tabLogout.Padding = new Padding(3);
            tabLogout.Size = new Size(752, 463);
            tabLogout.TabIndex = 3;
            tabLogout.Text = "Log Out";
            tabLogout.UseVisualStyleBackColor = true;
            // 
            // btnLogOut
            // 
            btnLogOut.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogOut.Location = new Point(319, 91);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(118, 39);
            btnLogOut.TabIndex = 1;
            btnLogOut.Text = "LOG OUT";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(115, 26);
            label1.Name = "label1";
            label1.Size = new Size(612, 40);
            label1.TabIndex = 0;
            label1.Text = "Are you sure you want to log out?";
            // 
            // eventsBindingSource
            // 
            eventsBindingSource.DataSource = typeof(Events);
            // 
            // UserView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 491);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UserView";
            Text = "Overview";
            KeyDown += UserView_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabCategories.ResumeLayout(false);
            tabCategories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            tabLogout.ResumeLayout(false);
            tabLogout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)eventsBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label lblBrowseEvents;
        private TextBox txtBoxBrowsePerformers;
        private Label lblBrowsePerformers;
        private Button btnBrowseEvents;
        private Button btnBrowsePerformers;
        private TabPage tabCategories;
        private Button btnBrowseCategories;
        private TextBox txtBoxBrowseCategories;
        private Label lblBrowseCategories;
        private TabPage tabLogout;
        private Button btnLogOut;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private BindingSource eventsBindingSource;
        private TextBox txtBoxBrowseEvents;
    }
}