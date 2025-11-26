namespace TraCuuHoaDonDT
{
    partial class FTraCuuHoaDonDienTu
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
            menuStrip1 = new MenuStrip();
            menuBanRa = new ToolStripMenuItem();
            menuMuaVao = new ToolStripMenuItem();
            tableLayoutPanel1 = new TableLayoutPanel();
            pChild = new Panel();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuBanRa, menuMuaVao });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuBanRa
            // 
            menuBanRa.BackColor = SystemColors.ActiveCaption;
            menuBanRa.Name = "menuBanRa";
            menuBanRa.Size = new Size(234, 25);
            menuBanRa.Text = "Tra cứu hóa đơn điện tử bán ra";
            menuBanRa.Click += menuBanRa_Click;
            // 
            // menuMuaVao
            // 
            menuMuaVao.Name = "menuMuaVao";
            menuMuaVao.Size = new Size(250, 25);
            menuMuaVao.Text = "Tra cứu hóa đơn điện tử mua vào";
            menuMuaVao.Click += menuMuaVao_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pChild, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 29);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 2.225041F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 97.7749557F));
            tableLayoutPanel1.Size = new Size(800, 421);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // pChild
            // 
            pChild.AutoScroll = true;
            pChild.Dock = DockStyle.Fill;
            pChild.Location = new Point(3, 12);
            pChild.Name = "pChild";
            pChild.Size = new Size(794, 406);
            pChild.TabIndex = 2;
            // 
            // FTraCuuHoaDonDienTu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Name = "FTraCuuHoaDonDienTu";
            Text = "FTraCuuHoaDonDienTu";
            Load += FTraCuuHoaDonDienTu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuBanRa;
        private ToolStripMenuItem menuMuaVao;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pChild;
    }
}