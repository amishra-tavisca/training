﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HRPage.aspx.cs" Inherits="AuthenticationForm.WebForm1" %>
<%@ Register Src="~/HRAddEmployeeTab.ascx" TagPrefix="uc1" TagName="HRAddEmployeeTab" %>
<%@ Register src="HRAddRemarkTab.ascx" tagname="HRAddRemarkTab" tagprefix="uc2" %> 
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
         
<div class="container">
  <ul class="nav nav-tabs">
   
      <li><a href="HRAddEmployeeTabPage.aspx">AddEmployee</a></li>
    <li><a href="HRAddRemarkPage.aspx">AddRemark</a></li>
      <li><a href="PasswordChange.aspx">Change Password</a></li>
      <li><asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Logout" /></li>
    

  </ul>

</div>
</asp:Content>


