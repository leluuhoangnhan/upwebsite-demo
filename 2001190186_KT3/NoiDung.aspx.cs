using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace _2001190186_KT3
{
    public partial class NoiDung : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KT3.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            String maTour = layMaTour();
            if (maTour.Equals(""))
            {
                lbl_thongBao_ND.Text = "Mã Tour liên kết rỗng. =>>> Vui lòng running lại từ trang 'TrangChu.aspx'!";
            }
            else
            {
                String id = layID_DanhMuc(maTour);
                if(id.Equals(""))
                {
                    lbl_thongBao_ND.Text = "Lỗi lấy id (03)!";
                    return;
                }    

                String sql1 = "SELECT [TenDM] FROM [tblDanhMuc] WHERE [MaDM]=@MADM";
                try
                {
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    cmd1.Parameters.AddWithValue("@MADM", id);
                    SqlDataReader sdr1 = cmd1.ExecuteReader();
                    while (sdr1.Read())
                    {
                        lbl_danhMuc.Text = sdr1.GetString(0);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    lbl_thongBao_ND.Text = "Đọc dữ liệu TIÊU ĐỀ bị lỗi (03)!";
                }


                String sql = "SELECT [Hinh], [TenTour], [MaTour], [Gia], [NSX], [MoTa] FROM [tblTour] WHERE [MaTour]=@MATOUR";
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MATOUR", maTour);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dtl_noiDung.DataSource = ds;
                    dtl_noiDung.DataBind();

                    conn.Close();

                }
                catch (Exception ex)
                {
                    lbl_thongBao_ND.Text = "Đọc dữ liệu từ CSDL lên bị lỗi (02)!";
                }
            }
        }

        public string layMaTour()
        {
            string url = HttpContext.Current.Request.RawUrl.ToString();
            string[] maTour = url.Split(new char[] { '=' });

            if (maTour[0].Equals(url))
            {
                return "";
            }
            return maTour[1];
        }

        public string layID_DanhMuc(string maTour)
        {
            String id = "";
            if (maTour.Equals(""))
            {
                lbl_thongBao_ND.Text = "Tham số mã tour truyền vào bị rỗng (02)!";
                return id;
            }
            
            String sql = "SELECT [idDM] FROM [tblTour] WHERE [MaTour]=@MATOUR";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MATOUR", maTour);
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    id = sdr.GetString(0);
                }
                conn.Close();
                return id;
            }
            catch(Exception ex)
            {
                lbl_thongBao_ND.Text = "Lỗi lấy id danh mục (01)!";
                return id;
            }
        }

    }
}