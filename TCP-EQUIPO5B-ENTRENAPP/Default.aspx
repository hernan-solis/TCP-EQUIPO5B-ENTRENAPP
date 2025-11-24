<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <figure class="text-center mt-5">
                <blockquote class="blockquote">
                    <h1>ENTRENAPP</h1>
                </blockquote>
                <figcaption class="blockquote-footer">Entrenamiento Personal. Resultados Reales. Creado Solo Para Vos.</figcaption>
            </figure>
        </section>

        <div class="container mt-5 mb-5">

            <div class="row g-4 justify-content-center">

                <div class="col-md-4">
                    <div class="card shadow-lg h-100 p-4">
                        <h2 id="gettingStartedTitle">Diseñado 100% para vos</h2>
                        <p>
                            Olvídate de rutinas genéricas. Evaluamos tu nivel, los elementos con los que contas (en casa o gimnasio) y tus lesiones, para crear un plan que se adapte perfectamente a tu vida.
                        </p>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card shadow-lg h-100 p-4">
                        <h2 id="librariesTitle">Rutinas Claras, Sin Errores</h2>
                        <p>
                            Visualiza tus días de entrenamiento en tarjetas sencillas. Mira las series, repeticiones y observaciones que tu profesor ha diseñado solo para vos. ¡Solo sigue el plan!
                        </p>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card shadow-lg h-100 p-4">
                        <h2 id="hostingTitle">Registra tu Progreso Real</h2>
                        <p>
                            Medi tu fuerza en cada entrenamiento. Registra los kilos utilizados en cada ejercicio directamente en la app. Al final del día, marca el entrenamiento como "Cumplido" con un simple check.
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <section class="text-center mt-5 mb-5">
            <a href="/Usuarios" class="btn btn-primary btn-lg text-uppercase" role="button">¡QUIERO SUMARME! </a>
        </section>

    </main>

</asp:Content>
