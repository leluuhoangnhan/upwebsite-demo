<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="_2001190186_KT3.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #content_dangNhap{
            margin-top:40px;
            margin-left:30px;
        }

        .inDam{
            font-size:22px;
            font-weight:bold;
        }

        .inDam_ChuVang{
            font-size:22px;
            font-weight:bold;
            color:#ffd800;
        }

        .dangNhap{
            width: 800px;
            background:#ff6a00;
            color:#ffffff;
            font-size:24px;
            font-weight:bold;
            text-align:center;
        }

        .thongBao{
            font-size:24px;
            color:red;
            font-weight:bold;
        }

        .title_ChaoMung{
            font-size:26px;
            color:red;
            font-weight:bold;
            margin-bottom:20px;
        }

        .thongTin_DangNhap{
            font-size:20px;
            color:#1b2aa3;
            margin-bottom:20px;
        }

        .btn_DangXuat{
            margin-left:100px;
            font-size:22px;
        }


    </style>

    <div id="Main">
        <div id="content_dangNhap">
             <asp:MultiView ID="mtv_login" runat="server">
                 <asp:View ID="view1" runat="server">
                    <asp:Label ID="lbl_email" runat="server" Text="Địa chỉ email(*)" CssClass="inDam" ></asp:Label><br /><br />
                    <input ID="txt_email" runat="server" name="txt_email" type="text" placeholder="Địa chỉ Email" style="width:450px;" /><br /><br />

                    <asp:Label ID="lbl_matKhau" runat="server" Text="Mật khẩu(*)" CssClass="inDam" ></asp:Label><br /><br />
                    <input ID="txt_matKhau" runat="server" name="txt_matKhau" type="password" placeholder="Mật khẩu" style="width:450px;" /><br /><br />

                    <asp:HyperLink ID="hyl_quenMatKhau"  runat="server" Text="Quên mật khẩu ?" NavigateUrl="~/QuenMatKhau.aspx" CssClass="inDam_ChuVang" ></asp:HyperLink><br /><br />

                    <asp:Button ID="btn_dangNhap" runat="server" Text="Đăng nhập" CssClass="dangNhap" OnClick="btn_dangNhap_Click" /><br /><br />

                    <asp:RegularExpressionValidator ID="check_Email" runat="server" ControlToValidate="txt_email" ErrorMessage="Email không hợp lệ!" Font-Bold="true" Font-Size="18px" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator><br /><br />
           
                    <asp:RequiredFieldValidator ID="check_Email_Rong" runat="server" ControlToValidate="txt_email" ErrorMessage="Chưa nhập Email!" Font-Bold="true" Font-Size="18px" ForeColor="Red" ></asp:RequiredFieldValidator> <br /><br />
                    <asp:RequiredFieldValidator ID="check_Pass_Rong" runat="server" ControlToValidate="txt_matKhau"  ErrorMessage="Chưa nhập mật khẩu!" Font-Bold="true" Font-Size="18px" ForeColor="Red" /><br /><br />
            
                    <asp:Label ID="lbl_thongBao_dangNhap" runat="server" Text="" CssClass="thongBao" ></asp:Label>
               </asp:View>


               <asp:View ID="view2" runat="server">
                   <asp:Label ID="lbl_chaoMung" runat="server" Text="Xin chào, chúc mừng bạn đã đăng nhập thành công!" CssClass="title_ChaoMung"></asp:Label><br /><br />
                   
                   <div style="margin-left:50px">
                       <asp:Label ID="lbl_hoTen" runat="server" Text="" CssClass="thongTin_DangNhap"></asp:Label><br /><br />
                   
                       <asp:Label ID="lbl_sdt" runat="server" Text="" CssClass="thongTin_DangNhap"></asp:Label><br /><br />

                       <asp:Label ID="lbl_gioiTinh" runat="server" Text="" CssClass="thongTin_DangNhap"></asp:Label><br /><br />
                   
                       <asp:Label ID="lbl_soThich" runat="server" Text="" CssClass="thongTin_DangNhap"></asp:Label><br /><br />

                       <asp:Label ID="lbl_email_show" runat="server" Text="" CssClass="thongTin_DangNhap"></asp:Label><br /><br />

                       <asp:Button ID="btn_dangXuat" runat="server" Text="Đăng xuất" CssClass="btn btn-danger btn_DangXuat" OnClick="btn_dangXuat_Click"></asp:Button>
                  </div>
               </asp:View>


             </asp:MultiView>
        </div>
    </div>

</asp:Content>
