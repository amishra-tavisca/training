<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HRAddRemarkTab.ascx.cs" Inherits="AuthenticationForm.HRAddRemarkTab" %>
<style type="text/css">
    #Reset1 {
        text-align: left;
        width: 74px;
        margin-left: 38px;
    }
    .auto-style1 {
        width: 85%;
        height: 174px;
    }
    .auto-style3 {
        width: 167px;
    }
    .auto-style5 {
        width: 153px;
        height: 56px;
        text-align: right;
    }
    .auto-style6 {
        width: 167px;
        height: 56px;
    }
    .auto-style7 {
        width: 153px;
        text-align: right;
    }
    #TextArea1 {
        height: 35px;
        width: 182px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style5">Select Employee:</td>
        <td class="auto-style6">
            <asp:DropDownList ID="DropDownEmployee" runat="server" Height="23px" Width="225px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style7">Enter Remark:</td>
        <td class="auto-style3">
            
    <asp:TextBox ID="TextBoxRemark" runat="server" Height="33px" Width="447px"></asp:TextBox></td>
    </tr>
    <tr>
       <td class="auto-style2">
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </td>
        <td class="auto-style3">
            <input id="Reset1" type="reset" value="reset" /></td>
    </tr>
</table>

