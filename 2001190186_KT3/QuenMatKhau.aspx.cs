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
    public partial class QuenMatKhau : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KT3.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int kt_Password_Khop(String pass1, String pass2)
        {
            if (!pass1.Equals(pass2))
                return 0;
            return 1;
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            String email = txt_email.Value.ToString();
            String pass = txt_matKhau.Value.ToString();
            String pass_XN= txt_matKhau_XN.Value.ToString();

            if(kt_Password_Khop(pass,pass_XN)==0)
            {
                lbl_thongBao_UpdatePassword.Text = "Mật khẩu xác nhận không khớp!";
            }
            else
            {
                String sql = "SELECT * FROM [tblKhachHang] WHERE [EMAIL]=@EMAIL";
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    int kt = 0;
                    while (sdr.Read())
                    {
                        kt++;
                    }
                    sdr.Close();
                    if (kt == 0)
                    {
                        conn.Close();
                        lbl_thongBao_UpdatePassword.Text = "Tài khoản vừa yêu cầu đổi mật khẩu không tồn tại!";
                        return;
                    }
                    else
                    {
                        String sql1 = "UPDATE [tblKhachHang] SET [MATKHAU]=@PASS WHERE [EMAIL]=@EMAIL";
                        try
                        {
                            SqlCommand cmd1 = new SqlCommand(sql1, conn);
                            cmd1.Parameters.AddWithValue("@PASS", pass);
                            cmd1.Parameters.AddWithValue("@EMAIL", email);
                            cmd1.ExecuteNonQuery();

                            conn.Close();
                            lbl_thongBao_UpdatePassword.Text = "Cập nhật mật khẩu thành công!";

                        }
                        catch (Exception ex)
                        {
                            lbl_thongBao_UpdatePassword.Text = "Lỗi cập nhật mật khẩu (02)!";
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    lbl_thongBao_UpdatePassword.Text = "Lỗi cập nhật mật khẩu (01)!";
                }
            }    
        }
    }
}