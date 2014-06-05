<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ThijnVanDijk_IndividueleOpdrach_SE22._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="GridView1" runat="server">
        <Columns>  
                <asp:BoundField DataField="CHANNELID" HeaderText="CustomCHANNELID" ReadOnly="True"   
                    SortExpression="CHANNELID" />
        </Columns>
    </asp:GridView>
</asp:Content>
