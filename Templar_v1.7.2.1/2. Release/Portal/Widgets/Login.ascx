<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="WidgetDemo.Login" %>
<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>


<asp:Panel ID="Panel1" runat="server" Visible="true" Height="209px" Width="454px">
<gtc:TemplarLabel ID="LabelLogin" runat="server" Text="Login"></gtc:TemplarLabel>

<asp:Table ID="Table2" runat="server" Visible="true" Height="22px" Width="533px">
    <asp:TableRow runat="server">
        <asp:TableCell><gtc:TemplarLabel ID="LabelUserID" runat="server" Text="Enter User Id"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxUserID" runat="server" Text=""></asp:TextBox></asp:TableCell>
         <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserID" ErrorMessage="User Id field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell><gtc:TemplarLabel ID="LabelPassword" runat="server" Text="Enter Password"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxPassword" runat="server" Text="0" TextMode="Password"></asp:TextBox></asp:TableCell>
        <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Password field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
    </asp:TableRow>
   
    <asp:TableRow>
        <asp:TableCell ><gtc:TemplarCheckBox ID="CheckBoxRememberMe" runat="server" Text="Remember Me"/></asp:TableCell>
        <asp:TableCell ><gtc:TemplarButton ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click"/></asp:TableCell>      
    </asp:TableRow>
</asp:Table>
</asp:Panel>


