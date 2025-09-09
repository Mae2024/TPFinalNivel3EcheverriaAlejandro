<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3EcheverríaAlejandro.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="row">
       <div class="col-4">
           <h1>Login</h1>
           <div class="mb-3">
               <label class="form-label">Email</label>
               <asp:TextBox runat="server" CssClass="form-control"  ID="txtEmail" REQUIRED="" />
           </div>
           <div class="mb-3">
               <label class="form-label">Contraseña</label>
               <asp:TextBox runat="server" CssClass="form-control" ID="txtContraseña" TextMode="Password" />
           </div>
           <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID="BtnIngresar" OnClick="BtnIngresar_Click" runat="server" />
           <a href="Home.aspx">Cancelar</a>

       </div>
   </div>
</asp:Content>
