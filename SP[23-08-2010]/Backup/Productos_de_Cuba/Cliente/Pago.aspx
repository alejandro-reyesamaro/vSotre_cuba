<%@ Page Title="Efectuar pago" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pago.aspx.cs" Inherits="Cliente_Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinkButton ID="LBPagar" runat="server" onclick="LBPagar_Click" >Boton Pago</asp:LinkButton>
</asp:Content>

