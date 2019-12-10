function LoadingOverlayShow(id) {
    $(id).LoadingOverlay("show", {
        color: "rgba(255, 255, 255, 0.5)",
        image: "/Content/loading.gif",
        imageResizeFactor: 0.6,
        //imageAnimation: "1.5s fadein",
    });
}

function LoadingOverlayHide(id) {
    $(id).LoadingOverlay("hide");
}

function ValidarFechas(dateIni, dateFin) {
    var _dateIni = new Date(dateIni);
    var _dateFin = new Date(dateFin);
    if (_dateFin < _dateIni)
        return false;
    else
        return true;
} 

function getDepartamentos(myCallback) {
    $.ajax({
        type: "GET",
        url: '/departamento/getdepartamentos',
        dataType: "json",
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#DepartamentoId").append('<option value=' + item.DepartamentoId + '>' + item.NombreDepartamento + '</option>');
            });

            return myCallback(result.data);
        },
        error: function (data) {
            alert('error');
        }
    });
}