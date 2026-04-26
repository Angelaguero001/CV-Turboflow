<%@ Page Title="" Language="C#" MasterPageFile="~/include/master.Master" AutoEventWireup="true" CodeBehind="sample.aspx.cs" Inherits="TurboFlow.pages.sample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f4f4f9;
    color: #333;
    }

.container {
    display: flex;
    width: 100%;
    max-width: 900px;
    margin: 20px auto;
    background: #fff;
    box-shadow: 0 2px 5px rgba(117, 116, 116, 0.1);
    border-left: 5px solid #5a5d5e;
    border-right: 5px solid #5a5d5e;
    border-top: 5px solid #5a5d5e;
    border-bottom: 5px solid #5a5d5e;
}

.left-column {
    line-height: 2;
    width: 30%;
    background-color: #646566;
    color: #000000;
    padding: 20px;
    box-sizing: border-box;
    border-left: 2px solid#333;
    border-bottom: 2px solid #333;
    border-top: 2px solid #333;
}

.right-column {
    line-height: 1;
    width: 70%;
    background-color: #fff;
    padding: 20px;
    box-sizing: border-box;
    border-right: 2px solid#333;
    border-bottom: 2px solid #333;
    border-top: 2px solid #333;
}

.left-column h1 {
    font-size: 1.8em;
    margin: 0 0 10px;
}

.left-column p {
    margin: 5px 0;
    font-size: 0.9em;
}

.left-column h2 {
    font-size: 1.2em;
    margin-top: 20px;
    border-bottom: 1px solid #0a0a0a;
    padding-bottom: 5px;
}

.right-column h2 {
    color: #2c3e50;
    padding-bottom: 5px;
    margin-bottom: 10px;
}

.center-name{
    text-align: center;
    color: #2c3e50;
    padding-bottom: 5px;
    margin-bottom: 10px;
}

.job, .Conocimientos {
    margin-bottom: 15px;
}

.date {
    font-style: italic;
    color: #555;
}

.skills ul ol {
    padding-left: 0px;
}

.skills ul li {
    margin-bottom: 5px;
    font-size: 0.9em;
}

footer {
    text-align: center;
    margin-top: 20px;
    font-size: 0.9em;
    color: #555;
}

.job-description {
    text-align: justify;
    display: inline;
}

.profile-foto {
    text-align: center;
    margin-bottom: 20px;
}

.profile-foto img {
    width: 120px;
    height: 120px;
    border-radius: 50%;
    border: 2px solid #2c3e50;
    object-fit: cover;
}

.section-title1 {
    font-size: 1.5em;
    font-weight: bold;
    color: #3d7c38;
    background-color: #aaf5a4;
    padding: 10px;
    margin: 20px 0 10px;
    border-left: 5px solid #000000;
    border-right: 5px solid #000000;
    border-top: 5px solid #000000;
    border-bottom: 5px solid #000000;
}

.section-title2 {
    font-size: 1.5em;
    font-weight: bold;
    color: #2c3e50;
    background-color: #d3f4ff;
    padding: 10px;
    margin: 20px 0 10px;
    border-left: 5px solid #000000;
    border-right: 5px solid #000000;
    border-top: 5px solid #000000;
    border-bottom: 5px solid #000000;
}

.section-title3 {
    font-size: 1.5em;
    font-weight: bold;
    color: #b32828;
    background-color: #f74e4e;
    padding: 10px;
    margin: 20px 0 10px;
    border-left: 5px solid #000000;
    border-right: 5px solid #000000;
    border-top: 5px solid #000000;
    border-bottom: 5px solid #000000;
}

.education-item, .job {
    margin-bottom: 15px;
}

.job h3, .educacion-item h3 {
    display: flex;
    justify-content: space-between;
    font-size: 1.2em;
    margin: 0;
    font-weight: bold;
}

.company {
    font-style: italic;
    color: #555;
    font-weight: bold;
}

.date {
    font-weight: normal;
    font-size: 0.9em;
    color: #333;
}

.nombre-completo {
    display: none;
}

@media screen and (max-width: 900px) {
.container {
    flex-direction: column;
}

.nombre-completo {
    text-align: center;
    color: #2c3e50;
    padding-bottom: 5px;
    margin-bottom: 10px;
    display: block;
    font-size: 1.8rem;
    font-weight: bold;
    text-align: center;
}
.left-column {
    width: 100%;
    padding: 10px;
    text-align: left;
    order: 1;
    display: block;
    background-color: white;
    border: none;
}

.right-column {
    width: 100%;
    order: 2;
    border-top: white;
}

.emoji {
    display: none;
}


.profile-foto,
.Idiomas,
.Hobbies {
    display: none;
}

.center-name,
.job-description {
    display: none;
}
}

