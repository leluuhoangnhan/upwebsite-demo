<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DataList.aspx.cs" Inherits="_2001190186_KT3.DataList" %>
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

       .chiTiet{
           font-size:22px;
           color:#db47eb;
           text-decoration:none;
           text-align:center;
       }

       .tenTour{
           font-size:18px;
           font-weight:bold;
           text-align:center;
       }


    </style>

    <div id="Main">
        <div id="content">
            <div class="title">
                <asp:Label ID="lbl_danhMuc" runat="server" CssClass="lbl_title" Text=""></asp:Label>
            </div>

            <asp:DataList ID="dtl_danhMuc" runat="server" RepeatColumns="3" OnItemDataBound="dtl_danhMuc_ItemDataBound">
                <ItemTemplate>
                    <div class="row mb-3">
                        <div class="col-md-4" style="margin-left:10px">
                            <img id="lbl_img" src='<%#Eval("Hinh") %>' width="300" height="200" /><br /><br />
                            <asp:Label ID="lbl_tenTour" runat="server" Text='<%#Eval("TenTour") %>' Width="300px" CssClass="tenTour"></asp:Label><br /><br />
                            <asp:Label ID="lbl_an" runat="server" Visible="false" Text='<%#Eval("MaTour") %>'></asp:Label>
                            
                            <asp:HyperLink ID="hyl_chiTiet" runat="server" CssClass="chiTiet" NavigateUrl="~/NoiDung.aspx" Text="Chi tiết" Width="300px" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <br /> <br />

            <asp:Label ID="lbl_thongBao_dtl" runat="server" Text="" CssClass="thongBao"></asp:Label>
        </div>
    </div>
</asp:Content>
