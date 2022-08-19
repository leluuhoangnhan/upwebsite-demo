<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="_2001190186_KT3.DangKy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .Main{
            width:975px;
            font-size:18px;

        }

        #dangKy{
            float:left;
        }

        .lbl_DangKy_class{
            width: 900px;
            background:#ff6a00;
            color:#ff0000;
            font-size:26px;
            font-weight:bold;
            text-align:center;
        }

        .lbl_title{
            width: 900px;
            background:#ffd800;
            color:#000000;
            font-size:24px;
        }

        .thongBao{
            font-size:24px;
            color:red;
            font-weight:bold;
        }

    </style>
    
    <div id="Main">
        <div id="dangKy">
            <div class="lbl_DangKy_class">
                <asp:Label ID="lbl_dangKy" runat="server" Text="ĐĂNG KÝ"></asp:Label>
            </div>

            <div id="thongTinCaNhan">
                <div class="lbl_title">
                    <asp:Label ID="lbl_thongTinCaNhan" runat="server" Text="THÔNG TIN CÁ NHÂN"></asp:Label>
                </div>

                <table border="0">
                    <tr style="border-bottom: 20px solid white;border-top: 10px solid white">
                        <td style="padding-right:150px"><asp:Label ID="lbl_hoTeb" runat="server" Text="Họ tên"></asp:Label></td>
                        <td><asp:TextBox ID="txt_hoTen" runat="server" Width="350"></asp:TextBox></td>
                    </tr>

                    <tr style="border-bottom: 20px solid white">
                        <td><asp:Label ID="lbl_SDT" runat="server" Text="Số điện thoại"></asp:Label></td>
                        <td><asp:TextBox ID="txt_SDT" runat="server" Width="320" TextMode="Phone"></asp:TextBox></td>
                    </tr>

                    <tr style="border-bottom: 20px solid white">
                        <td><asp:Label ID="lbl_gioiTinh" runat="server" Text="Giới tính"></asp:Label></td>
                        <td>
                            <input type="radio" name="gioiTinh" value="Nam" />Nam
                            <input type="radio" name="gioiTinh" value="Nữ" style="margin-left:100px" />Nữ
                        </td>
                    </tr>

                   <tr style="border-bottom: 20px solid white">
                        <td><asp:Label ID="lbl_soThich" runat="server" Text="Sở thích"></asp:Label></td>
                        <td>
                            <input type="checkbox" name="hoa" value="Hoa" />Hoa
                            <input type="checkbox" name="songNuoc" value="Sông Nước" style="margin-left:100px" />Sông nước <br />
                            <input type="checkbox" name="nuiRung" value="Núi rừng" />Núi rừng
                            <input type="checkbox" name="nuiDoi" value="Núi đồi" style="margin-left:68px" />Núi đồi <br />
                            <input type="checkbox" name="bien" value="Biển" />Biển
                            <input type="checkbox" name="dongVatHoangDa" value="Động vật hoang dã" style="margin-left:100px" />Động vật hoang dã
                        </td>
                    </tr>

                </table>
            </div>




            <div id="thongTinDangNhap">
                <div class="lbl_title">
                    <asp:Label ID="Label1" runat="server" Text="THÔNG TIN ĐĂNG NHẬP"></asp:Label>
                </div>

                <table border="0">
                    <tr style="border-bottom: 20px solid white;border-top: 10px solid white">
                        <td style="padding-right:115px"><asp:Label ID="lbl_Email" runat="server" Text="Địa chỉ email"></asp:Label></td>
                        <td><asp:TextBox ID="txt_Email" runat="server" Width="450" TextMode="Email"></asp:TextBox></td>
                    </tr>
                    <tr style="border-bottom: 20px solid white">
                        <td><asp:Label ID="lbl_MatKhau" runat="server" Text="Mật khẩu"></asp:Label></td>
                        <td><asp:TextBox ID="txt_MatKhau" runat="server" Width="320" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr style="border-bottom: 20px solid white">
                        <td><asp:Label ID="lbl_XacNhanMatKhau" runat="server" Text="Nhập lại mật khẩu"></asp:Label></td>
                        <td><asp:TextBox ID="txt_XacNhanMatKhau" runat="server" Width="320" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr style="border-bottom: 20px solid white">
                        <td colspan="2" style="text-align:center"><asp:Button ID="btn_DangKy" runat="server" Text="Đăng ký" CssClass="btn btn-warning" OnClick="btn_DangKy_Click"/><td>
                    </tr>
                </table>
            </div>
            <br /><br />

            <asp:RegularExpressionValidator ID="check_Email" runat="server" ControlToValidate="txt_Email" ErrorMessage="Email không hợp lệ!" Font-Bold="true" Font-Size="18px" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator><br /><br />
            <asp:Label ID="lbl_thongBao_DangKy" runat="server" Text="" CssClass="thongBao"></asp:Label>


        </div>
    </div>

</asp:Content>