.btn {
    background-color: #6c757d; /* Gris Bootstrap */
    color: white; /* Texto en blanco */
    border: none; /* Sin borde */
    padding: 10px 15px;
    border-radius: 5px;
    cursor: pointer;
}

.btn:hover {
    background-color: #5a6268; /* Gris más oscuro al pasar el mouse */
}

.btn:active, 
.btn:focus {
    background-color: #495057 !important; /* Gris aún más oscuro al hacer clic */
    box-shadow: none !important; /* Evita sombras alrededor */
    outline: none !important; /* Elimina el borde azul en algunos navegadores */
}

</style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">


<div ng-controller="MiController as control">



<div class="page-content" >
    <div id="Principal">
<body>
    <div class="container">
    <div class="left-column">

    <div class="profile-foto">
        <img src="/images/Im2.jpg" alt="Foto de perfil">
    </div>
        <div>
            <h1 class="nombre-completo" ><span class="nombre"></span></h1>
                <h2>Datos Personales</h2>
            <button type="button" class="btn btn-primary show-info" data-section="DatosPersonales">Ver</button>
            <button type="button" class="btn btn-primary" onclick="editarDatos('DatosPersonales')">cambiar</button>
                    <p><span class="emoji">🏚️</span> <span class="direccion"></span></p>
                    <p><span class="emoji">📱</span> <span class="telefono"></span></p>
                    <p><span class="emoji">📧</span> <a class="correo" href="?"></a></p>
                    <p><span class="emoji">📅</span> <span class="fechaNacimiento"></span></p>
                    <p><span class="emoji">🕴️</span> <span class="estadoCivil"></span></p>
        </div>

        <div class="skills">
            <h2>Habilidades</h2>
            <button type="button" class="btn btn-primary show-info" data-section="Habilidades">Ver</button>
            <button type="button" class="btn btn-primary" onclick="abrirModal('Habilidades')">Agregar</button>
            <button type="button" class="btn btn-primary" onclick="abrirModalEditar('Habilidades')">Editar Habilidades</button>
            <ol class="habilidades"></ol>
        </div>

        <div class="Idiomas">
            <button type="button" class="btn btn-primary show-info" data-section="Idiomas">Ver</button>
            <button type="button" class="btn btn-primary" onclick="abrirModal('Idiomas')">Agregar</button>
            <button type="button" class="btn btn-primary" onclick="abrirModalEditar('Idiomas')">Editar Idiomas</button>
            <h2>Idiomas</h2>
            <ul>

                 <li class="idiomas">Idioma - Porcentaje</li>

            </ul>
        </div>

        <div class="Hobbies">
            <h2>Hobbies</h2>
            <button type="button" class="btn btn-primary show-info" data-section="Hobbies">Ver</button>
            <button type="button" class="btn btn-primary" onclick="abrirModal('Hobbies')">Agregar</button>
            <button type="button" class="btn btn-primary" onclick="abrirModalEditar('Hobbies')">Editar Hobbies</button>
            <p class="hobbies"></p>
        </div>
    </div>

    <div class="right-column">
            <h2 class="center-name"> <span class="nombre"></span></h2>

        <section>
            <h2 class="section-title1">Educación</h2>
            <button type="button" class="btn btn-primary show-info" data-section="Educacion">Ver</button>
            <button type="button" class="btn btn-primary" onclick="abrirModal('Educacion')">Agregar</button>
            <button type="button" class="btn btn-primary" onclick="abrirModalEditar('Educacion')">Editar Educación</button>

            <div class="educacion"></div>

        </section>

        <section>
            <h2 class="section-title2">Experiencia Laboral</h2>
            <button type="button" class="btn btn-primary show-info" data-section="Trabajos">Ver</button>
            <button type="button" class="btn btn-primary" onclick="abrirModal('Trabajos')">Agregar</button>
            <button type="button" class="btn btn-primary" onclick="abrirModalEditar('Trabajos')">Editar Trabajos</button>

                <div class="trabajos"></div>
        </section>

        <section>
            <h2 class="section-title3">Otros conocimientos</h2>
            <button type="button" class="btn btn-primary show-info" data-section="Conocimientos">Ver</button>
            <button type="button" class="btn btn-primary" onclick="abrirModal('Conocimientos')">Agregar</button>
            <button type="button" class="btn btn-primary" onclick="abrirModalEditar('Conocimientos')">Editar Conocimientos</button>
                <ul class="conocimientos"></ul>
        </section>

    </div>
    </div>
