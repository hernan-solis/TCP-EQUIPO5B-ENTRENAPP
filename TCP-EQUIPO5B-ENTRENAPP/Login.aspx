﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Email</label>
      <asp:TextBox ID="EmailLogin" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
    <div id="emailHelp" class="form-text">No compartas tus datos con desconocidos.</div>
  </div>
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">Contraseña</label>
     <asp:TextBox ID="ConstraseniaLogin" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
  </div>
        <asp:Button ID="BtnLogin" CssClass="btn btn-primary" runat="server" Text="Loguear" OnClick="BtnLogin_Click" />

</asp:Content>
