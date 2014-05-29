<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="ThijnVanDijk_IndividueleOpdrach_SE22.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblUserName" runat="server" Text="UserName :"></asp:Label>
&nbsp;<asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
    ControlToValidate="tbUserName" ErrorMessage="UserName may not be empty"></asp:RequiredFieldValidator>
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label>
&nbsp;
<asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
    ControlToValidate="tbPassword" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
<br />
<asp:Label ID="Label3" runat="server" Text="Confirm Password :"></asp:Label>
&nbsp;<asp:TextBox ID="tbPasswordConfirm" runat="server"></asp:TextBox>
<asp:CompareValidator ID="CompareValidator1" runat="server" 
    ControlToCompare="tbPassword" ControlToValidate="tbPasswordConfirm" 
    ErrorMessage="Password has to match"></asp:CompareValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
    ControlToValidate="tbPasswordConfirm" ErrorMessage="Please Repeat Password"></asp:RequiredFieldValidator>
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnNewAccount" runat="server" onclick="btnNewAccount_Click" 
    Text="Make New Account" Width="133px" />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
</asp:Content>