</body>


    </div>
</div>








    <div id="infoModal" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 id="modalTitle" class="modal-title"></h5>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
                <div id="modalContent"></div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>


        <script>
            $(document).ready(function () {
                $(".show-info").click(function () {
                    let section = $(this).data("section");
                    let title = section.replace(/([A-Z])/g, ' $1').trim();
                    $("#modalTitle").text(title);

                    $.ajax({
                        type: "POST",
                        url: "sample.aspx/CargarDatosPersonales",
                        data: JSON.stringify({ datos: { MatriculaID: "1" } }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            let contenido = "";

                            if (response.d[section]) {
                                switch (section) {
                                    case "DatosPersonales":
                                        let datos = response.d.DatosPersonales[0];
                                        contenido = `
                                <p><strong>Nombre:</strong> ${datos.NombreCompleto}</p>
                                <p><strong>Fecha Nacimiento:</strong> ${datos.FechaNacimiento}</p>
                                <p><strong>Dirección:</strong> ${datos.Direccion}</p>
                                <p><strong>Estado Civil:</strong> ${datos.EstadoCivil}</p>
                                <p><strong>Teléfono:</strong> ${datos.Telefono}</p>
                                <p><strong>Correo:</strong> ${datos.Correo}</p>
                            `;
                                        break;
                                    case "Conocimientos":
                                        contenido = "<ul>";
                                        response.d.Conocimientos.forEach(c => {
                                            contenido += `<li>${c.Conocimiento}</li>`;
                                        });
                                        contenido += "</ul>";
                                        break;
                                    case "Educacion":
                                        contenido = "";
                                        response.d.Educacion.forEach(edu => {
                                            contenido += `
                                    <div class="educacion-item">
                                        <h3>${edu.Titulo} <span class="date">${edu.FechaIniFin}</span></h3>
                                        <p>${edu.Escuela}</p>
                                    </div>
                                `;
                                        });
                                        break;
                                    case "Habilidades":
                                        contenido = "<ul>";
                                        response.d.Habilidades.forEach(h => {
                                            contenido += `<li>${h.Habilidad}</li>`;
                                        });
                                        contenido += "</ul>";
                                        break;
                                    case "Hobbies":
                                        contenido = "<ul>";
                                        response.d.Hobbies.forEach(hobbie => {
                                            contenido += `<li>${hobbie.Hobbie}</li>`;
                                        });
                                        contenido += "</ul>";
                                        break;
                                    case "Idiomas":
                                        contenido = "<ul>";
                                        response.d.Idiomas.forEach(idioma => {
                                            contenido += `<li>${idioma.Idioma} (${idioma.Porcentaje}%)</li>`;
                                        });
                                        contenido += "</ul>";
                                        break;
                                    case "Trabajos":
                                        contenido = "";
                                        response.d.Trabajos.forEach(trabajo => {
                                            contenido += `
                                    <div class="job">
                                        <h3>${trabajo.Puesto} <span class="date">${trabajo.FechaIniFin}</span></h3>
                                        <p class="company">${trabajo.Empresa}</p>
                                        <p><strong>Funciones:</strong> ${trabajo.Funciones}</p>
                                        <p><strong>Logros:</strong> ${trabajo.Logros}</p>
                                    </div>
                                `;
                                        });
                                        break;
                                }
                            } else {
                                contenido = "<p>No hay información disponible.</p>";
                            }

                            $("#modalContent").html(contenido);
                            $("#infoModal").modal("show");
                        },
                        error: function (error) {
                            console.log("Error:", error);
                        }
                    });
                });
            });

        </script>

    
        <div id="editarDatosPersonalesModal" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Editar Datos Personales</h5>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
                <form id="formDatosPersonales">
                    <div class="form-group">
                        <label for="nombreCompleto">Nombre Completo</label>
                        <input type="text" class="form-control" id="nombreCompleto" name="nombreCompleto">
                    </div>
                    <div class="form-group">
                        <label for="fechaNacimiento">Fecha de Nacimiento</label>
                        <input type="text" class="form-control" id="fechaNacimiento" name="fechaNacimiento">
                    </div>
                    <div class="form-group">
                        <label for="direccion">Dirección</label>
                        <input type="text" class="form-control" id="direccion" name="direccion">
                    </div>
                    <div class="form-group">
                        <label for="estadoCivil">Estado Civil</label>
                        <input type="text" class="form-control" id="estadoCivil" name="estadoCivil">
                    </div>
                    <div class="form-group">
                        <label for="telefono">Teléfono</label>
                        <input type="text" class="form-control" id="telefono" name="telefono">
                    </div>
                    <div class="form-group">
                        <label for="correo">Correo</label>
                        <input type="text" class="form-control" id="correo" name="correo">
                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-primary" onclick="guardarDatosPersonales()">Guardar</button>
            </div>
        </div>
    </div>
