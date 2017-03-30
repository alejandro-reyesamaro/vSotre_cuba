<%@ Page Title="Error" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Error_Page.aspx.cs" Inherits="Error_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="LError" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large" >Ha ocurrido un error en el proceso de navegación</asp:Label>
</asp:Content>

