
namespace BTCK
{
    partial class QuanLy
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quanLySanPhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLoạiHàngHóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyDonHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyNhanVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyKhachHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLySanPhamToolStripMenuItem,
            this.quảnLýLoạiHàngHóaToolStripMenuItem,
            this.quanLyDonHangToolStripMenuItem,
            this.quanLyNhanVienToolStripMenuItem,
            this.quanLyKhachHangToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(1291, 34);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quanLySanPhamToolStripMenuItem
            // 
            this.quanLySanPhamToolStripMenuItem.Name = "quanLySanPhamToolStripMenuItem";
            this.quanLySanPhamToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.quanLySanPhamToolStripMenuItem.Text = "Quản Lý Hàng Hóa";
            this.quanLySanPhamToolStripMenuItem.Click += new System.EventHandler(this.quảnLíSảnPhẩmToolStripMenuItem_Click);
            // 
            // quảnLýLoạiHàngHóaToolStripMenuItem
            // 
            this.quảnLýLoạiHàngHóaToolStripMenuItem.Name = "quảnLýLoạiHàngHóaToolStripMenuItem";
            this.quảnLýLoạiHàngHóaToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.quảnLýLoạiHàngHóaToolStripMenuItem.Text = "Quản Lý Loại Hàng Hóa";
            this.quảnLýLoạiHàngHóaToolStripMenuItem.Click += new System.EventHandler(this.quảnLýLoạiHàngHóaToolStripMenuItem_Click);
            // 
            // quanLyDonHangToolStripMenuItem
            // 
            this.quanLyDonHangToolStripMenuItem.Name = "quanLyDonHangToolStripMenuItem";
            this.quanLyDonHangToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.quanLyDonHangToolStripMenuItem.Text = "Quản Lý Đơn Hàng";
            // 
            // quanLyNhanVienToolStripMenuItem
            // 
            this.quanLyNhanVienToolStripMenuItem.Name = "quanLyNhanVienToolStripMenuItem";
            this.quanLyNhanVienToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.quanLyNhanVienToolStripMenuItem.Text = "Quản Lý Nhân Viên";
            this.quanLyNhanVienToolStripMenuItem.Click += new System.EventHandler(this.quanLyNhanVienToolStripMenuItem_Click);
            // 
            // quanLyKhachHangToolStripMenuItem
            // 
            this.quanLyKhachHangToolStripMenuItem.Name = "quanLyKhachHangToolStripMenuItem";
            this.quanLyKhachHangToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.quanLyKhachHangToolStripMenuItem.Text = "Quản Lý Khách Hàng";
            // 
            // QuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 854);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QuanLy";
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.QuanLy_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quanLySanPhamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyDonHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyNhanVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyKhachHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýLoạiHàngHóaToolStripMenuItem;
    }
}

