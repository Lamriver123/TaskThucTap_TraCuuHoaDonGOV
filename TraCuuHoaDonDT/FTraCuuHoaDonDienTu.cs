using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraCuuHoaDonDT
{
    public partial class FTraCuuHoaDonDienTu : Form
    {
        public FTraCuuHoaDonDienTu()
        {
            InitializeComponent();
        }

        private void menuBanRa_Click(object sender, EventArgs e)
        {
            menuBanRa.BackColor = SystemColors.ActiveCaption;
            menuMuaVao.BackColor = SystemColors.Control;
            FBanRa fBanRa = new FBanRa();
            OpenChildForm(fBanRa);

        }

        private void menuMuaVao_Click(object sender, EventArgs e)
        {
            menuBanRa.BackColor = SystemColors.Control;
            menuMuaVao.BackColor = SystemColors.ActiveCaption;
            FMuaVao fMuaVao = new FMuaVao();
            OpenChildForm(fMuaVao);
        }

        private void OpenChildForm(Form childForm)
        {
            // Xóa form con cũ nếu có
            pChild.Controls.Clear();

            childForm.TopLevel = false;          // Không phải form độc lập
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;     // Full panel

            pChild.Controls.Add(childForm);
            childForm.Show();
        }

        private void FTraCuuHoaDonDienTu_Load(object sender, EventArgs e)
        {
            menuBanRa_Click(sender, e);
        }
    }
}
