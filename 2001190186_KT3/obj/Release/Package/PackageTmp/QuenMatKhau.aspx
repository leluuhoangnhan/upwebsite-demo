<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="QuenMatKhau.aspx.cs" Inherits="_2001190186_KT3.QuenMatKhau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #content_UpdatePass{
            margin-top:40px;
            margin-left:30px;
        }

        .inDam{
            font-size:22px;
            font-weight:bold;
        }

        .update{
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


    </style>

    <div id="Main">
        <div id="content_UpdatePass">
            <asp:Label ID="lbl_email" runat="server" Text="Địa chỉ email(*)" CssClass="inDam" ></asp:Label><br /><br />
            <input ID="txt_email" runat="server" name="txt_email" type="text" placeholder="Địa chỉ Email" style="width:450px;" /><br /><br />

            <asp:Label ID="lbl_matKhau" runat="server" Text="Mật khẩu mới(*)" CssClass="inDam" ></asp:Label><br /><br />
            <input ID="txt_matKhau" runat="server" name="txt_matKhau" type="password" placeholder="Mật khẩu mới" style="width:450px;" /><br /><br />

            <asp:Label ID="lbl_matKhau_XN" runat="server" Text="Nhập lại mật khẩu(*)" CssClass="inDam" ></asp:Label><br /><br />
            <input ID="txt_matKhau_XN" runat="server" name="txt_matKhau_XN" type="password" placeholder="Nhập lại mật khẩu" style="width:450px;" /><br /><br />

            <asp:Button ID="btn_update" runat="server" Text="Cập nhật mật khẩu" CssClass="update" OnClick="btn_update_Click" /><br /><br />



            <asp:RegularExpressionValidator ID="check_Email" runat="server" ControlToValidate="txt_email" ErrorMessage="Email không hợp lệ!" Font-Bold="true" Font-Size="18px" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator><br /><br />
           
            <asp:RequiredFieldValidator ID="check_Email_Rong" runat="server" ControlToValidate="txt_email" ErrorMessage="Chưa nhập Email!" Font-Bold="true" Font-Size="18px" ForeColor="Red" ></asp:RequiredFieldValidator> <br /><br />
            <asp:RequiredFieldValidator ID="check_Pass_Rong" runat="server" ControlToValidate="txt_matKhau"  ErrorMessage="Chưa nhập mật khẩu!" Font-Bold="true" Font-Size="18px" ForeColor="Red" /><br /><br />
            <asp:RequiredFieldValidator ID="check_Pass_XN_Rong" runat="server" ControlToValidate="txt_matKhau_XN"  ErrorMessage="Chưa nhập mật khẩu xác nhận!" Font-Bold="true" Font-Size="18px" ForeColor="Red" /><br /><br />
            
            <asp:Label ID="lbl_thongBao_UpdatePassword" runat="server" Text="" CssClass="thongBao" ></asp:Label>
        
        </div>
    </div>
</asp:Content>
