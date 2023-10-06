<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TablaMultiplicar.aspx.cs" Inherits="AspNetWebApplication.TablaMultiplicar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="text-align:center;text-align:-webkit-center">
        <!-- Se crea un formulario -->
        <p style="padding-top:14px">
            <!-- Se crea una lista desplegable con los números del 1 al 10 -->
            Seleccione una opción:
            <asp:DropDownList ID="tabNumber" runat="server" class="form-control"></asp:DropDownList>
            <br />
            <!-- Botón para enviar el formulario -->
            <asp:Button ID="submitTabla" runat="server" Text="Ver Tabla" class="btn btn-primary" OnClick="submitTabla_Click" />
        </p>

        
        <br /><br />
        <div id="tablaResultado" runat="server"></div>
    </div>

</asp:Content>
