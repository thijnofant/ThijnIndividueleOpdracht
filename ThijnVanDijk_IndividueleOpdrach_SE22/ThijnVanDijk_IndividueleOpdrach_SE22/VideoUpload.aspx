<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VideoUpload.aspx.cs" Inherits="ThijnVanDijk_IndividueleOpdrach_SE22.VideoUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblConfirm" runat="server"></asp:Label>
    <br />
    <asp:FileUpload ID="fileUp" runat="server" />
<br />
&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label1" runat="server" Text="Title: "></asp:Label>
<asp:TextBox ID="tbTitle" runat="server" Width="177px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Dit is een Verplicht veld" ControlToValidate="tbTitle"></asp:RequiredFieldValidator>
    <br />
<asp:Label ID="Label2" runat="server" Text="Lenght: "></asp:Label>
<asp:TextBox ID="tbLenght" runat="server" Width="177px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Dit is een Verplicht veld" ControlToValidate="tbTitle"></asp:RequiredFieldValidator>
<br />
<asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Button" />
</asp:Content>
