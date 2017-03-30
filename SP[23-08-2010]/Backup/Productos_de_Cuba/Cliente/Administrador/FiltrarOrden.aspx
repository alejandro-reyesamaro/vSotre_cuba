<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FiltrarOrden.aspx.cs" Inherits="Cliente_Administrador_FiltrarOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../App_Themes/Store/FormStyleSheet.css" rel="stylesheet" type="text/css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container_form">
    <div class="row"> 
        <div class="column_left_form"> 
            No. Orden: 
         </div>
         <div class="column_rigth_form">
            <asp:TextBox ID="TBNoOrden" runat="server" />
         </div>
    </div>
    <div class="row"> 
        <div class="column_left_form">
            Login del cliente: 
        </div>    
        <div class="column_rigth_form"> 
            <asp:TextBox ID="TBLogin" runat="server" />
        </div>
    </div>
    <div class="row"> 
        <div class="column_left_form">
            Estado de la Orden:
        </div>
        <div class="column_rigth_form">     
            <asp:DropDownList ID="DDLEstado" runat="server" />
        </div>
    </div>
    <div class="row"> 
        <div class="column_left_form">
            <asp:CheckBox ID="ChBFechaDespues" runat="server" AutoPostBack="True" Text="Después de:" oncheckedchanged="ChBFechaDespues_CheckedChanged" /> 
        </div>
        <div class="column_rigth_form">
            <asp:DropDownList ID="DDLFechaDDia" runat="server" Enabled="False" >
                <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
            </asp:DropDownList>
            de <asp:DropDownList ID="DDLFechaDMes" runat="server" Enabled="False" >
                <asp:ListItem Value="1">Enero</asp:ListItem>
                <asp:ListItem Value="2">Febrero</asp:ListItem>
                <asp:ListItem Value="3">Marzo</asp:ListItem>
                <asp:ListItem Value="4">Abril</asp:ListItem>
                <asp:ListItem Value="5">Mayo</asp:ListItem>
                <asp:ListItem Value="6">Junio</asp:ListItem>
                <asp:ListItem Value="7">Julio</asp:ListItem>
                <asp:ListItem Value="8">Agosto</asp:ListItem>
                <asp:ListItem Value="9">Septiembre</asp:ListItem>
                <asp:ListItem Value="10">Octubre</asp:ListItem>
                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                <asp:ListItem Value="12">Diciembre</asp:ListItem>
            </asp:DropDownList>
            del <asp:DropDownList ID="DDLFechaDAnno" runat="server" Enabled="False" />
        </div>
    </div>
    <div class="row"> 
        <div class="column_left_form">    
            <asp:CheckBox ID="ChBFechaAntes" runat="server" AutoPostBack="True" Text="Antes de:" oncheckedchanged="ChbFechaAntes_CheckedChanged" />
        </div>
        <div class="column_rigth_form">
             <asp:DropDownList ID="DDLFechaADia" runat="server" Enabled="False" >
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>21</asp:ListItem>
        <asp:ListItem>22</asp:ListItem>
        <asp:ListItem>23</asp:ListItem>
        <asp:ListItem>24</asp:ListItem>
        <asp:ListItem>25</asp:ListItem>
        <asp:ListItem>26</asp:ListItem>
        <asp:ListItem>27</asp:ListItem>
        <asp:ListItem>28</asp:ListItem>
        <asp:ListItem>29</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>31</asp:ListItem>
        </asp:DropDownList>
                de <asp:DropDownList ID="DDLFechaAMes" runat="server" Enabled="False" >
                    <asp:ListItem Value="1">Enero</asp:ListItem>
                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                    <asp:ListItem Value="4">Abril</asp:ListItem>
                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                    <asp:ListItem Value="6">Junio</asp:ListItem>
                    <asp:ListItem Value="7">Julio</asp:ListItem>
                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList>
                del <asp:DropDownList ID="DDLFechaAAnno" runat="server" Enabled="False" />
        </div>
    </div>
    <div class="row"> 
        <div class="column_left_form"></div>
        <div class="column_rigth_form">
            <asp:LinkButton ID="TextBox1" runat="server" OnClick="Filtrar_onClick">Filtrar</asp:LinkButton>
        </div>
    </div>
</div>
</asp:Content>

