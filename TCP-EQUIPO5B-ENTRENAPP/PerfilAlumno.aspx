<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilAlumno.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.PerfilAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">

        <div class="col-md-4">
            <div class="card border-secondary  mb-3" style="max-width: 18rem;">
                <div class="card-header bg-light  border-secondary fw-bold ">DIA 1</div>
                <div class="card-body text-secondary">
                    <h5 class="card-title">EJERCICIOS</h5>
                    <p class="card-text">Sentadillas</p>
                    <p class="card-text">Peso muerto</p>
                    <p class="card-text">Bulgaras</p>
                    <p class="card-text">Remo con polea</p>
                    <p class="card-text">Bici fija</p>
                </div>
                <div class="card-footer bg-light border-secondary">
                    <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault">
                        <label class="form-check-label" for="flexSwitchCheckDefault">Realizado</label>
                    </div>
                </div>
        </div>

    </div>

    <div class="col-md-4">
        <div class="card border-secondary  mb-3" style="max-width: 18rem;">
            <div class="card-header bg-light border-secondary fw-bold ">DIA 2</div>
            <div class="card-body text-secondary">
                <h5 class="card-title">EJERCICIOS</h5>
                <p class="card-text">Gemelos de pie</p>
                <p class="card-text">Abdominales</p>
                <p class="card-text">Planta</p>
                <p class="card-text">Cinta</p>
                <p class="card-text">Saltos a la soga</p>
            </div>
            <div class="card-footer bg-light border-secondary ">
                <div class="form-check form-switch">
                    <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault">
                    <label class="form-check-label" for="flexSwitchCheckDefault">Realizado</label>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-4">
        <div class="card border-secondary  mb-3" style="max-width: 18rem;">
            <div class="card-header bg-light border-secondary fw-bold ">DIA 3</div>
            <div class="card-body text-secondary">
                <h5 class="card-title">EJERCICIOS</h5>
                <p class="card-text">Biceps con barra</p>
                <p class="card-text">Biceps con polea</p>
                <p class="card-text">Remo</p>
                <p class="card-text">Triceps con mancuerna</p>
                <p class="card-text">Prensa Hack</p>
            </div>
            <div class="card-footer bg-light border-secondary ">
            <div class="form-check form-switch">
                <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault">
                <label class="form-check-label" for="flexSwitchCheckDefault">Realizado</label>
            </div>
        </div>
    </div>
    </div>

</asp:Content>
