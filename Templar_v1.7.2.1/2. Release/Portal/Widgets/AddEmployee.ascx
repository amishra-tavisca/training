<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.ascx.cs" Inherits="WidgetDemo.AddEmployee" %>




<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>

<asp:Panel ID="pnlSettings" runat="server" Visible="true">
<gtc:TemplarLabel ID="LabelAddEmployee" runat="server" Text="Add Employee"></gtc:TemplarLabel>

<asp:Table ID="Table1" runat="server" Visible="true" Height="38px" Width="520px">
    <asp:TableRow>
        <asp:TableCell><gtc:TemplarLabel ID="LabelTitle" runat="server" Text="Title"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxTitle" runat="server" Text=""></asp:TextBox></asp:TableCell>
        <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxTitle" ErrorMessage="Title field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><gtc:TemplarLabel ID="LabelFirstName" runat="server" Text="First Name"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxFirstName" runat="server" Text=""></asp:TextBox></asp:TableCell>
        <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxFirstName" ErrorMessage="First Name field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell><gtc:TemplarLabel ID="LabelLastName" runat="server" Text="Last Name"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxLastName" runat="server" Text=""></asp:TextBox></asp:TableCell>
        <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxLastName" ErrorMessage="Last Name field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
     </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><gtc:TemplarLabel ID="LabelEmail" runat="server" Text="Email"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxEmail" runat="server" Text=""></asp:TextBox></asp:TableCell>
        <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Email field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell><gtc:TemplarLabel ID="LabelPhone" runat="server" Text="Phone"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxPhone" runat="server" Text=""></asp:TextBox></asp:TableCell>
        <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxPhone" ErrorMessage="Phone number field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>   
     </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell><gtc:TemplarLabel ID="LabelDesignation" runat="server" Text="Designation"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxDesignation" runat="server" Text=""></asp:TextBox></asp:TableCell>
        <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxDesignation" ErrorMessage="Designation field cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
     </asp:TableRow>
   

     <asp:TableRow>
        <asp:TableCell ><gtc:TemplarButton ID="ButtonLogin" runat="server" Text="Submit" OnClick="ButtonLogin_Click"/></asp:TableCell>      
         <asp:TableCell><asp:Button ID="ButtonLogout" runat="server" CausesValidation="False" OnClick="ButtonLogout_Click" Text="Logout" Width="150px" /></asp:TableCell>    
     </asp:TableRow>



   
</asp:Table>
</asp:Panel>