</div>




    

         <script>
             function editarDatos(seccion) {
                 switch (seccion) {
                     case 'DatosPersonales':
                         $('#editarDatosPersonalesModal').modal('show');
                         break;
                     // Agrega casos para otras secciones
                 }
             }

             function guardarDatosPersonales() {
                 let datos = {
                     MatriculaID: "1",
                     NombreCompleto: $('#nombreCompleto').val(),
                     FechaNacimiento: $('#fechaNacimiento').val(),
                     Direccion: $('#direccion').val(),
                     EstadoCivil: $('#estadoCivil').val(),
                     Telefono: $('#telefono').val(),
                     Correo: $('#correo').val()
                 };

                 $.ajax({
                     type: "POST",
                     url: "sample.aspx/ActualizarDatosPersonales",
                     data: JSON.stringify({ datos: datos }),
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (response) {
                         if (response.d) {
                             alert('Datos actualizados correctamente');
                             $('#editarDatosPersonalesModal').modal('hide');
                             location.reload(); // Recargar la página para ver los cambios
                         } else {
                             alert('Error al actualizar los datos');
                         }
                     },
                     error: function (error) {
                         console.log("Error:", error);
                     }
                 });
             }
         </script>






</div>


        <div id="modalAgregar" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 id="modalTitulo" class="modal-title"></h5>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
                <form id="formAgregar">

                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-primary" onclick="guardarDatos()">Guardar</button>
            </div>
        </div>
    </div>
</div>

    
            <script>
                function abrirModal(seccion) {
                    $('#modalTitulo').text(`Agregar ${seccion}`);

                    $('#formAgregar').empty();

                    let campos = "";
                    switch (seccion) {
                        case "Educacion":
                            campos = `
                <div class="form-group">
                    <label for="escuela">Escuela</label>
                    <input type="text" class="form-control" id="escuela" name="escuela">
                </div>
                <div class="form-group">
                    <label for="titulo">Título</label>
                    <input type="text" class="form-control" id="titulo" name="titulo">
                </div>
                <div class="form-group">
                    <label for="fechaIniFin">Fecha Inicio/Fin</label>
                    <input type="text" class="form-control" id="fechaIniFin" name="fechaIniFin">
                </div>
            `;
                            break;
                        case "Habilidades":
                            campos = `
                <div class="form-group">
                    <label for="habilidad">Habilidad</label>
                    <input type="text" class="form-control" id="habilidad" name="habilidad">
                </div>
            `;
                            break;
                        case "Hobbies":
                            campos = `
                <div class="form-group">
                    <label for="hobbie">Hobbie</label>
                    <input type="text" class="form-control" id="hobbie" name="hobbie">
                </div>
            `;
                            break;
                        case "Idiomas":
                            campos = `
                <div class="form-group">
                    <label for="idioma">Idioma</label>
                    <input type="text" class="form-control" id="idioma" name="idioma">
                </div>
                <div class="form-group">
                    <label for="porcentaje">Porcentaje</label>
                    <input type="text" class="form-control" id="porcentaje" name="porcentaje">
                </div>
            `;
                            break;
                        case "Conocimientos":
                            campos = `
                <div class="form-group">
                    <label for="conocimiento">Conocimiento</label>
                    <input type="text" class="form-control" id="conocimiento" name="conocimiento">
                </div>
            `;
                            break;
                        case "Trabajos":
                            campos = `
                <div class="form-group">
                    <label for="empresa">Empresa</label>
                    <input type="text" class="form-control" id="empresa" name="empresa">
                </div>
                <div class="form-group">
                    <label for="puesto">Puesto</label>
                    <input type="text" class="form-control" id="puesto" name="puesto">
                </div>
                <div class="form-group">
                    <label for="funciones">Funciones</label>
                    <input type="text" class="form-control" id="funciones" name="funciones">
                </div>
                <div class="form-group">
                    <label for="logros">Logros</label>
                    <input type="text" class="form-control" id="logros" name="logros">
                </div>
                <div class="form-group">
                    <label for="fechaIniFin">Fecha Inicio/Fin</label>
                    <input type="text" class="form-control" id="fechaIniFin" name="fechaIniFin">
                </div>
            `;
                            break;

                    }

                    $('#formAgregar').html(campos);

                    $('#modalAgregar').modal('show');
                }

                function guardarDatos() {
                    let seccion = $('#modalTitulo').text().replace('Agregar ', '');
                    let datos = {};

                    switch (seccion) {
                        case "Educacion":
                            datos = {
                                Escuela: $('#escuela').val(),
                                Titulo: $('#titulo').val(),
                                FechaIniFin: $('#fechaIniFin').val(),
                                MatriculaID: "1"
                            };
                            break;
                        case "Habilidades":
                            datos = {
                                Habilidad: $('#habilidad').val(),
                                MatriculaID: "1"
                            };
                            break;
                        case "Hobbies":
                            datos = {
                                Hobbie: $('#hobbie').val(),
                                MatriculaID: "1"
                            };
                            break;
                        case "Idiomas":
                            datos = {
                                Idioma: $('#idioma').val(),
                                Porcentaje: $('#porcentaje').val(),
                                MatriculaID: "1"
                            };
                            break;
                        case "Conocimientos":
                            datos = {
                                Conocimiento: $('#conocimiento').val(),
                                MatriculaID: "1"
                            };
                            break;
                        case "Trabajos":
                            datos = {
                                Empresa: $('#empresa').val(),
                                Puesto: $('#puesto').val(),
                                Funciones: $('#funciones').val(),
                                Logros: $('#logros').val(),
                                FechaIniFin: $('#fechaIniFin').val(),
                                MatriculaID: "1"
                            };
                            break;
                    }

                    $.ajax({
                        type: "POST",
                        url: `sample.aspx/Agregar${seccion}`,
                        data: JSON.stringify({ datos: datos }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            if (response.d) {
                                alert('Datos guardados correctamente');
                                $('#modalAgregar').modal('hide');
                                location.reload();
                            } else {
                                alert('Error al guardar los datos');
                            }
                        },
                        error: function (error) {
                            console.log("Error:", error);
                        }
                    });
                }

            </script>



