<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">

            <figure class="text-center">
                <blockquote class="blockquote">
                    <h1>ENTRENAPP</h1>
                </blockquote>
                <figcaption class="blockquote-footer">Entrenamiento Personal. Resultados Reales. Creado Solo Para Vos.
                </figcaption>
            </figure>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Diseñado 100% para vos</h2>
                <p>
                    Olvídate de rutinas genéricas. Evaluamos tu nivel, los elementos con los que contas (en casa o gimnasio) y tus lesiones, para crear un plan que se adapte perfectamente a tu vida.
                </p>
               
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Rutinas Claras, Sin Errores</h2>
                <p>
                    Visualiza tus días de entrenamiento en tarjetas sencillas. Mira las series, repeticiones y observaciones que tu profesor ha diseñado solo para vos. ¡Solo sigue el plan!
                </p>
                
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Registra tu Progreso Real</h2>
                <p>
                    Medi tu fuerza en cada entrenamiento. Registra los kilos utilizados en cada ejercicio directamente en la app. Al final del día, marca el entrenamiento como "Cumplido" con un simple check.
                </p>
               
                
            </section>
            <section class="text-center">
                <a href="/Usuarios" class="btn btn-secondary btn-lg text-uppercase" role="button">¡QUIERO SUMARME! </a>
            </section>

        </div>
    </main>

</asp:Content>
