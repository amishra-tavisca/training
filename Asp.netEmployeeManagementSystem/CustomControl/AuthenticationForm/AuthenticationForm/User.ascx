﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="User.ascx.cs" Inherits="CustomControl.User" %>

<asp:Panel ID="Panel1" runat="server" Height="371px" Width="406px">
    <h2 align="center">Display Remarks</h2>

    <asp:Label ID="EnterEmployeeIDLabel" runat="server" Text="Enter Employee ID"></asp:Label>
    <br />
    <input id="TextEmployeeId" type="number" style="width: 267px; height: 32px" />
    <br />
    <br />
    <input id="ButtonDisplayRemark" type="button" value="Display Remarks" style="height: 35px; width: 155px" />
    <br />
    <br />
    <textarea id="TextAreaRemarks" style="width: 399px; height: 183px"></textarea>
</asp:Panel>