<div id="editarApartadoModal" class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 id="modalTitulo" class="modal-title">Editar Apartado</h5>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
                <form id="formEditarApartado">
                    <!-- Campos dinámicos se insertarán aquí -->
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-primary" onclick="guardarCambios()">Guardar</button>
            </div>
        </div>
    </div>
</div>




    <script>

        let apartadoActual = "";

        function abrirModalEditar(apartado) {
            apartadoActual = apartado; // Guardar el apartado actual
            $("#modalTitulo").text(`Editar ${apartado}`);

            // Limpiar el formulario
            $("#formEditarApartado").empty();

            // Cargar los campos según el apartado
            let campos = "";
            switch (apartado) {
                case "Educacion":
                    campos = `
                <div class="form-group">
                    <label for="escuela">Escuela</label>
                    <input type="text" class="form-control" id="escuela" name="escuela">
                </div>
                <div class="form-group">
                    <label for="titulo">Título</label>
                    <input type="text" class="form-control" id="titulo" name="titulo">
                </div>
                <div class="form-group">
                    <label for="fechaIniFin">Fecha Inicio/Fin</label>
                    <input type="text" class="form-control" id="fechaIniFin" name="fechaIniFin">
                </div>
            `;
                    break;
                case "Trabajos":
                    campos = `
                <div class="form-group">
                    <label for="empresa">Empresa</label>
                    <input type="text" class="form-control" id="empresa" name="empresa">
                </div>
                <div class="form-group">
                    <label for="puesto">Puesto</label>
                    <input type="text" class="form-control" id="puesto" name="puesto">
                </div>
                <div class="form-group">
                    <label for="funciones">Funciones</label>
                    <input type="text" class="form-control" id="funciones" name="funciones">
                </div>
                <div class="form-group">
                    <label for="logros">Logros</label>
                    <input type="text" class="form-control" id="logros" name="logros">
                </div>
                <div class="form-group">
                    <label for="fechaIniFin">Fecha Inicio/Fin</label>
                    <input type="text" class="form-control" id="fechaIniFin" name="fechaIniFin">
                </div>
            `;
                    break;
                case "Habilidades":
                    campos = `
                <div class="form-group">
                    <label for="habilidad">Habilidad</label>
                    <input type="text" class="form-control" id="habilidad" name="habilidad">
                </div>
            `;
                    break;
                case "Idiomas":
                    campos = `
                <div class="form-group">
                    <label for="idioma">Idioma</label>
                    <input type="text" class="form-control" id="idioma" name="idioma">
                </div>
                <div class="form-group">
                    <label for="porcentaje">Porcentaje</label>
                    <input type="text" class="form-control" id="porcentaje" name="porcentaje">
                </div>
            `;
                    break;
                case "Hobbies":
                    campos = `
                <div class="form-group">
                    <label for="hobbie">Hobbie</label>
                    <input type="text" class="form-control" id="hobbie" name="hobbie">
                </div>
            `;
                    break;
                case "Conocimientos":
                    campos = `
                <div class="form-group">
                    <label for="conocimiento">Conocimiento</label>
                    <input type="text" class="form-control" id="conocimiento" name="conocimiento">
                </div>
            `;
                    break;
            }

            // Insertar los campos en el formulario
            $("#formEditarApartado").html(campos);

            // Cargar los datos actuales del apartado
            $.ajax({
                type: "POST",
                url: "sample.aspx/CargarDatosPersonales",
                data: JSON.stringify({ datos: { MatriculaID: "1" } }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d) {
                        switch (apartado) {
                            case "Educacion":
                                $("#escuela").val(response.d.Educacion[0].Escuela);
                                $("#titulo").val(response.d.Educacion[0].Titulo);
                                $("#fechaIniFin").val(response.d.Educacion[0].FechaIniFin);
                                break;
                            case "Trabajos":
                                $("#empresa").val(response.d.Trabajos[0].Empresa);
                                $("#puesto").val(response.d.Trabajos[0].Puesto);
                                $("#funciones").val(response.d.Trabajos[0].Funciones);
                                $("#logros").val(response.d.Trabajos[0].Logros);
                                $("#fechaIniFin").val(response.d.Trabajos[0].FechaIniFin);
                                break;
                            case "Habilidades":
                                $("#habilidad").val(response.d.Habilidades[0].Habilidad);
                                break;
                            case "Idiomas":
                                $("#idioma").val(response.d.Idiomas[0].Idioma);
                                $("#porcentaje").val(response.d.Idiomas[0].Porcentaje);
                                break;
                            case "Hobbies":
                                $("#hobbie").val(response.d.Hobbies[0].Hobbie);
                                break;
                            case "Conocimientos":
                                $("#conocimiento").val(response.d.Conocimientos[0].Conocimiento);
                                break;
                        }
                        $("#editarApartadoModal").modal("show");
                    }
                },
                error: function (error) {
                    console.log("Error:", error);
                }
            });
        }

        function guardarCambios() {
            let datos = { MatriculaID: "1" };

            // Construir los datos según el apartado actual
            switch (apartadoActual) {
                case "Educacion":
                    datos.Escuela = $("#escuela").val();
                    datos.Titulo = $("#titulo").val();
                    datos.FechaIniFin = $("#fechaIniFin").val();
                    break;
                case "Trabajos":
                    datos.Empresa = $("#empresa").val();
                    datos.Puesto = $("#puesto").val();
                    datos.Funciones = $("#funciones").val();
                    datos.Logros = $("#logros").val();
                    datos.FechaIniFin = $("#fechaIniFin").val();
                    break;
                case "Habilidades":
                    datos.Habilidad = $("#habilidad").val();
                    break;
                case "Idiomas":
                    datos.Idioma = $("#idioma").val();
                    datos.Porcentaje = $("#porcentaje").val();
                    break;
                case "Hobbies":
                    datos.Hobbie = $("#hobbie").val();
                    break;
                case "Conocimientos":
                    datos.Conocimiento = $("#conocimiento").val();
                    break;
            }

            // Enviar los datos al servidor
            $.ajax({
                type: "POST",
                url: `sample.aspx/Actualizar${apartadoActual}`,
                data: JSON.stringify({ datos: datos }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d) {
                        alert('Cambios guardados correctamente');
                        $("#editarApartadoModal").modal("hide");
                        location.reload(); // Recargar la página para ver los cambios
                    } else {
                        alert('Error al guardar los cambios');
                    }
                },
                error: function (error) {
                    console.log("Error en la solicitud AJAX:", error);
                }
            });
        }

    </script>





<script type="text/javascript" language="javascript" src="sample.js"></script>


</asp:Content>