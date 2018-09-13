$(document).on("click", '#BtnConsultar', function (e) {

    $.ajax({
        type: "GET",
        url: "Home/GetPartialConsulta",
        data: { carrera: $("#Carreras").val(), curso: $("#Cursos").val() },
        success: function (data) {
            $("#Partial").html(data);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
});

$(document).on("click", '.BtnEdit', function (e) {

    //document.getElementById("Id").value = $(this).closest("tr").find(".TdId").text();
    //document.getElementById("Nombres").value = $(this).closest("tr").find(".TdNombres").text();
    //document.getElementById("Usuario").value = $(this).closest("tr").find(".TdUsuario").text();
    //document.getElementById("Perfil").value = $(this).closest("tr").find(".TdPerfil").text();

    //var estado = $(this).closest("tr").find(".TdEstado").text();

    //if (estado == "INACTIVO") {
    //    document.getElementById("Estado").checked = false;
    //}

    //else {
    //    document.getElementById("Estado").checked = true;
    //}
    $('#EditModal').modal();
});