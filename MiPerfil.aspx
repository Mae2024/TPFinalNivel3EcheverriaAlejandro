<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPFinalNivel3EcheverríaAlejandro.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Mi Perfil</h2>

    <div class="row g-3">
        <div class="col-md-6">
            <label for="lblEmail" class="form-label">Email</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
              <asp:RequiredFieldValidator ErrorMessage="Debes completar el campo" ControlToValidate="txtNombre" runat="server" />
        </div>
        <div class="col-12">
            <label for="lblNombre" class="form-label">Nombre</label>
            <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />
            <asp:RequiredFieldValidator ErrorMessage="Debes completar el campo" ControlToValidate="txtNombre" runat="server" />
        </div>
        <div class="col-12">
            <label for="lblApellido" class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="10" />
              <asp:RequiredFieldValidator ErrorMessage="Debes completar el campo" ControlToValidate="txtNombre" runat="server" />

            <div class="mb-3">
                <label class="form-label">Ingrese Archivo de Imagen</label>
                <input class="form-control" id="txtImagen" runat="server" type="file">
            </div>
            <div class="col-6">
                <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" Text="Guardar" />
                <a href="/">Cancelar</a>
            </div>

            <div class="row">
                <div class="col-5">
                    <asp:Image ImageUrl="https://www.shutterstock.com/image-vector/vector-flat-illustration-grayscale-avatar-600nw-2281862025.jpg" ID="ImagenNueva" CssClass="img-fluid mb-3" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
