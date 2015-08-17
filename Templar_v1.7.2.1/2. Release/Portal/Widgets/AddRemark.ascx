<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddRemark.ascx.cs" Inherits="WidgetDemo.AddRemark" %>


<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>


<asp:Panel ID="Panel1" runat="server" Visible="true">
<gtc:TemplarLabel ID="LabelAddRemark" runat="server" Text="Add Remark"></gtc:TemplarLabel>

<asp:Table ID="Table2" runat="server" Visible="true" Height="116px" Width="533px">
    <asp:TableRow ID="TableRow2" runat="server">
        <asp:TableCell><gtc:TemplarLabel ID="LabelSelectEmployee" runat="server" Text="Select Employee"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:DropDownList ID="DropDownEmployee" runat="server" Height="23px" Width="225px"></asp:DropDownList></asp:TableCell>
    </asp:TableRow>   
    <asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell><gtc:TemplarLabel ID="LabelRemark" runat="server" Text="Enter Remark"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxRemark" runat="server" Text="" ></asp:TextBox></asp:TableCell>
        <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxRemark" ErrorMessage="Remark field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
    </asp:TableRow>   
    <asp:TableRow>
        <asp:TableCell ><gtc:TemplarButton ID="ButtonSubmit" runat="server" Text="submit" OnClick="ButtonSubmit_Click"/></asp:TableCell>  
        <asp:TableCell><asp:Button ID="ButtonLogout" runat="server" CausesValidation="False" OnClick="ButtonLogout_Click" Text="Logout" Width="150px" /></asp:TableCell>   
    </asp:TableRow>
</asp:Table>
</asp:Panel>