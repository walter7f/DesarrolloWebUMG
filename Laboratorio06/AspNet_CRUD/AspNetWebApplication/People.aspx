<%@ Page Title="Lista de personas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="People.aspx.cs" Inherits="AspNetWebApplication.People" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Panel ID="pnlPersonList" runat="server" Visible="true">
        <h2>Lista de personas</h2>
        <asp:Button ID="btnAddPerson" runat="server" class="btn btn-primary" Text="Nueva Persona" OnClick="btnAddPerson_Click" />
        <asp:GridView ID="GridView1" runat="server" class="table table-hover table-primary"
            AutoGenerateColumns="False" DataKeyNames="PersonId_G5"
            OnRowEditing="GridView1_RowEditing"
            OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="PersonId_G5" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="Code" HeaderText="Código" />
                <asp:BoundField DataField="FirstName" HeaderText="Nombre" />
                <asp:BoundField DataField="LastName" HeaderText="Apellido" />
                <asp:BoundField DataField="Sede" HeaderText="Teléfono" />
                <asp:BoundField DataField="Plan" HeaderText="Dirección" />
                <asp:BoundField DataField="Centro_Educativo" HeaderText="Tipo de Sangre" />
                <asp:BoundField DataField="CreationDate" HeaderText="Fecha de Creación" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:CommandField ShowEditButton="True" ControlStyle-Width="55px" />
                <asp:CommandField ShowDeleteButton="True" ControlStyle-Width="55px" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <!-- Formulario para crear o editar persona -->
    <asp:Panel ID="pnlPerson" runat="server" Visible="false">
        <h2>Crear/Actualizar Persona</h2>
        <asp:TextBox ID="txtId" runat="server" Visible="false" Text="0"></asp:TextBox><br />
        <asp:TextBox ID="txtCode" runat="server" placeholder="Código"></asp:TextBox><br />
        <asp:TextBox ID="txtFirstName" runat="server" placeholder="Nombre"></asp:TextBox><br />
        <asp:TextBox ID="txtLastName" runat="server" placeholder="Apellido"></asp:TextBox><br />
        <asp:TextBox ID="txtPhone" runat="server" placeholder="Teléfono"></asp:TextBox><br />
        <asp:TextBox ID="txtAddress" runat="server" placeholder="Dirección"></asp:TextBox><br />
        <asp:TextBox ID="txtBloodType" runat="server" placeholder="Tipo de Sangre"></asp:TextBox><br />
        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger" OnClick="btnCancel_Click" />
    </asp:Panel>
</asp:Content>
