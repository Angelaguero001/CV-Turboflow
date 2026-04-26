$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "sample.aspx/CargarDatosPersonales",
        data: JSON.stringify({ datos: { MatriculaID: "1" } }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.DatosPersonales) {
                let datos = response.d.DatosPersonales[0];

                $(".nombre").text(datos.NombreCompleto);
                $(".fechaNacimiento").text(datos.FechaNacimiento);
                $(".direccion").text(datos.Direccion);
                $(".estadoCivil").text(datos.EstadoCivil);
                $(".telefono").text(datos.Telefono);
                $(".correo").text(datos.Correo);
            }

            if (response.d.Conocimientos) {
                $(".conocimientos").each(function () {
                    $(this).empty();
                    response.d.Conocimientos.forEach(conocimiento => {
                        $(this).append("<li>" + conocimiento.Conocimiento + "</li>");
                    });
                });
            }

            if (response.d.Educacion) {
                $(".educacion").each(function () {
                    $(this).empty();
                    response.d.Educacion.forEach(edu => {
                        $(this).append(`
                            <div class="educacion-item">
                                <h3> ${edu.Titulo} <span class="date"> ${edu.FechaIniFin} </span></h3>
                                <p>${edu.Escuela}</p>
                            </div>
                        `);
                    });
                });
            }

            if (response.d.Habilidades) {
                $(".habilidades").each(function () {
                    $(this).empty();
                    response.d.Habilidades.forEach(habilidad => {
                        $(this).append("<li>" + habilidad.Habilidad + "</li>");
                    });
                });
            }

            if (response.d.Hobbies) {
                $(".hobbies").each(function () {
                    $(this).empty();
                    response.d.Hobbies.forEach(hobbie => {
                        $(this).append("<li>" + hobbie.Hobbie + "</li>");
                    });
                });
            }

            if (response.d.Idiomas) {
                $(".idiomas").each(function () {
                    $(this).empty();
                    response.d.Idiomas.forEach(idioma => {
                        $(this).append("<li>" + idioma.Idioma + " (" + idioma.Porcentaje + "%)</li>");
                    });
                });
            }

            if (response.d.Trabajos) {
                $(".trabajos").each(function () {
                    $(this).empty();
                    response.d.Trabajos.forEach(trabajo => {
                        $(this).append(`
                            <div class="job">
                                <h3> ${trabajo.Puesto} <span class="date"> ${trabajo.FechaIniFin}</span></h3>
                                <p class="company"> ${trabajo.Empresa}</p>
                                <div class="job-description">
                                    <p><strong>Funciones:</strong> ${trabajo.Funciones}</p>
                                    <p><strong>Logros:</strong> ${trabajo.Logros}</p>
                                </div>
                            </div>
                        `);
                    });
                });
            }
        },
        error: function (error) {
            console.log("Error:", error);
        }
    });
});

