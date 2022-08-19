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
    public partial class DangNhap : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KT3.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                mtv_login.ActiveViewIndex = 0;
            }    
            
        }

        protected void btn_dangNhap_Click(object sender, EventArgs e)
        {
            String email = txt_email.Value.ToString();
            String pass = txt_matKhau.Value.ToString();

            String sql = "SELECT * FROM [tblKhachHang] WHERE [EMAIL]=@EMAIL";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@EMAIL", email);
                SqlDataReader sdr = cmd.ExecuteReader();
                int kt = 0;
                while(sdr.Read())
                {
                    kt++;
                }
                sdr.Close();
                if(kt==0)
                {
                    conn.Close();
                    lbl_thongBao_dangNhap.Text = "Tài khoản vừa đăng nhập không tồn tại!";
                    return;
                }    
                else
                {
                    String sql1 = "SELECT * FROM [tblKhachHang] WHERE [EMAIL]=@EMAIL AND [MATKHAU]=@PASS";
                    try
                    {
                        SqlCommand cmd1 = new SqlCommand(sql1, conn);
                        cmd1.Parameters.AddWithValue("@EMAIL", email);
                        cmd1.Parameters.AddWithValue("@PASS", pass);
                        SqlDataReader sdr1 = cmd1.ExecuteReader();
                        while (sdr1.Read())
                        {
                            conn.Close();
                            thongBaoDangNhapThanhCong(email);

                            return;
                        }
                        sdr1.Close();
                        conn.Close();
                        lbl_thongBao_dangNhap.Text = "Mật khẩu không chính xác!";

                    }
                    catch(Exception ex)
                    {
                        lbl_thongBao_dangNhap.Text = "Lỗi đăng nhập (02)!";
                        conn.Close();
                    }
                }    
            }
            catch (Exception ex)
            {
                lbl_thongBao_dangNhap.Text = "Lỗi đăng nhập (01)!";
            }
        }

        public void thongBaoDangNhapThanhCong(string email)
        {
            txt_email.Value = txt_matKhau.Value = string.Empty;

            mtv_login.ActiveViewIndex = 1;
            String sql = "SELECT [HOTEN], [GIOITINH], [SOTHICH], [DIENTHOAI], [EMAIL] FROM [tblKhachHang] WHERE [EMAIL]=@EMAIL";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@EMAIL", email);
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    lbl_hoTen.Text = "Họ tên: " + sdr.GetString(0);
                    lbl_gioiTinh.Text = "Giới tính: " + sdr.GetString(1);
                    lbl_soThich.Text = "Sở thích: " + sdr.GetString(2);
                    lbl_sdt.Text = "Số điện thoại: " + sdr.GetString(3);
                    lbl_email_show.Text = "Email: " + sdr.GetString(4);
                }    
                conn.Close();
            }
            catch(Exception ex)
            {}

        }

        protected void btn_dangXuat_Click(object sender, EventArgs e)
        {
            mtv_login.ActiveViewIndex = 0;
            lbl_thongBao_dangNhap.Text = "Đăng xuất thành công!";
        }
    }
}