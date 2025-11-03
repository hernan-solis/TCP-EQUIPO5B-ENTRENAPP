<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilAlumno.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.PerfilAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">

        <div class="col-md-4">
            <div class="card border-secondary mb-3">

                <div class="card-header bg-light border-secondary fw-bold text-center">DIA 1</div>

                <div class="card-body text-secondary">

                    <table class="table table-sm text-secondary">
                        <thead>
                            <tr>
                                <th scope="col">EJERCICIOS</th>
                                <th scope="col" class="text-center">SERIES</th>
                                <th scope="col" class="text-center">REPETICIONES</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Sentadillas</td>
                                <td class="text-center">4</td>
                                <td class="text-center">10-12</td>
                            </tr>
                            <tr>
                                <td>Peso muerto</td>
                                <td class="text-center">3</td>
                                <td class="text-center">8</td>
                            </tr>
                            <tr>
                                <td>Bulgaras</td>
                                <td class="text-center">3</td>
                                <td class="text-center">12</td>
                            </tr>
                            <tr>
                                <td>Remo con polea</td>
                                <td class="text-center">4</td>
                                <td class="text-center">10</td>
                            </tr>
                            <tr>
                                <td>Bici fija</td>
                                <td class="text-center">-</td>
                                <td class="text-center">20 min</td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="card-footer bg-light border-secondary">
                    <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault">
                        <label class="form-check-label" for="flexSwitchCheckDefault">Realizado</label>
                    </div>
                </div>

            </div>
        </div>


        <div class="col-12 col-md-4">
            <div class="card border-secondary mb-3">

                <div class="card-header bg-light border-secondary fw-bold text-center">DIA 2</div>

                <div class="card-body text-secondary">

                    <table class="table table-sm text-secondary">
                        <thead>
                            <tr>
                                <th scope="col">EJERCICIOS</th>
                                <th scope="col" class="text-center">SERIES</th>
                                <th scope="col" class="text-center">REPETICIONES</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Gemelos de pie</td>
                                <td class="text-center">3</td>
                                <td class="text-center">15-20</td>
                            </tr>
                            <tr>
                                <td>Abdominales</td>
                                <td class="text-center">3</td>
                                <td class="text-center">20</td>
                            </tr>
                            <tr>
                                <td>Planta</td>
                                <td class="text-center">3</td>
                                <td class="text-center">45 seg</td>
                            </tr>
                            <tr>
                                <td>Cinta</td>
                                <td class="text-center">-</td>
                                <td class="text-center">30 min</td>
                            </tr>
                            <tr>
                                <td>Saltos a la soga</td>
                                <td class="text-center">-</td>
                                <td class="text-center">10 min</td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="card-footer bg-light border-secondary">
                    <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheck2">
                        <label class="form-check-label" for="flexSwitchCheck2">Realizado</label>
                    </div>
                </div>

            </div>
        </div>

        <div class="col-12 col-md-4">
            <div class="card border-secondary mb-3">

                <div class="card-header bg-light border-secondary fw-bold text-center">DIA 3</div>

                <div class="card-body text-secondary">

                    <table class="table table-sm text-secondary">
                        <thead>
                            <tr>
                                <th scope="col">EJERCICIOS</th>
                                <th scope="col" class="text-center">SERIES</th>
                                <th scope="col" class="text-center">REPETICIONES</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Bíceps con barra</td>
                                <td class="text-center">4</td>
                                <td class="text-center">10</td>
                            </tr>
                            <tr>
                                <td>Bíceps con polea</td>
                                <td class="text-center">3</td>
                                <td class="text-center">12</td>
                            </tr>
                            <tr>
                                <td>Remo</td>
                                <td class="text-center">4</td>
                                <td class="text-center">8</td>
                            </tr>
                            <tr>
                                <td>Tríceps polea</td>
                                <td class="text-center">3</td>
                                <td class="text-center">10-12</td>
                            </tr>
                            <tr>
                                <td>Prensa Hack</td>
                                <td class="text-center">4</td>
                                <td class="text-center">8</td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="card-footer bg-light border-secondary">
                    <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheck3">
                        <label class="form-check-label" for="flexSwitchCheck3">Realizado</label>
                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
