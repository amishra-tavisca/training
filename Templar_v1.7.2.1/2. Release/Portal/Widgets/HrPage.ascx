<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HrPage.ascx.cs" Inherits="WidgetDemo.HrPage" %>

<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>
<asp:Panel ID="Panel1" runat="server" Visible="true">

<asp:Table ID="Table2" runat="server" Visible="true" Height="157px" Width="911px">
    
    <asp:TableRow ID="TableRow2" runat="server">
        <asp:TableCell><asp:Button ID="ButtonAddRemark" runat="server" OnClick="ButtonAddRemark_Click" Text="Add Remark" Width="150px" /></asp:TableCell>    
        <asp:TableCell><asp:Button ID="ButtonChangePassword" runat="server" OnClick="ButtonChangePassword_Click" Text="Change Password" Width="150px" /></asp:TableCell>    
        <asp:TableCell><asp:Button ID="ButtonLogout" runat="server" CausesValidation="False" OnClick="ButtonLogout_Click" Text="Logout" Width="150px" /></asp:TableCell>    
    </asp:TableRow>
   
</asp:Table>
</asp:Panel>