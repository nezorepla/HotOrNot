<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="hon.aspx.cs" Inherits="hon" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .chl_img
        {
            /*      padding: 20px;*/
            height: 110%;
            width: 110%;
            max-height: 200px;
            max-width: 200px;
            cursor: pointer;
        }
        .ana
        {
            padding: 50px;
        }
    </style>

    <script type="text/javascript">


        $(document).ready(function() {
 

        });
        //dom ready bitti
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">New Challenge</asp:LinkButton>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Toplar" runat="server" Text="Label"></asp:Label>
   <span style="display:none"> <asp:TextBox ID="TextBox1"        runat="server"></asp:TextBox>  </span> 
 
 
 
</asp:Content>
