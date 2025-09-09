<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CatalogoForm.aspx.cs" Inherits="TPFinalNivel3EcheverríaAlejandro.CatalogoForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-Control" runat="server"></asp:TextBox>

            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-Control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre Producto</label>
                <asp:TextBox ID="txtNombre" CssClass="form-Control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-Control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-Select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-Select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click1" Text="Aceptar" CssClass="btn btn-primary" />
                <a href="CatalogoLista.aspx">Cancelar</a>
            </div>
        </div>


        <div class="col-6">
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="UpDatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                        runat="server" ID="imgCatalogo" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
