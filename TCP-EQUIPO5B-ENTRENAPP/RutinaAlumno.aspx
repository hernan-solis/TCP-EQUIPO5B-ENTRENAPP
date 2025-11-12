<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RutinaAlumno.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.RutinaAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
    <div class="row justify-content-center">

        <div class="col-auto col-lg-auto">
            <div class="card border-secondary mb-3">

                <div class="card-header bg-light border-secondary fw-bold text-center">DIA X</div>

                <div class="card-body text-secondary">

                    <table class="table table-sm text-secondary mb-0 align-middle">
                        <thead>
                            <tr>
                                <th scope="col">EJERCICIOS</th>
                                <th scope="col" class="text-center">SERIES</th>
                                <th scope="col" class="text-center">REPETICIONES</th>
                                <th scope="col" class="text-center">DESCANSO (min)</th>
                                <th scope="col" class="text-center">PESO (kg)</th>
                                <th scope="col" class="text-center">OBSERVACIONES</th>
                                <th scope="col" class="text-center">VIDEO DEMOSTRATIVO </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Sentadillas</td>
                                <td class="text-center">4</td>
                                <td class="text-center">10</td>
                                <td class="text-center">1.30</td>
                                <td class="text-center">40</td>
                                <td class="text-center">Espalda erguida</td>
                                <td class="text-center">
                                https://youtu.be/BjixzWEw4EY?si=ptFCLhGmoTTjWuf9td>
                            </tr>
                            <tr>
                                <td>Peso muerto</td>
                                <td class="text-center">3</td>
                                <td class="text-center">8</td>
                                <td class="text-center">1.30</td>
                                <td class="text-center">100</td>
                                <td class="text-center">Espalda erguida</td>
                                <td class="text-center">https://youtu.be/BjixzWEw4EY?si=ptFCLhGmoTTjWuf9td></td>
                            </tr>
                            <tr>
                                <td>Bulgaras</td>
                                <td class="text-center">3</td>
                                <td class="text-center">12</td>
                                <td class="text-center">2</td>
                                <td class="text-center">15</td>
                                <td class="text-center">La rodilla no sobrepasa la punta del pie</td>
                                <td class="text-center">https://youtu.be/BjixzWEw4EY?si=ptFCLhGmoTTjWuf9td></td>
                            </tr>
                            <tr>
                                <td>Remo con polea</td>
                                <td class="text-center">4</td>
                                <td class="text-center">10</td>
                                <td class="text-center">1</td>
                                <td class="text-center">35</td>
                                <td class="text-center">Sacar pecho</td>
                                <td class="text-center">https://youtu.be/BjixzWEw4EY?si=ptFCLhGmoTTjWuf9td></td>
                            </tr>
                            <tr>
                                <td>Bici fija</td>
                                <td class="text-center">-</td>
                                <td class="text-center">20 min</td>
                                <td class="text-center">-</td>
                                <td class="text-center">-</td>
                                <td class="text-center">Mantener un ritmo constante</td>
                                <td class="text-center">https://youtu.be/BjixzWEw4EY?si=ptFCLhGmoTTjWuf9td></td>
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
    </div>
</div>

</asp:Content>
