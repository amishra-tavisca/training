<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserPage.ascx.cs" Inherits="WidgetDemo.UserPage" %>
<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>
<asp:Panel ID="Panel1" runat="server" Visible="true">

<asp:Table ID="Table2" runat="server" Visible="true" Height="157px" Width="911px">
    
    <asp:TableRow ID="TableRow2" runat="server">
        <asp:TableCell><gtc:TemplarLabel ID="LabelEmployeeId" runat="server" Text="Employee Id"></gtc:TemplarLabel></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="TextBoxEmployeeId" runat="server" Text=""></asp:TextBox></asp:TableCell>    
         <asp:TableCell>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</asp:TableCell>  
        <asp:TableCell><asp:Button ID="ButtonChangePassword" runat="server" OnClick="ButtonChangePassword_Click" Text="Change Password" Width="150px" /></asp:TableCell>    
        <asp:TableCell><asp:Button ID="ButtonLogout" runat="server" CausesValidation="False" OnClick="ButtonLogout_Click" Text="Logout" Width="150px" /></asp:TableCell>    
         </asp:TableRow>
    <asp:TableRow ID="TableRow3" runat="server">
         <asp:TableCell>  
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
         </asp:TableCell> 
    </asp:TableRow>
</asp:Table>
</asp:Panel>