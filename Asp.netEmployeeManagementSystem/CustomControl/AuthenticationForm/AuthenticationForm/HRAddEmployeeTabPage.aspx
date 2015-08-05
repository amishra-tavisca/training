<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HRAddEmployeeTabPage.aspx.cs" Inherits="AuthenticationForm.HRAddEmployee" %>

<%@ Register Src="~/HRAddEmployeeTab.ascx" TagPrefix="uc1" TagName="HRAddEmployeeTab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <div class="container">
  <ul class="nav nav-tabs">
   
    <li><a href="HRAddEmployeeTabPage.aspx">AddEmployee</a></li>
    <li><a href="HRAddRemarkPage.aspx">AddRemark</a></li>
    <li><a href="PasswordChange.aspx">Change Password</a></li>

  </ul>
    <uc1:HRAddEmployeeTab runat="server" ID="HRAddEmployeeTab" />
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" CausesValidation="False" OnClick="Button1_Click" Text="Logout" />
</asp:Content>
