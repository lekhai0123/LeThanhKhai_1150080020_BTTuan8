using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LeThanhKhai_1150080020_BTTuan8_TH3
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-DJ7K5TD;Initial Catalog=QuanLyBanSach;Integrated Security=True;Encrypt=False";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadNXBList();
        }

        private void LoadNXBList()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NhaXuatBan", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNXB.DataSource = dt;
            }
        }

        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNXB.Text = dgvNXB.Rows[e.RowIndex].Cells["MaNXB"].Value.ToString();
                txtTenNXB.Text = dgvNXB.Rows[e.RowIndex].Cells["TenNXB"].Value.ToString();
                txtDiaChi.Text = dgvNXB.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNXB.Text))
            {
                MessageBox.Show("Vui lòng chọn Nhà Xuất Bản cần cập nhật!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CapNhatThongTin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@maNXB", txtMaNXB.Text.Trim());
                cmd.Parameters.AddWithValue("@tenNXB", txtTenNXB.Text.Trim());
                cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Cập nhật thông tin thành công!");
            LoadNXBList();
        }
    }
}
