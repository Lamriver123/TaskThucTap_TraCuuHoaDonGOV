using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraCuuHoaDonDT.Infrastructure;
using TraCuuHoaDonDT.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace TraCuuHoaDonDT
{
    public partial class FMuaVao : Form
    {

        public FMuaVao()
        {
            InitializeComponent();
            SetCbTrangThai();
            SetCbKetQua();
        }
        private bool mayTinhTien = false;
        private string state = "";
        private int totalHDD = 0;
        private int totalMT = 0;
        private void SetCbTrangThai()
        {
            List<ItemData> items = new List<ItemData>
            {
                new ItemData { DisplayText = "Tất cả", Value = "" },
                new ItemData { DisplayText = "Hóa đơn mới", Value = "1" },
                new ItemData { DisplayText = "Hóa đơn thay thế", Value = "2" },
                new ItemData { DisplayText = "Hóa đơn điều chỉnh", Value = "3" },
                new ItemData { DisplayText = "Hóa đơn đã bị thay thế", Value = "4" },
                new ItemData { DisplayText = "Hóa đơn đã bị điều chỉnh", Value = "5" },
                new ItemData { DisplayText = "Hóa đơn đã bị hủy", Value = "6" }
            };

            cbTrangThai.DataSource = items;

            cbTrangThai.DisplayMember = "DisplayText";

            cbTrangThai.ValueMember = "Value";
        }

        private void SetCbKetQua()
        {
            List<ItemData> items = new List<ItemData>
            {
                new ItemData { DisplayText = "Đã cấp mã hóa đơn", Value = "5" },
                new ItemData { DisplayText = "Cục thuế đã nhận không mã", Value = "6" },
                new ItemData { DisplayText = "Cục thuế đã nhận hóa đơn có mã khởi tạo từ máy tính tiền", Value = "8" }

            };

            cbKetQua.DataSource = items;


            cbKetQua.DisplayMember = "DisplayText";

            cbKetQua.ValueMember = "Value";
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDateTruoc = dtpNgayTruoc.Value;
                DateTime selectedDateSau = dtpNgaySau.Value;

                var client = new GdtApiClient();

                var searchModel = new InvoiceSearchModel
                {
                    sold = false,
                    mayTinhTien = this.mayTinhTien,
                    tdlapGe = selectedDateTruoc.ToString("dd/MM/yyyy"),
                    tdlapLe = selectedDateSau.ToString("dd/MM/yyyy"),
                    ttxly = cbTrangThai.SelectedValue.ToString(),
                    mst = txtMSTNguoiMua.Text,
                    shdon = txtSHDon.Text,
                    nmcccd = txtCCCD.Text,
                };

                pTable.Hide();
                var result = await client.GetInvoicesPagingAsync(searchModel, state);
                state = result.state;

                if (!mayTinhTien)
                {
                    dgvHoaDonDienTu.DataSource = result.datas;
                    totalHDD = result.total;

                }
                else
                {
                    dgvMayTinhTien.DataSource = result.datas;
                    totalMT = result.total;

                }
                lblTotal.Text = $"Tổng số hóa đơn: {result.total}";
                pTable.Show();
                btnXuatFile.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void btnHDDT_Click(object sender, EventArgs e)
        {
            mayTinhTien = false;
            btnHDDT.BackColor = System.Drawing.Color.Chocolate;
            btnMayTinhTien.BackColor = SystemColors.Control;
            dgvMayTinhTien.Hide();
            dgvHoaDonDienTu.Show();
            dgvHoaDonDienTu.Dock = DockStyle.Fill;
            lblTotal.Text = "Tổng số hóa đơn: " + totalHDD.ToString();
            btnXuatFile.Enabled = false;
        }

        private void btnMayTinhTien_Click(object sender, EventArgs e)
        {
            mayTinhTien = true;
            btnMayTinhTien.BackColor = System.Drawing.Color.Chocolate;
            btnHDDT.BackColor = SystemColors.Control;
            dgvHoaDonDienTu.Hide();

            dgvMayTinhTien.Show();
            dgvMayTinhTien.Dock = DockStyle.Fill;
            lblTotal.Text = "Tổng số hóa đơn: " + totalMT.ToString();
            btnXuatFile.Enabled = false;
        }

        private void FMuaVao_Load(object sender, EventArgs e)
        {
            btnHDDT_Click(sender, e);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnXuatFile.Enabled = true;
            }
        }

        private async void btnXuatFile_Click(object sender, EventArgs e)
        {
            var client = new GdtApiClient();
            try
            {
                var row = mayTinhTien
                    ? dgvMayTinhTien.CurrentRow.DataBoundItem as InvoiceItemModel
                    : dgvHoaDonDienTu.CurrentRow.DataBoundItem as InvoiceItemModel;

                if (row == null)
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn.");
                    return;
                }

                var bytes = await client.ExportInvoiceXmlAsync(
                    mayTinhTien,
                    row.nbmst,
                    row.khhdon,
                    row.shdon.ToString(),
                    row.khmshdon.ToString()
                );
                if( bytes != null)
                {
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Title = "Chọn vị trí lưu";
                        sfd.Filter = "ZIP Archive (*.zip)|*.zip";
                        sfd.FileName = $"HD_{row.shdon}.zip";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            System.IO.File.WriteAllBytes(sfd.FileName, bytes);
                            MessageBox.Show($"Đã lưu file thành công:\n{sfd.FileName}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Yêu cầu thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Xuất File");
            }
        }
    }
}
