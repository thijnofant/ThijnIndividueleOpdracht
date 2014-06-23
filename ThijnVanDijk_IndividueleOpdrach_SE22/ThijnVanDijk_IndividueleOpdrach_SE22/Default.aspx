<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ThijnVanDijk_IndividueleOpdrach_SE22._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="GridView1" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Label id="lblCustomerID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VIDNAAM") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Channel">
                <ItemTemplate>
                    <asp:HyperLink ID="hypelinkchannel" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CHANNAME") %>' NavigateUrl='<%# string.Format("channel/{0}",DataBinder.Eval(Container,"DataItem.CHANNAME")) %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView> 
</asp:Content>
