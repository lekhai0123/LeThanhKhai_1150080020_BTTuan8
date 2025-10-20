using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LeThanhKhai_1150080020_BTTuan8
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-DJ7K5TD;Initial Catalog=QuanLyBanSach;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadNXB();
        }

        private void LoadNXB()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("HienThiNXB", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvNXB.DataSource = dt;
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadNXB();
        }
    }
}
