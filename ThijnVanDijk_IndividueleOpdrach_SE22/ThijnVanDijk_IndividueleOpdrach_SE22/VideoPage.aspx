<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VideoPage.aspx.cs" Inherits="ThijnVanDijk_IndividueleOpdrach_SE22.VideoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
    <br />
    By:
    <asp:HyperLink ID="linkChannel" runat="server">HyperLink</asp:HyperLink>
    <br />
    <asp:Label ID="lblLenght" runat="server" Text="Label"></asp:Label>
    <br />
    Views: <asp:Label ID="lblViews" runat="server" Text="Label"></asp:Label>
    <br />
    Likes:
    <asp:Label ID="lblLike" runat="server" Text="Label"></asp:Label>
    <br />
    Dislikes:
    <asp:Label ID="lblDislike" runat="server" Text="Label"></asp:Label>
</asp:Content>
