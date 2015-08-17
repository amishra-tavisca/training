<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs" Inherits="WidgetDemo.ChangePassword" %>


<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>


<asp:Panel ID="Panel1" runat="server" Visible="true">
<gtc:TemplarLabel ID="LabelChangePassword" runat="server" Text="Change Password"></gtc:TemplarLabel>

<asp:Table ID="Table2" runat="server" Visible="true" Height="116px" Width="533px">
    <asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell><gtc:TemplarLabel ID="LabelOldPassword" runat="server" Text="Enter Current Password"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxOldPassword" runat="server" Text="" TextMode="Password"></asp:TextBox></asp:TableCell>
         <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxOldPassword" ErrorMessage="Current Password field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRow2" runat="server">
        <asp:TableCell><gtc:TemplarLabel ID="LabelNewPassword" runat="server" Text="Enter New Password"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxNewPassword" runat="server" Text="" TextMode="Password"></asp:TextBox></asp:TableCell>
         <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxNewPassword" ErrorMessage="New Password field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRow3" runat="server">
        <asp:TableCell><gtc:TemplarLabel ID="LabelConfirmPassword" runat="server" Text=" Confirm New Password"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxConfirmPassword" runat="server" Text="" TextMode="Password"></asp:TextBox></asp:TableCell>
        <asp:TableCell><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxNewPassword" ControlToValidate="TextBoxConfirmPassword" ErrorMessage="Password Mismatch" ForeColor="Red"></asp:CompareValidator></asp:TableCell>
    </asp:TableRow>
   
   
    <asp:TableRow>
        <asp:TableCell ><gtc:TemplarButton ID="ButtonLogin" runat="server" Text="submit" OnClick="ButtonLogin_Click"/></asp:TableCell>  
        <%--<asp:TableCell>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</asp:TableCell>--%>  
        <asp:TableCell><asp:Button ID="ButtonLogout" runat="server" CausesValidation="False" OnClick="ButtonLogout_Click" Text="Logout" Width="150px" /></asp:TableCell>   
    </asp:TableRow>
</asp:Table>
</asp:Panel>

