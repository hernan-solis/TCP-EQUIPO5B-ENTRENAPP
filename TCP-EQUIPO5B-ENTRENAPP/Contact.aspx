<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>5B TEAM</h3>
        <address>
            <br />
            Callefalsa 123, Bs. As. Argentina<br />
            <abbr title="Phone">Tel:</abbr>
            0800-555-1212
        </address>

        <address>
            <strong>Support:</strong>   <a href="mailto:hernansolis@icloud.com">hernansolis@icloud.com</a><br />
            <strong>Admin:</strong>   <a href="mailto:brunoberti094@gmail.com">brunoberti@icloud.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:valentina.gomez.fara@gmail.com">valentina.gomez.fara@gmail.com</a>
        </address>
    </main>
</asp:Content>
