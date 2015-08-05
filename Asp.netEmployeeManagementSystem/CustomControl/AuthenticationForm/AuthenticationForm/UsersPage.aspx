<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersPage.aspx.cs" Inherits="AuthenticationForm.Userspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 730px;
        }
        .auto-style3 {
            text-align: right;
        }
        .auto-style4 {
            width: 730px;
            height: 28px;
        }
        .auto-style5 {
            text-align: right;
            height: 28px;
        }
        .auto-style6 {
            width: 730px;
            height: 5px;
        }
        .auto-style7 {
            text-align: right;
            height: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Employee Id"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Button ID="ButtonChangePassword" runat="server" OnClick="ButtonChangePassword_Click" Text="Change Password" Width="150px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:TextBox ID="EmployeeIdBox" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style5">
                </td>
        </tr>
        <tr>
            <td class="auto-style6">
            </td>
            <td class="auto-style7">
                </td>
        </tr>
        <tr>
            <td class="auto-style2">


                <asp:gridview ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="4" PageSize="2"    
        ForeColor="#333333" GridLines="None" Width="633px" AllowPaging="True"    
        OnPageIndexChanging="grdData_PageIndexChanging" Height="86px">    
        <alternatingrowstyle BackColor="White" ForeColor="#284775"></alternatingrowstyle>    
          <columns>    
             <asp:boundfield DataField="Timestamp" HeaderText="Timestamp"></asp:boundfield>    
             <asp:boundfield DataField="Text" HeaderText="Text"></asp:boundfield>    
          </columns>    
           <editrowstyle BackColor="#999999"></editrowstyle>    
           <footerstyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></footerstyle>    
           <headerstyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></headerstyle>    
           <pagerstyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></pagerstyle>    
           <rowstyle BackColor="#F7F6F3" ForeColor="#333333"></rowstyle>    
           <selectedrowstyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></selectedrowstyle>    
           <sortedascendingcellstyle BackColor="#E9E7E2"></sortedascendingcellstyle>    
           <sortedascendingheaderstyle BackColor="#506C8C"></sortedascendingheaderstyle>    
           <sorteddescendingcellstyle BackColor="#FFFDF8"></sorteddescendingcellstyle>    
           <sorteddescendingheaderstyle BackColor="#6F8DAE"></sorteddescendingheaderstyle>    
</asp:gridview>    
                <br />
                <br />
            </td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
</asp:Content>
