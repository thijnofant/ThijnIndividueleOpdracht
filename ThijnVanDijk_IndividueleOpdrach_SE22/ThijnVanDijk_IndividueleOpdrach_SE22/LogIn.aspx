<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ThijnVanDijk_IndividueleOpdrach_SE22.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<asp:Label ID="Label1" runat="server" Text="UserName: "></asp:Label>
    <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
        ControlToValidate="tbUserName" ErrorMessage="Enter UserName Field"></asp:RequiredFieldValidator>
    <br />
&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" 
        ControlToValidate="tbPassword" ErrorMessage="Enter Password Field"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="btnLogIn"
        runat="server" Text="Log In" onclick="Button1_Click" />
</asp:Content>
