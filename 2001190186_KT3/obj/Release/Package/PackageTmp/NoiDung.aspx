<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NoiDung.aspx.cs" Inherits="_2001190186_KT3.NoiDung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       .thongBao{
            font-size:24px;
            color:red;
            font-weight:bold;
        }

       .title{
            width: 930px;
            border-bottom: 5px solid #ce1212;
            margin-bottom:40px;
       }

       .lbl_title{ 
            color:red;
            font-size:26px;
            background-color:#4cff00;
            padding-right:50px;
        }

       .tenTour{
           font-size:36px;
           font-weight:bold;
           margin-bottom:8px;
           
       }

       .gia{
           font-size:26px;
           color:#ffd800;
           font-weight:bold;
           padding-bottom:15px;
       }

       .noiDung{
           font-size:20px;
           line-height:30px;
       }

       b p{
           color:red;
       }


    </style>

    <div id="Main">
        <div id="content">
            <div class="title">
                <asp:Label ID="lbl_danhMuc" runat="server" CssClass="lbl_title" Text=""></asp:Label>
            </div>

            <asp:DataList ID="dtl_noiDung" runat="server" RepeatColumns="1">
                <ItemTemplate>
                    <div class="row" style="width:960px;height:auto;margin-left:10px">
                        <div class="col-5">
                            <img id="lbl_img" src='<%#Eval("Hinh") %>' width="380" height="400" /><br /><br />
                        </div>

                        <div class="col-7">
                            <div style="border-bottom: 1px solid #b5a8a8; margin-bottom:40px;">
                                <asp:Label ID="lbl_tenTour" runat="server" CssClass="tenTour" Text='<%#Eval("TenTour") %>'></asp:Label><br /><br />
                                <asp:Label ID="lbl_gia" runat="server" CssClass="gia" Text='<%#Eval("Gia") + " đ" %>'></asp:Label><br /><br />
                            </div>

                            <div>
                                <table class="noiDung">
                                    <tr style="border-bottom: 30px solid white">
                                        <td style="border-right: 70px solid white"><asp:Label ID="lbl_NSX" runat="server" Text="Nhà sản xuất: "></asp:Label></td>
                                        <td><asp:Label ID="lbl_nhaSanXuat" runat="server" Text='<%#Eval("NSX") %>'></asp:Label></td>
                                    </tr>
                                    
                                    <tr style="border-bottom: 40px solid white">
                                        <td style="border-right: 70px solid white"><asp:Label ID="lbl_MSP" runat="server" Text="Mã sản phẩm: "></asp:Label></td>
                                        <td><asp:Label ID="lbl_maSanPha" runat="server" Text='<%#Eval("MaTour") %>'></asp:Label></td>
                                    </tr>

                                    <tr style="border-bottom: 30px solid white">
                                        <td colspan="2"><asp:Label ID="Label1" runat="server" Text='<%#Eval("MoTa") +".<br /><b><p> Tour khởi hành thứ 7 hàng tuần. <p></b>"%>'></asp:Label></td>
                                    </tr>

                                </table>
                            </div>

                        </div>

                    </div>

                </ItemTemplate>
            </asp:DataList>
            <br /> <br />

            <asp:Label ID="lbl_thongBao_ND" runat="server" Text="" CssClass="thongBao"></asp:Label>

        </div>
    </div>


</asp:Content>
