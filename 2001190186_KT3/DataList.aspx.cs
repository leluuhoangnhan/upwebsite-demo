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
    public partial class DataList : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KT3.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            String maDM = layMaDM();
            if (maDM.Equals(""))
            {
                maDM = "DM003";
            }

                String sql1 = "SELECT DISTINCT [TenDM] FROM [tblDanhMuc] WHERE [MaDM]=@MADM";
                try
                {
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    cmd1.Parameters.AddWithValue("@MADM", maDM);
                    SqlDataReader sdr1 = cmd1.ExecuteReader();
                    while(sdr1.Read())
                    {
                        lbl_danhMuc.Text = sdr1.GetString(0);
                    }   

                    conn.Close();
                }
                catch(Exception ex)
                {
                    lbl_thongBao_dtl.Text = "Đọc dữ liệu TIÊU ĐỀ bị lỗi (02)!";
                }


                String sql = "SELECT [HINH], [TenTour], [MaTour] FROM [tblTour] WHERE [idDM]=@MADM";
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MADM", maDM);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dtl_danhMuc.DataSource = ds;
                    dtl_danhMuc.DataBind();

                    conn.Close();

                }
                catch (Exception ex)
                {
                    lbl_thongBao_dtl.Text = "Đọc dữ liệu datalist bị lỗi (01)!";
                }
            
        }

        public string layMaDM()
        {
            string url = HttpContext.Current.Request.RawUrl.ToString();
            string[] maDM = url.Split(new char[] { '=' });

            if (maDM[0].Equals(url))
            {
                return "";
            }
            return maDM[1];
        }

        protected void dtl_danhMuc_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lbl_an");
            HyperLink hl = (HyperLink)e.Item.FindControl("hyl_chiTiet");
            if (hl != null && lbl != null)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                string maTour = drv["MaTour"].ToString();

                hl.NavigateUrl = "~/NoiDung.aspx?id=" + maTour;

            }
        }



    }
}