<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChannelPage.aspx.cs" Inherits="ThijnVanDijk_IndividueleOpdrach_SE22.ChannelPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblChannelName" runat="server" Text="ChannelNam"></asp:Label>
&nbsp;<asp:Label ID="lblSub" runat="server" Text="Subscribers: 000000"></asp:Label>
    <asp:Button ID="btnSub" runat="server" onclick="btnSub_Click" 
        Text="Subscribe" style="margin-left: 120px" />
&nbsp;<br />
    <asp:Label ID="ChannelNAme" runat="server" Text="ChannelName :"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="tbChannelName" runat="server"></asp:TextBox>
    <asp:CheckBox ID="cbAdds" runat="server" 
        Text="Check for addvertisements on your videos" />
    <asp:RequiredFieldValidator ID="RequiredFieldValChannelName" runat="server" 
        ControlToValidate="tbChannelName" ErrorMessage="Please Enter A ChannelName"></asp:RequiredFieldValidator>
    <asp:Button ID="btnUpgrade" runat="server" onclick="btnUpgrade_Click" 
        Text="Upgrade Account" />
&nbsp;<br />
    <asp:Label ID="lblDiscription" runat="server" Text="Channel Discription: "></asp:Label>
    <asp:TextBox ID="tbDisc" runat="server" Width="372px"></asp:TextBox>
    &nbsp;
</asp:Content>
