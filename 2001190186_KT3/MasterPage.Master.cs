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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KT3.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayData_Grv_Menu();
        }


        //GridView Menu
        private void DisplayData_Grv_Menu()
        {
            conn.Open();
            String sql = "SELECT [MaDM], [TenDM] FROM [tblDanhMuc]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grv_Menu.DataSource = ds;
                grv_Menu.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                grv_Menu.DataSource = ds;
                grv_Menu.DataBind();
                int columnCount = grv_Menu.Rows[0].Cells.Count;
                grv_Menu.Rows[0].Cells.Clear();
                grv_Menu.Rows[0].Cells.Add(new TableCell());
                grv_Menu.Rows[0].Cells[0].ColumnSpan = columnCount;
                grv_Menu.Rows[0].Cells[0].Text = "không có dữ liệu";
            }

        }

        protected void grv_Menu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (Label)e.Row.FindControl("lbl_danhMuc");
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null && lbl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string maDM = drv["MaDM"].ToString();

                    hl.NavigateUrl = "~/DataList.aspx?id=" + maDM;

                }
            }
        }





    }
}