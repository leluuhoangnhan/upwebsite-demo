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
    public partial class DangKy : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KT3.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_DangKy_Click(object sender, EventArgs e)
        {
            String hoTen= txt_hoTen.Text.ToString();
            String sdt= txt_SDT.Text.ToString();
            String email = txt_Email.Text.ToString();
            String gioiTinh="";
            String soThich="";
            String matKhau= txt_MatKhau.Text.ToString();
            String matKhau_XN = txt_XacNhanMatKhau.Text.ToString();

            if (Request.Form["gioiTinh"] != null)
            {
                gioiTinh = Request.Form["gioiTinh"].ToString();
            }

            if (Request.Form["hoa"] != null)
            {
                soThich += Request.Form["hoa"].ToString() + ", ";
            }

            if (Request.Form["songNuoc"] != null)
            {
                soThich += Request.Form["songNuoc"].ToString() + ", ";
            }

            if (Request.Form["nuiRung"] != null)
            {
                soThich += Request.Form["nuiRung"].ToString() + ", ";
            }

            if (Request.Form["nuiDoi"] != null)
            {
                soThich += Request.Form["nuiDoi"].ToString() + ", ";
            }

            if (Request.Form["bien"] != null)
            {
                soThich += Request.Form["bien"].ToString() + ", ";
            }

            if (Request.Form["dongVatHoangDa"] != null)
            {
                soThich += Request.Form["dongVatHoangDa"].ToString() + ", ";
            }


            if (hoTen.Equals("") || sdt.Equals("") || email.Equals("") || gioiTinh.Equals("") || soThich.Equals("") || matKhau.Equals("") || matKhau_XN.Equals(""))
            {
                lbl_thongBao_DangKy.Text = "Không được bỏ trống các mục trên!";
            }
            else if(kt_Password_Khop(matKhau,matKhau_XN)==0)
            {
                lbl_thongBao_DangKy.Text = "Mật khẩu đăng ký không trùng khớp!";
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
                    while(sdr.Read())
                    {
                        conn.Close();
                        lbl_thongBao_DangKy.Text = "Email bạn vừa đăng ký đã tồn tại!";
                        return;
                    }
                    sdr.Close();


                    String sql1 = "INSERT INTO [tblKhachHang] ([HOTEN], [DIENTHOAI], [GIOITINH], [SOTHICH], [EMAIL], [MATKHAU]) VALUES (@HOTEN, @SDT, @GIOITINH, @SOTHICH, @EMAIL, @MATKHAU)";
                    try
                    {
                        SqlCommand cmd1 = new SqlCommand(sql1, conn);
                        cmd1.Parameters.AddWithValue("@HOTEN", hoTen);
                        cmd1.Parameters.AddWithValue("@SDT", sdt);
                        cmd1.Parameters.AddWithValue("@GIOITINH", gioiTinh);
                        cmd1.Parameters.AddWithValue("@SOTHICH", soThich);
                        cmd1.Parameters.AddWithValue("@EMAIL", email);
                        cmd1.Parameters.AddWithValue("@MATKHAU", matKhau);
                        cmd1.ExecuteNonQuery();

                        conn.Close();
                        lbl_thongBao_DangKy.Text = "Đăng ký tài khoản thành công!";
                    }
                    catch
                    {
                        lbl_thongBao_DangKy.Text = "Lỗi đăng ký tài khoản (02)!";
                    }

                    conn.Close();
                }
                catch
                {
                    lbl_thongBao_DangKy.Text = "Lỗi đăng ký tài khoản (01)!";
                }
            }
        }


        public int kt_Password_Khop(String pass1,String pass2)
        {
            if (!pass1.Equals(pass2))
                return 0;
            return 1;
        }

    }
}