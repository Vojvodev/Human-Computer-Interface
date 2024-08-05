namespace SellingTickets
{
    partial class SellTicket
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
            txtBoxFname = new TextBox();
            lblFname = new Label();
            lblLastName = new Label();
            txtBoxLname = new TextBox();
            comboBox1 = new ComboBox();
            lblTicketType = new Label();
            txtBoxPrice = new TextBox();
            lblPrice = new Label();
            btnSell = new Button();
            SuspendLayout();
            // 
            // txtBoxFname
            // 
            txtBoxFname.Location = new Point(146, 101);
            txtBoxFname.Name = "txtBoxFname";
            txtBoxFname.Size = new Size(287, 23);
            txtBoxFname.TabIndex = 0;
            // 
            // lblFname
            // 
            lblFname.AutoSize = true;
            lblFname.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblFname.Location = new Point(12, 94);
            lblFname.Name = "lblFname";
            lblFname.Size = new Size(113, 30);
            lblFname.TabIndex = 1;
            lblFname.Text = "First Name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblLastName.Location = new Point(12, 154);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(112, 30);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Last Name";
            // 
            // txtBoxLname
            // 
            txtBoxLname.Location = new Point(146, 161);
            txtBoxLname.Name = "txtBoxLname";
            txtBoxLname.Size = new Size(287, 23);
            txtBoxLname.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "REGULAR", "VIP" });
            comboBox1.Location = new Point(557, 161);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 4;
            // 
            // lblTicketType
            // 
            lblTicketType.AutoSize = true;
            lblTicketType.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTicketType.Location = new Point(557, 101);
            lblTicketType.Name = "lblTicketType";
            lblTicketType.Size = new Size(116, 30);
            lblTicketType.TabIndex = 5;
            lblTicketType.Text = "Ticket Type";
            // 
            // txtBoxPrice
            // 
            txtBoxPrice.Location = new Point(295, 285);
            txtBoxPrice.Name = "txtBoxPrice";
            txtBoxPrice.Size = new Size(120, 23);
            txtBoxPrice.TabIndex = 6;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrice.Location = new Point(213, 278);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(58, 30);
            lblPrice.TabIndex = 7;
            lblPrice.Text = "Price";
            // 
            // btnSell
            // 
            btnSell.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnSell.Location = new Point(307, 381);
            btnSell.Name = "btnSell";
            btnSell.Size = new Size(147, 54);
            btnSell.TabIndex = 8;
            btnSell.Text = "Sell";
            btnSell.UseVisualStyleBackColor = true;
            btnSell.Click += btnSell_Click;
            // 
            // SellTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 491);
            Controls.Add(btnSell);
            Controls.Add(lblPrice);
            Controls.Add(txtBoxPrice);
            Controls.Add(lblTicketType);
            Controls.Add(comboBox1);
            Controls.Add(lblLastName);
            Controls.Add(txtBoxLname);
            Controls.Add(lblFname);
            Controls.Add(txtBoxFname);
            Name = "SellTicket";
            Text = "SellTicket";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxFname;
        private Label lblFname;
        private Label lblLastName;
        private TextBox txtBoxLname;
        private ComboBox comboBox1;
        private Label lblTicketType;
        private TextBox txtBoxPrice;
        private Label lblPrice;
        private Button btnSell;
    }
}