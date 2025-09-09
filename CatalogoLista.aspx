<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CatalogoLista.aspx.cs" Inherits="TPFinalNivel3EcheverríaAlejandro.CatalogoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>lista de Catalogo</h1>
    <div class="col-6">
        <div class="mb-3">
            <asp:Label Text="Filtro" runat="server" />
            <asp:TextBox ID="txtFiltro" AutoPostBack="true" OnTextChanged="Filtro_TextChanged" CssClass="form-Control" runat="server" />
        </div>
    </div>
    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <asp:CheckBox Text="Filtro avanzado" CssClass="" ID="chkFiltroAvanzado"
                AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" runat="server" />
        </div>
    </div>

    <%if (chkFiltroAvanzado.Checked)
        {%>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                <asp:DropDownList ID="ddlCampo" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="form-control" runat="server">
                    
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList ID="ddlCriterio" CssClass="form-Control" runat="server">
                </asp:DropDownList>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox CssClass="form-Control" ID="txtFiltroavanzado" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Button Text="Búsqueda" CssClass="btn btn-primary" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
         <%} %>
    </div>
   

    <asp:GridView ID="dgvCatalogo" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table"
        OnSelectedIndexChanged="dgvCatalogo_SelectedIndexChanged" OnPageIndexChanging="dgvCatalogo_PageIndexChanging"
        AllowPaging="true" PageSize="10">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Modificación" ShowSelectButton="true" SelectText="Editar" />
        </Columns>
    </asp:GridView>
    <a href="CatalogoForm.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
